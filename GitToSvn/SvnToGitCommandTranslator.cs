using System;

namespace GitToSvn
{
    public static class SvnToGitCommandTranslator
    {
        public static string GetGitCommand(string svnCommand)
        {
            var command = svnCommand.Trim().ToLowerInvariant();
            var gitCommand = CommandMappings.Default.Properties[command];
            if (gitCommand == null)
            {
                throw new NotImplementedException(string.Format("git-svn command not implemented for '{0}'", svnCommand));
            }
            return gitCommand.DefaultValue.ToString();
        }
    }
}