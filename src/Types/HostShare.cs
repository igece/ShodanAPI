using System;


namespace Shodan.API.Types
{
  public class HostShare
  {
    public string Name { get; set; }
    public string Comment { get; set; }

    public override string ToString()
    {
      return String.Format("{0} ({1})", Name, Comment);
    }
  }
}

