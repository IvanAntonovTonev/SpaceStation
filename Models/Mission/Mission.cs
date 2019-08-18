using System.Collections.Generic;

namespace SpaceStation.Models.Mission
{
    using Planets;
    using Astronauts.Contracts;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> items = planet.Items.ToList();
            foreach (IAstronaut astronaut in astronauts)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);

                    items.RemoveAt(i);
                    i--;
                }  
            }
        }
    }
}