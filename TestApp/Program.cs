using Shodan.API;


ShodanClient.ApiKey = "";

while (true)
{
    try
    {
        var queryResults = (await ShodanClient.SearchHostsAsync("200 hipcam", maxPages: 1)).Matches.Where(host => !string.IsNullOrEmpty(host.Screenshot?.Data));
        Console.WriteLine($"Found a total of {queryResults.Count()} results");
        await Task.Delay(10000);
    }

    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
    }
}