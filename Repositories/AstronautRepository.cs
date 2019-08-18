using System.Linq;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private IList<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.astronauts.ToList();


        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
        }

        public IAstronaut FindByName(string name)
        {
            return this.astronauts.FirstOrDefault(a => a.Name == name);
        } 
    }
}