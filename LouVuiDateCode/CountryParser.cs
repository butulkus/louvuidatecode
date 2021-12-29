using System;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            // hang me if that will be incorrect
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            string[] france = new string[] { "A0", "A1", "A2", "AA", "AAS", "AH", "AN", "AR", "AS", "BA", "BJ", "BU", "DR", "DU", "DR", "DT", "CO", "CT", "CX", "ET", "FL", "LW", "MB", "MI", "NO", "RA", "RI", "SD", "SF", "SL", "SN", "SP", "SR", "TJ", "TH", "TR", "TS", "VI", "VX" };
            string[] italy = new string[] { "BC", "BO", "CE", "FO", "MA", "OB", "RC", "RE", "SA", "TD" };
            string[] spain = new string[] { "CA", "LO", "LB", "LM", "LW", "GI" };
            string[] usa = new string[] { "FC", "FH", "LA", "OS", "SD", "FL" };
            if (factoryLocationCode == "FL" || factoryLocationCode == "SD")
            {
                return new Country[] { Country.France, Country.USA };
            }
            else if (factoryLocationCode == "LW")
            {
                return new Country[] { Country.France, Country.Spain };
            }
            else if (factoryLocationCode == "LP" || factoryLocationCode == "OL")
            {
                return new Country[] { Country.Germany };
            }
            else if (factoryLocationCode == "DI" || factoryLocationCode == "FA")
            {
                return new Country[] { Country.Switzerland };
            }

            for (int i = 0; i < france.Length; i++)
            {
                if (factoryLocationCode == france[i])
                {
                    return new Country[] { Country.France };
                }
            }

            for (int i = 0; i < italy.Length; i++)
            {
                if (factoryLocationCode == italy[i])
                {
                    return new Country[] { Country.Italy };
                }
            }

            for (int i = 0; i < usa.Length; i++)
            {
                if (factoryLocationCode == usa[i])
                {
                    return new Country[] { Country.USA };
                }
            }

            for (int i = 0; i < spain.Length; i++)
            {
                if (factoryLocationCode == spain[i])
                {
                    return new Country[] { Country.Spain };
                }
            }

            throw new ArgumentException("no", nameof(factoryLocationCode));
        }
    }
}
