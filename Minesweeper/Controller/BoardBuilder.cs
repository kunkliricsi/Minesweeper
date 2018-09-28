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
        private BoardInfo _boardInfo;

        public void SetBoardInfo(BoardInfo info)
        {
            _boardInfo = info;
        }

        public Board BuildBoard()
        {
            var _board = new Board();

            _board.InitializeBoard(_boardInfo);

            _board.GenerateBombs(_boardInfo);

            _board.SetNeighbors(_boardInfo);

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
                    board.AddCell((row, column), new BoardCell());
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

        private static List<BoardCell> GetNeighborsFor(this Board board, (int row, int column) tuple, Predicate<(int, int)> IsInBoard)
        {
            var neighbors = new List<BoardCell>();

            for (int x = tuple.row - 1; x <= tuple.row + 1; x++)
                for (int y = tuple.column - 1; y <= tuple.column + 1; y++)
                {
                    if (IsInBoard((x, y)))
                    {
                        neighbors.Add(board[x, y]);
                    }
                }

            return neighbors;
        }
    }
}
