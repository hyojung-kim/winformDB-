using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformTable2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        DB dB = new DB();
        string szQuery = "select * from MEMBER as M inner join EMPLOYEE as E on M.EmCode = E.EmCode";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectMember(szQuery);
            
            GridviewHeader();
        }

        public void SelectMember(string szQuery)
        {
            // DataSet을 가져온다
            DataSet ds = dB.GetData(szQuery);
            // DataSource 속성을 설정
            metroGrid1.DataSource = ds.Tables[0];
        }
        public void GridviewHeader()
        {
            metroGrid1.Columns[0].HeaderText = "id";
            metroGrid1.Columns[1].HeaderText = "시작일자";
            metroGrid1.Columns[2].HeaderText = "종료일자";
            metroGrid1.Columns[3].HeaderText = "사용자ID";
            metroGrid1.Columns[4].HeaderText = "비밀번호";
            metroGrid1.Columns[5].HeaderText = "사원번호";
            metroGrid1.Columns[6].HeaderText = "사용여부";
            metroGrid1.Columns[7].HeaderText = "레 벨";
            metroGrid1.Columns[8].Visible = false;
            metroGrid1.Columns[9].Visible = false;
            metroGrid1.Columns[10].Visible = false;
            metroGrid1.Columns[11].Visible = false;
            metroGrid1.Columns[12].Visible = false;

        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            SelectMember(szQuery);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
          
            UserForm userForm = new UserForm();
            UserForm.UserStruct form1userStruct = new UserForm.UserStruct
            {
                id = metroGrid1.CurrentRow.Cells[0].Value.ToString(),
                Sdate = metroGrid1.CurrentRow.Cells[1].Value.ToString(),
                Edate = metroGrid1.CurrentRow.Cells[2].Value.ToString(),
                UserId = metroGrid1.CurrentRow.Cells[3].Value.ToString(),
                UserPass = metroGrid1.CurrentRow.Cells[4].Value.ToString(),
                EmCode = metroGrid1.CurrentRow.Cells[5].Value.ToString(),
                usew = metroGrid1.CurrentRow.Cells[6].Value.ToString(),
                UserLv = metroGrid1.CurrentRow.Cells[7].Value.ToString(),
                EmName = metroGrid1.CurrentRow.Cells[10].Value.ToString(),
                GroupCode = metroGrid1.CurrentRow.Cells[11].Value.ToString(),
                GroupName = metroGrid1.CurrentRow.Cells[12].Value.ToString()
            };
         
            userForm.userDB = form1userStruct;
     
            userForm.ShowDialog();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
