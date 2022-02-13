using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        public class Prod
        {
            public string Name;
            public string Proizvoditel;
            public string Date;
            public string Age;
        }

        private void add(object sender, RoutedEventArgs e)
        {
            Prod prod = new Prod();
            prod.Name = naz.Text;
            prod.Proizvoditel = pro.Text;
            prod.Date = dt.Text;
            prod.Age = voz.Text;
            string path = @"C:\Users\Lenovo\Desktop\data.txt";
            string text = prod.Name + " " + prod.Proizvoditel + " " + prod.Date + " " + prod.Age;
            if(naz.Text != "" && pro.Text != "" && dt.Text != "" && voz.Text != "")
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    sw.WriteLine(text);
                    MessageBox.Show("Данные сохранены");
                }
                naz.Text = ""; pro.Text = ""; dt.Text = ""; voz.Text = "";
            }
            else { MessageBox.Show("Вы заполнили не все поля"); }
        }
        private void change(object sender, RoutedEventArgs e)
        {
            tt.IsReadOnly = false;
            StreamReader read = new StreamReader(@"C:\Users\Lenovo\Desktop\data.txt", Encoding.GetEncoding(1251));
            tt.Text = read.ReadToEnd();
            read.Dispose();
        }

        private void sohr(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\Lenovo\Desktop\data.txt";
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                sw.WriteLine(tt.Text);
                MessageBox.Show("Данные сохранены");
            }
            tt.Text = "";
            tt.IsReadOnly = true;
        }
    }
}
