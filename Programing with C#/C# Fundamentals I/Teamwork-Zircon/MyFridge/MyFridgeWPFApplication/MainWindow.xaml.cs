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
using MyFridge;
using System.Windows.Controls.Primitives;
using MyFridgeWPFApplication;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                InitializeProducts();
                InitializeMeals();
                InitializeFridge();
                ShoppingList.MyShoppingList.Clear();
            }
            catch(ArgumentNullOrWhitespaceException ae ) 
            {
                MessageBox.Show(ae.Message, "Error! Please, restart the program!" );
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error! Please, restart the program!");
            }
        }

        private void InitializeProducts()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"..\..\products.txt"))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string[] data = line.Split('|');
                    ProductFlyweightFactory.Factory.MakeProduct(data[1], data);
                }
            }
        }

        private void InitializeMeals()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"..\..\meals.txt"))
            {
                string[] mealStrings = reader.ReadToEnd().Split(new string[] { "Meal" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in mealStrings)
                {
                    string[] mealData = item.Split(new string[] { "|", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    MealFlyweightFactory.Factory.CreateMeal(mealData[0], mealData);
                }
            }
        }

        private void InitializeFridge()
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"..\..\fridge.txt"))
            {
                Refrigerator.MyFridge.Deserialize(reader.ReadToEnd());
            }
        }
        
        private void OnGenerateShoppingListClick(object sender, RoutedEventArgs e)
        {
            hidden.Focus();
            if (ShoppingList.MyShoppingList.Count > 0)
            {
                var generateShoppingListControl = new ShoppingListWindow();
                generateShoppingListControl.ShowDialog();
            }
            else
            {
                MessageBox.Show("The generated Shopping List is empty.", "Information");
            }
        }

        private void OnComposeMenuClick(object sender, RoutedEventArgs e)
        {
            var composeMenuControl = new ComposeMenuWindow();
            hidden.Focus();
            composeMenuControl.ShowDialog();
        }

        private void OnEditFridgeButtonClick(object sender, RoutedEventArgs e)
        {
            var editFridgeControl = new EditFridgeWindow();
            hidden.Focus();
            editFridgeControl.ShowDialog();
        }

        private void OnMenuWeekMenuClearClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to clear the week menu?", "Clear week menu", MessageBoxButton.OKCancel)
                == MessageBoxResult.OK)
            {
                WeekMenu.MyMenu.Clear();
                MessageBox.Show("The week menu is cleared!", "Information");
            }
        }

        private void OnMenuClearFridgeClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to clear the fridge?", "Clear fridge", MessageBoxButton.OKCancel)
                == MessageBoxResult.OK)
            {
                Refrigerator.MyFridge.Clear();
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"..\..\fridge.txt"))
                {
                    writer.Write(Refrigerator.MyFridge.Serialize());
                }
                MessageBox.Show("The fridge is cleared!", "Information");
            }
        }
    }
}
