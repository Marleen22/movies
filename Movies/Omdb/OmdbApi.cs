using Newtonsoft.Json;
using Ogd.Movies.Omdb.Models;
using System;
using System.IO;
using System.Net;

namespace Ogd.Movies.Omdb
{
    public class OmdbApi
    {
        static public string doPUT(string URI)
        {
            Uri uri = new Uri(String.Format(URI));

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            HttpWebResponse httpResponse = null;
            try
            {
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            string result = null;
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            //Response response = JsonConvert.DeserializeObject<Response>(result);

            return result;
        }
    }
}
