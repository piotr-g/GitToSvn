using System;
using System.Runtime.InteropServices;

namespace GitToSvn
{
    public class VcsRunner : IApplicationCaller
    {
        [DllImport("msvcrt.dll")]
        static extern bool system(string str);

        private readonly string _command;

        public VcsRunner(string application, string arguments)
        {
            _command = string.Format("\"{0}\" {1}", application, arguments);
        }

        public int Run()
        {
            system(_command);
            return Environment.ExitCode;
        }

        public override string ToString()
        {
            return _command;
        }
    }
}