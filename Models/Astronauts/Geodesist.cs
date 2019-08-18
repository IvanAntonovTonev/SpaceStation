namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double InitialUnitsOfOxygen = 50d;

        public Geodesist(string name)
        : base(name, InitialUnitsOfOxygen)
        {

        }
    }
}
