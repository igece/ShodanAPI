namespace Shodan.API.Interfaces
{
  interface IPagedResults<T> where T : class
  {
    T[] Matches { get; set; }

    uint Total { get; set; }
  }
}
