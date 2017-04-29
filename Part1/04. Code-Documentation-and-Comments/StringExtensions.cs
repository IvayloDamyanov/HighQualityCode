namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// String converting tools.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts string to MD5 Hash.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>MD5 Hash representation of a string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Converts true-like phrases to boolean.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns><c>True</c> if input is true-like phrase, <c>False</c> otherwise.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts a string to 16-bit integer.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>16-bit integer representation if input is valid, <c>0</c> otherwise.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts a string to 16-bit integer.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>16-bit integer representation if input is valid, <c>0</c> otherwise.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts a string to 32-bit integer.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Correct 32-bit integer representation if input is valid, <c>0</c> otherwise.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts a string to DateTime variable.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Correct DateTime variable representation if input is valid, <c>01/01/0001 12:00:00 AM</c> otherwise.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes first letter of a string.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>A string with capitalized first letter if input is not null ot empty, empty string otherwise.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Extracts a substring by enclosing strings. 
        /// </summary>
        /// <param name="input">Source string.</param>
        /// <param name="startString">String that marks the start of the desired result.</param>
        /// <param name="endString">String that marks the end of the desired result.</param>
        /// <param name="startFrom">Position in the source string from which to start the search.</param>
        /// <returns>Extracted string if the input parameters are valid and found, empty string otherwise.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0; //not needed, parameter already set in method's parameters list, should be deleted after revision
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts Cyrillic letters to their Latin transliteration in a string.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Target string with Cyrillic letters converted to their Latin representation.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts Latin letters to their traditional phonetic Cyrillic keyboard counterparts.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Target string with Latin letters converted to their traditional phonetic Cyrillic keyboard representation.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts a string to valid username.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Target string with Cyrillic letters converted to Latin letters and unallowed symbols removed.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();

            //remove symbols that are not allowed
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts a string to valid filename.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Target string with Cyrillic letters converted to Latin letters, empty spaces replaced by dash "<c>-</c>" unallowed symbols removed.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();

            //remove symbols that are not allowed
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Extracts a n-number of leading characters from a string.
        /// </summary>
        /// <param name="input">Target string.</param>
        /// <param name="charsCount">Number of leading characters to be extracted.</param>
        /// <returns>N-number leading characters as a string if the desired number was smaller than the string's length, the original string otherwise.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// File extension from a filename string.
        /// </summary>
        /// <param name="fileName">Target filename string.</param>
        /// <returns>File extension if there is any, empty string otherwise.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts file extension to content type.
        /// </summary>
        /// <param name="fileExtension">Target file extension string.</param>
        /// <returns>Converted file extension to corresponding content type if file extension is recognized, generic type otherwise.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the characters of a string to an array of their ASCII 8-bit integer represesentations.
        /// </summary>
        /// <param name="input">Target string.</param>
        /// <returns>Array of 8-bit integers.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
