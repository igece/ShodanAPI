﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Shodan.API.Exceptions;
using Shodan.API.Interfaces;
using Shodan.API.Types.Json;


namespace Shodan.API
{
  public class HostSearch : ShodanMethod<HostSearchJson>, IFilterable, IPageable
  {
    public string Query { get; set; }

    public bool? HasScreenshot { get; set; }

    public ushort? Port { get; set; }

    public DateTime? After { get; set; }

    public uint MaxPages { get; set; }

    public bool? Minify { get; set; }


    public HostSearch()
    : base("shodan/host/search")
    {
      Query = string.Empty;
      MaxPages = 1;
      Minify = null;
      HasScreenshot = null;
      Port = null;
    }


    public override HostSearchJson Execute()
    {
      if (Query == null)
        throw new ShodanException("Query string can't be null.");

      RequestParams.Clear();
      RequestParams.Add("query", InterfaceUtils.AddFiltersToQuery(Query, this));

      if (Minify.HasValue)
        RequestParams.Add("minify", Minify.Value.ToString().ToLowerInvariant());

      if (MaxPages == 1)
        return base.Execute();

      uint currentPage = 1;
      uint realMaxPages = MaxPages;

      var allResults = new HostSearchJson();
      var allHosts = new List<HostJson>();

      //int retries = 0;

      do
      {
        RequestParams["page"] = currentPage.ToString();

        try
        {
          var pageResults = base.Execute();
          //retries = 0;

          if (currentPage == 1)
          {
            allResults.Total = pageResults.Total;
            uint totalPages = Convert.ToUInt32(Math.Ceiling(pageResults.Total / Convert.ToDouble(ShodanApi.ResultsPerPage)));

            if (realMaxPages > totalPages)
              realMaxPages = totalPages;
          }

          allHosts.AddRange(pageResults.Matches);
          Thread.Sleep(1000);
        }

        catch (Exception)
        {
          /*
          if (++retries == 3)
          {
            retries = 0;
            currentPage++;
            continue;
          }
          currentPage++;
          Thread.Sleep(1000);
          continue;
          */
        }
      } while (currentPage++ < realMaxPages);

      allResults.Matches = allHosts.ToArray();

      return allResults;
    }


    public override async Task<HostSearchJson> ExecuteAsync()
    {
      if (Query == null)
        throw new ShodanException("Query string can't be null.");

      RequestParams.Clear();
      RequestParams.Add("query", InterfaceUtils.AddFiltersToQuery(Query, this));

      if (Minify.HasValue)
        RequestParams.Add("minify", Minify.Value.ToString().ToLowerInvariant());

      if (MaxPages == 1)
        return await base.ExecuteAsync();

      uint currentPage = 1;
      uint realMaxPages = MaxPages;

      var allResults = new HostSearchJson();
      var allHosts = new List<HostJson>();

      //int retries = 0;

      do
      {
        RequestParams["page"] = currentPage.ToString();

        try
        {
          var pageResults = base.Execute();
          //retries = 0;

          if (currentPage == 1)
          {
            allResults.Total = pageResults.Total;
            uint totalPages = Convert.ToUInt32(Math.Ceiling(pageResults.Total / Convert.ToDouble(ShodanApi.ResultsPerPage)));

            if (realMaxPages > totalPages)
              realMaxPages = totalPages;
          }

          allHosts.AddRange(pageResults.Matches);
          await Task.Delay(1000);
        }

        catch (Exception)
        {
          /*
          if (++retries == 3)
          {
            retries = 0;
            currentPage++;
            continue;
          }
          currentPage++;
          Thread.Sleep(1000);
          continue;
          */
        }
      } while (currentPage++ < realMaxPages);

      allResults.Matches = allHosts.ToArray();

      return allResults;
    }

  }
}
