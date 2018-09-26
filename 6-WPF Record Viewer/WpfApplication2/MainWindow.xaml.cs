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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Person
        {
            public string Name { get; set; }
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public int Number3 { get; set; }
        }

        string line;
        List<Person> list = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\temp\\oscourse\\360-p6.txt");

            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split('"');

                list.Add(new Person()
                {
                    Name = split[1],
                    Number1 = int.Parse(split[2].Split(',')[1]),
                    Number2 = int.Parse(split[2].Split(',')[2]),
                    Number3 = int.Parse(split[2].Split(',')[3])
                });
            }
            dataGrid.ItemsSource = list;
        }
    }
}
