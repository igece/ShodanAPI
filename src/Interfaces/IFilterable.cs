using System;
using System.Collections.Generic;


namespace Shodan.API.Interfaces
{
  interface IFilterable
  {
    bool? HasScreenshot { get; set; }

    ushort? Port { get; set; }

    DateTime? After { get; set; }
  }


  internal partial class InterfaceUtils
  {
    public static void AddFilter(IFilterable method, Dictionary<string, string> queryParams)
    {
      if (method.HasScreenshot.HasValue)
        queryParams.Add("has_screenshot", method.HasScreenshot.Value.ToString());

      if (method.Port.HasValue)
        queryParams.Add("port", method.Port.Value.ToString());

      if (method.After.HasValue)
        queryParams.Add("after", method.After.Value.ToString("dd/MM/yyyy"));
    }
  }
}
