using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


//Functions of this program:
namespace FileSearch
{
     /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string fileLoc; //Stores location of wanted file
        public DataTable table = GetTable();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnBF_Click(object sender, RoutedEventArgs e)
        {
            //initialising an OFD
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //Set filter for specific file
            dlg.DefaultExt = "CSV";
            dlg.Filter = "CSV Files (*.CSV)|*.CSV";

            Nullable<bool> result = dlg.ShowDialog();

            //Show location in textbox
            if (result == true)
            {
                fileLoc = dlg.FileName;
                txtbFileLoc.Text = fileLoc;
            }
        }
        public static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("url", typeof(string));
            table.Columns.Add("username", typeof(string));
            table.Columns.Add("password", typeof(string));
            table.Columns.Add("extra", typeof(string));
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("grouping", typeof(string));
            table.Columns.Add("fav", typeof(bool));

            return null;
        }
        private void btnFD_Click(object sender, RoutedEventArgs e)
        {
            //enables the use of the data from the file

            StreamReader content = new StreamReader(File.OpenRead(fileLoc));


            //Currently doesn't work
            //CSV file headers
            List<string> url = new List<string>();
            List<string> username = new List<string>();
            List<string> password = new List<string>();
            List<string> extra = new List<string>();
            List<string> name = new List<string>();
            List<string> grouping = new List<string>();
            List<string> fav = new List<string>();

            while (!content.EndOfStream)
            {
                string line = content.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] values = line.Split(',');
                    if (values.Length >=7)
                    {
                        url.Add(values[0]);
                        username.Add(values[1]);
                        password.Add(values[2]);
                        extra.Add(values[3]);
                        name.Add(values[4]);
                        grouping.Add(values[5]);
                        fav.Add(values[6]);
                    }
                }
            }           
        }


    }
}
