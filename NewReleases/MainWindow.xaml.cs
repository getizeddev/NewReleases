using HtmlAgilityPack;
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

namespace NewReleases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Entries> Artists = new List<Entries>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Entries
        {
            public string Name { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public string Review { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var html = @"https://www.allmusic.com/newreleases";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectNodes("//div[@class='new-release-items-container']/div[@class='new-release']/div[@class='meta-container']");
            foreach (HtmlNode i in node)
            {
                Artists.Add(new Entries() 
                {
                    //Name = i.SelectSingleNode("/div[@class='artist']").InnerText,
                    //Title = i.SelectSingleNode("/div[@class='title']").InnerText,
                    //Genre = i.SelectSingleNode("/div[@class='genres']").InnerText,
                    //Review = i.SelectSingleNode("//div[@class='headline-review']").InnerText,
                    Name = i.ChildNodes[1].InnerText.Trim(),
                    Title = i.ChildNodes[3].InnerText.Trim(),
                    Genre = i.ChildNodes[7].InnerText.Trim(),
                    Review = i.ChildNodes[i.ChildNodes.Count - 2].InnerText.Trim(),
                }
                );
            }
            MusicReleases.ItemsSource = Artists;
        }

        private void InformationArtist(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult boxResult = System.Windows.MessageBox.Show("Would you like to save this albun in the Favourites?", "Save Artist and Album", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                Entries obj = ((FrameworkElement)e.OriginalSource).DataContext as Entries;
                App.Table.InsertData(obj.Name, obj.Title, obj.Genre);
                MessageBox.Show($"{obj.Name} - {obj.Title} saved", "Save Artist and Album", MessageBoxButton.OK);
            }
            else
            {
                //nothing
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window favour = new Fav();
            favour.Show();
        }
    }
}
