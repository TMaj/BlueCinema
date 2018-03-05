using BlueCinema.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Helpers
{
    public static class ConversionHelper
    {
        public static IList<int> ParseDelimitedStringToInts(char delimiter, string _string)
        {
            _string = _string.NormalizeString(delimiter);
            return _string.Split(delimiter).Select(x => Int32.Parse(x)).ToList();
        }

        public static IList<int> ParseDelimitedStringsToInts(char delimiter, List<string> strings)
        {
            var _string = string.Empty;
            strings.ForEach(s => { _string += s; _string += delimiter; });
            _string = _string.NormalizeString(delimiter);
            return _string.Split(delimiter).Select(x => Int32.Parse(x)).ToList();
        }

    }
}
