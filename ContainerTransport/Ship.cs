using System.Collections.Generic;
using System.Linq;

namespace ContainerTransport
{
    public class Ship
    {
        private readonly List<Row> _rows = new List<Row>();
        public IEnumerable<Row> Rows => _rows;

        public int Weight => _rows.Sum(row => row.Weight);

        public Ship(int width, int height)
        {
            for (var i = 0; i < height; i++)
            {
                _rows.Add(new Row {Length = width, IsFirstRow = i == 0});
            }
        }
    }
}