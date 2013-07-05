using System;
using System.Collections.Generic;
using log4net;

namespace GitToSvn
{
    class Program
    {
        // do not use console logger!
        private static readonly ILog Logger = LogManager.GetLogger(typeof (Program));

        static int Main(string[] args)
        {
            try
            {
                var repositoryType = RepositoryTypeChecker.CheckRepositoryType();
                var vcsRunner = VcsRunnerFactory.NewVcsRunner(repositoryType, args);
                return Run(vcsRunner);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                return -1;
            }
        }

        private static int Run(IApplicationCaller runner)
        {
            var exitCode = runner.Run();
            Logger.InfoFormat("{0}: {1}", runner, exitCode);
            return exitCode;
        }
    }
}
