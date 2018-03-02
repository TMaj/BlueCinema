using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Helpers
{
    public static class ConversionHelper
    {
        public static IList<int> ParseDelimitedStringToInts(string delimiter, string _string)
        {
            _string.TrimStart(':');
            _string.TrimEnd(':');
            return _string.Split(delimiter).Select(x => Int32.Parse(x)).ToList();
        }

        public static IList<int> ParseDelimitedStringsToInts(string delimiter, List<string> strings)
        {
            var _string = string.Empty;
            strings.ForEach(s => { _string += s;  _string += delimiter; });
            _string.TrimStart(':');
            _string.TrimEnd(':');
            return _string.Split(delimiter).Select(x => Int32.Parse(x)).ToList();
        }
    }
}
