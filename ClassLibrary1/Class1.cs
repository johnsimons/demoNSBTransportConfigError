using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using log4net;

namespace ClassLibrary1
{
    public class Class1
    {
        readonly ILog _log = LogManager.GetLogger(typeof(Class1));
       private IBus bus;
       public Class1()
       {
           //setup nservicebus
           bus = Configure.With().DefineEndpointName("ASender")
                          //.DefiningCommandsAs(t => "TPIMessages".Equals(t.Namespace))
                          //.DefiningEventsAs(t=>"TPIMessages".Equals(t.Namespace))
                          .DefaultBuilder()
                          .UseTransport<Msmq>()
               //.JsonSerializer()
                          .BinarySerializer()
                          .UnicastBus()//.CreateBus().Start();
           .SendOnly();
       }

        public void Amethod()
        {
            // might try to send here
            //bus.Send(new TPIMessages.UnpackingFailure(Guid.NewGuid()));
        }
    }
}
