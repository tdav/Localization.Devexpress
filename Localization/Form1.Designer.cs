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
            this.SuspendLayout();
            // 
            // ParseDevexpress
            // 
            this.ParseDevexpress.Location = new System.Drawing.Point(138, 61);
            this.ParseDevexpress.Name = "ParseDevexpress";
            this.ParseDevexpress.Size = new System.Drawing.Size(75, 23);
            this.ParseDevexpress.TabIndex = 0;
            this.ParseDevexpress.Text = "Devexpress";
            this.ParseDevexpress.Click += new System.EventHandler(this.ParseDevexpress_Click);
            // 
            // Translate
            // 
            this.Translate.Location = new System.Drawing.Point(381, 3);
            this.Translate.Name = "Translate";
            this.Translate.Size = new System.Drawing.Size(75, 23);
            this.Translate.TabIndex = 1;
            this.Translate.Text = "trans";
            this.Translate.Click += new System.EventHandler(this.ParseYandex_Click);
            // 
            // GoYandex
            // 
            this.GoYandex.Location = new System.Drawing.Point(290, 61);
            this.GoYandex.Name = "GoYandex";
            this.GoYandex.Size = new System.Drawing.Size(75, 23);
            this.GoYandex.TabIndex = 2;
            this.GoYandex.Text = "yandex";
            this.GoYandex.Click += new System.EventHandler(this.GoYandex_Click);
            // 
            // GoDevexpress
            // 
            this.GoDevexpress.Location = new System.Drawing.Point(91, 3);
            this.GoDevexpress.Name = "GoDevexpress";
            this.GoDevexpress.Size = new System.Drawing.Size(75, 23);
            this.GoDevexpress.TabIndex = 3;
            this.GoDevexpress.Text = "DX login";
            this.GoDevexpress.Click += new System.EventHandler(this.GoDevexrpess_Click);
            // 
            // InsertTransToDX
            // 
            this.InsertTransToDX.Location = new System.Drawing.Point(217, 128);
            this.InsertTransToDX.Name = "InsertTransToDX";
            this.InsertTransToDX.Size = new System.Drawing.Size(75, 23);
            this.InsertTransToDX.TabIndex = 4;
            this.InsertTransToDX.Text = "Insert trans";
            this.InsertTransToDX.Click += new System.EventHandler(this.TranslateDevexpress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 638);
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
    }
}

