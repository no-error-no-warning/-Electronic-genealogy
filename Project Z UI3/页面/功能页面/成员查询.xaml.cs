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
using Project_Z_UI.类;
using Project_Z_UI.ViewModel;

namespace Project_Z_UI.页面.功能页面
{
    /// <summary>
    /// 成员查询.xaml 的交互逻辑
    /// </summary>
    public partial class 成员查询 : Window
    {
        public 成员查询()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();//用户名数据绑定
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//位置居中
        }

        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string con = "Server=.;Database=电子族谱;user id=sa;pwd=123123";  //这里是保存连接数据库的字符串
            string sql = "select * from 成员表1 ;";                //SQL查询语句

            SqlConnection mycon = new SqlConnection(con);                        //创建SQL连接对象

            mycon.Open();                                                        //打开
            SqlDataAdapter myda = new SqlDataAdapter(sql, con);                  //实例化SqlDtatAdapter并执行SQL语句，至于什么是SQLDataAdapter，
            //就是用来连接DataSet与数据库的，DataSet是C#中用来保存数据库数据的，
            //在这里没有用DataSet，不过原理是一样的，SQLDataAdapter从数据库中取得数据
            //然后再DataSet中创建列与行来填充，个人理解。
            DataTable dt = new DataTable();                                     //创建DtatTable实例
            myda.Fill(dt);                                                      //填充table
            dataGrid1.ItemsSource = dt.DefaultView; 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string con = "Server=.;Database=电子族谱;user id=sa;pwd=123123";  //这里是保存连接数据库的字符串
            string sql = string.Format("select * from 成员表1 where 姓名='{0}'", txtName.Text);   //SQL查询语句


            SqlConnection mycon = new SqlConnection(con);

            //打开
            SqlDataAdapter myda = new SqlDataAdapter(sql, con);                  //实例化SqlDtatAdapter并执行SQL语句，至于什么是SQLDataAdapter，
            //就是用来连接DataSet与数据库的，DataSet是C#中用来保存数据库数据的，
            //在这里没有用DataSet，不过原理是一样的，SQLDataAdapter从数据库中取得数据
            //然后再DataSet中创建列与行来填充，个人理解。
            DataTable dt = new DataTable();                                     //创建DtatTable实例
            myda.Fill(dt);                                                      //填充table
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            第N代信息 x = new 第N代信息();
            x.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            生日查询 x = new 生日查询();
            x.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            子女查询 x = new 子女查询();
            x.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("没有权限访问成员管理！");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("没有权限访问族谱管理！");
        }
    }
}
