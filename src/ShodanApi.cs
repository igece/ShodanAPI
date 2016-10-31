namespace Shodan.API
{
  public class ShodanApi
  {
    public static string Key { get; set; }
    public const string URL = "https://api.shodan.io";

    public const uint RESULTS_PER_PAGE = 100;
  }
}
