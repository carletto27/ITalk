using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Progetto_APL
{
    public partial class WrMsg : Form
    {
        public static string email = frmLogin.email1;
        public static string email2 = frmRegister.email1;
        public string idcl;

        public WrMsg(string idcl1)
        {
            InitializeComponent();
            idcl = idcl1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            string invio = "id2" + email + email2;
            frmRegister.c.Send(invio);
            Environment.Exit(Environment.ExitCode);
        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void SndBut_Click(object sender, EventArgs e)
        {
            string msg = "";

            try
            {
                string path = "C:/Users/lillo/Desktop/Advanced programming languages/Progetto APL1/Test.txt";
                StreamWriter sw = new StreamWriter(path);
                string msg1 = txtMsg.Text;
                sw.WriteLine(msg1);
                sw.Close();

                string msg2;
                StreamReader sr = new StreamReader(path);
                msg= sr.ReadLine();
                sr.Close();
               
                bool result = File.Exists(path);
                if (result == true)
                {
                    File.Delete(path);
                }
                else
                {
                    MessageBox.Show("File non trovato!", "Invio fallito!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }          
            }
            catch (Exception er)
            {
                MessageBox.Show("Errore " + er.Message);              
            }
            string invio1 = "id3,idcl" + idcl + ",";
            string invio2 = "email"+email + email2 + ",msg" + msg;
            string invio3 = frmRegister.c.Encrypt(invio2);
            string invio = invio1 + invio3;

            frmRegister.c.Send(invio);
            txtMsg.Text = "";
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }
    }
}
