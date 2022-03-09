using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace housemanagesystem
{
    public partial class MainWindow : Form
    {
        static string username;
        public MainWindow()
        {
            username = "administrator";
            InitializeComponent();  //初始化控件
        }
        public MainWindow(string user)
        {
            username = user;
            InitializeComponent();  ////初始化控件
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UnitPrice oset = new UnitPrice();
            oset.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Manager minf = new Manager();
            minf.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ChangePWD user = new ChangePWD(username);
            user.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Roominf roominf = new Roominf();
            roominf.TopLevel = false;
            roominf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            roominf.WindowState = FormWindowState.Normal;
            roominf.Dock = DockStyle.Fill;
            roominf.KeyPreview = true;
            roominf.Parent = splitContainer1.Panel2;
            roominf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Userinf userinf = new Userinf();
            userinf.TopLevel = false;
            userinf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            userinf.WindowState = FormWindowState.Normal;
            userinf.Dock = DockStyle.Fill;
            userinf.KeyPreview = true;
            userinf.Parent = splitContainer1.Panel2;
            userinf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Rent rentinf = new Rent();
            rentinf.TopLevel = false;
            rentinf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            rentinf.WindowState = FormWindowState.Normal;
            rentinf.Dock = DockStyle.Fill;
            rentinf.KeyPreview = true;
            rentinf.Parent = splitContainer1.Panel2;
            rentinf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Lifeexpenses binf = new Lifeexpenses();
            binf.TopLevel = false;
            binf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            binf.WindowState = FormWindowState.Normal;
            binf.Dock = DockStyle.Fill;
            binf.KeyPreview = true;
            binf.Parent = splitContainer1.Panel2;
            binf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            CompanyFinance finance = new CompanyFinance();
            finance.TopLevel = false;
            finance.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            finance.WindowState = FormWindowState.Normal;
            finance.Dock = DockStyle.Fill;
            finance.KeyPreview = true;
            finance.Parent = splitContainer1.Panel2;
            finance.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "房屋租赁管理系统       当前用户：" + username;
            if (username.Equals("adm"))
                toolStripButton3.Visible = false;  //Button3消失
            else
                toolStripButton2.Visible = false;  //Button2消失
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();  //跳出程序，程序停止运行
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
