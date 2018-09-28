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
        private Dictionary<(int row, int column), Cell> _cells;

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
                return _cells.Where(c => (c.Key.row.Equals(row) && c.Key.column.Equals(column)))
                    .Select(c => c.Value)
                    .SingleOrDefault() ?? throw new KeyNotFoundException($"No cell exists for the given row: {row}, column: {column} parameters");
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
