using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformTable3
{
    public partial class EmployeeForm : Form
    {
        int iRow = 1;
        string img_file;
        DB dB = new DB();
        byte[] imageBytes;
        public byte[] Picture;
        public EmployeeForm()
        {
            InitializeComponent();

        }
        public struct EmStruct
        {
            public string
                id,
                Name,
                EmCa,
                EmCode,
                EmPo,
                EmG,
                EmT,
                EngName,
                GroupCode,
                GroupName,
                JoinEm,
                WorkYears,
                Number,
                Email,
                birth,
                Snumber,
                Age,
                Edu,
                Sex,
                OutEm,
                StandWork,
                Marriage,
                Family,
                Year20,
                Obstacle,
                Annuity,
                SAnnuity,
                Bank,
                Accout,
                AccountName,
                Address1,
                Address2;
        }
        public EmStruct EmDB = new EmStruct();

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            textBox2.Text = EmDB.Name;
            textBox1.Text = EmDB.EmCode;
            textBox3.Text = EmDB.EngName;
            textBox4.Text = EmDB.EmCa;
            textBox5.Text = EmDB.Snumber;
            textBox6.Text = EmDB.Sex;
            //textBox7.Text = EmDB.; 외국인여부
            textBox8.Text = EmDB.birth;
            //textBox9.Text = EmDB.; 생일구분
            textBox10.Text = EmDB.JoinEm;
            textBox11.Text = EmDB.StandWork;
            textBox12.Text = EmDB.OutEm;
            textBox13.Text = EmDB.Number;
            textBox14.Text = EmDB.Number;
            textBox15.Text = EmDB.Email;
            //textBox16.Text = EmDB.;  사업장
            textBox17.Text = EmDB.GroupName;
            textBox18.Text = EmDB.EmPo;
            //textBox19.Text = EmDB.직급
            textBox20.Text = EmDB.EmG;
            textBox21.Text = EmDB.EmT;
            textBox22.Text = EmDB.Family;
            textBox23.Text = EmDB.Year20;
            textBox24.Text = EmDB.Marriage;
            textBox25.Text = EmDB.Obstacle;
            textBox26.Text = EmDB.Annuity;
            textBox27.Text = EmDB.SAnnuity;
            textBox28.Text = EmDB.Bank;
            textBox29.Text = EmDB.Accout;
            textBox30.Text = EmDB.AccountName;
            textBox31.Text = EmDB.Address1;
            textBox32.Text = EmDB.Address2;


            ImageConverter converter = new ImageConverter();
            if(Picture != null)
            {
                Image img = (Image)converter.ConvertFrom(Picture);
                pictureBox1.Image = img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                imageBytes = Picture;
            }
            else
            {
                imageBytes = null;
            }
           




        }

        private void button5_Click(object sender, EventArgs e)
        {
            img_file = string.Empty;
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.InitialDirectory = @"C:\";
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                img_file = Dialog.FileName;
            }
            else if (Dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
        
                pictureBox1.Image = Bitmap.FromFile(img_file);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            string str = img_file;
            int indexImg = str.IndexOf("img") + 4;
            string imgString = str.Substring(indexImg);
            int indexdot = imgString.IndexOf(".");

            string imgEx = imgString.Substring(indexdot);
            string imgName = imgString.Substring(0, indexdot);
            label2.Text = imgEx;
            label3.Text = imgName;

            ImageConverter converter = new ImageConverter();
            imageBytes = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
            
    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            iRow = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            //textBox7.Tex  = "";
            textBox8.Text = "";
            //textBox9.Tex  = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            //textBox16.Te  = "";
            textBox17.Text = "";
            textBox18.Text = "";
            //textBox19.Te  = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (iRow == 0)
            {
                if (textBox1.TextLength > 0 && textBox2.TextLength > 0)
                {

                    SqlConnection conn = new SqlConnection();

                    conn.ConnectionString = @"Server=localhost; database=Member_Employee; uid=sa; pwd=sa";

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Employee_Insert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", textBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmCa", textBox4.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmCode", textBox1.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmPo", textBox18.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmG", textBox20.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmT", textBox21.Text));
                    cmd.Parameters.Add(new SqlParameter("@EngName ", textBox3.Text));
                    cmd.Parameters.Add(new SqlParameter("@GroupCode", ' '));
                    cmd.Parameters.Add(new SqlParameter("@GroupName", textBox17.Text));
                    cmd.Parameters.Add(new SqlParameter("@JoinEm", textBox10.Text));
                    cmd.Parameters.Add(new SqlParameter("@WorkYears", ' '));
                    cmd.Parameters.Add(new SqlParameter("@Number", textBox13.Text));
                    cmd.Parameters.Add(new SqlParameter("@Email", textBox15.Text));
                    cmd.Parameters.Add(new SqlParameter("@birth", textBox8.Text));
                    cmd.Parameters.Add(new SqlParameter("@Snumber", textBox5.Text));
                    cmd.Parameters.Add(new SqlParameter("@Age", ' '));
                    cmd.Parameters.Add(new SqlParameter("@Edu", ' '));
                    cmd.Parameters.Add(new SqlParameter("@Sex", textBox6.Text));
                    cmd.Parameters.Add(new SqlParameter("@OutEm", textBox12.Text));
                    cmd.Parameters.Add(new SqlParameter("@StandWork", textBox11.Text));
                    cmd.Parameters.Add(new SqlParameter("@Marriage", textBox24.Text));
                    cmd.Parameters.Add(new SqlParameter("@Family", textBox22.Text));
                    cmd.Parameters.Add(new SqlParameter("@Year20", textBox23.Text));
                    cmd.Parameters.Add(new SqlParameter("@Obstacle", textBox25.Text));
                    cmd.Parameters.Add(new SqlParameter("@Annuity", textBox26.Text));
                    cmd.Parameters.Add(new SqlParameter("@SAnnuity", textBox27.Text));
                    cmd.Parameters.Add(new SqlParameter("@Bank", textBox28.Text));
                    cmd.Parameters.Add(new SqlParameter("@Accout", textBox29.Text));
                    cmd.Parameters.Add(new SqlParameter("@AccountName", textBox30.Text));
                    cmd.Parameters.Add(new SqlParameter("@Address1", textBox31.Text));
                    cmd.Parameters.Add(new SqlParameter("@Address2", textBox32.Text));
              

                    cmd.Parameters.Add(new SqlParameter("@Picture", imageBytes));



                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("insert");

                }
              
            }
            else
            {
                if (textBox1.TextLength > 0 && textBox2.TextLength > 0)
                {

                    SqlConnection conn = new SqlConnection();

                    conn.ConnectionString = @"Server=localhost; database=Member_Employee; uid=sa; pwd=sa";

                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Employee_Update", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", EmDB.id));
                    cmd.Parameters.Add(new SqlParameter("@Name", textBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmCa", textBox4.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmCode", textBox1.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmPo", textBox18.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmG", textBox20.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmT", textBox21.Text));
                    cmd.Parameters.Add(new SqlParameter("@EngName ", textBox3.Text));
                    cmd.Parameters.Add(new SqlParameter("@GroupCode", ' '));
                    cmd.Parameters.Add(new SqlParameter("@GroupName", textBox17.Text));
                    cmd.Parameters.Add(new SqlParameter("@JoinEm", textBox10.Text));
                    cmd.Parameters.Add(new SqlParameter("@WorkYears", ' '));
                    cmd.Parameters.Add(new SqlParameter("@Number", textBox13.Text));
                    cmd.Parameters.Add(new SqlParameter("@Email", textBox15.Text));
                    cmd.Parameters.Add(new SqlParameter("@birth", textBox8.Text));
                    cmd.Parameters.Add(new SqlParameter("@Snumber", textBox5.Text));
                    cmd.Parameters.Add(new SqlParameter("@Age", ' '));
                    cmd.Parameters.Add(new SqlParameter("@Edu", ' '));
                    cmd.Parameters.Add(new SqlParameter("@Sex", textBox6.Text));
                    cmd.Parameters.Add(new SqlParameter("@OutEm", textBox12.Text));
                    cmd.Parameters.Add(new SqlParameter("@StandWork", textBox11.Text));
                    cmd.Parameters.Add(new SqlParameter("@Marriage", textBox24.Text));
                    cmd.Parameters.Add(new SqlParameter("@Family", textBox22.Text));
                    cmd.Parameters.Add(new SqlParameter("@Year20", textBox23.Text));
                    cmd.Parameters.Add(new SqlParameter("@Obstacle", textBox25.Text));
                    cmd.Parameters.Add(new SqlParameter("@Annuity", textBox26.Text));
                    cmd.Parameters.Add(new SqlParameter("@SAnnuity", textBox27.Text));
                    cmd.Parameters.Add(new SqlParameter("@Bank", textBox28.Text));
                    cmd.Parameters.Add(new SqlParameter("@Accout", textBox29.Text));
                    cmd.Parameters.Add(new SqlParameter("@AccountName", textBox30.Text));
                    cmd.Parameters.Add(new SqlParameter("@Address1", textBox31.Text));
                    cmd.Parameters.Add(new SqlParameter("@Address2", textBox32.Text));
                    if (pictureBox1.Image == null)
                    {
                        

                        SqlParameter paramPicture = new SqlParameter("@Picture", SqlDbType.Image);
                        paramPicture.Value = DBNull.Value;
                        cmd.Parameters.Add(paramPicture);
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@Picture", imageBytes));
                    }
                        

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("update");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string szQuery = string.Format("exec EMPLOYEE_delete {0}", "'" + EmDB.id + "'");
            if (MessageBox.Show("삭제하시겠습니까?", "확인창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataSet ds = dB.GetData(szQuery);
                iRow = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                //textBox7.Tex  = "";
                textBox8.Text = "";
                //textBox9.Tex  = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                //textBox16.Te  = "";
                textBox17.Text = "";
                textBox18.Text = "";
                //textBox19.Te  = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox24.Text = "";
                textBox25.Text = "";
                textBox26.Text = "";
                textBox27.Text = "";
                textBox28.Text = "";
                textBox29.Text = "";
                textBox30.Text = "";
                textBox31.Text = "";
                textBox32.Text = "";
                MessageBox.Show("delete");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            pictureBox1.Image = null;

        }
    }
}


