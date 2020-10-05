using System.Collections.Generic;
using System.Linq;

namespace MyLib
{
    public static class EnumerableExtension
    {
        public static IEnumerable<string> FindStr(this IEnumerable<string> collection, string strToFind)
        {
            var result = collection.Where(str => str.Contains(strToFind));

            return result;
        }
    }
}