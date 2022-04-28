
namespace Progetto_APL
{
    partial class ModUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModUser));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckbxModNome = new System.Windows.Forms.CheckBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.Label = new System.Windows.Forms.Label();
            this.CheckbxModCognome = new System.Windows.Forms.CheckBox();
            this.txtCognome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckbxModPass = new System.Windows.Forms.CheckBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.modBut = new System.Windows.Forms.Button();
            this.goBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Modifica Utente! ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Non puoi modificare la tua mail! E\' il tuo identificativo! ";
            // 
            // CheckbxModNome
            // 
            this.CheckbxModNome.AutoSize = true;
            this.CheckbxModNome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckbxModNome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckbxModNome.Location = new System.Drawing.Point(196, 171);
            this.CheckbxModNome.Name = "CheckbxModNome";
            this.CheckbxModNome.Size = new System.Drawing.Size(154, 22);
            this.CheckbxModNome.TabIndex = 2;
            this.CheckbxModNome.Text = "Clicca per modificare!";
            this.CheckbxModNome.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNome.Location = new System.Drawing.Point(134, 137);
            this.txtNome.Multiline = true;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(216, 28);
            this.txtNome.TabIndex = 1;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(134, 116);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(44, 18);
            this.Label.TabIndex = 20;
            this.Label.Text = "Nome";
            this.Label.Click += new System.EventHandler(this.label3_Click);
            // 
            // CheckbxModCognome
            // 
            this.CheckbxModCognome.AutoSize = true;
            this.CheckbxModCognome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckbxModCognome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckbxModCognome.Location = new System.Drawing.Point(196, 255);
            this.CheckbxModCognome.Name = "CheckbxModCognome";
            this.CheckbxModCognome.Size = new System.Drawing.Size(154, 22);
            this.CheckbxModCognome.TabIndex = 4;
            this.CheckbxModCognome.Text = "Clicca per modificare!";
            this.CheckbxModCognome.UseVisualStyleBackColor = true;
            // 
            // txtCognome
            // 
            this.txtCognome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtCognome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCognome.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCognome.Location = new System.Drawing.Point(134, 221);
            this.txtCognome.Multiline = true;
            this.txtCognome.Name = "txtCognome";
            this.txtCognome.Size = new System.Drawing.Size(216, 28);
            this.txtCognome.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cognome";
            // 
            // CheckbxModPass
            // 
            this.CheckbxModPass.AutoSize = true;
            this.CheckbxModPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckbxModPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckbxModPass.Location = new System.Drawing.Point(196, 341);
            this.CheckbxModPass.Name = "CheckbxModPass";
            this.CheckbxModPass.Size = new System.Drawing.Size(154, 22);
            this.CheckbxModPass.TabIndex = 6;
            this.CheckbxModPass.Text = "Clicca per modificare!";
            this.CheckbxModPass.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPass.Location = new System.Drawing.Point(134, 307);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(216, 28);
            this.txtPass.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(462, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Spunta i campi che vuoi modificare e poi clicca su modifica!";
            // 
            // modBut
            // 
            this.modBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.modBut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modBut.FlatAppearance.BorderSize = 0;
            this.modBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modBut.ForeColor = System.Drawing.Color.White;
            this.modBut.Location = new System.Drawing.Point(134, 394);
            this.modBut.Name = "modBut";
            this.modBut.Size = new System.Drawing.Size(216, 35);
            this.modBut.TabIndex = 7;
            this.modBut.Text = "MODIFICA";
            this.modBut.UseVisualStyleBackColor = false;
            this.modBut.Click += new System.EventHandler(this.modBut_Click);
            // 
            // goBack
            // 
            this.goBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.goBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBack.FlatAppearance.BorderSize = 0;
            this.goBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBack.ForeColor = System.Drawing.Color.White;
            this.goBack.Location = new System.Drawing.Point(134, 441);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(216, 35);
            this.goBack.TabIndex = 30;
            this.goBack.Text = "Torna indietro";
            this.goBack.UseVisualStyleBackColor = false;
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
            // 
            // ModUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(483, 488);
            this.Controls.Add(this.goBack);
            this.Controls.Add(this.modBut);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CheckbxModPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckbxModCognome);
            this.Controls.Add(this.txtCognome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CheckbxModNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ModUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifica Utente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckbxModNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.CheckBox CheckbxModCognome;
        private System.Windows.Forms.TextBox txtCognome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CheckbxModPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button modBut;
        private System.Windows.Forms.Button goBack;
    }
}