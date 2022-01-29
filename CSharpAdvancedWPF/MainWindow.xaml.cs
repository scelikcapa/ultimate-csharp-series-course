using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace CSharpAdvancedWPF
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //DownloadHtmlAsync("http://udemy.com");

            //var html = GetHtml("http://udemy.com");
            //MessageBox.Show(html.Substring(0, 10));

            var getHtmlTask = GetHtmlAsync("http://udemy.com");
            // can do other job while task is working
            MessageBox.Show("Waiting for the task to complete");
            // use await when the rest ot that method cannot be executed until the result is ready
            var html = await getHtmlTask;
            MessageBox.Show(html.Substring(0, 10));
        }

        public string GetHtml(string url)
        {
            var webClient = new WebClient();
            return webClient.DownloadString(url);
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url);
        }

        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"C:\Users\Admin\OneDrive\Masaüstü\downloaded\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }
        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter=new StreamWriter(@"C:\Users\Admin\OneDrive\Masaüstü\downloaded\result.html"))
            {
                streamWriter.Write(html);
            }
        }
    }
}
