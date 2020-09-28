using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformTable3
{
    public partial class Form1 : Form
    {
        DB dB = new DB();
        string szQuery = "select * from EMPLOYEE";
        enum Radio
        {
            전체,
            재직,
            퇴사,
            남자,
            여자,
            혼인,
            미혼
        }
        Radio radioText = Radio.전체;
        Radio radioText2 = Radio.전체;
        Radio radioText3 = Radio.전체;
        public void SelectEmployee(string szQuery)
        {
            // DataSet을 가져온다
            DataSet ds = dB.GetData(szQuery);
            // DataSource 속성을 설정
            dataGridView1.DataSource = ds.Tables[0];
        }
        public void GridviewHeader()
        {
            dataGridView1.Columns[0].HeaderText = "id";
            dataGridView1.Columns[1].HeaderText = "사원이름";
            dataGridView1.Columns[2].HeaderText = "재직구분";
            dataGridView1.Columns[3].HeaderText = "사원코드";
            dataGridView1.Columns[4].HeaderText = "직위";
            dataGridView1.Columns[5].HeaderText = "직군";
            dataGridView1.Columns[6].HeaderText = "직무";
            dataGridView1.Columns[7].HeaderText = "영문이름";
            dataGridView1.Columns[8].HeaderText = "부서코드";
            dataGridView1.Columns[9].HeaderText = "부서명";
            dataGridView1.Columns[10].HeaderText = "입사일자";
            dataGridView1.Columns[11].HeaderText = "근속년수";
            dataGridView1.Columns[12].HeaderText = "전화번호";
            dataGridView1.Columns[13].HeaderText = "이메일";
            dataGridView1.Columns[14].HeaderText = "생년월일";
            dataGridView1.Columns[15].HeaderText = "주민번호";
            dataGridView1.Columns[16].HeaderText = "나이";
            dataGridView1.Columns[17].HeaderText = "학력";
            dataGridView1.Columns[18].HeaderText = "성별";
            dataGridView1.Columns[19].HeaderText = "퇴사일자";
            dataGridView1.Columns[20].HeaderText = "근속일자";
            dataGridView1.Columns[21].HeaderText = "결혼여부";
            dataGridView1.Columns[22].HeaderText = "가족부양수";
            dataGridView1.Columns[23].HeaderText = "20세미만자녀";
            dataGridView1.Columns[24].HeaderText = "장애여부";
            dataGridView1.Columns[25].HeaderText = "연금대상자";
            dataGridView1.Columns[26].HeaderText = "연금시작일자";
            dataGridView1.Columns[27].HeaderText = "급여은행";
            dataGridView1.Columns[28].HeaderText = "계좌번호";
            dataGridView1.Columns[29].HeaderText = "예금주명";
            dataGridView1.Columns[30].HeaderText = "주소1";
            dataGridView1.Columns[31].HeaderText = "주소2";
            dataGridView1.Columns[32].HeaderText = "사진";
    
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectEmployee(szQuery);
            GridviewHeader();
            radioButton3.Checked = true;
            radioButton6.Checked = true;
            radioButton9.Checked = true;
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            SelectEmployee(szQuery);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            byte[] picture;

            if (dataGridView1.CurrentRow.Cells[32].Value.ToString() == "System.Byte[]")
                picture = (byte[])dataGridView1.CurrentRow.Cells[32].Value;
            else
                picture = null;
           
            
            EmployeeForm employeeForm = new EmployeeForm();
            EmployeeForm.EmStruct form1EmStruct = new EmployeeForm.EmStruct
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString(),
                Name = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                EmCa = dataGridView1.CurrentRow.Cells[2].Value.ToString(),
                EmCode = dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                EmPo = dataGridView1.CurrentRow.Cells[4].Value.ToString(),
                EmG = dataGridView1.CurrentRow.Cells[5].Value.ToString(),
                EmT = dataGridView1.CurrentRow.Cells[6].Value.ToString(),
                EngName = dataGridView1.CurrentRow.Cells[7].Value.ToString(),
                GroupCode = dataGridView1.CurrentRow.Cells[8].Value.ToString(),
                GroupName = dataGridView1.CurrentRow.Cells[9].Value.ToString(),
                JoinEm = dataGridView1.CurrentRow.Cells[10].Value.ToString(),
                WorkYears = dataGridView1.CurrentRow.Cells[11].Value.ToString(),
                Number = dataGridView1.CurrentRow.Cells[12].Value.ToString(),
                Email = dataGridView1.CurrentRow.Cells[13].Value.ToString(),
                birth = dataGridView1.CurrentRow.Cells[14].Value.ToString(),
                Snumber = dataGridView1.CurrentRow.Cells[15].Value.ToString(),
                Age = dataGridView1.CurrentRow.Cells[16].Value.ToString(),
                Edu = dataGridView1.CurrentRow.Cells[17].Value.ToString(),
                Sex = dataGridView1.CurrentRow.Cells[18].Value.ToString(),
                OutEm = dataGridView1.CurrentRow.Cells[19].Value.ToString(),
                StandWork = dataGridView1.CurrentRow.Cells[20].Value.ToString(),
                Marriage = dataGridView1.CurrentRow.Cells[21].Value.ToString(),
                Family = dataGridView1.CurrentRow.Cells[22].Value.ToString(),
                Year20 = dataGridView1.CurrentRow.Cells[23].Value.ToString(),
                Obstacle = dataGridView1.CurrentRow.Cells[24].Value.ToString(),
                Annuity = dataGridView1.CurrentRow.Cells[25].Value.ToString(),
                SAnnuity = dataGridView1.CurrentRow.Cells[26].Value.ToString(),
                Bank = dataGridView1.CurrentRow.Cells[27].Value.ToString(),
                Accout = dataGridView1.CurrentRow.Cells[28].Value.ToString(),
                AccountName = dataGridView1.CurrentRow.Cells[29].Value.ToString(),
                Address1 = dataGridView1.CurrentRow.Cells[30].Value.ToString(),
                Address2 = dataGridView1.CurrentRow.Cells[31].Value.ToString(),
        };
            employeeForm.EmDB = form1EmStruct;
            employeeForm.Picture = picture;
            employeeForm.ShowDialog();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM employee where 1=1";
            if(radioText.ToString() != "전체")
            {
                sql += " AND EmCa = '" + radioText.ToString() + "'";
            }
            if (radioText2.ToString() != "전체")
            {
                sql += string.Format(" AND Sex = '{0}'", radioText2.ToString());
            }
            if (radioText3.ToString() != "전체")
            {
                sql += string.Format(" AND Marriage = '{0}'", radioText3.ToString());
            }
            
            SqlConnection conn = new SqlConnection();
            DataSet ds = new DataSet();

            conn.ConnectionString = @"Server=localhost; database=Member_Employee; uid=sa; pwd=sa";
            conn.Open();
           
            SqlCommand cmd = new SqlCommand("sp_ExecuteSQL", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@SQL", SqlDbType.NVarChar);
            param1.Value = sql;
            cmd.Parameters.Add(param1);

         
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];


        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioText = Radio.재직;
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioText = Radio.퇴사;
        }
        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioText = Radio.전체;
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioText2 = Radio.남자;
        }
        private void radioButton5_Click(object sender, EventArgs e)
        {
            radioText2 = Radio.여자;
        }
        private void radioButton6_Click(object sender, EventArgs e)
        {
            radioText2 = Radio.전체;
        }
        private void radioButton7_Click(object sender, EventArgs e)
        {
            radioText3 = Radio.혼인;
        }
        private void radioButton8_Click(object sender, EventArgs e)
        {
            radioText3 = Radio.미혼;
        }
        private void radioButton9_Click(object sender, EventArgs e)
        {
            radioText3 = Radio.전체;
        }


    }
}
