using System.Collections.Generic;
using System.Windows;

namespace Project_Z_UI
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private List<Project_Z_UI.页面.Window2> documents = new List<Project_Z_UI.页面.Window2>();
        public List<Project_Z_UI.页面.Window2> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

    }
}
