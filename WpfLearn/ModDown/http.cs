using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace WpfLearn
{
	internal class http
	{
		public string HttpPost(string Url, string postDataStr)
		{
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.Proxy = null;
				CookieContainer cookieContainer = new CookieContainer();
				httpWebRequest.ContentLength = (long)Encoding.UTF8.GetByteCount(postDataStr);
				httpWebRequest.CookieContainer = cookieContainer;
				Stream requestStream = httpWebRequest.GetRequestStream();
				StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.GetEncoding("gb2312"));
				streamWriter.Write(postDataStr);
				streamWriter.Close();
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				httpWebResponse.Cookies = cookieContainer.GetCookies(httpWebResponse.ResponseUri);
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				result = text;
			}
			catch (Exception)
			{
                //System.Windows.MessageBox.Show("当前网络不可用");
				result = "{\"code\":\"404\"}";
			}
			return result;
		}

		public string HttpGet(string Url, string postDataStr)
		{
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url + ((postDataStr == "") ? "" : "?") + postDataStr);
				httpWebRequest.Method = "GET";
				httpWebRequest.ContentType = "text/html;charset=UTF-8";
				httpWebRequest.Timeout = 8000;
				httpWebRequest.Proxy = null;
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				result = text;
			}
			catch (Exception)
			{
				result = "{\"version\":1}";
			}
			return result;
		}

		public bool DownloadFile(string URL, string filename/*, System.Windows.Controls.Label label1*/)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				long contentLength = httpWebResponse.ContentLength;
				Stream responseStream = httpWebResponse.GetResponseStream();
				Stream stream = new FileStream(filename, FileMode.Create);
				long num = 0L;
				byte[] array = new byte[10240];
                int i = responseStream.Read(array, 0, array.Length);
                while (i > 0)
                {
                    num = (long)i + num;
                    //System.Windows.Forms.Application.DoEvents();
                    stream.Write(array, 0, i);
                    i = responseStream.Read(array, 0, array.Length);
                    //float num2 = (float)num / (float)contentLength * 100f;
                    //label1.Content = "下载进度：" + ((float)Math.Round((double)num2, 3)).ToString() + "%";
                    //System.Windows.Forms.Application.DoEvents();
                }
                stream.Close();
				responseStream.Close();
                return true;
			}
			catch (Exception)
			{
                //System.Windows.MessageBox.Show("下载失败，可能是网络问题");
                return false;
			}
		}
	}
}
