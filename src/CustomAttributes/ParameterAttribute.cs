using System;


namespace Shodan.API.CustomAttributes
{
  public class ParameterAttribute : Attribute
  {
    public string Name { get; set; }


    public ParameterAttribute()
    {
      Name = null;
    }

    public ParameterAttribute(string name)
    {
      Name = name;
    }
  }
}
