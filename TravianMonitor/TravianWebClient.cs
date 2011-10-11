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
	/// <summary>
	/// Description of TravianWebClient.
	/// </summary>
	public class TravianWebClient
	{
		private HttpWebRequest request;
		private CookieContainer cookies;
		public string strCurCookie = null;
		private string strLastQueryPageURI = null;
		public TravianWebClient()
		{
		}
		
		private void CreateRequest(string Uri)
		{
			request = (HttpWebRequest)WebRequest.Create(Uri);
			if (TravianAccessor.TrAcsr.glbCfg.Proxy != null)
				request.Proxy = TravianAccessor.TrAcsr.glbCfg.Proxy;
			if (cookies == null)
				cookies = new CookieContainer();
			request.CookieContainer = cookies;
			if (strLastQueryPageURI != null)
				request.Referer = strLastQueryPageURI;
			strLastQueryPageURI = Uri;
			//request.Timeout = 30000;
			request.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:5.0) Gecko/20100101 Firefox/5.0";
			request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");
			request.Headers.Add("Accept-Encoding", "gzip, deflate");
			request.Headers.Add("Accept-Charset", "GB2312,utf-8;q=0.7,*;q=0.7");
			request.ServicePoint.Expect100Continue = false;
			request.KeepAlive = true;
		}
		
		public string HttpQuery(string Uri, Dictionary<string, string> Data)
		{
			try
			{
				string BaseAddress = string.Format("http://{0}/", TravianAccessor.TrAcsr.glbCfg.strSvrURL);
				CreateRequest(BaseAddress + Uri);
				if(Data == null)
				{
					return HttpGet();
				}
				else
				{
					return HttpPost(Data);
				}
			}
			catch (Exception)
			{
				return "";
			}
		}
		
		private string HttpGet()
		{
			request.Method = "GET";
			return FetchResponse();
		}
		
		private string HttpPost(Dictionary<string, string> Data)
		{
			request.Method = "POST";
			
			string QueryString = null;
			StringBuilder sb = new StringBuilder();
			foreach(KeyValuePair<string, string> x in Data)
			{
				if(sb.Length != 0)
					sb.Append("&");

				// Got to support some weired form data, like arrays
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
			request.ContentType = "application/x-www-form-urlencoded";
			
			ASCIIEncoding encoding = new ASCIIEncoding ();
    		byte[] qry_bytes = encoding.GetBytes(QueryString);
    		request.ContentLength = qry_bytes.Length;
    		
			Stream newStream = request.GetRequestStream();
			newStream.Write(qry_bytes, 0, qry_bytes.Length);
			newStream.Close();
			
			return FetchResponse(); 
		}
		
		private string FetchResponse()
		{
			string result = null;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			response.Cookies = cookies.GetCookies(request.RequestUri);
			
			foreach (Cookie cook in response.Cookies)
			{
				if (cook.Name == "T3E")
				{
					this.strCurCookie = cook.Value;
				}
			}
			
			if (response.ContentEncoding == "gzip")
			{
				using(Stream streamReceive = response.GetResponseStream())
				{
					using(GZipStream zipStream = new GZipStream(streamReceive, CompressionMode.Decompress))
				        using (StreamReader sr = new StreamReader(zipStream, Encoding.UTF8))
				            result = sr.ReadToEnd();
				}
			}
			else
			{
				using(Stream streamReceive = response.GetResponseStream())
				{
					using(StreamReader sr = new StreamReader(streamReceive, Encoding.UTF8))
						result = sr.ReadToEnd();
				}
			}

			return result;
		}
	}
}
