using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using Minesweeper.Model.Cells;

namespace Minesweeper.Controller
{
    public class TableBuilder
    {
        private Type[,] _cells;
        private TableInfo _tableInfo;

        public void SetTableInfo(TableInfo info)
        {
            _tableInfo = info;
            _cells = new Type[info.Rows, info.Columns];
        }

        public Table BuildTable()
        {
            var table = new Table();

            for (int row = 0; row < _tableInfo.Rows; row++)
                for (int column = 0; column < _tableInfo.Columns; column++)
                {
                    _cells[row, column] = typeof(Number);
                }

            GenerateBombs();

            for (int row = 0; row < _tableInfo.Rows; row++)
                for (int column = 0; column < _tableInfo.Columns; column++)
                {
                    table
                }

            return table;
        }

        private void GenerateBombs()
        {
            var random = new Random();

            for (int i = 0; i < _tableInfo.Bombs; i++)
            {
                int row, column;
                do
                {
                    row = random.Next(_tableInfo.Rows);
                    column = random.Next(_tableInfo.Columns);

                } while (_cells[row, column] == typeof(Bomb));

                _cells[row, column] = typeof(Bomb);
            }
        }

        private void BuildCellsFromType()
        {
        }
    }
}
