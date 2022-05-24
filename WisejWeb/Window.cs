using System;
using Wisej.Web;

namespace WisejWeb
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            DietProject.WisejWeb.DataAccess.UserOperations usOp= new DietProject.WisejWeb.DataAccess.UserOperations();
            var ls = usOp.GetAll();
        }
    }
}
