using System;
using System.Collections.Generic;
using CSharpAdvanceNET.EventsAndDelegates;

namespace CSharpAdvanceNET.ExceptionHandling
{
    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // Access YouTube web service
                // Read tha data
                // Create a list of Video objects

                // lets create an exception manually 
                throw new Exception("Oops some low level Youtube error");
            }
            catch (Exception ex)
            {
                // Log

                throw new YouTubeException("Could not fetch the videos from Youtube", ex);
            }

            return new List<Video>();
        }
    }
}