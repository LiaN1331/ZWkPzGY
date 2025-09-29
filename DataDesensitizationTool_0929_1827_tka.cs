// 代码生成时间: 2025-09-29 18:27:04
using System;
using System.Text.RegularExpressions;

namespace DataDesensitization
{
    /// <summary>
    /// Provides functionality to desensitize sensitive data such as phone numbers, email addresses, etc.
    /// </summary>
    public class DataDesensitizationTool
    {
        /// <summary>
        /// Desensitizes a string containing phone numbers by replacing part of the digits with asterisks.
        /// </summary>
        /// <param name="input">The input string that may contain phone numbers.</param>
        /// <returns>The desensitized string.</returns>
        public string DesensitizePhoneNumbers(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));

            // Regular expression pattern to match phone numbers
            string pattern = @"(\+\d{1,3}[- ]?)?\d{10}";
            return Regex.Replace(input, pattern, m => m.Value.Substring(0, 3) + "****" + m.Value.Substring(m.Value.Length - 4));
        }

        /// <summary>
        /// Desensitizes a string containing email addresses by replacing part of the local part with asterisks.
        /// </summary>
        /// <param name="input">The input string that may contain email addresses.</param>
        /// <returns>The desensitized string.</returns>
        public string DesensitizeEmailAddresses(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));

            // Regular expression pattern to match email addresses
            string pattern = @"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+";
            return Regex.Replace(input, pattern, m =>
            {
                string email = m.Value;
                return email.Substring(0, 2) + email.Substring(email.IndexOf('@'));
            });
        }

        // Additional desensitization methods can be added here as needed.
    }
}
