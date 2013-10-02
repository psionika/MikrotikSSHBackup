namespace MikrotikSSHBackup
{
    partial class Form_Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.btn_StartBackup = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastBackup = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StateBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mikrotikListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new MikrotikSSHBackup.DataSet1();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tsb_Add = new System.Windows.Forms.ToolStripButton();
            this.tsb_Edit = new System.Windows.Forms.ToolStripButton();
            this.tsb_Delete = new System.Windows.Forms.ToolStripButton();
            this.tsb_Exit = new System.Windows.Forms.ToolStripButton();
            this.tsb_About = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mikrotikListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_StartBackup
            // 
            this.btn_StartBackup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btn_StartBackup, 2);
            this.btn_StartBackup.Location = new System.Drawing.Point(250, 353);
            this.btn_StartBackup.Name = "btn_StartBackup";
            this.btn_StartBackup.Size = new System.Drawing.Size(134, 23);
            this.btn_StartBackup.TabIndex = 0;
            this.btn_StartBackup.Text = "StartBackup";
            this.btn_StartBackup.UseVisualStyleBackColor = true;
            this.btn_StartBackup.Click += new System.EventHandler(this.btn_StartBackup_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.iPDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.LastBackup,
            this.StateBackup});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.DataSource = this.mikrotikListBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(628, 336);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iPDataGridViewTextBoxColumn
            // 
            this.iPDataGridViewTextBoxColumn.DataPropertyName = "IP";
            this.iPDataGridViewTextBoxColumn.HeaderText = "IP";
            this.iPDataGridViewTextBoxColumn.Name = "iPDataGridViewTextBoxColumn";
            this.iPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
            this.loginDataGridViewTextBoxColumn.HeaderText = "Login";
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            this.loginDataGridViewTextBoxColumn.Width = 120;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            this.passwordDataGridViewTextBoxColumn.Width = 120;
            // 
            // LastBackup
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "LastBackup";
            this.LastBackup.DefaultCellStyle = dataGridViewCellStyle1;
            this.LastBackup.HeaderText = "LastBackup";
            this.LastBackup.Name = "LastBackup";
            this.LastBackup.ReadOnly = true;
            this.LastBackup.Text = "LastBackup";
            // 
            // StateBackup
            // 
            this.StateBackup.HeaderText = "StateBackup";
            this.StateBackup.Name = "StateBackup";
            this.StateBackup.ReadOnly = true;
            // 
            // mikrotikListBindingSource
            // 
            this.mikrotikListBindingSource.DataMember = "MikrotikList";
            this.mikrotikListBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Add,
            this.tsb_Edit,
            this.tsb_Delete,
            this.toolStripSeparator1,
            this.tsb_Exit,
            this.tsb_About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(634, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_StartBackup, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 387);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tsb_Add
            // 
            this.tsb_Add.Image = global::MikrotikSSHBackup.Properties.Resources.add_32x32;
            this.tsb_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Add.Name = "tsb_Add";
            this.tsb_Add.Size = new System.Drawing.Size(49, 22);
            this.tsb_Add.Text = "Add";
            this.tsb_Add.Click += new System.EventHandler(this.tsb_Add_Click);
            // 
            // tsb_Edit
            // 
            this.tsb_Edit.Image = global::MikrotikSSHBackup.Properties.Resources.edit_32x32;
            this.tsb_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Edit.Name = "tsb_Edit";
            this.tsb_Edit.Size = new System.Drawing.Size(47, 22);
            this.tsb_Edit.Text = "Edit";
            this.tsb_Edit.Click += new System.EventHandler(this.tsb_Edit_Click);
            // 
            // tsb_Delete
            // 
            this.tsb_Delete.Image = global::MikrotikSSHBackup.Properties.Resources.delete_32x32;
            this.tsb_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Delete.Name = "tsb_Delete";
            this.tsb_Delete.Size = new System.Drawing.Size(60, 22);
            this.tsb_Delete.Text = "Delete";
            this.tsb_Delete.Click += new System.EventHandler(this.tsb_Delete_Click);
            // 
            // tsb_Exit
            // 
            this.tsb_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_Exit.Image = global::MikrotikSSHBackup.Properties.Resources.door_32x32;
            this.tsb_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Exit.Name = "tsb_Exit";
            this.tsb_Exit.Size = new System.Drawing.Size(45, 22);
            this.tsb_Exit.Text = "Exit";
            this.tsb_Exit.Click += new System.EventHandler(this.tsb_Exit_Click);
            // 
            // tsb_About
            // 
            this.tsb_About.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_About.Image = global::MikrotikSSHBackup.Properties.Resources.help_32x32;
            this.tsb_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_About.Name = "tsb_About";
            this.tsb_About.Size = new System.Drawing.Size(60, 22);
            this.tsb_About.Text = "About";
            this.tsb_About.Click += new System.EventHandler(this.tsb_About_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "Form_Main";
            this.Text = "Mikrotik SSH Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mikrotikListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartBackup;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource mikrotikListBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_Add;
        private System.Windows.Forms.ToolStripButton tsb_Edit;
        private System.Windows.Forms.ToolStripButton tsb_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_Exit;
        private System.Windows.Forms.ToolStripButton tsb_About;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn LastBackup;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateBackup;
    }
}

