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
using System.Data;
using System.Data.SqlClient;

namespace Project_Z_UI.页面.功能页面
{
    /// <summary>
    /// 新增成员.xaml 的交互逻辑
    /// </summary>
    public partial class 新增成员 : Window
    {
        public 新增成员()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string id = idTextbox.Text;
            string name = nameTextbox.Text;
            string password = passTextbox.Text;
            string birth = birthTextbox.Text;
            string fid = fidTextbox.Text;
            string age = ageTextbox.Text;
            string dai = daiTextbox.Text;
            string admin = isAdminTextbox.Text;
            string gender = genderTextbox.Text;


            string connStr = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";
            string sql = string.Format("insert into  成员表1(编号,姓名,年龄,密码,代数,父亲编号,是否为管理员,性别,出生日期) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", id, name, age, password, dai, fid, admin, gender, birth);
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

            idTextbox.Text = "";
            nameTextbox.Text = "";
            ageTextbox.Text = "";
            passTextbox.Text = "";
            birthTextbox.Text = "";
            daiTextbox.Text = "";
            fidTextbox.Text = "";
            isAdminTextbox.Text = "";
            genderTextbox.Text = "";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            主页面 x = new 主页面();
            x.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            人员管理 x = new 人员管理();
            x.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请在成员管理中查看。");

        }
    }
}
