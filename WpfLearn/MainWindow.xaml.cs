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

namespace WpfLearn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        
        // 显示按钮
        private void bt_show_Click(object sender, RoutedEventArgs e)
        {

            ModDownload modDownload = new ModDownload();

            // 显示
            string modre = modDownload.show(tb_modID.Text);
            if (modre == "true")
            {
                string title = modDownload.modShow.Title;
                string describe = modDownload.modShow.Describe;
               tb_descripbe.Text = title + "\r\n\r\n" + describe + "\r\n\r\n";
            }
            // 失败
            else
            {
                MessageBox.Show(modre);
            }
        }
        // 下载按钮
        private void bt_down_Click(object sender, RoutedEventArgs e) 
        {
            ModDownload modDownload = new ModDownload();
           string re= modDownload.down(tb_modID.Text, System.Environment.CurrentDirectory);
            // 下载失败
            if (re!="true")
            {
                MessageBox.Show(re);
            }
            // 下载成功
            else
            {
                // 打开文件夹
                System.Diagnostics.Process.Start("explorer.exe", System.Environment.CurrentDirectory);
            }
        }
    }
}
