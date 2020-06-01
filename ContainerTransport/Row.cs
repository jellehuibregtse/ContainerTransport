using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerTransport
{
    public class Row
    {
        private readonly List<Stack> _stacks = new List<Stack>();
        public IEnumerable<Stack> Stacks => _stacks;
        public int Weight => _stacks.Sum(stack => stack.Weight);

        public int Length { get; set; }
        public bool IsFirstRow { get; set; }

        public bool AddStack(Stack stack)
        {
            throw new NotImplementedException();
        }
    }
}