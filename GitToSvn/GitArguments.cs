using System;
using System.Collections.Generic;

namespace GitToSvn
{
    public class GitArguments : Arguments
    {
        public GitArguments(IEnumerable<string> args, string delimiter = " ")
            : base(args, delimiter)
        {}

        protected override string Translate(string arg)
        {
            return SvnToGitCommandTranslator.GetGitCommand(arg);
        }
    }
}
