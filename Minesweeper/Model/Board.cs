using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Model
{
    public class Board
    {
        private Dictionary<(int, int), IBoardCell> _cells;

        public IEnumerable<IBoardCell> Cells
        {
            get
            {
                return _cells.Values.ToList();
            }
        }

        public IBoardCell this[Button button]
        {
            get
            {
                foreach (var cell in _cells)
                {
                    if (cell.Value.Button == button) return cell.Value;
                }

                throw new KeyNotFoundException($"No cell exists for the given {button} parameter.");
            }
            set
            {
                this[button] = value;
            }
        }

        public IBoardCell this[int row, int column]
        {
            get
            {
                foreach (var cell in _cells)
                {
                    if (cell.Key.Item1 == row && cell.Key.Item2 == column) return cell.Value;
                }

                throw new KeyNotFoundException($"No cell exists for the given row: {row}, column: {column} parameters");
            }
            set
            {
                this[row, column] = value;
            }
        }

        public Board()
        {
            this._cells = new Dictionary<(int, int), IBoardCell>();
        }
    }
}
