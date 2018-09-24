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

        public TableInfo(int rows = 5, int columns = 5, int bombs = 5)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.Bombs = bombs;
        }
    }
}
