﻿using System;
using System.Collections.Generic;
using System.Threading;

using Shodan.API.Interfaces;
using Shodan.API.JsonTypes;


namespace Shodan.API
{
  public class HostSearch : ShodanMethod<HostSearchJson>, IPagedOutput
  {
    public string Query { get; set; }
    public uint MaxPages { get; set; }

    public bool? HasScreenShot { get; set; }
    public ushort? Port { get; set; }


    public HostSearch()
    : base("shodan/host/search")
    {
      Query = String.Empty;
      MaxPages = 1;

      HasScreenShot = null;
      Port = null;      
    }


    public override HostSearchJson Execute()
    {
      QueryParams.Clear();

      if (Query == null)
        throw new Exception("Query string can't be null.");

      QueryParams.Add("query", Query);

      if (HasScreenShot.HasValue)
        QueryParams.Add("has_screenshot", HasScreenShot.Value.ToString());

      if (Port.HasValue)
        QueryParams.Add("port", Port.Value.ToString());

      if (MaxPages == 1)
      {
        HostSearchJson result = base.Execute();

        foreach (HostJson host in result.Matches)
          host.Shares = Utils.GetHostShares(host);

        return result;
      }

      uint currentPage = 1;
      uint realMaxPages = MaxPages;

      HostSearchJson allResults = new HostSearchJson();
      List<HostJson> allHosts = new List<HostJson>();

      int retries = 0;
           
      do
      {
        QueryParams["page"] = currentPage.ToString();

        try
        {
          HostSearchJson pageResults = base.Execute();
          retries = 0;

          if (currentPage == 1)
          {
            allResults.Total = pageResults.Total;
            uint totalPages = Convert.ToUInt32(Math.Ceiling(pageResults.Total / 100.0));

            if (realMaxPages > totalPages)
              realMaxPages = totalPages;
          }

          allHosts.AddRange(pageResults.Matches);
        }

        catch (Exception)
        {
          if (++retries == 3)
          {
            retries = 0;
            currentPage++;
            continue;
          }

          Thread.Sleep(100);
          continue;
        }

        Thread.Sleep(100);

      } while (currentPage++ < realMaxPages);

      allResults.Matches = allHosts.ToArray();

      foreach (HostJson host in allResults.Matches)
        host.Shares = Utils.GetHostShares(host);

      return allResults;
    }
  }
}
