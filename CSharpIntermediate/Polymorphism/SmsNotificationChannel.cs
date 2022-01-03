using System;

namespace CSharpIntermediate.Polymorphism
{
    public class SmsNotificationChannel:INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending sms...");
        }
    }
}