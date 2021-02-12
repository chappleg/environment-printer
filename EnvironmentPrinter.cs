using CommandLine;
using Gapotchenko.FX.Diagnostics;
using System;
using System.Collections;
using System.Diagnostics;

namespace EnvironmentPrinter
{
    public class Args
    {
        [Value(index: 0, Required = true, HelpText = "Process to lookup env vars for")]
        public string ProcessName { get; set; }

        [Option(shortName: 'n', longName: "process-number", Required = false, HelpText = "If multiple processes with same name exist use this to specify which one", Default = 0)]
        public int ProcessNumber { get; set; }

        [Option(shortName: 'v', longName: "environment-variable", Required = false, HelpText = "Optionally specify a single environment variable to print", Default = "")]
        public string VariableName { get; set; }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Args>(args).WithParsed<Args>(a => Run(a));
        }
        private static void Run(Args args)
        {
            var procs = Process.GetProcessesByName(args.ProcessName);

            var env = procs[args.ProcessNumber].ReadEnvironmentVariables();

            if (args.VariableName == "")
            {
                foreach (DictionaryEntry envVar in env)
                {
                    Console.WriteLine($"{envVar.Key}: {envVar.Value}");
                }
            }
            else
            {
                Console.WriteLine($"{args.VariableName}: {env[args.VariableName]}");
            }
        }
    }
}
