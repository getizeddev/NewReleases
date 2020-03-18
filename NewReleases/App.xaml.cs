using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
