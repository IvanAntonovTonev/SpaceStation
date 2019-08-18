using System;

namespace SpaceStation.Models.Astronauts
{
    using Bags;
    using Contracts;
    using System.Text;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        protected double oxygen;

        private Astronaut()
        {
            this.Bag = new Backpack();
        }

        protected Astronaut(string name, double oxygen)
            : this()
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }

                this.oxygen = value;
            }
        }
        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; }

        public virtual void Breath()
        {
            this.oxygen -= 10;

            if (this.oxygen < 0)
            {
                this.oxygen = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Name: {this.Name}")
                .AppendLine($"Oxygen: {this.Oxygen}")
                .AppendLine($"Bag items: {(this.Bag.Items.Count > 0 ? string.Join(", ", this.Bag.Items) : "none")}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}