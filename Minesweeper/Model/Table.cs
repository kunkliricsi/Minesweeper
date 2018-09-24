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
        public TableInfo TableInfo { get; }
        public Dictionary<Button, ITableCell> CellButton { get; set; }
        public Dictionary<Point, ITableCell> Cells { get; set; }

        public ITableCell this[Button button]
        {
            get
            {
                return CellButton[button];
            }
        }

        public Table(TableInfo info = null)
        {
            if (info == null)
            {
                info = new TableInfo();
            }

            this.TableInfo = info;
        }

        public void Initialize()
        {
            if (TableInfo == null) throw new Exception("TableInfo is not set.");

            for (int rows = 0; rows < TableInfo.Rows; rows++)
                for (int columns = 0; columns < TableInfo.Columns; columns++)
                {

                }
        }
    }
}
