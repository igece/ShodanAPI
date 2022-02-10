using System;
using System.Collections;
using System.Reflection;
using System.Text;

using Shodan.API.CustomAttributes;

namespace Shodan.API
{
  public abstract class UrlParameters
  {
    public override string ToString()
    {
      var requestString = new StringBuilder();

      foreach (var property in GetType().GetProperties())
      {
        var value = property.GetValue(this);

        if (value == null)
          continue;

        var paramName = property.GetCustomAttribute<ParameterAttribute>()?.Name ?? property.Name.ToLowerInvariant();

        if (property.PropertyType != typeof(string) &&
             property.PropertyType.GetInterface(nameof(IEnumerable)) != null)
        {
          foreach (var entry in value as IEnumerable)
            requestString.Append($"{paramName}={entry.ToString().ToLowerInvariant()}&");
        }

        else if (!string.IsNullOrEmpty(value.ToString()))
        {
          if (value.GetType().IsEnum)
          {
            if (value.GetType().IsDefined(typeof(FlagsAttribute), false))
              requestString.Append($"{paramName}={value.ToString().Replace(' ', '\0').ToLowerInvariant()}&");
            else
              requestString.Append($"{paramName}={value.ToString().ToLowerInvariant()}&");
          }

          else if (value.GetType().Equals(typeof(DateTime)))
            requestString.Append($"{paramName}={(DateTime)value:s}&");

          else
            requestString.Append($"{paramName}={value.ToString().ToLowerInvariant()}&");
        }
      }

      return requestString.ToString().TrimEnd('?', '&');
    }

  }
}
