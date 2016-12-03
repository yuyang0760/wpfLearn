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

namespace WpfLearn
{
    /// <summary>
    /// Button.xaml 的交互逻辑
    /// </summary>
    public partial class ImageButton : System.Windows.Controls.UserControl
    {
        public event MouseButtonEventHandler ClickEvent;

        private ImageSource imageMouseEnter;
        private ImageSource imageMouseLeave;
        private string text;

        public ImageSource ImageMouseEnter
        {
            get
            {
                return imageMouseEnter;
            }

            set
            {
              
                imageMouseEnter = value; image.Source = imageMouseEnter;

            }
        }

        public ImageSource ImageMouseLeave
        {
            get
            {
                return imageMouseLeave;
            }

            set
            {
              
                imageMouseLeave = value; image.Source = imageMouseLeave;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                label.Content = value;
            }
        }

        public ImageButton()
        {
            InitializeComponent();
            
        }

        private void ImageButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                image.Source = ImageMouseEnter;
            }
        }
        private void ImageButton_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                image.Source = ImageMouseLeave;
            }
        }
        private void ImageButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                image.Source = ImageMouseEnter;

                Thickness t = new Thickness(0, 2, 0, 0);
                image.Margin = t;
                label.Margin = t;
                 
            }
        }
        private void ImageButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this.IsEnabled == true)
            {
                Thickness t = new Thickness(0, 0, 0, 0);
                image.Margin = t;
                image.Source = ImageMouseEnter;
                label.Margin = t;
                if (ClickEvent != null)
                {
                    ClickEvent(sender, e);
                }
            }
        }
    }
}
