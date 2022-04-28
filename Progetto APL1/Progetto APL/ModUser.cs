using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Progetto_APL
{
    public partial class ModUser : Form
    {
        public static string email = frmLogin.email1;
        public static string email2 = frmRegister.email1;
        public ModUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            string invio = "id2" + email + email2;
            frmRegister.c.Send(invio);
            Environment.Exit(Environment.ExitCode);
        }

        private void modBut_Click(object sender, EventArgs e)
        {


            if (CheckbxModNome.Checked && !CheckbxModCognome.Checked && !CheckbxModPass.Checked )
            {            
                string str = txtNome.Text;
                string invio = "id6,id0," + email + email2 + ","+str;
                frmRegister.c.Send(invio);
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
                CheckbxModNome.Checked = false;
            }
            else if (!CheckbxModNome.Checked && CheckbxModCognome.Checked && !CheckbxModPass.Checked)
            {
                string str = txtCognome.Text;
                string invio = "id6,id1," + email + email2 + "," + str;
                frmRegister.c.Send(invio);
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
                CheckbxModCognome.Checked = false;
            }
            else if (!CheckbxModNome.Checked && !CheckbxModCognome.Checked && CheckbxModPass.Checked)
            {
                string str = txtPass.Text;
                string invio = "id6,id2," + email + email2 + "," + str;
                frmRegister.c.Send(invio);
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
                CheckbxModPass.Checked = false;

            }
            else if (CheckbxModNome.Checked && CheckbxModCognome.Checked && !CheckbxModPass.Checked)
            {
                string str = txtNome.Text;
                string str1 = txtCognome.Text;
                string invio = "id6,id3," + email + email2 + "," + str + ","+ str1;
                frmRegister.c.Send(invio);
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
                CheckbxModNome.Checked = false;
                CheckbxModCognome.Checked = false;
            }
            else if (CheckbxModNome.Checked && !CheckbxModCognome.Checked && CheckbxModPass.Checked)
            {
                string str = txtNome.Text;
                string str1 = txtPass.Text;
                string invio = "id6,id4," + email + email2 + "," + str + "," + str1;
                frmRegister.c.Send(invio);
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
                CheckbxModNome.Checked = false;
                CheckbxModPass.Checked = false;
            }
            else if (!CheckbxModNome.Checked && CheckbxModCognome.Checked && CheckbxModPass.Checked)
            {
                string str = txtCognome.Text;
                string str1 = txtPass.Text;
                string invio = "id6,id5," + email + email2 + "," + str + "," + str1;
                frmRegister.c.Send(invio);
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
                CheckbxModCognome.Checked = false;
                CheckbxModPass.Checked = false;
            }
            else if (CheckbxModNome.Checked && CheckbxModCognome.Checked && CheckbxModPass.Checked)
            {
                string str = txtNome.Text;
                string str1 = txtCognome.Text;
                string str2 = txtPass.Text;
                string invio = "id6,id6," + email + email2 + "," + str + "," + str1+ ", " + str2;
                frmRegister.c.Send(invio);
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
                CheckbxModNome.Checked = false;
                CheckbxModCognome.Checked = false;
                CheckbxModPass.Checked = false;
            }
            else
            {
                MessageBox.Show("Non Vuoi modicare nulla? Torna indietro!");
                txtNome.Text = "";
                txtCognome.Text = "";
                txtPass.Text = "";
            }
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }
    }
}
