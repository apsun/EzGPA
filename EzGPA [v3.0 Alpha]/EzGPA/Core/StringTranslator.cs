namespace EzGPA.Core
{
    /// <summary>
    /// A function that takes a raw string as a parameter and 
    /// returns a localized version of that string.
    /// </summary>
    /// <param name="rawValue">The string to localize.</param>
    public delegate string StringTranslator(string rawValue);
}
