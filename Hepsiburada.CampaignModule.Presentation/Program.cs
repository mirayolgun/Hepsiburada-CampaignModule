using Hepsiburada.CampaignModule.Application;
using System;

namespace Hepsiburada.CampaignModule.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {

            DependencyLoader dependencyLoader = new DependencyLoader();
            var provider = dependencyLoader.Init();
            var commandParser = (ICommand)provider.GetService(typeof(ICommand));

            make:

            var keys = Read();

            commandParser.Execute(keys.command, keys.arguments);

            goto make;
        }

        public static (string command, string[] arguments) Read()
        {
            var input = Console.ReadLine().Split(' ');

            return (input[0], input[1..]);
        }
    }
}
