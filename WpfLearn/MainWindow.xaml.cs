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
       
        /// <summary>
        ///  测试按钮 2016.12.7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {

            // 【普通添加图片】
            image.Source = new BitmapImage(new Uri("资源/世界资源/怪物/8_001_003.png", UriKind.Relative));

            // 【给ComboBoxNoItem1】赋值
            comboBoxNoItem1.Items.Add("11111");
            comboBoxNoItem1.Items.Add("22222");
            comboBoxNoItem1.Items.Add("33333");
            comboBoxNoItem1.Items.Add("44444");
            comboBoxNoItem1.SelectedIndex = 0;

            // 【给ComboBoxNoItem2】赋值
            comboBoxNoItem2.ItemsSource = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            comboBoxNoItem2.SelectedIndex = 5;

            // 【给textbox赋值】
            textBox.Text = "hi";

            // 【listbox添加数据】
            List<Student> studentList = new List<Student>();

            string s = @"C:\Users\yy\Documents\Visual Studio 2015\Projects\WpfLearn\WpfLearn\资源\世界资源\怪物\8_001_003.png";
            if (!File.Exists(s)) { MessageBox.Show("图片文件不存在");return; }

            List<string> ll = new List<string>();
            for (int i = 0; i < 100; i++)
            {
               
                ll.Add(i.ToString());
                studentList.Add(new Student("小明1", s,ll, i));
            }    
            listBox.ItemsSource = studentList;



        }
    }
}
