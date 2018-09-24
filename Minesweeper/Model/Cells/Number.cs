using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.Model.Cells
{
    public class Number : ITableCell
    {
        public bool IsFlagged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Value { get; set; }

        public void Reveal()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
