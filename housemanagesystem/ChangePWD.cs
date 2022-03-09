using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace housemanagesystem
{
    public partial class ChangePWD : Form
    {
        static string currentusernamestr;
        public ChangePWD(string username)
        {
            currentusernamestr = username;
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {

                MessageBox.Show("新密码不能为空！"); //消息框跳出提示信息，提示密码不能为空
            }
            if (textBox3.Text == "")
            {

                MessageBox.Show("确认密码不能为空！");  //消息框跳出提示信息，提示确认密码不能为空
            }
            if (textBox2.Text.Trim() != "")//新密码不为空时，输入满足正则表达式
            {
                //使用regex（正则表达式）进行格式设置 至少有数字、大写字母、小写字母各一个。最少3个字符、最长20个字符。
                Regex regex = new Regex(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{3,20}");
                if (regex.IsMatch(textBox3.Text))//判断格式是否符合要求
                {
                    // MessageBox.Show("输入密码格式正确!");
                }
                else
                {
                    MessageBox.Show("至少有数字、大写字母、小写字母各一个。最少3个字符、最长20个字符！");  //消息框跳出异常
                    return;  //下面的不再执行
                }
                if (textBox3.Text == textBox2.Text)
                {
                    string password = textBox2.Text.Trim();
                    Dao dao = new Dao();
                    string sql = "update managers set UserPassWord='" + password + "' where Users='" + currentusernamestr + "'";
                    //string connString = "Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;Persist Security Info=True;User ID=sa1;Password=123456";
                    //SqlConnection con = new SqlConnection(connString);//创建connection对象
                    //con.Open();  //打开数据库连接
                    //SqlCommand command = new SqlCommand(sql, con);
                    //command.ExecuteNonQuery(); //执行命令
                    dao.Execute(sql);
                    MessageBox.Show("新密码已经修改完成");  //消息框汇报密码修改完成
                }
                else
                {
                    MessageBox.Show("请输入两次相同的密码");  //消息框跳出信息，提示两次输入的密码不一样
                    return;  //返回本窗体Form12
                }
            }

        }
    }
}
