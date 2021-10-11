using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proto;

namespace MovieStreaming.Actors
{
    class PlaybackStatisticsActor : IActor
    {
        private PID _moviePlayCounterActorRef;
        public Task ReceiveAsync(IContext context)
        {
            switch (context.Message)
            {
                case Started msg:
                    var props = Props.FromProducer(() => new MoviePlayCounterActor());
                    _moviePlayCounterActorRef = context.Spawn(props);
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
