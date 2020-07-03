using Project_Z_UI.ViewModel;
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
using System.Data;
using System.Data.SqlClient;

namespace Project_Z_UI.页面.功能页面
{
    /// <summary>
    /// 人员管理.xaml 的交互逻辑
    /// </summary>
    public partial class 人员管理 : Window
    {
        object cellTempValue = null;
        object cellFinshEditValue = null;
        int column;
        int row;
        string ID;

        string[] field = new string[] {
            "编号",
            "姓名",
            "年龄",
            "性别",
            "密码",
            "代数",
            "父亲编号",
           "出生日期" ,
            "是否为管理员"
        };

        public 人员管理()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();//用户名数据绑定
        }
        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            新增成员 x = new 新增成员();
            x.Show();
            this.Close();

        }

        private void DataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //cellTempValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
            //columnName = (e.Column.GetCellContent(0) as TextBlock).Text;
            //rowID = (DataGrid.Columns[1].GetCellContent(e.Rlock) as TextBox).Text;

            var cells = DataGrid.SelectedCells;
            row = DataGrid.Items.IndexOf(cells.First().Item);
            column = DataGrid.CurrentColumn.DisplayIndex;
            ID = (DataGrid.Columns[1].GetCellContent(DataGrid.Items[row]) as TextBlock).Text;
            if (column > 0)
            {
                cellTempValue = (e.Column.GetCellContent(e.Row) as TextBlock).Text;
            }
            //MessageBox.Show(ID);
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            //MessageBox.Show(cellFinshEditValue.ToString());
            if (column > 0)
            {
                cellFinshEditValue = (e.EditingElement as TextBox).Text;
                if (cellFinshEditValue != cellTempValue)
                {
                    string sql = string.Format("update 成员表1 set {0}='{1}' where 编号='{2}'", field[column - 1], cellFinshEditValue, ID);
                    string connStr = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";//连接字符串 
                                                                                                               //MessageBox.Show(sql);
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand command = new SqlCommand(sql, conn);
                    //command.CommandType = CommandType.Text;
                    int s = command.ExecuteNonQuery();
                    if (s == 0)
                    {
                        MessageBox.Show("修改失败");
                    }
                    else
                    {
                        MessageBox.Show("修改成功");
                    }
                    conn.Close();
                }
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string connStr = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";
            string sql = string.Format("delete from 成员表1 where 编号='{0}'", ID);
            //MessageBox.Show(sql);
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            //command.CommandType = CommandType.Text;
            int s = command.ExecuteNonQuery();
            if (s == 0)
            {
                MessageBox.Show("删除失败");
            }
            else
            {
                MessageBox.Show("删除成功");
            }
            string sql1 = "select * from 成员表1";
            SqlDataAdapter sqlada = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sqlada.Fill(ds, "基本成员表");
            DataView dv = new DataView(ds.Tables["基本成员表"]);
            DataGrid.ItemsSource = dv;
            conn.Close();
        }

        private void searchName(object sender, RoutedEventArgs e)
        {
            string sql = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";//连接字符串 
            SqlConnection sqlcon = new SqlConnection(sql);// 
            string sql1 = "select * from 成员表1 where 姓名='" + textbox1.Text + "'";
            SqlDataAdapter sqlada = new SqlDataAdapter(sql1, sqlcon);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sqlada.Fill(ds, "基本成员表");
            DataView dv = new DataView(ds.Tables["基本成员表"]);
            DataGrid.ItemsSource = dv;
        }

        private void searchID(object sender, RoutedEventArgs e)
        {
            string sql = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";//连接字符串 
            SqlConnection sqlcon = new SqlConnection(sql);// 
            string sql1 = "select * from 成员表 where 编号='" + textbox2.Text + "'";
            SqlDataAdapter sqlada = new SqlDataAdapter(sql1, sqlcon);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sqlada.Fill(ds, "基本成员表");
            DataView dv = new DataView(ds.Tables["基本成员表"]);
            DataGrid.ItemsSource = dv;
        }

        private void searchAll(object sender, RoutedEventArgs e)
        {
            string sql = "Data Source=(local);Initial Catalog=电子族谱;User ID=sa;Password=123123";//连接字符串 
            SqlConnection sqlcon = new SqlConnection(sql);// 
            string sql1 = "select * from 成员表1";
            SqlDataAdapter sqlada = new SqlDataAdapter(sql1, sqlcon);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sqlada.Fill(ds, "基本成员表");
            DataView dv = new DataView(ds.Tables["基本成员表"]);
            DataGrid.ItemsSource = dv;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请在成员管理中查看。");
        }
    }
}
