using System;
using System.Threading;

namespace CSharpAdvanceNET.EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // 1- Define a delegate
        // 2- Define an event based on that delegate
        // 3- Create an event publisher method and Raise the event

        // 1.a
        // public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        // 1.b create new VideoEventArgs if you needed 
        // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        // 1.c dont have to create your own delegate, can use generic types below :) so pass above 

        // 2.a
        // public event VideoEncodedEventHandler VideoEncoded; // if event is started, use -ing 
        // 2.b can use generic class
        // EventHandler
        // EventHandler<TEventArgs>
        // public event EventHandler VideoEncoding;
        public event EventHandler<VideoEventArgs> VideoEncoded; 

        // 3.
        // Event publisher methods should be protected / virtual / void
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                // VideoEncoded(this, EventArgs.Empty);
                VideoEncoded(this, new VideoEventArgs() {Video = video});
            }
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }


    }
}