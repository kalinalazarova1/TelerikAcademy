using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Program
    {
        static Engine GetEngineInstance()
        {
            return new EnhancedEngine();
        }

        static void Main(string[] args)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"../../test004.txt"))
            {
                Engine engine = GetEngineInstance();

                string command = reader.ReadLine();
                while (command != "end")
                {
                    engine.ExecuteCommand(command);
                    command = reader.ReadLine();
                }
            }
        }
    }
}
