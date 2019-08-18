using System;
using System.Collections.Generic;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;

        protected Planet ()
        {
            this.Items = new List<string>();
        }

        public Planet(string name, params string[] items)
            :this()
        {
            this.Name = name;
            this.Items = items;
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
                    throw new ArgumentNullException("Invalid name!");
                }

                this.name = value;
            }
        }

        public ICollection<string> Items { get; }
    }
}