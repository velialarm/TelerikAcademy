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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
            this.ProductList.ItemsSource = ProductFlyweightFactory.Factory.GetAvailableProducts().OrderBy(x => x.Name).Select(x => x.Name);
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            var selectedProduct = ProductFlyweightFactory.Factory.MakeProduct(ProductList.SelectedItem.ToString(), null);
            if (Refrigerator.MyFridge.ContainsKey(selectedProduct))
            {
                MessageBox.Show("The selected product could not be addedd, because it is already in the fridge!", "Warning");
            }
            else
            {
                Refrigerator.MyFridge.Add(selectedProduct, 0);
            }
        }
    }
}
