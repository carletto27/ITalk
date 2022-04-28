using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net;



namespace Progetto_APL
{
    
    public partial class dashboard : Form
    {
        public static string email = frmLogin.email1;
        public static string email2 = frmRegister.email1;
        public string mstrTab;
        public string mstrMsg1;
            
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
           
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {       
            string invio = "id2" + email + email2;       
            frmRegister.c.Send(invio);
            Environment.Exit(Environment.ExitCode);
        }

        private void sendMsg_Click(object sender, EventArgs e)
        {                       
            new MostraTab().Show();
            this.Hide();            
        }

        private void delUser_Click(object sender, EventArgs e)
        {
            string invio = "id5" + email + email2;
            frmRegister.c.Send(invio);
            MessageBox.Show("Utente eliminato correttamente");
            Environment.Exit(Environment.ExitCode);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            string invio = "id2" + email + email2;
            frmRegister.c.Send(invio);
            Environment.Exit(Environment.ExitCode);

        }

        private void modUser_Click(object sender, EventArgs e)
        {
            new ModUser().Show();
            this.Hide();
        }
    }
}
