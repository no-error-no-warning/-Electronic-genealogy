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
using Project_Z_UI.页面.功能页面;
using System.Data;
using System.Data.SqlClient;

namespace Project_Z_UI.页面
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//位置居中
        }

        

        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";
            string sql = "select * from 成员表1 where 编号='" + user.Text + "'and 密码='" + pwd.Password + "' ";
            string sql2 = "select * from 成员表1 where 编号='" + user.Text + "'and 密码='" + pwd.Password + "' and 是否为管理员 = '是' ";
            //MessageBox.Show(sql);
            //string sql = "insert into t_user (id,name,age,password,birth,dai,fid,admin) values ('2','张三','23','831143','2018-11-3','2','1','0')";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            SqlCommand command2 = new SqlCommand(sql2, conn);
            //command.CommandType = CommandType.Text;
            SqlDataReader  dr = command.ExecuteReader();
            
            if (user.Text == "" || pwd.Password == "")
            {
                MessageBox.Show("请输入用户名和密码");
            }
            else 
            {
                if (dr.Read())
                {
                   
                   dr.Close();
            SqlDataReader dr2 = command2.ExecuteReader();
            if (dr2.Read())
            {
                主页面 x = new 主页面();
                x.Show();
                this.Close();
            }
            else
            {
                成员查询 x = new 成员查询();
                x.Show();
                this.Close();
            }
                    
                }
                else
                {
                    MessageBox.Show("用户名或密码有误");
                }
            }
           
          
            conn.Close();

            
        }
    }
}
