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
using System.Data.SqlClient;
using System.Data;
using Project_Z_UI.类;
using Project_Z_UI.ViewModel;

namespace Project_Z_UI.页面.功能页面
{
    /// <summary>
    /// 新建族谱.xaml 的交互逻辑
    /// </summary>
    public partial class 新建族谱 : Window
    {
        public 新建族谱()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();//用户名数据绑定
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//位置居中
        }

        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string name = f1.Text;
            string id = f2.Text;
            string xi = f4.Text;
            string jianj = f3.Text;
            


            string connStr = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";
            string sql = string.Format("insert into  族谱表(族谱名称,族谱编号,族谱简介,族谱姓氏) values ('{0}','{1}','{2}','{3}')", name,id,jianj,xi);
            //MessageBox.Show(sql);
            //string sql = "insert into t_user (id,name,age,password,birth,dai,fid,admin) values ('2','张三','23','831143','2018-11-3','2','1','0')";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            //command.CommandType = CommandType.Text;
            int s = command.ExecuteNonQuery();
            if (s == 0)
            {
                MessageBox.Show("保存失败");
            }
            else
            {
                MessageBox.Show("保存成功");
            }
            conn.Close();

            f1.Text = "";
            f2.Text = "";
            f3.Text = "";
            f4.Text = "";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            人员管理 x = new 人员管理();
            x.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            删除族谱 x = new 删除族谱();
            x.Show();
            this.Close();
        }

        private void f1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void f2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void f4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void f3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请在成员管理中查看。");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            主页面 x = new 主页面();
            x.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
