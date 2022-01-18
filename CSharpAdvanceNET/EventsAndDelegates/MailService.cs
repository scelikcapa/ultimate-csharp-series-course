using System;

namespace CSharpAdvanceNET.EventsAndDelegates
{
    public class MailService
    {
        // this method have to have same signature with Delegate in VideoEncoder class
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending an email... "+ e.Video.Title);
        }
    }
}