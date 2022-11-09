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
            this.components = new System.ComponentModel.Container();
            this.ParseDevexpress = new DevExpress.XtraEditors.SimpleButton();
            this.Translate = new DevExpress.XtraEditors.SimpleButton();
            this.GoYandex = new DevExpress.XtraEditors.SimpleButton();
            this.GoDevexpress = new DevExpress.XtraEditors.SimpleButton();
            this.InsertTransToDX = new DevExpress.XtraEditors.SimpleButton();
            this.btnHttpClient = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSerializeDesir = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnglish = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSuggested = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.btnHttpClient.Location = new System.Drawing.Point(54, 91);
            this.btnHttpClient.Name = "btnHttpClient";
            this.btnHttpClient.Size = new System.Drawing.Size(75, 23);
            this.btnHttpClient.TabIndex = 5;
            this.btnHttpClient.Text = "HttpClient";
            this.btnHttpClient.Click += new System.EventHandler(this.btnHttpClient_Click);
            // 
            // BtnSerializeDesir
            // 
            this.BtnSerializeDesir.Location = new System.Drawing.Point(262, 91);
            this.BtnSerializeDesir.Name = "BtnSerializeDesir";
            this.BtnSerializeDesir.Size = new System.Drawing.Size(75, 23);
            this.BtnSerializeDesir.TabIndex = 6;
            this.BtnSerializeDesir.Text = "SerializeDesir";
            this.BtnSerializeDesir.Click += new System.EventHandler(this.BtnSerializeDesir_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.modelBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(54, 130);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1269, 676);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataSource = typeof(Localization.Models.Model);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colEnglish,
            this.colSuggested,
            this.colUz,
            this.colLt});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colEnglish
            // 
            this.colEnglish.FieldName = "English";
            this.colEnglish.Name = "colEnglish";
            this.colEnglish.Visible = true;
            this.colEnglish.VisibleIndex = 1;
            // 
            // colSuggested
            // 
            this.colSuggested.FieldName = "Suggested";
            this.colSuggested.Name = "colSuggested";
            this.colSuggested.Visible = true;
            this.colSuggested.VisibleIndex = 2;
            // 
            // colUz
            // 
            this.colUz.FieldName = "Uz";
            this.colUz.Name = "colUz";
            this.colUz.Visible = true;
            this.colUz.VisibleIndex = 3;
            // 
            // colLt
            // 
            this.colLt.FieldName = "Lt";
            this.colLt.Name = "colLt";
            this.colLt.Visible = true;
            this.colLt.VisibleIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1181, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1083, 101);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 818);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.BtnSerializeDesir);
            this.Controls.Add(this.btnHttpClient);
            this.Controls.Add(this.InsertTransToDX);
            this.Controls.Add(this.GoDevexpress);
            this.Controls.Add(this.GoYandex);
            this.Controls.Add(this.Translate);
            this.Controls.Add(this.ParseDevexpress);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton ParseDevexpress;
        private DevExpress.XtraEditors.SimpleButton Translate;
        private DevExpress.XtraEditors.SimpleButton GoYandex;
        private DevExpress.XtraEditors.SimpleButton GoDevexpress;
        private DevExpress.XtraEditors.SimpleButton InsertTransToDX;
        private DevExpress.XtraEditors.SimpleButton btnHttpClient;
        private DevExpress.XtraEditors.SimpleButton BtnSerializeDesir;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colEnglish;
        private DevExpress.XtraGrid.Columns.GridColumn colSuggested;
        private DevExpress.XtraGrid.Columns.GridColumn colUz;
        private DevExpress.XtraGrid.Columns.GridColumn colLt;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}

