using System;
using System.Collections.Generic;
using System.Linq;

//Lots of good examples out there for lunar phase calcs...
//This based on C# example from https://github.com/khalidabuhakmeh/MoonPhaseConsole 
//Credit to khalidabuhakmeh and the scientists that have done before us
// Copyright 2020 Khalid Abuhakmeh

namespace SextantHelper
{
    public static class LunarWorker
    {
        private static readonly IReadOnlyList<string> NorthernHemisphere
            = new List<string> { "🌑", "🌒", "🌓", "🌔", "🌕", "🌖", "🌗", "🌘", "🌑" };

        private static readonly IReadOnlyList<string> SouthernHemisphere
            = NorthernHemisphere.Reverse().ToList();

        private static readonly List<string> Names = new List<string>
        {
            Phase.NewMoon,
            Phase.WaxingCrescent, Phase.FirstQuarter, Phase.WaxingGibbous,
            Phase.FullMoon,
            Phase.WaningGibbous, Phase.ThirdQuarter, Phase.WaningCrescent
        };

        private const double TotalLengthOfCycle = 29.53; //good enough for our purposes

        private static readonly List<Phase> allPhases = new List<Phase>();

        static LunarWorker()
        {
            double period = TotalLengthOfCycle / Names.Count;
            // divide the moon phases into equal parts with no gaps
            allPhases = Names
                .Select((t, i) => new Phase(t, period * i, period * (i + 1)))
                .ToList();
        }

        /// <summary>
        /// Calculates the current phase of the moon.
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <remarks>https://www.subsystems.us/uploads/9/8/9/4/98948044/moonphase.pdf</remarks>
        /// <returns></returns>
        public static string CalculateMoonPhase(DateTime utcDateTime,
            Earth.Hemispheres viewFromEarth = Earth.Hemispheres.Northern)
        {
            const double julianConstant = 2415018.5;
            double julianDate = utcDateTime.ToOADate() + julianConstant;

            // Based on Greenwich New Moon (1920)
            double daysSinceLastNewMoon =
                new DateTime(1920, 1, 21, 5, 25, 00, DateTimeKind.Utc).ToOADate() + julianConstant;

            double newMoons = (julianDate - daysSinceLastNewMoon) / TotalLengthOfCycle;
            double intoCycle = (newMoons - Math.Truncate(newMoons)) * TotalLengthOfCycle;

            Phase objPhase = allPhases.First(p => intoCycle >= p.Start && intoCycle <= p.End);

            int iIndex = Convert.ToInt32(allPhases.IndexOf(objPhase));

            string currentPhase =
                viewFromEarth switch
                {
                    Earth.Hemispheres.Northern => NorthernHemisphere[iIndex],
                    _ => SouthernHemisphere[iIndex]
                };

            return FormatResult(objPhase.Name, currentPhase, Math.Round(intoCycle, 2), viewFromEarth, utcDateTime);

        } //CalculateMoonPhase

        internal static string FormatResult(string name, string emoji, double daysIntoCycle, Earth.Hemispheres hemisphere, DateTime moment)
        {

            const int FullMoon = 15;
            const double halfCycle = TotalLengthOfCycle / 2;
            string sMoment = moment.ToString("D");

            double numerator = daysIntoCycle > FullMoon
                // past the full moon, we want to count down
                ? halfCycle - (daysIntoCycle % halfCycle)
                // leading up to the full moon
                : daysIntoCycle;

            double Visibility = numerator / halfCycle * 100;

            double percent = Math.Round(Visibility, 2);
            return $"The Moon for {sMoment} is {daysIntoCycle} days\n" +
                   $"into the cycle, and is showing as \"{name}\"\n" +
                   $"with {percent}% visibility, and a face of {emoji} from the {hemisphere.ToString().ToLowerInvariant()} hemisphere.";

        } //FormatResult

        public class Phase
        {
            public const string NewMoon = "New Moon";
            public const string WaxingCrescent = "Waxing Crescent";
            public const string FirstQuarter = "First Quarter";
            public const string WaxingGibbous = "Waxing Gibbous";
            public const string FullMoon = "Full Moon";
            public const string WaningGibbous = "Waning Gibbous";
            public const string ThirdQuarter = "Third Quarter";
            public const string WaningCrescent = "Waning Crescent";

            public Phase(string name, double start, double end)
            {
                Name = name;
                Start = start;
                End = end;
            }

            public string Name { get; }

            /// <summary>
            /// The days into the cycle this phase starts
            /// </summary>
            public double Start { get; }

            /// <summary>
            /// The days into the cycle this phase ends
            /// </summary>
            public double End { get; }
        } //class phase
    } //class moon

    public static class Earth
    {
        public enum Hemispheres
        {
            Northern,
            Southern
        }
    } //class earth
} //ns
