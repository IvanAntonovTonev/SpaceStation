using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string result = string.Empty;

                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string type = input[1];
                        string astronautName = input[2];

                        result = controller.AddAstronaut(type, astronautName);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];
                        string[] items = input.Skip(2).ToArray();

                        result = controller.AddPlanet(input[1], items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string astronautName = input[1];

                        result = controller.RetireAstronaut(astronautName);

                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        result = controller.ExplorePlanet(planetName);
                    }
                    else if(input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
