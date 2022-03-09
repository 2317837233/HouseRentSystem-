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
    public partial class CompanyFinance : Form
    {
        public CompanyFinance()
        {
            InitializeComponent();
        }

        private void CompanyFinance_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection cno = new SqlConnection("Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456");//数据库连接字符串
            Dao dao = new Dao();
            IDataReader dc = null;
            try
            {

                //cno.Open();//打开数据库连接
                String select_by_id1 = "select * from  finalmoney";
                dc = dao.read(select_by_id1);
                //SqlCommand sqlCommand = new SqlCommand(select_by_id1, cno);
                //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dc;    //通过BindingSource控件来记录查询到的数据
                dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                dataGridView1.Columns["numm"].HeaderText = "编号";
                dataGridView1.Columns["years"].HeaderText = "年份";
                dataGridView1.Columns["mouth"].HeaderText = "月份";
                dataGridView1.Columns["balance"].HeaderText = "财务金额     （元）";
            }
            catch
            {
                //消息框跳出异常
                MessageBox.Show("输入数据违反要求!");//新加的学号必须在已有学号中,课程号在已有的课程中，成绩在0到100之间
            }
            finally
            {
                //cno.Dispose();//释放连接，即数据库连接断开
                dc.Close();
                dao.DaoClose();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text;
            //string connString = "Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;Persist Security Info=True;User ID=sa1;Password=123456";  //数据库连接字符串
            //SqlConnection connection = new SqlConnection(connString);//创建connection对象
            try
            {
                //打开数据库连接
                //connection.Open();
                Dao dao = new Dao();
                //创建SQL语句
                string sql = "select * from lifexpences";
                IDataReader dc = dao.read(sql);
                //创建SqlCommand对象
                //SqlCommand command = new SqlCommand(sql, connection);
                //创建DataAdapter对象
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //创建DataSet对象
                //DataSet dataSet = new DataSet();
                //dataAdapter.Fill(dataSet, "lifexpences");
                //DataTable dt = new DataTable();
                //dt = dataSet.Tables[0];
                //int j = dt.rows.count;
                double sum = 0;
                //string nianfen = dataSet.Tables[0].Rows[j - 1]["years"].ToString();
                string nianfen=null;
                string yuefen=null;
                while (dc.Read())
                {
                    nianfen = dc["years"].ToString();
                    yuefen = dc["mouth"].ToString();
                }
                //string yuefen = dataSet.Tables[0].Rows[j - 1]["mouth"].ToString();
                //for (int i = 0; i < j; i++)
                while (dc.Read())
                {
                    //sum += double.Parse(dataSet.Tables[0].Rows[i]["summoney"].ToString());
                    sum += double.Parse(dc["summoney"].ToString());
                }
                string money = sum.ToString();
                try
                {
                    string sqltext = "insert into  finalmoney values('" + num + "','" + nianfen + "','" + yuefen + "','" + money + "')";
                    //SqlCommand cmd = new SqlCommand(sqltext, connection);//使用
                    //cmd.ExecuteNonQuery();  //执行SQL命令
                    dao.Execute(sqltext);
                    MessageBox.Show("添加成功，请进行查询操作！");
                }
                catch
                {
                    MessageBox.Show("已存在此财务单号，请重新添加！");
                }
            }

            catch
            {
                MessageBox.Show("出现错误，请重新操作！");
            }
        }
    }
}

