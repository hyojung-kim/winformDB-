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
    public partial class UserForm : MetroFramework.Forms.MetroForm
    {
        DB dB = new DB();
        ArrayList codeArray = new ArrayList();
        int iRow=1;
        String szQuery = "SELECT emCode FROM EMPLOYEE";
        public struct UserStruct
        {
            public string id, Sdate, Edate, UserId, UserPass, EmCode, usew, UserLv, EmName, GroupCode, GroupName;
        }

        public UserStruct userDB = new UserStruct();
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = userDB.UserId;
            textBox2.Text = userDB.UserPass;
            dateTimePicker1.Text = userDB.Sdate;
            dateTimePicker2.Text = userDB.Edate;
            textBox5.Text = userDB.UserLv;
            employeeCode.Text = userDB.EmCode;
            textBox7.Text = userDB.GroupCode;
            textBox8.Text = userDB.GroupName;
            SelectMember(szQuery);
            employeeCode.ReadOnly = true;


            for (int I = 0; I < dataGridView1.Rows.Count - 1; I++)
            {
                codeArray.Add(dataGridView1.Rows[I].Cells[0].Value.ToString());
            }



        }
        public void SelectMember(string szQuery)
        {
            // DataSet을 가져온다
            DataSet ds = dB.GetData(szQuery);
            // DataSource 속성을 설정
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            employeeCode.ReadOnly = false;
            iRow = 0;
            textBox1.Text = "";
            textBox2.Text = "";

            textBox5.Text = "";
            employeeCode.Text = "";
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Boolean Correct = false;
            if (iRow == 0)
            {
                if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox5.TextLength > 0 && employeeCode.TextLength > 0)
                {
                    for (int j = 0; j < codeArray.Count; j++)
                    {
                        if ((string)codeArray[j] == employeeCode.Text)
                        {
                            string szQuery = string.Format("EXEC User_Insert {0},{1},{2},{3},{4},{5},{6}",
                            "'" + dateTimePicker1.Text + "'", "'" + dateTimePicker2.Text + "'", "'" + textBox1.Text + "'", "'" + textBox2.Text + "'", "'" + employeeCode.Text + "'", "'" + "사용/미사용" + "'", "'" + textBox5.Text + "'");
                            DataSet ds = dB.GetData(szQuery);
                            MessageBox.Show("Insert");
                            Correct = true;

                        }
                    }

                    if (Correct == false)
                    {
                        MessageBox.Show("사원코드를 정확히 입력해주세요.");
                    }

                }
            }
            else
            {
                
                if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox5.TextLength > 0 && employeeCode.TextLength > 0)
                {

                    string szQuery = string.Format("EXEC User_update{0},{1},{2},{3},{4},{5},{6},{7}",
                    "'" + userDB.id + "'", "'" + dateTimePicker1.Text + "'", "'" + dateTimePicker2.Text + "'", "'" + textBox1.Text + "'", "'" + textBox2.Text + "'", "'" + employeeCode.Text + "'", "'" + "사용/미사용" + "'", "'" + textBox5.Text + "'");
                    DataSet ds = dB.GetData(szQuery);
                    MessageBox.Show("update");

                }

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string szQuery = string.Format("exec User_delete {0}", "'" + userDB.id + "'");
            if (MessageBox.Show("삭제하시겠습니까?", "확인창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = dB.GetData(szQuery);
                iRow = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                employeeCode.Text = "";
                MessageBox.Show("delete");
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Closing");
        }
    }
}
