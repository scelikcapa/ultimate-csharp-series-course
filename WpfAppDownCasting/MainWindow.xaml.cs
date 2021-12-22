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

namespace WpfAppDownCasting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // DOWNCASTING
            // Explicit Downcasting
            if (sender is Button)
            {
                var button = (Button)sender;
                MessageBox.Show("usage of is keyword: "+button.Width.ToString());
            }

            // "As" Keyword Downcasting
            var button2 = sender as Button;
            if (button2!=null)
            {
                MessageBox.Show("usage of as keyword: "+button2.Width.ToString());
            }

            
            MessageBox.Show("Hello world");
        }
    }
}
