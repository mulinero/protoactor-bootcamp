using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using MovieStreaming.Actors;
using MovieStreaming.Messages;
using Proto;

namespace MovieStreaming
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new ActorSystem();
            Console.WriteLine("Actor system created");

            var props = Props.FromProducer(() => new UserActor());
            var pid = system.Root.Spawn(props);

            Console.ReadKey();
            Console.WriteLine("sending PlayMovieMessage (The Movie)");
            system.Root.Send(pid, new PlayMovieMessage("The Movie", 44));
            
            Console.ReadKey();
            Console.WriteLine("sending PlayMovieMessage (The Movie 2)");
            system.Root.Send(pid, new PlayMovieMessage("The Movie 2", 54));
            
            Console.ReadKey();
            Console.WriteLine("sending StopMovieMessage");
            system.Root.Send(pid, new StopMovieMessage());
            
            Console.ReadKey();
            Console.WriteLine("sending another StopMovieMessage");
            system.Root.Send(pid, new StopMovieMessage());


            Console.ReadLine();
        }

    }
}
