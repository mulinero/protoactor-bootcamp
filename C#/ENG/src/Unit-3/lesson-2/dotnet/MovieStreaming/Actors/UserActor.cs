using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieStreaming.Actors;
using MovieStreaming.Messages;
using Proto;

namespace MovieStreaming.Actors
{
    class UserActor : IActor
    {
        private readonly Behavior _behavior;
        private string _currentlyWatching;
        public UserActor()
        {
            Console.WriteLine("creating a UserActor");
            ColorConsole.WriteLineCyan("setting initial behavior to stopped");
            _behavior = new Behavior(Stopped);

        }

        public Task ReceiveAsync(IContext context) => _behavior.ReceiveAsync(context);

        private Task Stopped(IContext context)
        {
            switch (context.Message)
            {
                case PlayMovieMessage msg:
                    _currentlyWatching = msg.MovieTitle;
                    ColorConsole.WriteLineYellow($"User is currently watching '{_currentlyWatching}'");
                    _behavior.Become(Playing);
                    break;
                
                case StopMovieMessage msg:
                    ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing");
                    _currentlyWatching = null;
                    break;
            }
            ColorConsole.WriteLineCyan("UserActor has now become STOPPED");
            return Task.CompletedTask;
        }

        private Task Playing(IContext context)
        {
            switch (context.Message)
            {
                case PlayMovieMessage msg:
                    ColorConsole.WriteLineRed("Error: cannot start playing another movie before stopping existing one");
                    break;
                case StopMovieMessage msg:
                    ColorConsole.WriteLineYellow($"User has stopped watching '{_currentlyWatching}'");
                    _currentlyWatching = null;
                    _behavior.Become(Stopped);
                    break;

            }
            ColorConsole.WriteLineCyan("UserActor has now become PLAYING");
            return Task.CompletedTask;
        }
    }
}
