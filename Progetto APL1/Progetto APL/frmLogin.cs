using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;



namespace Progetto_APL
{
    public partial class frmLogin : Form
    {
        public static string email1;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            string hostName = Dns.GetHostName();
            Utente u = new Utente();
            u.email = txtEmail.Text;
            u.pass = txtPassword.Text;
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].MapToIPv4().ToString();
            u.ip = myIP;
            u.id = 1;
            var utenteJson = JsonConvert.SerializeObject(u);
            try
            {
                frmRegister.c.Send(utenteJson);
            }
            catch (Exception er)
            {
                MessageBox.Show("Impossibile stabilire la connessione al server");
                Application.Exit();
            }
            string str = frmRegister.c.Receive();
            int ritorno = Int32.Parse(str);

            if (ritorno == 1)
            {
                MessageBox.Show("Accesso negato. Reinserire E-mail e password o verificare che lo stesso utente non sia loggato in un'altra finesta!", "Registrazione fallita", MessageBoxButtons.OK, MessageBoxIcon.Error);               
                txtPassword.Text = "";               
                txtEmail.Text = "";
             
                txtEmail.Focus();
            }
            else
            { 
                email1 = txtEmail.Text;
                new MostraTab().Show();
                this.Hide();        
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtPassword.Text = "";           
            txtEmail.Focus();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
               
            }
            else
            {
                txtPassword.PasswordChar = '•';
               
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
