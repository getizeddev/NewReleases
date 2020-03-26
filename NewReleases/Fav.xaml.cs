using System.Collections.Generic;
using System.Windows;

namespace NewReleases
{
    /// <summary>
    /// Interaction logic for Fav.xaml
    /// </summary>
    public partial class Fav : Window
    {
        List<List<string>> list = new List<List<string>>();
        public Fav()
        {
            App.Table.ReadData(list);
            InitializeComponent();
            ListFavourite.ItemsSource = list;
        }

        private void ClearList_Click(object sender, RoutedEventArgs e)
        {
            App.Table.DeleteAll();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (List<string> viewItem in ListFavourite.SelectedItems)
            {
                App.Table.DeleteEntry(viewItem[1]);
            }
            MessageBox.Show("Selection Deleted");
            this.Close();
        }

        private void AddWind_Click(object sender, RoutedEventArgs e)
        {
            Window Adding = new AddingPopUp();
            this.Close();
            Adding.Show();
        }

    }
}
