/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-5
 * Time: 0:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Collections;
using System.Net;
using System.Web;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TravianMonitor
{
	public class PageQueryResult
	{
		public string strPageContent = null;
		public string strException = null;
	}
	
	public delegate void PageQueryCallBack(PageQueryResult result);
	
	public class RequestState
	{
		public HttpWebRequest request;
		public Dictionary<string, string> postData;
		public PageQueryCallBack cbFunc;
	}
	
	public class TravianWebClient
	{
		private CookieContainer cookies = null;
		public string strCurCookie = null;
		private string strLastQueryPageURI = null;
		public string strException;
		public TravianWebClient()
		{
		}
		
		const int DefaultTimeout = 2 * 60 * 1000; // 设置2分钟的访问超时
		
		//	如果定时器响应，中断http request
		private void TimeoutCallback(object state, bool timedOut)
		{
			if (timedOut)
			{
				HttpWebRequest request = state as HttpWebRequest;
				if (request != null)
				{
					request.Abort();
				}
			}
		}
		
		private HttpWebRequest CreateRequest(string Uri)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
			if (TravianAccessor.TrAcsr.glbCfg.Proxy != null)
				request.Proxy = TravianAccessor.TrAcsr.glbCfg.Proxy;
			if (cookies == null)
				cookies = new CookieContainer();
			request.CookieContainer = cookies;
			if (strLastQueryPageURI != null)
				request.Referer = strLastQueryPageURI;
			strLastQueryPageURI = Uri;
			request.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:5.0) Gecko/20100101 Firefox/5.0";
			request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");
			request.Headers.Add("Accept-Encoding", "gzip, deflate");
			request.Headers.Add("Accept-Charset", "GB2312,utf-8;q=0.7,*;q=0.7");
			request.ServicePoint.Expect100Continue = false;
			request.KeepAlive = true;
			
			return request;
		}
		
		public void HttpQuery(string Uri, Dictionary<string, string> postData, PageQueryCallBack func)
		{
			string BaseAddress = string.Format(
				"http://{0}/", TravianAccessor.TrAcsr.glbCfg.strSvrURL);
			HttpWebRequest request = CreateRequest(BaseAddress + Uri);
			RequestState reqState = new RequestState();
			reqState.request = request;
			reqState.postData = postData;
			reqState.cbFunc = func;
			
			strException = "";
			if (postData == null)
			{
				HttpGet(reqState);
			}
			else
			{
				HttpPost(reqState);
			}
		}
		
		private void HttpGet(RequestState reqState)
		{
			HttpWebRequest request = reqState.request;
			request.Method = "GET";
			
			AsynGetResponse(reqState);
		}
		
		private void HttpPost(RequestState reqState)
		{
			HttpWebRequest request = reqState.request;
			request.Method = "POST";
			
			request.ContentType = "application/x-www-form-urlencoded";
			request.BeginGetRequestStream(
				new AsyncCallback(GetReqStrmCallBack), reqState);
		}
		
		private void AsynGetResponse(RequestState reqState)
		{
			try
			{
				HttpWebRequest request = reqState.request;
				//	启动异步请求
				IAsyncResult result =
				(IAsyncResult)request.BeginGetResponse(
						new AsyncCallback(RespCallback), reqState);
				
				//	这里实现超时，如果发生访问超时，回调超时处理函数
				ThreadPool.RegisterWaitForSingleObject(
					result.AsyncWaitHandle
					, new WaitOrTimerCallback(TimeoutCallback)
					, reqState.request, DefaultTimeout, true);
			}
			catch (WebException e)
			{
				PageQueryResult result = new PageQueryResult();
				result.strException = string.Format(
					"发生异常，讲重新访问："
					+ "\nMessage: {0}"
					+ "\nStatus: {1}", e.Message, e.Status);
				
				PageQueryCallBack func = reqState.cbFunc;
				func(result);
			}
			catch (Exception e)
			{
				PageQueryResult result = new PageQueryResult();
				result.strException = string.Format(
					"发生异常，讲重新访问："
					+ "\nSource: {0}"
					+ "\nMessage: {1}", e.Source, e.Message);
				
				PageQueryCallBack func = reqState.cbFunc;
				func(result);
			}
		}
				
		private void GetReqStrmCallBack(IAsyncResult asynchronousResult)
		{
			RequestState reqState = (RequestState)asynchronousResult.AsyncState;
			HttpWebRequest request = reqState.request;
			Dictionary<string, string> postData = reqState.postData;
			
			string QueryString = null;
			StringBuilder sb = new StringBuilder();
			foreach(KeyValuePair<string, string> x in postData)
			{
				if(sb.Length != 0)
					sb.Append("&");

				if (x.Key == "!!!RawData!!!")
				{
					sb.Append(x.Value);
					continue;
				}

				sb.Append(HttpUtility.UrlEncode(x.Key));
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(x.Value));
			}
			QueryString = sb.ToString();
			
			ASCIIEncoding encoding = new ASCIIEncoding ();
    		byte[] qry_bytes = encoding.GetBytes(QueryString);
    		
			Stream newStream = request.GetRequestStream();
			newStream.Write(qry_bytes, 0, qry_bytes.Length);
			newStream.Close();
			
			AsynGetResponse(reqState);
		}
		
		//	访问未超时的回调函数
		private void RespCallback(IAsyncResult asynchronousResult)
		{
			//	获得状态对象
			RequestState reqState = (RequestState)asynchronousResult.AsyncState;
			HttpWebRequest request = reqState.request;
			try
			{
				HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(
					asynchronousResult);
				
				string strPageContent;
				if (response.ContentEncoding == "gzip")
				{
					using(Stream streamReceive = response.GetResponseStream())
					{
						using(GZipStream zipStream = new GZipStream(streamReceive, CompressionMode.Decompress))
					        using (StreamReader sr = new StreamReader(zipStream, Encoding.UTF8))
					            strPageContent = sr.ReadToEnd();
					}
				}
				else
				{
					using(Stream streamReceive = response.GetResponseStream())
					{
						using(StreamReader sr = new StreamReader(streamReceive, Encoding.UTF8))
							strPageContent = sr.ReadToEnd();
					}
				}
				
				response.Close();
				
				PageQueryResult result = new PageQueryResult();
				result.strPageContent = strPageContent;
				PageQueryCallBack func = reqState.cbFunc;
				func(result);
			}
			catch (WebException e)
			{
				PageQueryResult result = new PageQueryResult();
				result.strException = string.Format(
					"发生异常，讲重新访问："
					+ "\nMessage: {0}"
					+ "\nStatus: {1}", e.Message, e.Status);
				PageQueryCallBack func = reqState.cbFunc;
				func(result);
			}
		}
	}
}
