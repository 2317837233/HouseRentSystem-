using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace housemanagesystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent(); //
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username, password;
                username = textBox1.Text;
                password = textBox2.Text;
                //string connString = "Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;Persist Security Info=True;User ID=sa1;Password=123456";  //数据库连接字符串
                //SqlConnection connection = new SqlConnection(connString);//创建connection对象

                //打开数据库连接
                //connection.Open();
                Dao dao=new Dao();
                //创建SQL语句
                string sql1 = "select Users from managers where Users='" + username + "'";
                string sql2 = "select UserPassWord from managers where Users='" + username + "'";
                IDataReader dc1 = dao.read(sql1);
                IDataReader dc2 = dao.read(sql2);
                ////创建SqlCommand对象
                //SqlCommand command = new SqlCommand(sql, connection);
                ////创建DataAdapter对象
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                ////创建DataSet对象
                //DataSet dataSet = new DataSet();
                //dataAdapter.Fill(dataSet, "managers");
                //DataAdapter对象通过SqlCommand对象执行的SQL语句命令，将得到的结果填充到Dataset对象中

                //if (dataSet.Tables["managers"].Rows.Count < 1)
                //{
                //    MessageBox.Show("用户名不存在");
                //}
                if (dc1.Read())
                {
                    MessageBox.Show("用户名不存在");
                }
                else
                {
                    //string truepwd = dataSet.Tables[0].Rows[0]["UserPassWord"].ToString(); //数据库中存在的真实密码
                    //if (truepwd.CompareTo(password) == 0)
                    if (dc2.Read())
                    {
                        //{
                        MainWindow mainform = new MainWindow(username);
                        this.Hide();  //该窗体关闭
                        mainform.Show();
                    }
                    else
                        MessageBox.Show("密码错误");
                }
            }
            catch
            {

                MessageBox.Show("输入不正确!");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit(); //跳出程序，程序停止运行
        }
    }
}
