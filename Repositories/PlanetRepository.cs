using System.Linq;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    using Contracts;
    using Models.Planets;

    class PlanetRepository : IRepository<IPlanet>
    {
        IList<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.ToList();

        public void Add(IPlanet model)
        {
            this.planets.Add(model);
        }

        public bool Remove(IPlanet model)
        {
            return this.planets.Remove(model);
        }

        public IPlanet FindByName(string name)
        {
            return this.planets.FirstOrDefault(p => p.Name == name);
        }      
    }
}