using System.Text.RegularExpressions;

namespace WorkManagement.Helper
{
    public static class CommonFunction
    {
        public static List<string> SplitString(string input, string regexPattern)
        {
            List<string> result = new List<string>();

            // Use Regex.Split() to split the input string using the regex pattern
            string[] substrings = Regex.Split(input, regexPattern);

            // Add the substrings to the result list
            result.AddRange(substrings);

            return result;
        }
        public static string ConvertDateTimeToString(DateTime dateTime)
        {
            // Use the custom date format "dd MMM yyyy" to get "12 Aug 2019"
            string formattedDate = dateTime.ToString("dd MMM yyyy");
            return formattedDate;
        }
    }
}
