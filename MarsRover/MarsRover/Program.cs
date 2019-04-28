using Autofac;
using MarsRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MarsRover
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var instructions = new StringBuilder();
            instructions.AppendLine("5 5");
            instructions.AppendLine("1 2 N");
            instructions.AppendLine("LMLMLMLMM");
            instructions.AppendLine("3 3 E");
            instructions.Append("MMRMMRMRRM");

            var instructionLines = instructions.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            Console.WriteLine("\nTest Inputs \n------------------------------");

            foreach (var instructionLine in instructionLines)
            {
                Console.WriteLine(instructionLine);
            }

            Console.WriteLine("\nTest Outputs \n------------------------------");

            var programAssembly = Assembly.GetExecutingAssembly();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(programAssembly).AsImplementedInterfaces();

            using (var container = builder.Build())
            {

                var commandGenerator = container.Resolve<ICommandGenerator>();
                var invoker = container.Resolve<IInvoker>();
                var plateau = container.Resolve<IPlateau>();

                invoker.InitializePlateau(plateau);
                invoker.InitializeRovers(new List<IRover>());

                var commands = commandGenerator.Parse(instructions.ToString());
                invoker.SetCommands(commands);
                invoker.InvokeCommands();

                var instructionResults = invoker.GetLatestRoverLocations();

                foreach (var instructionResult in instructionResults)
                {
                    Console.WriteLine(instructionResult);
                }
              
            }

            Console.ReadKey();
        }
    }
}