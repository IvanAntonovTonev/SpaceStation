namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double InitialUnitsOfOxygen = 90d;

        public Meteorologist(string name)
        : base(name, InitialUnitsOfOxygen)
        {

        }
    }
}