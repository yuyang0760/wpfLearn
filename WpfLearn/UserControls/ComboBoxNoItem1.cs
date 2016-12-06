using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfLearn.UserControls
{
    /// <summary>
    /// 2016.12.6 希望不要出现bug，出现也搞不定了。。
    /// </summary>
    public class ComboBoxNoItem1 : ComboBox
    {
        #region 静态 构造函数
        static ComboBoxNoItem1()
        {

            //LeftClickCommand
            LeftClickCommand = new RoutedUICommand();
            LeftClickCommandBinding = new CommandBinding(LeftClickCommand);
            LeftClickCommandBinding.Executed += LeftClick;

            //RightClickCommand
            RightClickCommand = new RoutedUICommand();
            RightClickCommandBinding = new CommandBinding(RightClickCommand);
            RightClickCommandBinding.Executed += RightClick;
        }
        #endregion

        #region 左边按钮
        /// <summary>
        /// 左边按钮，附加属性，不太懂。。
        /// </summary>
        public static readonly DependencyProperty IsLeftEnabledProperty = DependencyProperty.RegisterAttached("IsLeftEnabled"
            , typeof(bool), typeof(ComboBoxNoItem1), new FrameworkPropertyMetadata(false, IsLeftEnabledChanged));

        private static void IsLeftEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("IsLeftEnabledChanged");
            var button = d as ImageButton4;
            if (e.OldValue != e.NewValue && button != null)
            {
                //绑定
                button.CommandBindings.Add(LeftClickCommandBinding);
            }
        }
       
        
        // get.set 但是从来就没用过
        [AttachedPropertyBrowsableForType(typeof(ComboBoxNoItem1))]
        public static bool GetIsLeftEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsLeftEnabledProperty);
        }

        public static void SetIsLeftEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsLeftEnabledProperty, value);
        }

        // 左边点击命令
        public static RoutedUICommand LeftClickCommand { get; private set; }
        /// <summary>
        /// 绑定事件
        /// </summary>
        private static readonly CommandBinding LeftClickCommandBinding;

        private static void LeftClick(object sender, ExecutedRoutedEventArgs e)
        {
            // Debug.WriteLine("左边按钮按下了");
            
            // 空，返回
            if (e.Parameter == null) return;

            ComboBoxNoItem1 comboBoxNoItem1 = (ComboBoxNoItem1)e.Parameter;
            if (comboBoxNoItem1.Items.Count<=0)
            {
                return;
            }

            // 循环显示
            if (comboBoxNoItem1.SelectedIndex==-1 || comboBoxNoItem1.SelectedIndex == 0)
            {
                comboBoxNoItem1.SelectedIndex = comboBoxNoItem1.Items.Count - 1;
                //SetIsLeftEnabled( comboBoxNoItem1, false);
            }
            else
            {
                comboBoxNoItem1.SelectedIndex -= 1;
            }
            
        }

        #endregion
       
        #region 右边按钮
        /// <summary>
        /// 右边按钮，附加属性，不太懂。。
        /// </summary>
        public static readonly DependencyProperty IsRightEnabledProperty = DependencyProperty.RegisterAttached("IsRightEnabled"
            , typeof(bool), typeof(ComboBoxNoItem1), new FrameworkPropertyMetadata(false, IsRightEnabledChanged));

        private static void IsRightEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("IsRightEnabledChanged");
            var button = d as ImageButton4;
            if (e.OldValue != e.NewValue && button != null)
            {
                //绑定
                button.CommandBindings.Add(RightClickCommandBinding);
            }
        }


        // get.set 但是从来就没用过
        [AttachedPropertyBrowsableForType(typeof(ComboBoxNoItem1))]
        public static bool GetIsRightEnabled(DependencyObject d)
        {
            return (bool)d.GetValue(IsRightEnabledProperty);
        }

        public static void SetIsRightEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsRightEnabledProperty, value);
        }

        // 右边点击命令
        public static RoutedUICommand RightClickCommand { get; private set; }
        /// <summary>
        /// 绑定事件
        /// </summary>
        private static readonly CommandBinding RightClickCommandBinding;

    

        private static void RightClick(object sender, ExecutedRoutedEventArgs e)
        {
            // Debug.WriteLine("右边按钮按下了");

            // 空，返回
            if (e.Parameter == null) return;

            ComboBoxNoItem1 comboBoxNoItem1 = (ComboBoxNoItem1)e.Parameter;
            if (comboBoxNoItem1.Items.Count <= 0)
            {
                return;
            }

            // 循环显示
            if (comboBoxNoItem1.SelectedIndex == -1 || comboBoxNoItem1.SelectedIndex == comboBoxNoItem1.Items.Count - 1)
            {
                comboBoxNoItem1.SelectedIndex = 0;
                //SetIsRightEnabled( comboBoxNoItem1, false);
            }
            else
            {
                comboBoxNoItem1.SelectedIndex += 1;
            }

        }

        #endregion
    }
}
