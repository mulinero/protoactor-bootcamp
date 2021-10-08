using System;
using System.Collections.Generic;
using System.Text;
using Proto;

namespace MovieStreaming.Messages
{
    class ResponseActorPidMessage
    {
        public PID Pid { get; }
        public string ActorName { get; }


        public ResponseActorPidMessage(string actorName, PID pid)
        {
            ActorName = actorName;
            Pid = pid;
        }
    }
}
