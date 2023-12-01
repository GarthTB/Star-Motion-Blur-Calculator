using System;
using System.Windows;
using System.Windows.Media;

namespace Star_Motion_Blur_Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RBTime_Click(object sender, RoutedEventArgs e)
        {
            TBTime.IsReadOnly = true;
            TBFWHM.IsReadOnly = false;
            TextBlockFWHM.Text = "星点半径";
            TBTime.Background = new SolidColorBrush(Color.FromRgb(234, 238, 240));
            TBFWHM.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void RBLength_Click(object sender, RoutedEventArgs e)
        {
            TBTime.IsReadOnly = false;
            TBFWHM.IsReadOnly = true;
            TextBlockFWHM.Text = "拖线长度";
            TBTime.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            TBFWHM.Background = new SolidColorBrush(Color.FromRgb(234, 238, 240));
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject("https://github.com/GarthTB/Star-Motion-Blur-Calculator");
            MessageBox.Show("此程序基于优化过的NPF法则，可计算出：\n1.最长不拖线曝光时间；\n2.特定曝光时间下的拖线长度。\n注意：焦距越广，偏差越大。\n作者：Garth。\n源码链接已复制到剪贴板。", "关于", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TBFL.Clear();
            TBSize.Clear();
            TBDec.Clear();
            TBFWHM.Clear();
            TBTime.Clear();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (RBTime.IsChecked == true)
            {
                double.TryParse(TBFL.Text, out double FL);
                double.TryParse(TBSize.Text, out double Size);
                double.TryParse(TBDec.Text, out double Dec);
                double.TryParse(TBFWHM.Text, out double FWHM);
                if (FL > 0 && Size > 0 && Dec >= -90 && Dec <= 90 && FWHM > 0)
                {
                    double Time = 86164.1 * Math.Atan(Size * FWHM / 2000 / FL) / Math.PI / Math.Cos(Math.Abs(Dec * Math.PI / 180));
                    if (Time > 3600)
                    {
                        TBTime.Text = "超过一小时";
                    }
                    else
                    {
                        TBTime.Text = Convert.ToString(Math.Round(Time, 3));
                    }
                }
                else
                {
                    MessageBox.Show("输入有误，请检查输入！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (RBLength.IsChecked == true)
            {
                double.TryParse(TBFL.Text, out double FL);
                double.TryParse(TBSize.Text, out double Size);
                double.TryParse(TBDec.Text, out double Dec);
                double.TryParse(TBTime.Text, out double Time);
                if (FL > 0 && Size > 0 && Dec >= -90 && Dec <= 90 && Time > 0)
                {
                    double Length = Math.Tan(Math.PI * Math.Cos(Math.Abs(Dec * Math.PI / 180)) * Time / 86164.1) * 2000 * FL / Size;
                    if (Length > 1000)
                    {
                        TBFWHM.Text = "超过1000像素";
                    }
                    else
                    {
                        TBFWHM.Text = Convert.ToString(Math.Round(Length, 3));
                    }
                }
                else
                {
                    MessageBox.Show("输入有误，请检查输入！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
