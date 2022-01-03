using System.Collections.Generic;

namespace CSharpIntermediate.Polymorphism
{
    public class VideoEncoder
    {
        // private readonly MailService _mailService;;

        //public VideoEncoder()
        //{
        //    _mailService = new MailService();
        //}

        //public void Encode(Video video)
        //{
        //    // Video encoding logic...

        //    _mailService.Send(new Mail());
        //}

        private readonly IList<INotificationChannel> _notificationChannels;

        public VideoEncoder()
        {
            _notificationChannels = new List<INotificationChannel>();
        }

        public void Encode(Video video)
        {
            // Video encoding logic...

            foreach (var channel in _notificationChannels)
            {
                channel.Send(new Message());
            }
        }

        public void RegisterNotificationChannel(INotificationChannel channel)
        {
            _notificationChannels.Add(channel);
        }
    }
}