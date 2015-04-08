using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wiercholki
{

    /// <summary>
    /// class for handling proper vertex names
    /// </summary>
    static class Alphabet
    {
        public static string GetNextBase26(string a)
        {
            return Base26Sequence().SkipWhile(x => x != a).Skip(1).First();
        }

        public static IEnumerable<string> Base26Sequence()
        {
            long i = 0L;
            while (true)
                yield return Base26Encode(i++);
        }

        private static char[] base26Chars = "abcdefghijklmnopqrstuvwxyz".ToUpper().ToCharArray();
        public static string Base26Encode(Int64 value)
        {
            string returnValue = null;
            do
            {
                returnValue = base26Chars[value % 26] + returnValue;
                value /= 26;
            } while (value-- != 0);
            return returnValue;
        }
    }
}
