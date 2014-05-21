using System.Collections.Generic;
using MbUnit.Framework;

namespace ProtoTest.Nightshade
{
    public class SuiteRepeater
    {
        [Factory("GetNumRepetitions")]
        public static int SuiteRepetitions;

        public static IEnumerable<int> GetNumRepetitions()
        {
            var num = int.Parse(Config.GetConfigValue("SuiteRepetitions", "1"));
            for (var i = 1; i <= num; i++)
            {
                yield return i;
            }
        }
    }
}
