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
    /// Interaction logic for ComposeMenuWindow.xaml
    /// </summary>
    public partial class ComposeMenuWindow : Window
    {
        private bool isVegetarian;

        public ComposeMenuWindow()
        {
            InitializeComponent();
            isVegetarian = false;
            UpdateMealList();
        }

        private void UpdateMealList()
        {
            if (!this.isVegetarian)
            {
                MealsList.ItemsSource = MealFlyweightFactory.Factory.GetAvailableMeals().OrderBy(x => x.MealType).ThenBy(x => x.Name).Select(x =>
                {
                    if (WeekMenu.MyMenu.ContainsKey(MealFlyweightFactory.Factory.CreateMeal(x.Name, null)) &&
                        WeekMenu.MyMenu[MealFlyweightFactory.Factory.CreateMeal(x.Name, null)] > 0)
                    {
                        return x.Name + " - Ordered quantity: " + WeekMenu.MyMenu[MealFlyweightFactory.Factory.CreateMeal(x.Name, null)].ToString();
                    }
                    else
                    {
                        return x.Name;
                    }
                });
            }
            else
            {
                MealsList.ItemsSource = MealFlyweightFactory.Factory.GetAvailableMeals().Where(x => x.IsVegetarian).OrderBy(x => x.MealType).ThenBy(x => x.Name).Select(x => 
                {
                    if (WeekMenu.MyMenu.ContainsKey(MealFlyweightFactory.Factory.CreateMeal(x.Name, null)) &&
                        WeekMenu.MyMenu[MealFlyweightFactory.Factory.CreateMeal(x.Name, null)] > 0)
                    {
                        return x.Name + " - Ordered quantity: " + WeekMenu.MyMenu[MealFlyweightFactory.Factory.CreateMeal(x.Name, null)].ToString();
                    }
                    else
                    {
                        return x.Name;
                    }
                });
            }
        }

        private void OnButtonClearClick(object sender, RoutedEventArgs e)
        {
            hidden.Focus();
            WeekMenu.MyMenu.Clear();
            UpdateMealList();
        }

        private void OnButtonOKClick(object sender, RoutedEventArgs e)
        {
            int sum = WeekMenu.MyMenu.GetFoodTypeDistribution().Where(i => i.Key != FoodType.Other).Sum(i => i.Value);
            string title = "Composed Week Menu Food Type Distribution:" + Environment.NewLine + new string('-', 50) + Environment.NewLine;
            if (sum > 0)
            {
                MessageBox.Show(title + string.Join("", WeekMenu.MyMenu.GetFoodTypeDistribution().Where(i => i.Key != FoodType.Other).Select(i => string.Format("{0} : {1:0%}{2}", i.Key, i.Value / (double)sum, Environment.NewLine))), "Information");
            }
            this.Close();
        }

        private void OnAddMealButtonClick(object sender, RoutedEventArgs e)
        {
            hidden.Focus();
            if (MealsList.SelectedItem != null)
            {
                var previouslySelectedItem = MealsList.SelectedIndex;
                var selectedMeal = MealFlyweightFactory.Factory.CreateMeal(MealsList.SelectedItem.ToString().Split(new string[]{" - "},StringSplitOptions.RemoveEmptyEntries)[0], null);
                if (WeekMenu.MyMenu.ContainsKey(selectedMeal))
                {
                    WeekMenu.MyMenu[selectedMeal]++;
                    UpdateMealList();           
                }
                else
                {
                    WeekMenu.MyMenu.Add(selectedMeal, 1);
                    UpdateMealList();
                }
                MealsList.SelectedIndex = previouslySelectedItem;
            }
            else
            {
                this.Close();
                string warning = "Warning: You have to select a meal from the list and then press Add Meal button.";
                MessageBox.Show(warning, "Invalid Meal Selection");
            }
        }

        private void OnRemoveMealButtonClick(object sender, RoutedEventArgs e)
        {
            hidden.Focus();
            if (MealsList.SelectedItem != null)
            {
                var selectedMeal = MealFlyweightFactory.Factory.CreateMeal(MealsList.SelectedItem.ToString().Split(new string[]{" - "},StringSplitOptions.RemoveEmptyEntries)[0], null);
                if (WeekMenu.MyMenu.ContainsKey(selectedMeal) && WeekMenu.MyMenu[selectedMeal] > 0)
                {
                    WeekMenu.MyMenu[selectedMeal]--;
                    UpdateMealList();
                }
                else
                {
                    this.Close();
                    string warning = "Warning: Unable to remove the selected meal from the list!";
                    MessageBox.Show(warning, "Invalid Meal Removal");
                }
            }
            else
            {
                this.Close();
                string warning = "Warning: You have to select a meal from the list and then press Remove Meal button.";
                MessageBox.Show(warning, "Invalid Meal Selection");
            }
        }

        private void OnVegetarianMenuClick(object sender, RoutedEventArgs e)
        {
            hidden.Focus();
            
            if (!isVegetarian)
            {
                isVegetarian = true;
                this.VegButton.Content = "Vegetarian Menu ON";
            }
            else
            {
                isVegetarian = false;
                this.VegButton.Content = "Vegetarian Menu OFF";
            }
            UpdateMealList();
        }
    }
}
