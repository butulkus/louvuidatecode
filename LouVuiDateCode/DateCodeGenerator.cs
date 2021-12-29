using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            // help 163 str DATEcodeparser
            if (manufacturingYear < 1980 || manufacturingYear >= 1990 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            string returN = (manufacturingYear - 1900).ToString(CultureInfo.CurrentCulture) + manufacturingMonth.ToString(CultureInfo.CurrentCulture);
            return returN;
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year >= 1990 || manufacturingDate.Month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            return (manufacturingDate.Year - 1900).ToString(CultureInfo.CurrentCulture) + manufacturingDate.Month.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear >= 1990 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int number;
            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out number) || int.TryParse(factoryLocationCode[1].ToString(), out number))
            {
                throw new ArgumentException("no", nameof(factoryLocationCode));
            }

            string returN = (manufacturingYear - 1900).ToString(CultureInfo.CurrentCulture) + manufacturingMonth.ToString(CultureInfo.CurrentCulture) + factoryLocationCode.ToUpper(CultureInfo.CurrentCulture);
            return returN;
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year >= 1990 || manufacturingDate.Month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int number;
            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out number) || int.TryParse(factoryLocationCode[1].ToString(), out number))
            {
                throw new ArgumentException("no", nameof(factoryLocationCode));
            }

            return (manufacturingDate.Year - 1900).ToString(CultureInfo.CurrentCulture) + manufacturingDate.Month.ToString(CultureInfo.CurrentCulture) + factoryLocationCode.ToUpper(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1990 || manufacturingYear > 2006 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int number;
            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out number) || int.TryParse(factoryLocationCode[1].ToString(), out number))
            {
                throw new ArgumentException("no", nameof(factoryLocationCode));
            }

            if (manufacturingMonth.ToString(CultureInfo.CurrentCulture).Length == 1)
            {
                return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + 0 + manufacturingYear.ToString(CultureInfo.CurrentCulture)[2] + manufacturingMonth.ToString(CultureInfo.CurrentCulture)[0] + manufacturingYear.ToString(CultureInfo.CurrentCulture)[3];
            }

            return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + manufacturingMonth.ToString(CultureInfo.CurrentCulture)[0] + manufacturingYear.ToString(CultureInfo.CurrentCulture)[2] + manufacturingMonth.ToString(CultureInfo.CurrentCulture)[1] + manufacturingYear.ToString(CultureInfo.CurrentCulture)[3];
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1990 || manufacturingDate.Year > 2006 || manufacturingDate.Month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int number;
            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out number) || int.TryParse(factoryLocationCode[1].ToString(), out number))
            {
                throw new ArgumentException("no", nameof(factoryLocationCode));
            }

            if (manufacturingDate.Month.ToString(CultureInfo.CurrentCulture).Length == 1)
            {
                return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + 0 + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[2] + manufacturingDate.Month.ToString(CultureInfo.CurrentCulture)[0] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[3];
            }

            return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + manufacturingDate.Month.ToString(CultureInfo.CurrentCulture)[0] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[2] + manufacturingDate.Month.ToString(CultureInfo.CurrentCulture)[1] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[3];
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int number;
            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out number) || int.TryParse(factoryLocationCode[1].ToString(), out number))
            {
                throw new ArgumentException("no", nameof(factoryLocationCode));
            }

            if (manufacturingWeek > ISOWeek.GetWeekOfYear(new DateTime((int)manufacturingYear, 12, 30)))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingYear < 2007 || manufacturingYear > DateTime.Today.Year || manufacturingWeek < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingWeek.ToString(CultureInfo.CurrentCulture).Length == 1)
            {
                return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + 0 + manufacturingYear.ToString(CultureInfo.CurrentCulture)[2] + manufacturingWeek.ToString(CultureInfo.CurrentCulture)[0] + manufacturingYear.ToString(CultureInfo.CurrentCulture)[3];
            }

            return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + manufacturingWeek.ToString(CultureInfo.CurrentCulture)[0] + manufacturingYear.ToString(CultureInfo.CurrentCulture)[2] + manufacturingWeek.ToString(CultureInfo.CurrentCulture)[1] + manufacturingYear.ToString(CultureInfo.CurrentCulture)[3];
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            int number;
            if (factoryLocationCode.Length != 2 || int.TryParse(factoryLocationCode[0].ToString(), out number) || int.TryParse(factoryLocationCode[1].ToString(), out number))
            {
                throw new ArgumentException("no", nameof(factoryLocationCode));
            }

            if (manufacturingDate.Year < 2007 || manufacturingDate.Year > DateTime.Today.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (manufacturingDate.Month == 1 && ISOWeek.GetWeekOfYear(manufacturingDate) == 52)
            {
                return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[0] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[2] + ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[1] + (manufacturingDate.Year - 1).ToString(CultureInfo.CurrentCulture)[3];
            }

            if (manufacturingDate.Month == 1 && ISOWeek.GetWeekOfYear(manufacturingDate) == 53)
            {
                return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[0] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[2] + ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[1] + (manufacturingDate.Year - 1).ToString(CultureInfo.CurrentCulture)[3];
            }

            if (ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture).Length == 1)
            {
                return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + 0 + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[2] + ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[0] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[3];
            }

            return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[0] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[2] + ISOWeek.GetWeekOfYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[1] + manufacturingDate.Year.ToString(CultureInfo.CurrentCulture)[3];
        }
    }
}
