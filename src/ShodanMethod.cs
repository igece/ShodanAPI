using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;


namespace Shodan.API
{
  public class ShodanMethod<T> where T : class
  {
    protected string MethodUrl { get; private set; }

    protected Dictionary<string, string> QueryParams { get; private set; }


    public ShodanMethod(string methodUrl)
    {
      MethodUrl = methodUrl;
      QueryParams = new Dictionary<string, string>();
    }


    public virtual T Execute()
    {
      if (String.IsNullOrEmpty(ShodanApi.Key))
        throw new Exception("Shodan API key not specified.");

      string queryParamStr = String.Empty;

      foreach (KeyValuePair<string, string> queryParam in QueryParams)
        queryParamStr += String.Format("&{0}={1}", queryParam.Key, queryParam.Value);

      HttpWebRequest request = WebRequest.Create(String.Format("{0}/{1}?key={2}{3}", ShodanApi.URL, MethodUrl, ShodanApi.Key, queryParamStr)) as HttpWebRequest;

      using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
      {
        DataContractJsonSerializer jsonSerializer;
        object objResponse;

        if (response.StatusCode != HttpStatusCode.OK)
        {
          jsonSerializer = new DataContractJsonSerializer(typeof(JsonTypes.Error));
          objResponse = jsonSerializer.ReadObject(response.GetResponseStream());

          throw new Exception(String.Format("Server error: {0}.", (objResponse as JsonTypes.Error).Message));
        }

        jsonSerializer = new DataContractJsonSerializer(typeof(T));
        objResponse = jsonSerializer.ReadObject(response.GetResponseStream());

        return (objResponse as T);
      }
    }
  }
}
