using System;
using System.Linq;
using log4net;

namespace GitToSvn
{
    public static class RepositoryTypeChecker
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(RepositoryTypeChecker));

        public enum RepositoryType
        {
            Svn,
            Git
        }

        public static RepositoryType CheckRepositoryType()
        {
            var repositoryTypes = Enum.GetValues(typeof(RepositoryType)).Cast<RepositoryType>().ToList();

            foreach (var repositoryType in repositoryTypes)
            {
                Logger.DebugFormat("Checking if it's {0} repository", repositoryType);
                var repositoryInformation = RepositoryInformationFactory.NewRepositoryInformation(repositoryType);
                var exitCode = repositoryInformation.Run();
                Logger.InfoFormat("{0}: {1}", repositoryInformation, exitCode);
                if (exitCode == 0)
                {
                    Logger.InfoFormat("Great Success! ;-) It's {0} repository", repositoryType);
                    return repositoryType;
                }
            }
            throw new Exception(string.Format("Working directory is not under suported vcs ({0})", repositoryTypes.AsString()));
        }
    }
}