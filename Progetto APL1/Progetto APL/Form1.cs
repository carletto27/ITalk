using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;


namespace Progetto_APL
{
    public partial class frmRegister : Form
    {
        public static string email1;

        public static Client c = new Client("127.0.0.1", 4404);
  

        public frmRegister()
        {

            InitializeComponent();
           
    }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {         
            if (txtNome.Text == "" | txtPassword.Text == "" | txtComPassword.Text == "" |
                txtCognome.Text == "" | txtEmail.Text == "" | txtEmail.Text.Contains("@") == false)
            {
                MessageBox.Show("Riempire tutti i campi in modo corretto, verificare il corretto inserimento della mail", "Registrazione fallita", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtComPassword.Text)
            {                                       
                string hostName = Dns.GetHostName();
                UtenteReg u = new UtenteReg();
                u.nome = txtNome.Text;
                u.cognome = txtCognome.Text;
                u.email = txtEmail.Text;
                u.pass = txtPassword.Text;
                string myIP = Dns.GetHostEntry(hostName).AddressList[0].MapToIPv4().ToString();
                u.ip = myIP;
                u.id = 0;

               var utenteJson = JsonConvert.SerializeObject(u);

                try
                {
                    c.Send(utenteJson);
                }
                catch (Exception er)
                {
                    MessageBox.Show("Impossibile stabilire la connessione al server");
                    Application.Exit();
                }

                string str = c.Receive();
               int ritorno = Int32.Parse(str);                               
                
                if (ritorno == 1)
                {              
                     MessageBox.Show("La registrazione non e' andata a buon fine, questa E-mail e' già utilizzata", "Registrazione fallita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = "";
                    txtPassword.Text = "";
                    txtComPassword.Text = "";
                    txtCognome.Text = "";
                    txtEmail.Text = "";
                    txtNome.Focus();
                }
                else
                {
                    email1 = txtEmail.Text;
                    MessageBox.Show("La registrazione e' andata a buon fine!");
                    new MostraTab().Show();
                    this.Hide();
                }                                             
            }
            else
            {
                MessageBox.Show("Le due password non combaciano", "Registrazione fallita ",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtCognome.Text = "";
            txtEmail.Text = "";
            txtNome.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
