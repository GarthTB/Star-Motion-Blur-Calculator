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
        }

        private void RBLength_Click(object sender, RoutedEventArgs e)
        {
            TBTime.IsReadOnly = false;
            TBFWHM.IsReadOnly = true;
            TextBlockFWHM.Text = "拖线长度";
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("本程序由Garth制作。\n","关于",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
