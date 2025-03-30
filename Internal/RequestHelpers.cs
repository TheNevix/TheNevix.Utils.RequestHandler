namespace TheNevix.Utils.RequestHandler.Internal
{
    internal static class RequestHelpers
    {
        internal static string EnsureTrailingQuestionMark(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return url;

            return url.EndsWith("?") ? url : url + "?";
        }
    }
}
