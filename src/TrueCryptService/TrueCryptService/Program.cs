using System.ServiceProcess;

namespace TrueCrypt.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new TrueCryptService(),  
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
