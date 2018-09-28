using OriAndTheBlindForest.Views.UtilityFunctions;
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
using System.Windows.Shapes;

namespace OriAndTheBlindForest.Views.Expenses
{
    /// <summary>
    /// Interaction logic for AddExpense.xaml
    /// </summary>
    public partial class AddExpense : Window
    {
        public AddExpense()
        {
            InitializeComponent();
        }

        private void backToExpensePage_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new MainWindow());
            
        }
    }
}
