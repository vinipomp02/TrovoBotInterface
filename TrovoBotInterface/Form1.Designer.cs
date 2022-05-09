namespace TrovoBotInterface
{
    partial class TrovoBot
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrovoBot));
            this.btnStartIshi = new System.Windows.Forms.Button();
            this.btnStartBia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnStopIshi = new System.Windows.Forms.Button();
            this.btnStopBia = new System.Windows.Forms.Button();
            this.lblActiveIshi = new System.Windows.Forms.Label();
            this.lblActiveBia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartIshi
            // 
            resources.ApplyResources(this.btnStartIshi, "btnStartIshi");
            this.btnStartIshi.Name = "btnStartIshi";
            this.btnStartIshi.UseVisualStyleBackColor = true;
            this.btnStartIshi.Click += new System.EventHandler(this.btnStartIshi_Click);
            // 
            // btnStartBia
            // 
            resources.ApplyResources(this.btnStartBia, "btnStartBia");
            this.btnStartBia.Name = "btnStartBia";
            this.btnStartBia.UseVisualStyleBackColor = true;
            this.btnStartBia.Click += new System.EventHandler(this.btnStartBia_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtLogin
            // 
            resources.ApplyResources(this.txtLogin, "txtLogin");
            this.txtLogin.Name = "txtLogin";
            // 
            // txtSenha
            // 
            resources.ApplyResources(this.txtSenha, "txtSenha");
            this.txtSenha.Name = "txtSenha";
            // 
            // lblHeader
            // 
            resources.ApplyResources(this.lblHeader, "lblHeader");
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHeader.Name = "lblHeader";
            // 
            // btnStopIshi
            // 
            resources.ApplyResources(this.btnStopIshi, "btnStopIshi");
            this.btnStopIshi.Name = "btnStopIshi";
            this.btnStopIshi.UseVisualStyleBackColor = true;
            this.btnStopIshi.Click += new System.EventHandler(this.btnStopIshi_Click);
            // 
            // btnStopBia
            // 
            resources.ApplyResources(this.btnStopBia, "btnStopBia");
            this.btnStopBia.Name = "btnStopBia";
            this.btnStopBia.UseVisualStyleBackColor = true;
            this.btnStopBia.Click += new System.EventHandler(this.btnStopBia_Click);
            // 
            // lblActiveIshi
            // 
            resources.ApplyResources(this.lblActiveIshi, "lblActiveIshi");
            this.lblActiveIshi.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveIshi.ForeColor = System.Drawing.Color.Red;
            this.lblActiveIshi.Name = "lblActiveIshi";
            // 
            // lblActiveBia
            // 
            resources.ApplyResources(this.lblActiveBia, "lblActiveBia");
            this.lblActiveBia.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveBia.ForeColor = System.Drawing.Color.Red;
            this.lblActiveBia.Name = "lblActiveBia";
            // 
            // TrovoBot
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblActiveBia);
            this.Controls.Add(this.lblActiveIshi);
            this.Controls.Add(this.btnStopBia);
            this.Controls.Add(this.btnStopIshi);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartBia);
            this.Controls.Add(this.btnStartIshi);
            this.Name = "TrovoBot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartIshi;
        private Button btnStartBia;
        private Label label1;
        private Label label2;
        private TextBox txtLogin;
        private TextBox txtSenha;
        private Label lblHeader;
        private Button btnStopIshi;
        private Button btnStopBia;
        private Label lblActiveIshi;
        private Label lblActiveBia;
    }
}