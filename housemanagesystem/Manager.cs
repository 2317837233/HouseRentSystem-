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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //String conn1 = "Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456";
            //SqlConnection sqlConnection1 = new SqlConnection(conn1);  //实例化连接对象
            Dao dao = new Dao();
            try
            {
                //sqlConnection1.Open();  //打开数据库连接
                String select_by_id1 = "select * from managers";
                //SqlCommand sqlCommand = new SqlCommand(select_by_id1, sqlConnection1);
                //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
                BindingSource bindingSource = new BindingSource();
                //bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                bindingSource.DataSource = dao.read(select_by_id1);
                dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                dataGridView1.Columns["Users"].HeaderText = "用户名";
                dataGridView1.Columns["UserPassWord"].HeaderText = "密码";
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!");  //消息框跳出异常
            }
            finally
            {
                //sqlConnection1.Close();  //数据库断开连接
                dao.DaoClose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string users = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            //SqlConnection cno = new SqlConnection("Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456");//数据库连接字符串
            Dao dao = new Dao();
            try
            {
                {
                    //cno.Open();//打开数据库连接
                    string insertStr = "INSERT INTO  managers (Users,UserPassWord)    " +
                        "VALUES ('" + users + "','" + pwd + "')";
                    //sqlcommand cmd = new sqlcommand(insertstr, cno);//使用
                    //cmd.ExecuteNonQuery();  //执行命令
                    dao.Execute(insertStr);
                    String select_by_id1 = "select * from managers";
                    //SqlCommand sqlCommand = new SqlCommand(select_by_id1, cno);
                    //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    //bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                    bindingSource.DataSource = dao.read(select_by_id1);    //通过BindingSource控件来记录查询到的数据
                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                }
            }
            catch
            {
                //消息框跳出异常
                MessageBox.Show("输入数据违反要求!");//新加的学号必须在已有学号中,课程号在已有的课程中，成绩在0到100之间
            }
            finally
            {
                //cno.Dispose();//释放连接，即数据库连接断开
                dao.DaoClose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user, pwd;
            user = textBox1.Text;
            pwd = textBox2.Text;
            //SqlConnection cno = new SqlConnection("Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456");//数据库连接字符串
            Dao dao = new Dao();
            try
            {
                {
                    //cno.Open();//打开数据库连接
                    string sqltext1 = "update managers set UserPassWord='" + pwd + "' where Users='" + user + "'";
                    //SqlCommand cmd = new SqlCommand(sqltext1, cno);//使用
                    //cmd.ExecuteNonQuery();  //执行命令
                    dao.Execute(sqltext1);
                    String select_by_id1 = "select * from managers";
                    //SqlCommand sqlCommand = new SqlCommand(select_by_id1, cno);
                    //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    //bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                    bindingSource.DataSource = dao.read(select_by_id1);    //通过BindingSource控件来记录查询到的数据
                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                }
            }
            catch
            {
                //消息框跳出异常
                MessageBox.Show("输入数据违反要求!");//新加的学号必须在已有学号中,课程号在已有的课程中，成绩在0到100之间
            }
            finally
            {
                //cno.Dispose();//释放连接，即数据库连接断开
                dao.DaoClose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string user;
            user = textBox1.Text;
            //SqlConnection cno = new SqlConnection("Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456");//数据库连接字符串
            Dao dao =new Dao();
            try
            {
                {
                    //cno.Open();//打开数据库连接
                    string sqltext1 = "delete from managers where Users='" + user + "'";
                    //SqlCommand cmd = new SqlCommand(sqltext1, cno);//使用
                    //cmd.ExecuteNonQuery();  //执行命令
                    dao.Execute(sqltext1);
                    String select_by_id1 = "select * from managers";
                    //SqlCommand sqlCommand = new SqlCommand(select_by_id1, cno);
                    //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    //bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                    bindingSource.DataSource = dao.read(select_by_id1);    //通过BindingSource控件来记录查询到的数据
                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                }
            }
            catch
            {
                //消息框跳出异常
                MessageBox.Show("输入数据违反要求!");//新加的学号必须在已有学号中,课程号在已有的课程中，成绩在0到100之间
            }
            finally
            {
                //cno.Dispose();//释放连接，即数据库连接断开
                dao.DaoClose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string user;
            user = textBox1.Text;
            //SqlConnection cno = new SqlConnection("Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456");//数据库连接字符串
            Dao dao=new Dao();
            try
            {
                {
                    //cno.Open();//打开数据库连接
                    String select_by_id1 = "select * from managers where  Users='" + user + "'";
                    //SqlCommand sqlCommand = new SqlCommand(select_by_id1, cno);
                    //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = dao.read(select_by_id1);    //通过BindingSource控件来记录查询到的数据
                    //bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                }
            }
            catch
            {
                //消息框跳出异常
                MessageBox.Show("输入数据违反要求!");//新加的学号必须在已有学号中,课程号在已有的课程中，成绩在0到100之间
            }
            finally
            {
                //cno.Dispose();//释放连接，即数据库连接断开
                dao.DaoClose();
            }
        }
    }
}

