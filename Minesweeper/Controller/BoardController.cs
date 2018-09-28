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
        private Board Board { get; set; }

        private BoardController() { }
        public static BoardController Instance
        {
            get { return instance.Value; }
        }

        #region Commands

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                {
                    _clickCommand = new RelayCommand<(int, int)>(this.ButtonClicked);
                }

                return _clickCommand;
            }
        }

        private ICommand _createCommand;
        public ICommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new RelayCommand<(int, int, int)>(this.CreateBoard);
                }

                return _createCommand;
            }
        }
        public void CreateBoard((int rows, int columns, int bombs)triple)
        {
            var info = new BoardInfo(triple.rows, triple.columns, triple.bombs);

            var builder = new BoardBuilder();
            this.Board = builder.BuildBoard(info);
        }

        public void ButtonClicked((int row, int column) tuple)
        {
            Board[tuple.row, tuple.column].IsClicked = true;
            Board[tuple.row, tuple.column].Reveal();
        }

        #endregion
    }
}
