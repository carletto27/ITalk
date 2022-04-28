using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Progetto_APL
{
    public partial class MostraTab : Form
    {
        public static string email = frmLogin.email1;
        public static string email2 = frmRegister.email1;
        public string mstrTab1;
        public string mstrTab;
        public string mstrMsg1;
        public Thread t1;
        readonly System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        List<List<string>> listaStr3 = new List<List<string>>();


        public void Ricezione1()
        {

            while(true)
            {             
                string str = frmRegister.c.Receive();
                    string id1 = "";

                    for (int i = 0; i < str.Length; i++)
                    {
                        char carattere = str[i];
                        if (carattere != ',')
                        {
                            id1 += carattere;

                        }
                        else
                        {
                            break;
                        }

                    }
                    int id = Int32.Parse(id1);

                    if (id == 1)
                    {
                        mstrTab = str;
                        mstrTab = mstrTab.Remove(0, 2);
                        string valore = "";
                        string valore1 = "";
                        List<string> listaStr = new List<string>();
                        List<List<string>> listaStr2 = new List<List<string>>();
                        listaStr3 = new List<List<string>>();

                    //Carlo, Lentini, .... / Concetta,Allegra,.../
                    for (int i = 0; i < mstrTab.Length; i++)
                        {
                            char carattere = mstrTab[i];
                            if (carattere != '/')
                            {
                                valore += carattere;
                            }
                            else
                            {
                                listaStr.Add(valore);
                                valore = "";
                                continue;
                            }

                        }

                        for (int i = 0; i < listaStr.Count; i++)
                        {
                            List<string> listaStr1 = new List<string>();

                            for (int j = 0; j < listaStr[i].Length; j++)
                            {
                                char carattere = listaStr[i][j];
                                if (carattere != ',')
                                {
                                    valore1 += carattere;
                                }
                                else
                                {
                                    listaStr1.Add(valore1);
                                    valore1 = "";
                                    continue;
                                }
                            }
                            listaStr1.Add(valore1);
                            valore1 = "";
                            listaStr2.Add(listaStr1);
                        }
               
                    MethodInvoker action = delegate
                    {                       
                        tabUsers.Rows.Clear();
                        tabUsers.AutoGenerateColumns = false;

                        for (int i = 0; i < listaStr2.Count; i++)
                        {
                            tabUsers.Rows.Add(listaStr2[i][0], listaStr2[i][1], listaStr2[i][2], listaStr2[i][5]);
                        }       
                    };
                    tabUsers.BeginInvoke(action);   
                
                }
                else if (id == 0)
                    {
                        mstrMsg1 = str;
                        mstrMsg1 = mstrMsg1.Remove(0, 2);
                        string email3 = "";
                        string msg = "";
                        int memo = 0;

                        string mstrMsg = frmRegister.c.Decrypt(mstrMsg1);

                    //email....,msg...
                        for (int i = 5; i < mstrMsg.Length; i++)
                        {
                            char carattere = mstrMsg[i];
                            if (carattere != ',')
                            {
                                email3 += carattere;
                            }
                            else
                            {
                                memo = i + 4;
                                break;
                            }
                        }
                        
                        for (int i = memo; i < mstrMsg.Length; i++)
                        {
                            char carattere = mstrMsg[i];
                            msg += carattere;
                        }
                        MessageBox.Show(email + email2 + " ha ricevuto un messaggio: '" + msg + "' da " + email3);
                    }
                    else if(id == 2)
                {
                    mstrMsg1 = str;
                    mstrMsg1 = mstrMsg1.Remove(0, 2);
                    MessageBox.Show("Invio fallito. Nessun utente online trovato con l'id selezionato. Ti consigliamo di tornare alla dashboard.", "Invio del messaggio fallito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }


        public MostraTab()
        {
            InitializeComponent();
            t1 = new Thread(Ricezione1);
            t1.Start();


            myTimer.Enabled = true;
            myTimer.Interval = (int)TimeSpan.FromMinutes(0.05).TotalMilliseconds;
            myTimer.Tick += Refresh;       
        }

        private void Refresh(object sender, EventArgs e)
        {
            string invio = "id4," + email + email2;
            frmRegister.c.Send(invio);
        }


        private void MostraTab_Load(object sender, EventArgs e)
        {
           
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            string invio = "id2" + email + email2;
            frmRegister.c.Send(invio);
            myTimer.Enabled = false;
            Environment.Exit(Environment.ExitCode);
        }
        
        private void goBack_Click(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
            new dashboard().Show();           
            this.Hide();
        }

        private void tabUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void sndBut_Click(object sender, EventArgs e)
        {
            string idcl = txtCod.Text;
            myTimer.Enabled = false;
            new WrMsg(idcl).Show();
            this.Hide();
        }
    }
}
