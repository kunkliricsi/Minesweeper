using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Model
{
    public class Table
    {
        private Dictionary<Tuple<Button, Point>, ITableCell> _cells;

        public ITableCell this[Button button]
        {
            get
            {
                ITableCell toReturn = null;

                foreach (var cell in _cells)
                {
                    if (cell.Key.Item1 == button) toReturn = cell.Value;
                }

                return toReturn ?? throw new KeyNotFoundException($"No cell exists for the given {button} parameter.");
            }
            set
            {
                this[button] = value;
            }
        }

        public ITableCell this[Point p]
        {
            get { return _cells[p]; }
            set { _cells[p] = value; }
        }

        public Table()
        {
            this._cells = new Dictionary<Tuple<Button, Point>, ITableCell>();
        }
    }
}
