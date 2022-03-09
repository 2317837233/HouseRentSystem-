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
    public partial class Lifeexpenses : Form
    {
        public Lifeexpenses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chaxunfangshi = "num";
            if (comboBox1.SelectedItem.ToString().Equals("单号"))
                chaxunfangshi = "listnum";
            else if (comboBox1.SelectedItem.ToString().Equals("房屋编号"))
                chaxunfangshi = "housenum";
            SqlConnection cno = new SqlConnection("Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456");//数据库连接字符串
            try
            {
                cno.Open();//打开数据库连接
                String select_by_id1 = "select * from lifexpences where " + chaxunfangshi + " like '%" + textBox1.Text + "%'";
                //String select_by_id1 = "select * from lifexpences where chaxunfangshi ='" + textBox1.Text + "'";

                SqlCommand sqlCommand = new SqlCommand(select_by_id1, cno);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                dataGridView1.DataSource = bindingSource; //将记录的数据显示在窗体的表中，并且表中只有一行
                dataGridView1.Columns["listnum"].HeaderText = "单号";
                dataGridView1.Columns["housenum"].HeaderText = "房屋编号";
                dataGridView1.Columns["preeletnum"].HeaderText = "上次电表数（度）";
                dataGridView1.Columns["thiseletnum"].HeaderText = "本次电表数（度）";
                dataGridView1.Columns["prewaternum"].HeaderText = "上次水表数（吨）";
                dataGridView1.Columns["thiswaternum"].HeaderText = "本次水表数（吨）";
                dataGridView1.Columns["net"].HeaderText = "是否缴纳网费";
                dataGridView1.Columns["property"].HeaderText = "是否缴纳物业费";
                dataGridView1.Columns["mouth"].HeaderText = "月份";
                dataGridView1.Columns["years"].HeaderText = "年份";
                dataGridView1.Columns["shourumoney"].HeaderText = "收入金额（元）";
                dataGridView1.Columns["zhichumoney"].HeaderText = "支出金额（元）";
                dataGridView1.Columns["summoney"].HeaderText = "净收入（元）";
            }
            catch
            {
                MessageBox.Show("不存在此查询数据！");
            }
            finally
            {
                cno.Dispose();//释放连接，即数据库连接断开
            }
        }

        private void Lifeexpenses_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            String conn1 = "Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456";
            SqlConnection sqlConnection1 = new SqlConnection(conn1);  //实例化连接对象
                                                                      //try
                                                                      //{
            sqlConnection1.Open();  //打开数据库连接
            comboBox2.Items.Clear();  //首先清理掉comboBox里先前保存的内容，以便之后加的时候又是全新内容
                                      //创建SQL语句
            string sql = "select housenum from house ";
            //创建SqlCommand对象


            SqlCommand command = new SqlCommand(sql, sqlConnection1);
            //创建DataAdapter对象
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            //创建DataSet对象
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "house");
            DataTable dt = new DataTable();
            dt = dataSet.Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox2.Items.Add(dt.Rows[i][0].ToString());
                }
            }

            String sqltext1 = "select * from lifexpences ";
            SqlCommand sqlCommand = new SqlCommand(sqltext1, sqlConnection1);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  ////执行命令，并读取数据
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Columns["listnum"].HeaderText = "单号";
            dataGridView1.Columns["housenum"].HeaderText = "房屋编号";
            dataGridView1.Columns["preeletnum"].HeaderText = "上次电表数（度）";
            dataGridView1.Columns["thiseletnum"].HeaderText = "本次电表数（度）";
            dataGridView1.Columns["prewaternum"].HeaderText = "上次水表数（吨）";
            dataGridView1.Columns["thiswaternum"].HeaderText = "本次水表数（吨）";
            dataGridView1.Columns["net"].HeaderText = "是否缴纳网费（元）";
            dataGridView1.Columns["property"].HeaderText = "是否缴纳物业费（元）";
            dataGridView1.Columns["mouth"].HeaderText = "月份";
            dataGridView1.Columns["years"].HeaderText = "年份";
            dataGridView1.Columns["shourumoney"].HeaderText = "收入金额（元）";
            dataGridView1.Columns["zhichumoney"].HeaderText = "支出金额（元）";
            dataGridView1.Columns["summoney"].HeaderText = "净收入（元）";


            /* }
            // catch
            // {
             //    MessageBox.Show("查询语句有误，请认真检查SQL语句!");  //消息框跳出异常
             }
             finally
             {
                 sqlConnection1.Close();  //数据库断开连接
             }*/

        }
        private void button2_Click(object sender, EventArgs e)
        {
            String conn1 = "Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456";
            SqlConnection sqlConnection1 = new SqlConnection(conn1);  //实例化连接对象
                                                                      // try{
            sqlConnection1.Open();
            string danhao, roomnum, predianbiao, dianbiao, preshuibiao, shuibiao, yuefen, nainfen, zhichu, net, wuye;
            danhao = textBox2.Text;
            roomnum = comboBox2.SelectedItem.ToString();
            predianbiao = textBox3.Text;
            dianbiao = textBox4.Text;
            preshuibiao = textBox5.Text;
            shuibiao = textBox6.Text;
            yuefen = comboBox3.SelectedItem.ToString();
            nainfen = textBox8.Text;
            zhichu = textBox7.Text;
            net = comboBox4.SelectedItem.ToString();
            wuye = comboBox5.SelectedItem.ToString();
            string sql = "select * from UnitPriceSet where mouth='" + yuefen + "'";
            SqlCommand command = new SqlCommand(sql, sqlConnection1);
            //创建DataAdapter对象
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            //创建DataSet对象
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "UnitPriceSet");
            double shuiprice = double.Parse(dataSet.Tables[0].Rows[0][1].ToString());
            double dianprice = double.Parse(dataSet.Tables[0].Rows[0][2].ToString());
            double wangfei = double.Parse(dataSet.Tables[0].Rows[0][3].ToString());
            double wuyefei = double.Parse(dataSet.Tables[0].Rows[0][4].ToString());
            string shouru;
            string jingshouru;
            string sqll = "select * from house  where housenum ='" + roomnum + "'";
            SqlCommand command1 = new SqlCommand(sqll, sqlConnection1);
            //创建DataAdapter对象
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(command1);
            //创建DataSet对象
            DataSet dataSet1 = new DataSet();
            dataAdapter1.Fill(dataSet1, "house");
            double yuezujin = double.Parse(dataSet1.Tables[0].Rows[0][7].ToString());
            if (net == "1" && wuye == "1")
            {
                shouru = ((double.Parse(dianbiao) - double.Parse(predianbiao)) * dianprice + (double.Parse(shuibiao) - double.Parse(preshuibiao)) * shuiprice + wangfei + wuyefei + yuezujin).ToString();
                jingshouru = (double.Parse(shouru) - double.Parse(zhichu)).ToString();
                try
                {
                    //sqlConnection1.Open();
                    string sqltext = "insert into lifexpences values('" + danhao + "', '" + roomnum + "', '" + predianbiao + "', '" + dianbiao + "', '" + preshuibiao + "', '" + shuibiao + "', '" + net + "', '" + wuye + "', '" + nainfen + "', '" + yuefen + "', '" + shouru + "', '" + zhichu + "', '" + jingshouru + "')";
                    SqlCommand cmd = new SqlCommand(sqltext, sqlConnection1);
                    cmd.ExecuteNonQuery();  //执行SQL命令
                    String sqltext1 = "select * from lifexpences ";
                    SqlCommand sqlCommand = new SqlCommand(sqltext1, sqlConnection1);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  //执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据


                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                    dataGridView1.Columns["listnum"].HeaderText = "单号";
                    dataGridView1.Columns["housenum"].HeaderText = "房屋编号";
                    dataGridView1.Columns["preeletnum"].HeaderText = "上次电表数（度）";
                    dataGridView1.Columns["thiseletnum"].HeaderText = "本次电表数（度）";
                    dataGridView1.Columns["prewaternum"].HeaderText = "上次水表数（吨）";
                    dataGridView1.Columns["thiswaternum"].HeaderText = "本次水表数（吨）";
                    dataGridView1.Columns["net"].HeaderText = "是否缴纳网费";
                    dataGridView1.Columns["property"].HeaderText = "是否缴纳物业费";
                    dataGridView1.Columns["mouth"].HeaderText = "月份";
                    dataGridView1.Columns["years"].HeaderText = "年份";
                    dataGridView1.Columns["shourumoney"].HeaderText = "收入金额（元）";
                    dataGridView1.Columns["zhichumoney"].HeaderText = "支出金额（元）";
                    dataGridView1.Columns["summoney"].HeaderText = "净收入（元）";
                }
                catch
                {
                    MessageBox.Show("出现错误，请重新添加！");
                }
            }
            else if (net == "0" && wuye == "1")
            {
                shouru = ((double.Parse(dianbiao) - double.Parse(predianbiao)) * dianprice + (double.Parse(shuibiao) - double.Parse(preshuibiao)) * shuiprice + wuyefei + yuezujin).ToString();
                jingshouru = (double.Parse(shouru) - double.Parse(zhichu)).ToString();
                try
                {
                    // sqlConnection1.Open();
                    string sqltext = "insert into lifexpences values('" + danhao + "', '" + roomnum + "', '" + predianbiao + "', '" + dianbiao + "', '" + preshuibiao + "', '" + shuibiao + "', '" + net + "', '" + wuye + "', '" + nainfen + "', '" + yuefen + "', '" + shouru + "', '" + zhichu + "', '" + jingshouru + "')";
                    SqlCommand cmd = new SqlCommand(sqltext, sqlConnection1);
                    cmd.ExecuteNonQuery();  //执行SQL命令
                    String sqltext1 = "select * from lifexpences ";
                    SqlCommand sqlCommand = new SqlCommand(sqltext1, sqlConnection1);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  //执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                    dataGridView1.Columns["listnum"].HeaderText = "单号";
                    dataGridView1.Columns["housenum"].HeaderText = "房屋编号";
                    dataGridView1.Columns["preeletnum"].HeaderText = "上次电表数（度）";
                    dataGridView1.Columns["thiseletnum"].HeaderText = "本次电表数（度）";
                    dataGridView1.Columns["prewaternum"].HeaderText = "上次水表数（吨）";
                    dataGridView1.Columns["thiswaternum"].HeaderText = "本次水表数（吨）";
                    dataGridView1.Columns["net"].HeaderText = "是否缴纳网费";
                    dataGridView1.Columns["property"].HeaderText = "是否缴纳物业费";
                    dataGridView1.Columns["mouth"].HeaderText = "月份";
                    dataGridView1.Columns["years"].HeaderText = "年份";
                    dataGridView1.Columns["shourumoney"].HeaderText = "收入金额（元）";
                    dataGridView1.Columns["zhichumoney"].HeaderText = "支出金额（元）";
                    dataGridView1.Columns["summoney"].HeaderText = "净收入（元）";
                }
                catch
                {
                    MessageBox.Show("已存在该单号，请重新添加！");

                }
            }
            else if (net == "1" && wuye == "0")
            {
                shouru = ((double.Parse(dianbiao) - double.Parse(predianbiao)) * dianprice + (double.Parse(shuibiao) - double.Parse(preshuibiao)) * shuiprice + wangfei + yuezujin).ToString();
                jingshouru = (double.Parse(shouru) - double.Parse(zhichu)).ToString(); ;
                try
                {


                    //sqlConnection1.Open();
                    string sqltext = "insert into lifexpences values('" + danhao + "', '" + roomnum + "', '" + predianbiao + "', '" + dianbiao + "', '" + preshuibiao + "', '" + shuibiao + "', '" + net + "', '" + wuye + "', '" + nainfen + "', '" + yuefen + "', '" + shouru + "', '" + zhichu + "', '" + jingshouru + "')";
                    SqlCommand cmd = new SqlCommand(sqltext, sqlConnection1);
                    cmd.ExecuteNonQuery();  //执行SQL命令
                    String sqltext1 = "select * from lifexpences ";
                    SqlCommand sqlCommand = new SqlCommand(sqltext1, sqlConnection1);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  //执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                    dataGridView1.Columns["listnum"].HeaderText = "单号";
                    dataGridView1.Columns["housenum"].HeaderText = "房屋编号";
                    dataGridView1.Columns["preeletnum"].HeaderText = "上次电表数（度）";
                    dataGridView1.Columns["thiseletnum"].HeaderText = "本次电表数（度）";
                    dataGridView1.Columns["prewaternum"].HeaderText = "上次水表数（吨）";
                    dataGridView1.Columns["thiswaternum"].HeaderText = "本次水表数（吨）";
                    dataGridView1.Columns["net"].HeaderText = "是否缴纳网费";
                    dataGridView1.Columns["property"].HeaderText = "是否缴纳物业费";
                    dataGridView1.Columns["mouth"].HeaderText = "月份";
                    dataGridView1.Columns["years"].HeaderText = "年份";
                    dataGridView1.Columns["shourumoney"].HeaderText = "收入金额（元）";
                    dataGridView1.Columns["zhichumoney"].HeaderText = "支出金额（元）";
                    dataGridView1.Columns["summoney"].HeaderText = "净收入（元）";
                }
                catch
                {
                    MessageBox.Show("已存在该单号，请重新添加！");
                    throw;
                }
            }
            else if (net == "0" && wuye == "0")
            {
                shouru = ((double.Parse(dianbiao) - double.Parse(predianbiao)) * dianprice + (double.Parse(shuibiao) - double.Parse(preshuibiao)) * shuiprice + yuezujin).ToString();
                jingshouru = (double.Parse(shouru) - double.Parse(zhichu)).ToString(); ;
                try
                {
                    //sqlConnection1.Open();
                    string sqltext = "insert into lifexpences values('" + danhao + "', '" + roomnum + "', '" + predianbiao + "', '" + dianbiao + "', '" + preshuibiao + "', '" + shuibiao + "', '" + net + "', '" + wuye + "', '" + nainfen + "', '" + yuefen + "', '" + shouru + "', '" + zhichu + "', '" + jingshouru + "')";
                    SqlCommand cmd = new SqlCommand(sqltext, sqlConnection1);
                    cmd.ExecuteNonQuery();  //执行SQL命令
                    String sqltext1 = "select * from lifexpences ";
                    SqlCommand sqlCommand = new SqlCommand(sqltext1, sqlConnection1);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();  //执行命令，并读取数据
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;    //通过BindingSource控件来记录查询到的数据
                    dataGridView1.DataSource = bindingSource;   //将记录的数据显示在窗体的表中，并且表中只有一行
                    dataGridView1.Columns["listnum"].HeaderText = "单号";
                    dataGridView1.Columns["housenum"].HeaderText = "房屋编号";
                    dataGridView1.Columns["preeletnum"].HeaderText = "上次电表数（度）";
                    dataGridView1.Columns["thiseletnum"].HeaderText = "本次电表数（度）";
                    dataGridView1.Columns["prewaternum"].HeaderText = "上次水表数（吨）";
                    dataGridView1.Columns["thiswaternum"].HeaderText = "本次水表数（吨）";
                    dataGridView1.Columns["net"].HeaderText = "是否缴纳网费";
                    dataGridView1.Columns["property"].HeaderText = "是否缴纳物业费";
                    dataGridView1.Columns["mouth"].HeaderText = "月份";
                    dataGridView1.Columns["years"].HeaderText = "年份";
                    dataGridView1.Columns["shourumoney"].HeaderText = "收入金额（元）";
                    dataGridView1.Columns["zhichumoney"].HeaderText = "支出金额（元）";
                    dataGridView1.Columns["summoney"].HeaderText = "净收入（元）";
                }
                catch
                {
                    MessageBox.Show("已存在该单号，请重新添加！");
                    throw;
                }
            }
            //  }
            //catch (Exception)
            //{
            //  MessageBox.Show("出现错误，请重新进行！");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string num = textBox2.Text;
            SqlConnection cno = new SqlConnection("Data Source=DESKTOP-BETU3VN;Initial Catalog=housemanage;User ID=sa1;Password=123456");//数据库连接字符串
            try
            {
                cno.Open();//打开数据库连接
                String select_by_id1 = "select * from lifexpences where  listnum ='" + textBox2.Text + "'";
                //String select_by_id1 = "select * from lifexpences where chaxunfangshi ='" + textBox1.Text + "'";
                SqlCommand command = new SqlCommand(select_by_id1, cno);
                //创建DataAdapter对象
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                //创建DataSet对象
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "lifexpences");
                comboBox3.Text = ds.Tables[0].Rows[0]["mouth"].ToString();
                comboBox2.Text = ds.Tables[0].Rows[0]["housenum"].ToString(); ;
                textBox3.Text = ds.Tables[0].Rows[0]["preeletnum"].ToString(); ;
                textBox4.Text = ds.Tables[0].Rows[0]["thiseletnum"].ToString(); ;
                textBox5.Text = ds.Tables[0].Rows[0]["prewaternum"].ToString(); ;
                textBox6.Text = ds.Tables[0].Rows[0]["thiswaternum"].ToString(); ;
                textBox8.Text = ds.Tables[0].Rows[0]["years"].ToString(); ;
                textBox7.Text = ds.Tables[0].Rows[0]["zhichumoney"].ToString(); ;
                comboBox4.Text = ds.Tables[0].Rows[0]["net"].ToString(); ;
                comboBox5.Text = ds.Tables[0].Rows[0]["property"].ToString();
            }
            catch
            {
                MessageBox.Show("不存在此查询数据！");
            }
            finally
            {
                cno.Dispose();//释放连接，即数据库连接断开
            }
        }
    }
}
