using System.Collections.Generic;
using System.Linq;

namespace GitToSvn
{
    public abstract class Arguments : IArguments
    {
        private readonly string _delimiter;
        private readonly List<string> _arguments;

        protected Arguments(IEnumerable<string> args, string delimiter = " ")
        {
            _delimiter = delimiter;
            _arguments = (args != null) ? new List<string>(args) : new List<string>();
        }

        protected abstract string Translate(string arg);

        public string ArgumentsAsString
        {
            get
            {
                return _arguments.Aggregate(string.Empty, (current, argument) => current + _delimiter + Translate(argument));
            }
        }

        public override string ToString()
        {
            return ArgumentsAsString;
        }
    }
}
