﻿using BlueCinema.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Helpers
{
    public static class ConversionHelper
    {
        public static IList<int> ParseDelimitedStringToInts(char delimiter, string _string)
        {
            if (_string.Equals(string.Empty))
            {
                return new List<int>();
            }

            _string = _string.NormalizeString(delimiter);
            return _string.Split(delimiter).Select(x => Int32.Parse(x)).ToList();
        }

        public static IList<int> ParseDelimitedStringsToInts(char delimiter, List<string> strings)
        {
            if (strings.Count == 0 || strings == null)
            {
                return new List<int>();
            }

            var _string = string.Empty;
            strings.ForEach(s => { _string += s; _string += delimiter; });
            _string = _string.NormalizeString(delimiter);
            return _string.Split(delimiter).Select(x => Int32.Parse(x)).ToList();
        }

        public static string ParseIntsToDelimitedString(char delimiter, IList<int> ints)
        {
            var _string = string.Empty;

            if (ints.Count == 0 || ints == null)
            {
                return _string;
            }

            foreach (var integer in ints)
            {
                _string = _string + integer.ToString() + delimiter; 
            }

            _string = _string.NormalizeString(delimiter);

            return _string;
        }

    }
}
