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
using MyFridge;

namespace MyFridgeWPFApplication
{
    /// <summary>
    /// Interaction logic for ShoppingListWindow.xaml
    /// </summary>
    public partial class ShoppingListWindow : Window
    {
        public ShoppingListWindow()
        {
            InitializeComponent();
            this.ToBuyList.Text = "Shopping List:" + Environment.NewLine +
                                    new string('-', 25) + Environment.NewLine +
                                    ShoppingList.MyShoppingList.ToString();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnPrintButtonClick(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { 
                dialog.PrintVisual(this.ToBuyList, "My Shopping List"); 
            }
            this.Close();
        }
    }
}
