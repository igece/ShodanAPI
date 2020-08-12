using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;

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

      var requestParamStr = string.Empty;

      foreach (var requestParam in RequestParams)
        requestParamStr += $"&{requestParam.Key}={requestParam.Value}";

      var request = WebRequest.Create($"{ShodanApi.URL}/{MethodUrl}?key={ShodanApi.Key}{requestParamStr}") as HttpWebRequest;
      DataContractJsonSerializer jsonSerializer;
      object objResponse;

      bool timeout;
      int retries = 0;

      do
      {
        timeout = false;

        try
        {
          using (var response = request.GetResponse() as HttpWebResponse)
          {
            jsonSerializer = new DataContractJsonSerializer(typeof(T), new DataContractJsonSerializerSettings
            {
              DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss.FFFFFF")
            });

            objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
          }
        }

        catch (WebException ex)
        {
          jsonSerializer = new DataContractJsonSerializer(typeof(Types.Json.Error));

          if (ex.Response != null)
          {
            objResponse = jsonSerializer.ReadObject(ex.Response.GetResponseStream());

            if (objResponse is Types.Json.Error shodanError)
            {
              if (shodanError.Message.StartsWith("The search request timed out") && retries++ < 5)
              {
                System.Diagnostics.Debug.WriteLine($"Request timed out, retrying... ({retries}/5)");

                timeout = true;
                Thread.Sleep(1000);
                continue;
              }
              else
                throw new ShodanException(shodanError.Message);
            }
          }

          else
            throw new ShodanException(ex.Message);
        }

        catch (Exception)
        {
          throw;
        }
      } while (timeout);

      return (objResponse as T);
    }


    public async virtual Task<T> ExecuteAsync()
    {
      if (string.IsNullOrEmpty(ShodanApi.Key))
        throw new ShodanException("Shodan API key not specified.");

      var requestParamStr = string.Empty;

      foreach (var requestParam in RequestParams)
        requestParamStr += $"&{requestParam.Key}={requestParam.Value}";

      var request = WebRequest.Create($"{ShodanApi.URL}/{MethodUrl}?key={ShodanApi.Key}{requestParamStr}") as HttpWebRequest;
      DataContractJsonSerializer jsonSerializer;
      object objResponse;

      bool timeout;
      int retries = 0;

      do
      {
        timeout = false;

        try
        {
          using (var response = await request.GetResponseAsync() as HttpWebResponse)
          {
            jsonSerializer = new DataContractJsonSerializer(typeof(T), new DataContractJsonSerializerSettings
            {
              DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ss.FFFFFF")
            });

            objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
          }
        }

        catch (WebException ex)
        {
          jsonSerializer = new DataContractJsonSerializer(typeof(Types.Json.Error));

          if (ex.Response != null)
          {
            objResponse = jsonSerializer.ReadObject(ex.Response.GetResponseStream());

            if (objResponse is Types.Json.Error shodanError)
            {
              if (shodanError.Message.StartsWith("The search request timed out") && retries++ < 5)
              {
                System.Diagnostics.Debug.WriteLine($"Request timed out, retrying... ({retries}/5)");

                timeout = true;

                await Task.Delay(1000);
                
                continue;
              }
              else
                throw new ShodanException(shodanError.Message);
            }
          }

          else
            throw new ShodanException(ex.Message);
        }

        catch (Exception)
        {
          throw;
        }
      } while (timeout);

      return (objResponse as T);
    }

  }
}
