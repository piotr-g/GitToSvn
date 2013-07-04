using System.Diagnostics;

namespace GitToSvn
{
    public class RepositoryInformation : IApplicationCaller
    {
        //private const int ProcessTimeout = 10000;
        //private const int TimeoutExitCode = -1;

        private readonly ProcessStartInfo _processStartInfo;
        
        public RepositoryInformation(string vcsApplication, string vcsApplicationArguments)
        {
            _processStartInfo = new ProcessStartInfo();
            ProcessStartInfo.FileName = vcsApplication;
            ProcessStartInfo.RedirectStandardOutput = true;
            ProcessStartInfo.RedirectStandardError = true;
            ProcessStartInfo.UseShellExecute = false;
            ProcessStartInfo.Arguments = vcsApplicationArguments;
        }

        public virtual int Run()
        {
            var process = new Process {StartInfo = ProcessStartInfo};
            process.Start();
            // TODO redirect error stream
            Output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return process.ExitCode;
            //if (process.WaitForExit(ProcessTimeout))
            //{
            //    return process.ExitCode;                
            //}
            //return TimeoutExitCode;
        }

        public string Output { get; protected set; }

        public ProcessStartInfo ProcessStartInfo
        {
            get { return _processStartInfo; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", ProcessStartInfo.FileName, ProcessStartInfo.Arguments);
        }
    }
}