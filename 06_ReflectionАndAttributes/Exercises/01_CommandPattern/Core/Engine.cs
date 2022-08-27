using CommandPattern.Core.Contracts;
using CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {  
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICommandInterpreter commandInterpreter;
        
        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;

            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string cmdArgs = this.reader.ReadLine();
                    
                    string result = this.commandInterpreter.Read(cmdArgs);
                    
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
