using System;

namespace ContainerTransport
{
    public class Container
    {
        public static int MaxWeightOnTop = 120000;
        private const int MaxWeight = 30000;
        private const int EmptyWeight = 4000;

        private int _weight;

        public int Weight
        {
            get => _weight;
            set
            {
                if (value <= MaxWeight && value >= EmptyWeight) _weight = value;
            }
        }

        public ContainerType Type { get; set; }

        public Container(int weight, ContainerType type)
        {
            Weight = weight;
            Type = type;
        }
    }
}