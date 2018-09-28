using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.Model
{
    public class Cell
    {
        private List<Cell> _neighbors;

        public string Value { get; private set; }
        public bool IsClicked { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsBomb { get; set; }

        public void Reveal()
        {
            if (this.Value != "0") return;

            this.IsClicked = true;

            _neighbors.ForEach(n =>
            {
                n.Reveal();
            });
        }

        public void Update(List<Cell> neighbors)
        {
            this._neighbors = neighbors;

            int value = 0;

            _neighbors.ForEach(n =>
            {
                if (n.IsBomb) value++;
            });

            this.Value = value.ToString();
        }
    }
}
