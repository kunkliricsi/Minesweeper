using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using Minesweeper.Model.Cells;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Minesweeper.Controller
{
    public class BoardController : ViewModelBase
    {
        private Board Board { get; set; }
        private BoardInfo BoardInfo { get; set; }
        private ICommand _clickCommand;

        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                {
                    _clickCommand = new RelayCommand<Button>(this.ButtonClicked);
                }

                return _clickCommand;
            }
        }
        public void CreateBoard(int rows = 5, int columns = 5, int bombs = 5)
        {
            this.BoardInfo = new BoardInfo(rows, columns, bombs);

            var builder = new BoardBuilder();
            builder.SetBoardInfo(this.BoardInfo);

            this.Board = builder.BuildBoard();
        }

        private void ButtonClicked(Button button)
        {
            Board[button].Reveal();
        }

        public int Rows
        {
            get { return this.BoardInfo.Rows; }
        }

        public int Columns
        {
            get { return this.BoardInfo.Columns; }
        }

        public IEnumerable<string> Values
        {
            get { return this.Board.Cells.Select(c => c.Value).ToList(); }
        }

        public IEnumerable<bool> IsEnabled
        {
            get { return this.Board.Cells.Select(c => c.IsClicked).ToList(); }
        }
    }
}
