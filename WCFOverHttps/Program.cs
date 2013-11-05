using System.ServiceProcess;

namespace PlushHTTPS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] servicesToRun = new ServiceBase[] 
                                              { 
                                                  new PlushHttpsService() 
                                              };
            ServiceBase.Run(servicesToRun);
        }
    }
}
