using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.Model
{
    public interface IBoardCell
    {
        string Value { get; }
        bool IsFlagged { get; set; }
        List<IBoardCell> Neighbors { get; set; }
        Button Button { get; set; }

        void Reveal();
        void Update();
    }
}
