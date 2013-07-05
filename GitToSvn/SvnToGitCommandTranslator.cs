namespace GitToSvn
{
    public static class SvnToGitCommandTranslator
    {
        public static string GetGitCommand(string svnCommand)
        {
            var command = svnCommand.Trim().ToLowerInvariant();
            var gitCommand = CommandMappings.Default.Properties[command];
            return gitCommand == null ? svnCommand : gitCommand.DefaultValue.ToString();
        }
    }
}