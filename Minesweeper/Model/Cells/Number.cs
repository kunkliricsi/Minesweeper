using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Minesweeper.Model.Cells
{
    public class Number : IBoardCell
    {
        public bool IsFlagged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IBoardCell> Neighbors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Button Button { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsClicked { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private int _value;
        public string Value
        {
            get
            {
                return this._value.ToString();
            }
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
