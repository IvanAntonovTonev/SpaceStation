using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    using Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using System.Linq;

    class Controller : IController
    {
        IRepository<IAstronaut> astronautRepository;
        IRepository<IPlanet> planetRepository;
        IMission mission;

        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astronautRepository.Add(astronaut);

            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName, items);
            planetRepository.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.Models.FirstOrDefault(a => a.Name == astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            this.astronautRepository.Remove(astronaut);

            return $"Astronaut {astronautName} was retired!";
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronautsWithOxygenAboveSixty = this.astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();

            IPlanet planet = planetRepository.Models.FirstOrDefault(p => p.Name == planetName);

          
            if (astronautsWithOxygenAboveSixty.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet!");
            }

            exploredPlanetsCount++;

            mission.Explore(planet, astronautsWithOxygenAboveSixty);

            int deadAstronauts = astronautsWithOxygenAboveSixty.Count(a => !a.CanBreath);

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{exploredPlanetsCount} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in this.astronautRepository.Models)
            {
                stringBuilder.AppendLine(astronaut.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
