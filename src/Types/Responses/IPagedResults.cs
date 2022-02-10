namespace Shodan.API.Types.Responses
{
  public interface IPagedResults<T> where T : class
  {
    T[] Matches { get; set; }

    uint Total { get; set; }
  }
}
