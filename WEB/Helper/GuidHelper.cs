using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WEB.Helper
{
    internal static class GuidHelper
    {
        /// <summary>
        /// The regular expression for finding a GUID
        /// </summary>
        private const string GuidRegex = @"\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b";

        /// <summary>
        /// Finds the first GUID in the given string.
        /// </summary>
        /// <param name="source">The source string to search.</param>
        /// <returns>guid in string</returns>
        public static Guid FindFirstGuid(string source)
        {
            var match = Regex.Match(source, GuidRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            if (!match.Success || match.Groups.Count < 1)
            {
                return Guid.Empty;
            }

            return new Guid(match.Groups[0].Value);
        }
    }
}