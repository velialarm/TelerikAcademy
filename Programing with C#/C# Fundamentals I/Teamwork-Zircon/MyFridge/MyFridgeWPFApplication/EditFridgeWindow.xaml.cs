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
using System.Windows.Controls.Primitives;

namespace MyFridgeWPFApplication
{
    /// <summary>
    /// Interaction logic for EditFridgeWindow.xaml
    /// </summary>
    public partial class EditFridgeWindow : Window
    {
        public EditFridgeWindow()
        {
            InitializeComponent();
            UpdateFridge();
        }

        private void UpdateFridge()
        {
            FridgeProductsList.ItemsSource = Refrigerator.MyFridge.Select(x => x.Key.Name + " " + x.Value + " " + x.Key.BaseUnit).OrderBy(x => x);
        }

        private void OnButtonSaveClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"..\..\fridge.txt"))
            {
                writer.Write(Refrigerator.MyFridge.Serialize());
            }
        }

        private void OnButtonCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            Refrigerator.MyFridge.Clear();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"..\..\fridge.txt"))
            {
                Refrigerator.MyFridge.Deserialize(reader.ReadToEnd());
            }
        }

        private void OnChangeButtonClick(object sender, RoutedEventArgs e)
        {
            hidden.Focus();
            if (this.FridgeProductsList.SelectedItem != null)
            {
                string productName = this.FridgeProductsList.SelectedItem.ToString();
                for (int i = 0; i < 2; i++)
                {
                    int startIndexRemoval = productName.LastIndexOf(' ');
                    productName = productName.Remove(startIndexRemoval);
                }
                int newQuantity;
                if (int.TryParse(this.NewProductQuantity.Text, out newQuantity))
                {
                    if (newQuantity <= 0)
                    {
                        Refrigerator.MyFridge.Remove(ProductFlyweightFactory.Factory.MakeProduct(productName, null));
                        UpdateFridge();
                    }
                    else
                    {
                        Refrigerator.MyFridge[ProductFlyweightFactory.Factory.MakeProduct(productName, null)] = newQuantity;
                        UpdateFridge();
                        this.NewProductQuantity.Text = string.Empty;
                    }
                }
                else
                {
                    this.NewProductQuantity.Text = string.Empty;
                    string warning = "Error: You have to specify a positive integer number for the new quantity!";
                    MessageBox.Show(warning, "Invalid Change Quantity");
                }
            }
            else
            {
                this.NewProductQuantity.Text = string.Empty;
                string warning = "Error: You have to select a product from the list and then press Change button.";
                MessageBox.Show(warning, "Invalid Change Quantity");
            }
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            var addProductForm = new AddProductWindow();
            addProductForm.ShowDialog();
            this.UpdateFridge();
        }
    }
}
