using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.Model.Cells
{
    public class Bomb : IBoardCell
    {
        public bool IsFlagged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IBoardCell> Neighbors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Button Button { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Value
        {
            get { return "B"; }
        }

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
