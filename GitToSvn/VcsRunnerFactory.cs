using System;

namespace GitToSvn
{
    public static class VcsRunnerFactory
    {
        public static IApplicationCaller NewVcsRunner(RepositoryTypeChecker.RepositoryType repositoryType, string[] args)
        {
            switch (repositoryType)
            {
                case RepositoryTypeChecker.RepositoryType.Svn:
                    return new VcsRunner(GitToSvnConfiguration.SvnBinary, new SvnArguments(args).ArgumentsAsString);
                case RepositoryTypeChecker.RepositoryType.Git:
                    return new VcsRunner(GitToSvnConfiguration.GitBinary, new GitArguments(args).ArgumentsAsString);
                default:
                    throw new NotImplementedException(string.Format("Vcs of {0} type is not supported yet", repositoryType));
            }
        }
    }
}