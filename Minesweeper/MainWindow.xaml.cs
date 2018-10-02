using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Minesweeper.Controller;
using Minesweeper.Model;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SizeProviderDialog dlg = new SizeProviderDialog
            {
                Owner = this,
                Margin = this.Margin
            };

            if (dlg.ShowDialog() ?? false)
            {
                CreateGridWithButtons();
            }
        }

        private void CreateGridWithButtons()
        {
            for (int row = 0; row < BoardInfo.Instance.Rows; row++)
            {
                Grid.RowDefinitions.Add(new RowDefinition());

                for (int column = 0; column < BoardInfo.Instance.Columns; column++)
                {
                    Grid.ColumnDefinitions.Add(new ColumnDefinition());

                    AddButton(row, column);
                }
            }
        }

        private void AddButton(int row, int column)
        {
            var button = new Button()
            {
                Name = "b" + row.ToString() + "_" + column.ToString()
            };

            Grid.SetRow(button, row);
            Grid.SetColumn(button, column);
            Grid.Children.Add(button);
        }
    }
}
