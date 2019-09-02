using System;


namespace Shodan.API.Exceptions
{
  /// <summary>
  /// Generic Shodan exception.
  /// </summary>
  public class ShodanException : Exception 
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Shodan.API.Exceptions.ShodanException"/>.
    /// to a default message.
    /// </summary>
    public ShodanException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Shodan.API.Exceptions.ShodanException"/> class with a specified message.
    /// </summary>
    /// <param name="message">The exception's message.</param>
  	public ShodanException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Shodan.API.Exceptions.ShodanException"/> class with a specified message and a
    /// reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The exception's message.</param>
    /// <param name="inner">Exception that caused it.</param>
  	public ShodanException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}
