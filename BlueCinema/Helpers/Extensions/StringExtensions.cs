using System.Linq;

namespace BlueCinema.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizeString(this string _string, char delimiter)
        {
            if (_string.FirstOrDefault().Equals(delimiter))
            {
                _string = _string.Remove(0, 1);
            }

            if (_string.LastOrDefault().Equals(delimiter))
            {
                _string = _string.Remove(_string.Length - 1, 1);
            }

            return _string;
        }
    }
}
