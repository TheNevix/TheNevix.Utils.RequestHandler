namespace TheNevix.Utils.RequestHandler.Models.Enums
{
    /// <summary>
    /// Enum with possible deserialization options
    /// </summary>
    public enum ResponseDeserialization
    {
        /// <summary>
        /// Sets deserialization to the standard system one.
        /// </summary>
        System,

        /// <summary>
        /// Sets deserialization to newtonsoft.
        /// </summary>
        NewtonSoft
    }
}
