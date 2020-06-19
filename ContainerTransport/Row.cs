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
        public bool IsLastRow { get; set; }

        public bool AddStack(Stack stack)
        {
            _stacks.Add(stack);
            return true;
        }

        public void BalanceRow()
        {
            
        }

        public bool IsRowBalanced()
        {
            var leftWeight = _stacks.GetRange(0, (int) Math.Floor((double) Length / 2)).Sum(stack => stack.Weight);
            var rightWeight = _stacks.GetRange((int) Math.Floor((double) Length / 2), Length).Sum(stack => stack.Weight);

            return Math.Abs(leftWeight - rightWeight) <= Weight * 0.2;
        }
    }
}