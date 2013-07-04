using System.Configuration;

namespace GitToSvn
{
    public static class GitToSvnConfiguration
    {
        public static string SvnBinary
        {
            get { return ConfigurationManager.AppSettings["SvnBinary"]; }
        }

        public static string GitBinary
        {
            get { return ConfigurationManager.AppSettings["GitBinary"]; }
        }

        public static string SvnInfoArgument
        {
            get { return ConfigurationManager.AppSettings["SvnInfoArgument"]; }
        }

        public static string GitSvnInfoArgument
        {
            get { return ConfigurationManager.AppSettings["GitSvnInfoArgument"]; }
        }
    }
}