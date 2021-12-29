using System;
using System.Globalization;
using System.Text;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length > 4 || dateCode.Length < 3)
            {
                throw new ArgumentException("cannot be > 4 or < 3", nameof(dateCode));
            }

            if (Convert.ToUInt32(dateCode[0..2], CultureInfo.CurrentCulture) < 80 || Convert.ToUInt32(dateCode[0..2], CultureInfo.CurrentCulture) >= 90 || Convert.ToUInt32(dateCode[2..], CultureInfo.CurrentCulture) > 12 || Convert.ToUInt32(dateCode[2..], CultureInfo.CurrentCulture) < 1)
            {
                throw new ArgumentException("no", nameof(dateCode));
            }

            manufacturingYear = Convert.ToUInt32(dateCode[0..2], CultureInfo.CurrentCulture) + 1900;
            manufacturingMonth = Convert.ToUInt32(dateCode[2..], CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length > 6 || dateCode.Length < 5)
            {
                throw new ArgumentException("cannot be > 6 or < 5", nameof(dateCode));
            }

            if (Convert.ToUInt32(dateCode[0..2], CultureInfo.CurrentCulture) <= 80 || Convert.ToUInt32(dateCode[0..2], CultureInfo.CurrentCulture) >= 90)
            {
                throw new ArgumentException("no", nameof(dateCode));
            }

            if (dateCode.Length == 6)
            {
                if (Convert.ToUInt32(dateCode[2..4], CultureInfo.CurrentCulture) > 12 || Convert.ToUInt32(dateCode[2..4], CultureInfo.CurrentCulture) < 1)
                {
                    throw new ArgumentException("no", nameof(dateCode));
                }
            }
            else
            {
                if (Convert.ToUInt32(dateCode[2..3], CultureInfo.CurrentCulture) > 12 || Convert.ToUInt32(dateCode[2..3], CultureInfo.CurrentCulture) < 1)
                {
                    throw new ArgumentException("no", nameof(dateCode));
                }
            }

            factoryLocationCountry = CountryParser.GetCountry(dateCode[^2..]);
            manufacturingYear = Convert.ToUInt32(dateCode[0..2], CultureInfo.CurrentCulture) + 1900;
            if (dateCode.Length == 6)
            {
                manufacturingMonth = Convert.ToUInt32(dateCode[2..4], CultureInfo.CurrentCulture);
            }
            else
            {
                manufacturingMonth = Convert.ToUInt32(dateCode[2] + string.Empty, CultureInfo.CurrentCulture);
            }

            factoryLocationCode = dateCode[^2..];
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 6)
            {
                throw new ArgumentException("cannot be < 5", nameof(dateCode));
            }

            if (Convert.ToUInt32(new string(dateCode[3] + string.Empty), CultureInfo.CurrentCulture) == 0)
            {
                if (Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) > 6 || Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture) > 12 || Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture) < 1)
                {
                    throw new ArgumentException("no", nameof(dateCode));
                }
            }
            else
            {
                if (Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) < 90 || Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture) > 12 || Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture) < 1)
                {
                    throw new ArgumentException("no", nameof(dateCode));
                }
            }

            factoryLocationCountry = CountryParser.GetCountry(dateCode[..2]);
            if (Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) < 6)
            {
                manufacturingYear = Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) + 2000;
            }
            else
            {
                manufacturingYear = Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) + 1900;
            }

            manufacturingMonth = Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture);
            factoryLocationCode = dateCode[..2];
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing month to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            // get a string, after parse/convert to uint, comparison to 6
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("cannot be < 5", nameof(dateCode));
            }

            // if first year letter  == 0 we just compare to 7 , or 21 if not
            if (Convert.ToUInt32(new string(dateCode[3] + string.Empty), CultureInfo.CurrentCulture) == 0)
            {
                if (Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) < 7 || Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture) < 1)
                {
                    throw new ArgumentException("no", nameof(dateCode));
                }
            }
            else
            {
                if (Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) > 21 || Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture) < 1)
                {
                    throw new ArgumentException("no", nameof(dateCode));
                }
            }

            if (Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture) > ISOWeek.GetWeekOfYear(new DateTime((int)Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) + 2000, 12, 30)))
            {
                throw new ArgumentException("first week on the next year", nameof(dateCode));
            }

            factoryLocationCountry = CountryParser.GetCountry(dateCode[..2]);
            manufacturingYear = Convert.ToUInt32(new string(dateCode[3] + string.Empty + dateCode[5]), CultureInfo.CurrentCulture) + 2000;
            manufacturingWeek = Convert.ToUInt32(new string(dateCode[2] + string.Empty + dateCode[4]), CultureInfo.CurrentCulture);
            factoryLocationCode = dateCode[..2];
        }
    }
}
