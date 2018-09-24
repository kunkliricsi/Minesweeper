using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Model;
using System.Windows.Controls;

namespace Minesweeper.Controller
{
    public class TableController
    {
        private Table Table { get; set; }

        public void ButtonClicked(Button button)
        {
            Table[button].Reveal();
        }


    }
}
