using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper.Model
{
    public class Board : IEnumerable<KeyValuePair<(int, int),Cell>>
    {
        private Dictionary<(int, int), Cell> _cells;

        public IEnumerable<Cell> Cells
        {
            get
            {
                return _cells.Values.ToList();
            }
        }

        public Cell this[int row, int column]
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
            this._cells = new Dictionary<(int, int), Cell>();
        }

        public void AddCell((int row, int column) tuple, Cell cell)
        {
            _cells.Add(tuple, cell);
        }

        public IEnumerator<KeyValuePair<(int, int), Cell>> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
