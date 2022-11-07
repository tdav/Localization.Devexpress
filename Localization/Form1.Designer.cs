namespace Localization
{
    partial class Form1
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
            this.ParseDevexpress = new DevExpress.XtraEditors.SimpleButton();
            this.Translate = new DevExpress.XtraEditors.SimpleButton();
            this.GoYandex = new DevExpress.XtraEditors.SimpleButton();
            this.GoDevexpress = new DevExpress.XtraEditors.SimpleButton();
            this.InsertTransToDX = new DevExpress.XtraEditors.SimpleButton();
            this.btnHttpClient = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // ParseDevexpress
            // 
            this.ParseDevexpress.Location = new System.Drawing.Point(155, 62);
            this.ParseDevexpress.Name = "ParseDevexpress";
            this.ParseDevexpress.Size = new System.Drawing.Size(75, 23);
            this.ParseDevexpress.TabIndex = 0;
            this.ParseDevexpress.Text = "Devexpress";
            this.ParseDevexpress.Click += new System.EventHandler(this.ParseDevexpress_Click);
            // 
            // Translate
            // 
            this.Translate.Location = new System.Drawing.Point(368, 62);
            this.Translate.Name = "Translate";
            this.Translate.Size = new System.Drawing.Size(75, 23);
            this.Translate.TabIndex = 1;
            this.Translate.Text = "trans";
            this.Translate.Click += new System.EventHandler(this.ParseYandex_Click);
            // 
            // GoYandex
            // 
            this.GoYandex.Location = new System.Drawing.Point(262, 62);
            this.GoYandex.Name = "GoYandex";
            this.GoYandex.Size = new System.Drawing.Size(75, 23);
            this.GoYandex.TabIndex = 2;
            this.GoYandex.Text = "yandex";
            this.GoYandex.Click += new System.EventHandler(this.GoYandex_Click);
            // 
            // GoDevexpress
            // 
            this.GoDevexpress.Location = new System.Drawing.Point(54, 62);
            this.GoDevexpress.Name = "GoDevexpress";
            this.GoDevexpress.Size = new System.Drawing.Size(75, 23);
            this.GoDevexpress.TabIndex = 3;
            this.GoDevexpress.Text = "DX login";
            this.GoDevexpress.Click += new System.EventHandler(this.GoDevexrpess_Click);
            // 
            // InsertTransToDX
            // 
            this.InsertTransToDX.Location = new System.Drawing.Point(461, 62);
            this.InsertTransToDX.Name = "InsertTransToDX";
            this.InsertTransToDX.Size = new System.Drawing.Size(75, 23);
            this.InsertTransToDX.TabIndex = 4;
            this.InsertTransToDX.Text = "Insert trans";
            this.InsertTransToDX.Click += new System.EventHandler(this.TranslateDevexpress_Click);
            // 
            // btnHttpClient
            // 
            this.btnHttpClient.Location = new System.Drawing.Point(54, 162);
            this.btnHttpClient.Name = "btnHttpClient";
            this.btnHttpClient.Size = new System.Drawing.Size(75, 23);
            this.btnHttpClient.TabIndex = 5;
            this.btnHttpClient.Text = "HttpClient";
            this.btnHttpClient.Click += new System.EventHandler(this.btnHttpClient_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(191, 162);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "HttpClient";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 297);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnHttpClient);
            this.Controls.Add(this.InsertTransToDX);
            this.Controls.Add(this.GoDevexpress);
            this.Controls.Add(this.GoYandex);
            this.Controls.Add(this.Translate);
            this.Controls.Add(this.ParseDevexpress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton ParseDevexpress;
        private DevExpress.XtraEditors.SimpleButton Translate;
        private DevExpress.XtraEditors.SimpleButton GoYandex;
        private DevExpress.XtraEditors.SimpleButton GoDevexpress;
        private DevExpress.XtraEditors.SimpleButton InsertTransToDX;
        private DevExpress.XtraEditors.SimpleButton btnHttpClient;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

