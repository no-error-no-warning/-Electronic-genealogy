using Project_Z_UI.类;
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

namespace Project_Z_UI.页面.启动页面
{
    /// <summary>
    /// 用户隐私手册.xaml 的交互逻辑
    /// </summary>
    public partial class 用户隐私手册 : Window
    {
        public 用户隐私手册()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//位置居中
        }
        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);

        }

    }
}
