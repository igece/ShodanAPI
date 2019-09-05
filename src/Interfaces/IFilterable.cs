using System;
using System.Text;


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
    public static string AddFiltersToQuery(string query, IFilterable filters)
    {
      StringBuilder filteredQuery = new StringBuilder(query);

      if (filters.HasScreenshot.HasValue)
        filteredQuery.AppendFormat(" has_screenshot:{0}", filters.HasScreenshot.Value.ToString().ToLowerInvariant());

      if (filters.Port.HasValue)
        filteredQuery.AppendFormat(" port:{0}", filters.Port.Value.ToString());

      if (filters.After.HasValue)
        filteredQuery.AppendFormat(" &#61;&#66;&#74;&#65;&#72;:\"{0}\"", filters.After.Value.ToString("dd/MM/yyyy"));

      return filteredQuery.ToString();
    }
  }
}
