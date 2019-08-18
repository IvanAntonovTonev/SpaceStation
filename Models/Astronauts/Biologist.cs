namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialUnitsOfOxygen = 70d;

        public Biologist(string name)
        : base(name, InitialUnitsOfOxygen)
        {

        }

        public override void Breath()
        {
            this.oxygen -= 5;

            if (this.oxygen < 0)
            {
                this.oxygen = 0;
            }
        }
    }
}