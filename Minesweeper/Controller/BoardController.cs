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
    public class BoardController : ViewModelBase
    {
        private static readonly Lazy<BoardController> instance = new Lazy<BoardController>(() => new BoardController());
        private Board Board { get; set; }
        private BoardInfo Info { get; set; }

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
                    _clickCommand = new RelayCommand<(int, int, int)>(this.CreateBoard);
                }

                return _createCommand;
            }
        }
        private void CreateBoard((int rows, int columns, int bombs)triple)
        {
            this.Info = new BoardInfo(triple.rows, triple.columns, triple.bombs);
            this.Rows = triple.rows;
            this.Columns = triple.columns;

            var builder = new BoardBuilder();
            this.Board = builder.BuildBoard(this.Info);

            this.PropertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs("Rows"));
            this.PropertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs("Columns"));
            this.PropertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs("Values"));
            this.RaisePropertyChanged();
        }

        private void ButtonClicked((int row, int column) tuple)
        {
            Board[tuple.row, tuple.column].IsClicked = true;
            Board[tuple.row, tuple.column].Reveal();

            this.PropertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
        }

        #endregion

        #region Properties

        private int _rows;
        public int Rows
        {
            get { return this.Info.Rows; }
            set { Set(ref _rows, value); }
        }

        private int _columns;
        public int Columns
        {
            get { return this.Info.Columns; }
            set { Set(ref _columns, value); }
        }

        public IEnumerable<string> Values
        {
            get { return this.Board.Cells.Select(c => c.Value).ToList(); }
        }

        public IEnumerable<bool> IsEnabled
        {
            get { return this.Board.Cells.Select(c => !c.IsClicked).ToList(); }
        }

        #endregion
    }
}
