
namespace Progetto_APL
{
    partial class dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboard));
            this.sendMsg = new System.Windows.Forms.Button();
            this.modUser = new System.Windows.Forms.Button();
            this.delUser = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendMsg
            // 
            this.sendMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.sendMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendMsg.FlatAppearance.BorderSize = 0;
            this.sendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendMsg.ForeColor = System.Drawing.Color.White;
            this.sendMsg.Location = new System.Drawing.Point(47, 52);
            this.sendMsg.Name = "sendMsg";
            this.sendMsg.Size = new System.Drawing.Size(216, 35);
            this.sendMsg.TabIndex = 13;
            this.sendMsg.Text = "INVIA MESSAGGIO";
            this.sendMsg.UseVisualStyleBackColor = false;
            this.sendMsg.Click += new System.EventHandler(this.sendMsg_Click);
            // 
            // modUser
            // 
            this.modUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.modUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modUser.FlatAppearance.BorderSize = 0;
            this.modUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modUser.ForeColor = System.Drawing.Color.White;
            this.modUser.Location = new System.Drawing.Point(47, 129);
            this.modUser.Name = "modUser";
            this.modUser.Size = new System.Drawing.Size(216, 35);
            this.modUser.TabIndex = 14;
            this.modUser.Text = "MODIFICA UTENTE";
            this.modUser.UseVisualStyleBackColor = false;
            this.modUser.Click += new System.EventHandler(this.modUser_Click);
            // 
            // delUser
            // 
            this.delUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.delUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delUser.FlatAppearance.BorderSize = 0;
            this.delUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delUser.ForeColor = System.Drawing.Color.White;
            this.delUser.Location = new System.Drawing.Point(47, 213);
            this.delUser.Name = "delUser";
            this.delUser.Size = new System.Drawing.Size(216, 35);
            this.delUser.TabIndex = 15;
            this.delUser.Text = "ELIMINA ACCOUNT";
            this.delUser.UseVisualStyleBackColor = false;
            this.delUser.Click += new System.EventHandler(this.delUser_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Location = new System.Drawing.Point(47, 297);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(216, 35);
            this.logout.TabIndex = 16;
            this.logout.Text = "LOGOUT";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(304, 384);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.delUser);
            this.Controls.Add(this.modUser);
            this.Controls.Add(this.sendMsg);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.dashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sendMsg;
        private System.Windows.Forms.Button modUser;
        private System.Windows.Forms.Button delUser;
        private System.Windows.Forms.Button logout;
    }
}