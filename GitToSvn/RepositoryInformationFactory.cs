using System;

namespace GitToSvn
{
    public static class RepositoryInformationFactory
    {
        public static IApplicationCaller NewRepositoryInformation(RepositoryTypeChecker.RepositoryType repositoryType)
        {
            switch (repositoryType)
            {
                case RepositoryTypeChecker.RepositoryType.Svn:
                    return new RepositoryInformation(GitToSvnConfiguration.SvnBinary, GitToSvnConfiguration.SvnInfoArgument);
                case RepositoryTypeChecker.RepositoryType.Git:
                    return new RepositoryInformation(GitToSvnConfiguration.GitBinary, GitToSvnConfiguration.GitSvnInfoArgument);
                default:
                    throw new NotImplementedException(string.Format("Checking repository of type {0} is not supported yet", repositoryType));
            }
        }
    }
}