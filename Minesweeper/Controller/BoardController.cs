using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Minesweeper.Controller
{
    public class BoardController
    {
        private static readonly Lazy<BoardController> instance = new Lazy<BoardController>(() => new BoardController());
        private Board _board;

        private BoardController() { }
        public static BoardController Instance
        {
            get { return instance.Value; }
        }

        public void CreateBoard(Board board)
        {
            this._board = board;
        }

        public void CreateBoard(int rows, int columns, int bombs)
        {
            BoardInfo.Instance.SetInfo(rows, columns, bombs);

            this.CreateBoard(BoardInfo.Instance);
        }

        public void CreateBoard(BoardInfo info)
        {
            var builder = new BoardBuilder();

            this._board = builder.BuildBoard(info);
        }

        public void ButtonClicked(int row, int column)
        {
            var tuple = (row, column);

            this.ButtonClicked(tuple);
        }

        public void ButtonClicked((int row, int column) tuple)
        {
            _board[tuple.row, tuple.column].IsClicked = true;
            _board[tuple.row, tuple.column].Reveal();
        }
    }
}
