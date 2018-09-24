using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public class TableInfo
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Bombs { get; set; }

        public TableInfo(int rows, int columns, int bombs)
        {
            if (rows < 1 || columns < 1) throw new ArgumentException($"Board must have at least 1 row and 1 column. Current values = {{ rows: {rows}, columns: {columns} }}");
            if (bombs > rows * columns) throw new ArgumentException("Too many bombs");

            this.Rows = rows;
            this.Columns = columns;
            this.Bombs = bombs;
        }
    }
}
