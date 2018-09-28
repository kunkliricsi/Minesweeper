using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;

namespace Minesweeper.Controller
{
    public class BoardBuilder
    {
        public Board BuildBoard(BoardInfo info)
        {
            var _board = new Board();

            _board.InitializeBoard(info);

            _board.GenerateBombs(info);

            _board.SetNeighbors(info);

            return _board;
        }
    }

    internal static class BoardExtensions
    {
        public static void InitializeBoard(this Board board, BoardInfo info)
        {
            for (int row = 0; row < info.Rows; row++)
                for (int column = 0; column < info.Columns; column++)
                {
                    board.AddCell((row, column), new Cell());
                }
        }

        public static void GenerateBombs(this Board board, BoardInfo info)
        {
            var random = new Random();

            for (int i = 0; i < info.Bombs; i++)
            {
                int row, column;
                do
                {
                    row = random.Next(info.Rows);
                    column = random.Next(info.Columns);

                } while (board[row, column].IsBomb);

                board[row, column].IsBomb = true;
            }
        }

        public static void SetNeighbors(this Board board, BoardInfo info)
        {
            foreach (var cell in board)
            {
                cell.Value.Update(board.GetNeighborsFor(cell.Key, ((int row, int column) tuple) =>
                {
                    if (tuple.row < 0 || tuple.column < 0)
                        return false;

                    if (tuple.row >= info.Rows || tuple.column >= info.Columns)
                        return false;

                    return true;
                }));
            }
        }

        private static List<Cell> GetNeighborsFor(this Board board, (int row, int column) tuple, Predicate<(int, int)> IsInBoard)
        {
            var neighbors = new List<Cell>();

            for (int row = tuple.row - 1; row <= tuple.row + 1; row++)
                for (int column = tuple.column - 1; column <= tuple.column + 1; column++)
                {
                    if (row == tuple.row && column == tuple.column) continue;

                    if (IsInBoard((row, column)))
                    {
                        neighbors.Add(board[row, column]);
                    }
                }

            return neighbors;
        }
    }
}
