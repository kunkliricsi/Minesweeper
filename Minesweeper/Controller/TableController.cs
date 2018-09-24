using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using Minesweeper.Model.Cells;
using System.Windows.Controls;
using System.Windows;

namespace Minesweeper.Controller
{
    public class TableController
    {
        private Table Table { get; set; }

        public void CreateTable(int rows = 5, int columns = 5, int bombs = 5)
        {
            var info = new TableInfo(rows, columns, bombs);

            var builder = new TableBuilder();
            builder.SetTableInfo(info);
            builder.BuildTable();
        }

        public void ButtonClicked(Button button)
        {
            Table[button].Reveal();
        }
    }
}
