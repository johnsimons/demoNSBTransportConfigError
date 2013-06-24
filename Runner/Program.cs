using System;
using System.Configuration;
using System.IO;
using ClassLibrary1;
using log4net.Config;

namespace Runner
{
    class Program
    {
        static void Main()
        {
            var log4NetConfig = ConfigurationManager.AppSettings["log4netConfig"];
            if (log4NetConfig != null && File.Exists(log4NetConfig))
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfig));
            }
            else
            {
                Console.Error.WriteLine("Could not find log4net");
            }

            new Class1().Amethod();

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
