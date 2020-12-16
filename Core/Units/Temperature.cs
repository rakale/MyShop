
using System.Collections.Generic;

namespace Abc.Core.Units {

    public static class Temperature {

        public static UnitInfo Measure = new UnitInfo
        (
            measureName,
            "T",
            "Thermodynamic Temperature",
            "Thermodynamic temperature is the absolute measure of temperature " +
            "and is one of the principal parameters of thermodynamics."
        );
        public static List<UnitInfo> Units =>
            new List<UnitInfo> {
                new UnitInfo(kelvinName, "°K"),
                new UnitInfo(celsiusName, "°C", celsiusFactor),
                new UnitInfo(fahrenheitName, "°F", fahrenheitFactor),
                new UnitInfo(rankineName, "°R", rankineFactor)
            };


        internal const string measureName = "Temperature";

        internal const string celsiusName = "Celsius";
        internal const string fahrenheitName = "Fahrenheit";
        internal const string kelvinName = "Kelvin";
        internal const string rankineName = "Rankine";

        internal const string celsiusToKelvinRuleId = "Celsius to Kelvin";
        internal const string fahrenheitToKelvinRuleId = "Fahrenheit to Kelvin";
        internal const string rankineToKelvinRuleId = "Rankine to Kelvin";
        internal const string kelvinToCelsiusRuleId = "Kelvin to Celsius";
        internal const string kelvinToFahrenheitRuleId = "Kelvin to Fahrenheit";
        internal const string kelvinToRankineRuleId = "Kelvin to Rankine";

        internal const double celsiusFactor = 273.15;
        internal const double fahrenheitFactor = 459.67;
        internal const double rankineFactor = 1.8000;

    }

}
