using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfLearn.UserControls
{
    /// <summary>
    /// ImageButton3.xaml 的交互逻辑
    /// </summary>
    public partial class ImageButton3 : Button
    {
        // 运行顺序：静态-》普通
        public ImageButton3()
        {
            InitializeComponent();

            // 给当前值附初始值
            // CurrentImage = ImageMouseLeave;
            //t = this.Margin;
        }

        // private static bool isFirst = true;
        #region 【依赖属性】
        // 依赖属性 参考网址：http://www.cnblogs.com/luluping/archive/2011/05/06/2039489.html
        // 没怎么看懂.... http://blog.csdn.net/luxiaoyu_sdc/article/details/6173758
        // http://blog.csdn.net/rabbitsoft_1987/article/details/18677067


        // 1. 创建依赖属性---静态只读
        public static readonly DependencyProperty ImageMouseEnterProperty;//鼠标经过时的画刷
        public static readonly DependencyProperty ImageMouseLeaveProperty;//鼠标按下时的画刷
        public static readonly DependencyProperty ImageCurrentProperty;//当前
        public static readonly DependencyProperty TextProperty;

        //private ImageSource imageMouseEnter;
        //private ImageSource imageMouseLeave;

        // 2.注册依赖属性 .  运行顺序：静态-》普通
        static ImageButton3()
        {
            ImageButton3.ImageMouseEnterProperty =
            DependencyProperty.Register("ImageMouseEnter", typeof(ImageSource), typeof(ImageButton3),
                   new PropertyMetadata(new BitmapImage(),new PropertyChangedCallback(PropertyChange)));
            //注意：一个字母写错，搞了2小时。。
            ImageButton3.ImageMouseLeaveProperty =
            DependencyProperty.Register("ImageMouseLeave", typeof(ImageSource), typeof(ImageButton3),
                new PropertyMetadata( new BitmapImage(), new PropertyChangedCallback(PropertyChange)));

            ImageButton3.ImageCurrentProperty = /*ImageButton3.ImageMouseLeaveProperty;*/
            DependencyProperty.Register("ImageCurrent", typeof(ImageSource), typeof(ImageButton3),
                   new PropertyMetadata(new BitmapImage(), new PropertyChangedCallback(PropertyChange)));

            ImageButton3.TextProperty = /*ImageButton3.ImageMouseLeaveProperty;*/
            DependencyProperty.Register("Text", typeof(string), typeof(ImageButton3),
                    new PropertyMetadata("", new PropertyChangedCallback(PropertyChange)));



            // 给当前值附初始值
            // ImageButton3.CurrentImageProperty = ImageButton3.ImageMouseLeaveProperty;
            // DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageSource), new FrameworkPropertyMetadata(typeof(ImageSource)));

        }

        // 回调函数 
        private static void PropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (e.Property.Name == "ImageMouseEnter")
            //{
            //    // MessageBox.Show("ImageMouseEnter");
           
            
            //}
            //if (e.Property.Name == "ImageMouseLeave" /*&&　isFirst*/)
            //{
            //    // MessageBox.Show("ImageMouseLeave");
            //    //CurrentImageProperty = ImageMouseLeaveProperty;
            //    //isFirst = false;

            //}
            //if (e.Property.Name == "CurrentImage")
            //{
            //    // MessageBox.Show("ImageMouseLeave");
            //}

        }


        // 3.包装属性
        /// <summary>
        /// 鼠标进入时的图片
        /// </summary>
        public ImageSource ImageMouseEnter
        {
            get
            {
                return base.GetValue(ImageButton3.ImageMouseEnterProperty) as ImageSource;
            }
            set
            {
                base.SetValue(ImageButton3.ImageMouseEnterProperty, value);
            }
        }

        /// <summary>
        /// 鼠标离开时的图片
        /// </summary>
        public ImageSource ImageMouseLeave
        {
            get
            {
                return base.GetValue(ImageButton3.ImageMouseLeaveProperty) as ImageSource;
            }
            set
            {
                base.SetValue(ImageButton3.ImageMouseLeaveProperty, value);
            }
        }

        public ImageSource ImageCurrent
        {
            get
            {
                return base.GetValue(ImageButton3.ImageCurrentProperty) as ImageSource;
            }
            set
            {
                base.SetValue(ImageButton3.ImageCurrentProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return base.GetValue(ImageButton3.TextProperty) as string;
            }
            set
            {
                base.SetValue(ImageButton3.TextProperty, value);
            }
        }


        #endregion

        Thickness 按钮初始位置;
        private void ImageButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                ImageCurrent = ImageMouseEnter;
                //image.Source = ImageMouseEnter;
                //this.Text = "进入";
                //this.Margin = new Thickness(t.Left, t.Top + 3, t.Right, t.Bottom);
            }
        }
        private void ImageButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                ImageCurrent = ImageMouseLeave;


                //image.Source = ImageMouseLeave;
                // Thickness t = new Thickness(0, t.Top, 0, 0);
                //image.Margin = t;
                //label.Margin = t;
                //this.Text = "离开";
                this.Margin = 按钮初始位置;
            }
        }
        private void ImageButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                //image.Source = ImageMouseEnter;

                //Thickness t = new Thickness(0, 2, 0, 0);
                //image.Margin = t;
                //label.Margin = t;
                //this.Text = "按下";
                this.Margin = new Thickness(按钮初始位置.Left, 按钮初始位置.Top+2, 按钮初始位置.Right, 按钮初始位置.Bottom);

            }
        }
        private void ImageButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                //Thickness t = new Thickness(0, 0, 0, 0);
                //image.Margin = t;
                //image.Source = ImageMouseEnter;
                //label.Margin = t;
                //if (ClickEvent != null)
                //{
                //    ClickEvent(sender, e);
                //}
                //this.Text = "抬起";
                this.Margin = 按钮初始位置;
            }
        }

        private void ImageButton_Loaded(object sender, RoutedEventArgs e)
        {
            //ImageCurrent = ImageMouseLeave;
            按钮初始位置 = this.Margin;
        }


    }
}
