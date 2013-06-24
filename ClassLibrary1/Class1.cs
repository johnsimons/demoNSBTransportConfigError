namespace ClassLibrary1
{
    using System;
    using NServiceBus;

    public class Class1
    {
        private IBus bus;

        public Class1()
        {
            Configure.Serialization.Binary();

            //setup nservicebus
            bus = Configure.With()
                           .DefaultBuilder()
                           .UseTransport<Msmq>()
                           .UnicastBus()
                           .SendOnly();


            bus.Send("SendOnlyDestination@someserver", new TestMessage());

            Console.WriteLine("Message sent");

        }

        public void Amethod()
        {
            // might try to send here
            //bus.Send(new TPIMessages.UnpackingFailure(Guid.NewGuid()));
        }
    }

    [Serializable]
    public class TestMessage : IMessage
    {
    }
}
