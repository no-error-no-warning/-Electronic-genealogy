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
using System.Windows.Shapes;
using Project_Z_UI.页面;
using Project_Z_UI.类;
using Project_Z_UI.ViewModel;


namespace Project_Z_UI.页面.功能页面
{
    /// <summary>
    /// 主页面.xaml 的交互逻辑
    /// </summary>
    public partial class 主页面 : Window
    {
        public 主页面()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();  //用户名数据绑定
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//位置居中
        }

        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            新建族谱 x = new 新建族谱();
            x.Show();
            this.Close();
        }

        private void f4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void f3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void f2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void f1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            删除族谱 x = new 删除族谱();
            x.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            人员管理 x = new 人员管理();
            x.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请在成员管理中查看。");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
