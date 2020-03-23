using System.Windows;

namespace NewReleases
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static SQLiteTable table;

        public static SQLiteTable Table
        {
            get
            {
                if (table == null)
                {
                    table = new SQLiteTable();
                }
                return table;
            }
        }
    }

}
