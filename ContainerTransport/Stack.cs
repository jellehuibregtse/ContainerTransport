using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerTransport
{
    public class Stack
    {
        private const int MaxWeight = 150000;

        private readonly List<Container> _containers = new List<Container>();
        public IEnumerable<Container> Containers => _containers;

        public int Length => _containers.Count;
        public int Weight => _containers.Sum(container => container.Weight);

        public bool IsFirstRow { get; set; }

        public bool IsLastRow { get; set; }

        private bool IsValuableInStack => _containers.Any(container =>
            container.Type == ContainerType.Valuable || container.Type == ContainerType.CooledValuable);

        public bool AddContainer(Container container)
        {
            return container.Type switch
            {
                ContainerType.Normal => AddNormalContainer(container),
                ContainerType.Cooled => AddCooledContainer(container),
                ContainerType.Valuable => AddValuableContainer(container),
                ContainerType.CooledValuable => AddCooledValuableContainer(container),
                _ => false
            };
        }

        public void SortStack()
        {
            var valuable = _containers.FirstOrDefault(container =>
                container.Type == ContainerType.Valuable || container.Type == ContainerType.CooledValuable);

            _containers.Remove(valuable);
            _containers.OrderByDescending(container => container.Weight);
            _containers.Add(valuable);
        }

        private bool AddNormalContainer(Container container)
        {
            if (TooHeavy(container)) return false;
            
            _containers.Add(container);
            return true;
        }

        private bool AddCooledContainer(Container container)
        {
            if (TooHeavy(container)) return false;

            if (!IsFirstRow) return false;
            
            _containers.Add(container);
            return true;
        }

        private bool AddValuableContainer(Container container)
        {
            if (TooHeavy(container)) return false;

            if (IsValuableInStack) return false;

            if (!IsFirstRow && !IsLastRow) return false;

            _containers.Add(container);
            return true;        }

        private bool AddCooledValuableContainer(Container container)
        {
            if (TooHeavy(container)) return false;

            if (IsValuableInStack) return false;

            if (!IsFirstRow && !IsLastRow) return false;

            _containers.Add(container);
            return true;        }

        private bool TooHeavy(Container container)
        {
            return Weight + container.Weight > MaxWeight;
        }
    }
}