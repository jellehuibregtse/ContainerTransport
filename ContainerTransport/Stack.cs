using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerTransport
{
    public class Stack
    {
        private readonly List<Container> _containers = new List<Container>();
        public IEnumerable<Container> Containers => _containers;

        public int Length => _containers.Count;
        public int Weight => _containers.Sum(container => container.Weight);

        public bool IsFirstRow { get; set; }

        private bool IsValuableInStack => _containers.Any(container =>
            container.Type == ContainerType.Valuable || container.Type == ContainerType.CooledValuable);

        public bool AddContainer(Container container)
        {
            if (!IsFirstRow &&
                (container.Type == ContainerType.Cooled || container.Type == ContainerType.CooledValuable))
                return false;

            if (IsValuableInStack && (container.Type == ContainerType.Valuable ||
                                      container.Type == ContainerType.CooledValuable)) return false;

            SortStack(_containers);
            return true;
        }

        private bool TooMuchWeight(Container referenceContainer)
        {
            var tempList = _containers;
            tempList.Add(referenceContainer);
            SortStack(tempList);

            foreach (var container in tempList)
            {
                var index = tempList.FindIndex(c => c == container);
                var weightOnContainer = tempList.Where(c => tempList.FindIndex(i => i == container) > index)
                    .Sum(c => container.Weight);

                if (weightOnContainer > Container.MaxWeightOnTop)
                    return false;
            }

            return true;
        }

        public static void SortStack(List<Container> containers)
        {
            var valuable = containers.Find(container =>
                container.Type == ContainerType.Valuable || container.Type == ContainerType.CooledValuable);

            var tempList = containers;
            tempList.Remove(valuable);
            
            containers.Clear();

            foreach (var container in containers)
                containers.Remove(container);

            var sortedTempList = tempList.OrderByDescending(container => container.Weight).ToList();
            sortedTempList.Add(valuable);

            containers.AddRange(sortedTempList);
        }
    }
}