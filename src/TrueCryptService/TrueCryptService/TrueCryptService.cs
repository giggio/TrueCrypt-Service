using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace TrueCrypt.Service
{
    partial class TrueCryptService : ServiceBase
    {
        public TrueCryptService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var process = GetTrueCryptProcess();
            const string arguments = "/q preferences /a logon /a favorites";
            process.StartInfo.Arguments = arguments;
            process.Start();
        }

        private Process GetTrueCryptProcess()
        {
            var executable = Path.Combine(Environment.ExpandEnvironmentVariables(@"%systemdrive%\Program Files\"), "TrueCrypt", "TrueCrypt.exe");                
            if (!File.Exists(executable))
                throw new FileNotFoundException("Can't find TrueCrypt executable.", executable);
            var process = new Process {StartInfo = new ProcessStartInfo(executable)};
            return process;
        }

        protected override void OnStop()
        {
            var process = GetTrueCryptProcess();
            const string arguments = "/q /d /f";
            process.StartInfo.Arguments = arguments;
            process.Start();
            process.WaitForExit(3000);
        }
    }
}
