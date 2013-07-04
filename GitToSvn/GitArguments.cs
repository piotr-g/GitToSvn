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
            var originalCommand = arg.Trim().ToLowerInvariant();
            var command = CommandMappings.Default.Properties[originalCommand];
            if (command == null)
            {
                throw new Exception("Command {0} is not supported in this repository");
            }
            return command.DefaultValue.ToString();
        }
    }
}
