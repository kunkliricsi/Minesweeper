using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using Minesweeper.Controller;
using System.Windows.Input;

namespace Minesweeper
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Setter Properties

        public BoardInfo Info
        {
            set
            {
                this.Rows = value.Rows;
                this.Columns = value.Columns;
            }
        }

        public Board Board
        {
            set
            {
                this.Values = value.Cells.Select(c => c.Value);
                this.Coordinates = value.Select(c => c.Key);
                this.IsEnabled = value.Cells.Select(c => !c.IsClicked);
            }
        }

        #endregion

        #region Properties

        private int rows;
        public int Rows
        {
            get { return rows; }
            set { Set(ref rows, value); }
        }

        private int columns;
        public int Columns
        {
            get { return columns; }
            set { Set(ref columns, value); }
        }

        private IEnumerable<string> values;
        public IEnumerable<string> Values
        {
            get { return values; }
            set { Set(ref values, value); }
        }

        private IEnumerable<(int, int)> coordinates;
        public IEnumerable<(int, int)> Coordinates
        {
            get { return coordinates; }
            set { Set(ref coordinates, value); }
        }

        private IEnumerable<bool> isEnabled;
        public IEnumerable<bool> IsEnabled
        {
            get { return IsEnabled; }
            set { Set(ref isEnabled, value); }
        }

        #endregion

        #region Commands

        private ICommand cellClick;
        public ICommand CellClick
        {
            get
            {
                if (cellClick == null)
                {
                    cellClick = new RelayCommand<(int, int)>(BoardController.Instance.ButtonClicked);
                }

                return cellClick;
            }
        }

        private ICommand createBoard;
        public ICommand CreateBoard
        {
            get
            {
                if (createBoard == null)
                {
                    createBoard = new RelayCommand<(int, int, int)>(BoardController.Instance.CreateBoard);
                }

                return createBoard;
            }
        }

        #endregion
    }
}
