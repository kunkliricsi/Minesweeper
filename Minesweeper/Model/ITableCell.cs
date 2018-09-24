using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.Model
{
    public interface ITableCell
    {
        bool IsFlagged { get; set; }
        List<ITableCell> Neighbors { get; set; }

        void Reveal();
        void Update();
    }
}
