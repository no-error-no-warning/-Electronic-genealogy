﻿
using Project_Z_UI.类;
using System;
using System.Windows;

namespace Project_Z_UI
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//位置居中
        }
        protected override void OnSourceInitialized(EventArgs e)//去除左上图标
        {
            IconHelper.RemoveIcon(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)  //注册按钮
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  //登录点击按钮
        {
            页面.Window2 doc = new Project_Z_UI.页面.Window2();
            doc.Owner = this;
           
            doc.ShowDialog();
            //Application.Current获得当前运行的Application
            ((App)Application.Current).Documents.Add(doc);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)  //用户隐私手册
        {

        }
    }
}
