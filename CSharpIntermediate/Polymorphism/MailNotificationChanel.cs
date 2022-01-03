using System;

namespace CSharpIntermediate.Polymorphism
{
    public class MailNotificationChanel:INotificationChannel
    {
        public void Send(Message message)
        {
            Console.WriteLine("Sending mail...");
        }
    }
}