using System.Collections.Generic;

namespace GitToSvn
{
    public class SvnArguments : Arguments
    {
        public SvnArguments(IEnumerable<string> args, string delimiter = " ") : base(args, delimiter)
        {}

        protected override string Translate(string arg)
        {
            return arg;
        }
    }
}