using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace login_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=safouaneBA;Initial Catalog=loginform;Integrated Security=True");


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

     

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String email, password;
            email = email_box.Text;
            password = password_box.Text;

            try
            {
                String querry = "SELECT * FROM logininfo WHERE email ='" + email_box.Text+ "' AND password ='"+password_box.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry ,conn);

                DataTable dTable= new DataTable();   
                sda.Fill(dTable);

                if (dTable.Rows.Count > 0) {
                    email = email_box.Text;
                    password = password_box.Text;

                    menuform form2 = new menuform();
                    form2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("invalid login detail", "error",MessageBoxButtons.OK,  MessageBoxIcon.Error );
                    email_box.Clear();
                    password_box.Clear();

                    email_box.Focus();
                }

            }
            catch {
                MessageBox.Show("Error");
                       
            }
            finally
            {
                conn.Close();   
            }
       

        
        }
    }
}
