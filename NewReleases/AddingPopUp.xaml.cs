using System.Windows;

namespace NewReleases
{
    /// <summary>
    /// Interaction logic for AddingPopUp.xaml
    /// </summary>
    public partial class AddingPopUp : Window
    {
        public AddingPopUp()
        {
            InitializeComponent();
        }

        private void SaveNew_Click(object sender, RoutedEventArgs e)
        {
            if (ArtistInput.Text != "")
            {
                MainWindow.Entries newOne = new MainWindow.Entries { Name = ArtistInput.Text, Title = AlbumInput.Text, Genre = GenreInput.Text };
                App.Table.InsertData(newOne.Name, newOne.Title, newOne.Genre);
                MessageBox.Show($"{newOne.Name} added to the list", "", MessageBoxButton.OK);
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
