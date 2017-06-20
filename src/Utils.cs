using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Shodan.API.JsonTypes;
using Shodan.API.Types;


namespace Shodan.API
{
  public class Utils
  {
    public static HostShare[] GetHostShares(HostJson host)
    {
      List<HostShare> shares = new List<HostShare>();
      Regex regEx = new Regex(@"([a-zA-Z0-9!@#\$%\^&\(\)-_'\{\}\.~ ]+)\s+(Disk)\s+([a-zA-Z0-9!@#\$%\^&\(\)-_'\{\}\.~\s]+)", RegexOptions.None);

      string[] entries = host.Data.Split(new string[] { "\n\t" }, StringSplitOptions.RemoveEmptyEntries);

      if (entries.Length > 0)
      {
        bool sharesFound = false;

        foreach (string line in entries)
        {
          if (!sharesFound)
          {
            if (line.TrimStart().StartsWith("Sharename       Type      Comment"))
              sharesFound = true;
          }
          else
          {
            MatchCollection matches = regEx.Matches(line);

            if (matches.Count == 1)
            {
              HostShare newShare = new HostShare();
              newShare.Name = matches[0].Groups[1].ToString().Trim();
              newShare.Comment = matches[0].Groups[3].ToString().Trim();

              shares.Add(newShare);
            }
          }
        }
      }

      return shares.ToArray();
    }
  }
}
