using System.Collections;
using System.Text;

namespace GitToSvn
{
    public static class Collections
    {
        public static string AsString(this IEnumerable collection, string delimiter = ", ")
        {
            var text = new StringBuilder();
            foreach (var item in collection)
            {
                text.AppendFormat("{0}{1}", item, delimiter);
            }
            var textLength = text.Length;
            return text.ToString(0, textLength - (textLength == 0 ? 0 : delimiter.Length));
        }
    }
}
