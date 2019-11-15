using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using Shodan.API.Exceptions;


namespace Shodan.API
{
  public class ShodanMethod<T> where T : class
  {
    protected string MethodUrl { get; set; }

    protected Dictionary<string, string> RequestParams { get; private set; }


    public ShodanMethod(string methodUrl)
    {
      MethodUrl = methodUrl;
      RequestParams = new Dictionary<string, string>();
    }


    public virtual T Execute()
    {
      if (string.IsNullOrEmpty(ShodanApi.Key))
        throw new ShodanException("Shodan API key not specified.");

      string requestParamStr = String.Empty;

      foreach (KeyValuePair<string, string> requestParam in RequestParams)
        requestParamStr += $"&{requestParam.Key}={requestParam.Value}";

      HttpWebRequest request = WebRequest.Create($"{ShodanApi.URL}/{MethodUrl}?key={ShodanApi.Key}{requestParamStr}") as HttpWebRequest;
      DataContractJsonSerializer jsonSerializer;
      object objResponse;

      try
      {
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
          jsonSerializer = new DataContractJsonSerializer(typeof(T), new DataContractJsonSerializerSettings
          {
            DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss.ffffff")
          });

          objResponse = jsonSerializer.ReadObject(response.GetResponseStream());

          return (objResponse as T);
        }
      }

      catch (WebException ex)
      {
        jsonSerializer = new DataContractJsonSerializer(typeof(JsonTypes.Error));

        if (ex.Response != null)
        {
          objResponse = jsonSerializer.ReadObject(ex.Response.GetResponseStream());
          throw new ShodanException((objResponse as JsonTypes.Error).Message);
        }

        else
          throw new ShodanException(ex.Message);
      }

      catch (Exception)
      {
        throw;
      }
    }
  }
}
