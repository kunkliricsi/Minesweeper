using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using Minesweeper.Model.Cells;

namespace Minesweeper.Controller
{
    public class BoardBuilder
    {
        private Type[,] _cells;
        private BoardInfo _boardInfo;

        public void SetBoardInfo(BoardInfo info)
        {
            _boardInfo = info;
            _cells = new Type[info.Rows, info.Columns];
        }

        public Board BuildBoard()
        {
            var board = new Board();

            for (int row = 0; row < _boardInfo.Rows; row++)
                for (int column = 0; column < _boardInfo.Columns; column++)
                {
                    _cells[row, column] = typeof(Number);
                }

            GenerateBombs();

            for (int row = 0; row < _boardInfo.Rows; row++)
                for (int column = 0; column < _boardInfo.Columns; column++)
                {
                }

            return board;
        }

        private void GenerateBombs()
        {
            var random = new Random();

            for (int i = 0; i < _boardInfo.Bombs; i++)
            {
                int row, column;
                do
                {
                    row = random.Next(_boardInfo.Rows);
                    column = random.Next(_boardInfo.Columns);

                } while (_cells[row, column] == typeof(Bomb));

                _cells[row, column] = typeof(Bomb);
            }
        }

        private void BuildCellsFromType()
        {
        }
    }
}
