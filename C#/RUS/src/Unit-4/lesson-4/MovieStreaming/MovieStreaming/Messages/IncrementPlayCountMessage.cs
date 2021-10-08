using System;
using System.Collections.Generic;
using System.Text;
using Proto;

namespace MovieStreaming.Messages
{
    class IncrementPlayCountMessage
    {
        public string MovieTitle { get; }

        public IncrementPlayCountMessage(string movieTitle)
        {
            MovieTitle = movieTitle;
        }
    }
}
