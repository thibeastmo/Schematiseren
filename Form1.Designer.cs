namespace Schematiseren
{
    partial class Schematiseren
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schematiseren));
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbMaandag = new System.Windows.Forms.ComboBox();
            this.cmbZondag = new System.Windows.Forms.ComboBox();
            this.cmbZaterdag = new System.Windows.Forms.ComboBox();
            this.cmbVrijdag = new System.Windows.Forms.ComboBox();
            this.cmbDonderdag = new System.Windows.Forms.ComboBox();
            this.cmbWoensdag = new System.Windows.Forms.ComboBox();
            this.cmbDinsdag = new System.Windows.Forms.ComboBox();
            this.lblDLName = new System.Windows.Forms.Label();
            this.lblDLMaandag = new System.Windows.Forms.Label();
            this.lblDLDinsdag = new System.Windows.Forms.Label();
            this.lblDLWoensdag = new System.Windows.Forms.Label();
            this.lblDLDonderdag = new System.Windows.Forms.Label();
            this.lblDLVrijdag = new System.Windows.Forms.Label();
            this.lblDLZaterdag = new System.Windows.Forms.Label();
            this.lblDLZondag = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.DL = new System.Windows.Forms.DataGridView();
            this.DLData = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weekdag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddSpecific = new System.Windows.Forms.Button();
            this.btnRemoveSpecific = new System.Windows.Forms.Button();
            this.pnlData = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCZondag = new System.Windows.Forms.Label();
            this.lblCZaterdag = new System.Windows.Forms.Label();
            this.lblCVrijdag = new System.Windows.Forms.Label();
            this.lblCDonderdag = new System.Windows.Forms.Label();
            this.lblCWoensdag = new System.Windows.Forms.Label();
            this.lblCDinsdag = new System.Windows.Forms.Label();
            this.btnSortData = new System.Windows.Forms.Button();
            this.lblCMaandag = new System.Windows.Forms.Label();
            this.pnlPersonen = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNotCombineWith = new System.Windows.Forms.ComboBox();
            this.pnlGenerate = new System.Windows.Forms.Panel();
            this.cbCarsDIfferent = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMixen = new System.Windows.Forms.ComboBox();
            this.cmbMaxPassagiers = new System.Windows.Forms.ComboBox();
            this.lblMaxPassagiers = new System.Windows.Forms.Label();
            this.cbZondag = new System.Windows.Forms.CheckBox();
            this.cbDinsdag = new System.Windows.Forms.CheckBox();
            this.btnGenerateZonderNamen = new System.Windows.Forms.Button();
            this.cbShortMaand = new System.Windows.Forms.CheckBox();
            this.cbWoensdag = new System.Windows.Forms.CheckBox();
            this.cbVrijdag = new System.Windows.Forms.CheckBox();
            this.cbShowYear = new System.Windows.Forms.CheckBox();
            this.cbMaandag = new System.Windows.Forms.CheckBox();
            this.btnGenerateMetNamen = new System.Windows.Forms.Button();
            this.cmbAantalAutos = new System.Windows.Forms.ComboBox();
            this.cbZaterdag = new System.Windows.Forms.CheckBox();
            this.lblAantalAutos = new System.Windows.Forms.Label();
            this.cbDonderdag = new System.Windows.Forms.CheckBox();
            this.Firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saterday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zitplaatsen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLData)).BeginInit();
            this.pnlData.SuspendLayout();
            this.pnlPersonen.SuspendLayout();
            this.pnlGenerate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPerson.Location = new System.Drawing.Point(577, 28);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(71, 38);
            this.btnAddPerson.TabIndex = 9;
            this.btnAddPerson.Text = "Voeg toe";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Location = new System.Drawing.Point(686, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(71, 38);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "Pas aan";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Location = new System.Drawing.Point(788, 28);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(71, 38);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.TabStop = false;
            this.btnRemove.Text = "Verwijder";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(11, 29);
            this.txtName.Margin = new System.Windows.Forms.Padding(6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 20);
            this.txtName.TabIndex = 1;
            // 
            // cmbMaandag
            // 
            this.cmbMaandag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaandag.FormattingEnabled = true;
            this.cmbMaandag.Location = new System.Drawing.Point(11, 90);
            this.cmbMaandag.Name = "cmbMaandag";
            this.cmbMaandag.Size = new System.Drawing.Size(121, 21);
            this.cmbMaandag.TabIndex = 2;
            // 
            // cmbZondag
            // 
            this.cmbZondag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZondag.FormattingEnabled = true;
            this.cmbZondag.Location = new System.Drawing.Point(773, 90);
            this.cmbZondag.Name = "cmbZondag";
            this.cmbZondag.Size = new System.Drawing.Size(121, 21);
            this.cmbZondag.TabIndex = 8;
            // 
            // cmbZaterdag
            // 
            this.cmbZaterdag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZaterdag.FormattingEnabled = true;
            this.cmbZaterdag.Location = new System.Drawing.Point(646, 90);
            this.cmbZaterdag.Name = "cmbZaterdag";
            this.cmbZaterdag.Size = new System.Drawing.Size(121, 21);
            this.cmbZaterdag.TabIndex = 7;
            // 
            // cmbVrijdag
            // 
            this.cmbVrijdag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVrijdag.FormattingEnabled = true;
            this.cmbVrijdag.Location = new System.Drawing.Point(519, 90);
            this.cmbVrijdag.Name = "cmbVrijdag";
            this.cmbVrijdag.Size = new System.Drawing.Size(121, 21);
            this.cmbVrijdag.TabIndex = 6;
            // 
            // cmbDonderdag
            // 
            this.cmbDonderdag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonderdag.FormattingEnabled = true;
            this.cmbDonderdag.Location = new System.Drawing.Point(392, 90);
            this.cmbDonderdag.Name = "cmbDonderdag";
            this.cmbDonderdag.Size = new System.Drawing.Size(121, 21);
            this.cmbDonderdag.TabIndex = 5;
            // 
            // cmbWoensdag
            // 
            this.cmbWoensdag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWoensdag.FormattingEnabled = true;
            this.cmbWoensdag.Location = new System.Drawing.Point(265, 90);
            this.cmbWoensdag.Name = "cmbWoensdag";
            this.cmbWoensdag.Size = new System.Drawing.Size(121, 21);
            this.cmbWoensdag.TabIndex = 4;
            // 
            // cmbDinsdag
            // 
            this.cmbDinsdag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDinsdag.FormattingEnabled = true;
            this.cmbDinsdag.Location = new System.Drawing.Point(138, 90);
            this.cmbDinsdag.Name = "cmbDinsdag";
            this.cmbDinsdag.Size = new System.Drawing.Size(121, 21);
            this.cmbDinsdag.TabIndex = 3;
            // 
            // lblDLName
            // 
            this.lblDLName.AutoSize = true;
            this.lblDLName.Location = new System.Drawing.Point(11, 10);
            this.lblDLName.Name = "lblDLName";
            this.lblDLName.Size = new System.Drawing.Size(35, 13);
            this.lblDLName.TabIndex = 14;
            this.lblDLName.Text = "Naam";
            // 
            // lblDLMaandag
            // 
            this.lblDLMaandag.AutoSize = true;
            this.lblDLMaandag.Location = new System.Drawing.Point(45, 74);
            this.lblDLMaandag.Name = "lblDLMaandag";
            this.lblDLMaandag.Size = new System.Drawing.Size(52, 13);
            this.lblDLMaandag.TabIndex = 16;
            this.lblDLMaandag.Text = "Maandag";
            // 
            // lblDLDinsdag
            // 
            this.lblDLDinsdag.AutoSize = true;
            this.lblDLDinsdag.Location = new System.Drawing.Point(174, 74);
            this.lblDLDinsdag.Name = "lblDLDinsdag";
            this.lblDLDinsdag.Size = new System.Drawing.Size(46, 13);
            this.lblDLDinsdag.TabIndex = 17;
            this.lblDLDinsdag.Text = "Dinsdag";
            // 
            // lblDLWoensdag
            // 
            this.lblDLWoensdag.AutoSize = true;
            this.lblDLWoensdag.Location = new System.Drawing.Point(296, 74);
            this.lblDLWoensdag.Name = "lblDLWoensdag";
            this.lblDLWoensdag.Size = new System.Drawing.Size(59, 13);
            this.lblDLWoensdag.TabIndex = 18;
            this.lblDLWoensdag.Text = "Woensdag";
            // 
            // lblDLDonderdag
            // 
            this.lblDLDonderdag.AutoSize = true;
            this.lblDLDonderdag.Location = new System.Drawing.Point(421, 74);
            this.lblDLDonderdag.Name = "lblDLDonderdag";
            this.lblDLDonderdag.Size = new System.Drawing.Size(60, 13);
            this.lblDLDonderdag.TabIndex = 19;
            this.lblDLDonderdag.Text = "Donderdag";
            // 
            // lblDLVrijdag
            // 
            this.lblDLVrijdag.AutoSize = true;
            this.lblDLVrijdag.Location = new System.Drawing.Point(559, 74);
            this.lblDLVrijdag.Name = "lblDLVrijdag";
            this.lblDLVrijdag.Size = new System.Drawing.Size(39, 13);
            this.lblDLVrijdag.TabIndex = 20;
            this.lblDLVrijdag.Text = "Vrijdag";
            // 
            // lblDLZaterdag
            // 
            this.lblDLZaterdag.AutoSize = true;
            this.lblDLZaterdag.Location = new System.Drawing.Point(681, 74);
            this.lblDLZaterdag.Name = "lblDLZaterdag";
            this.lblDLZaterdag.Size = new System.Drawing.Size(50, 13);
            this.lblDLZaterdag.TabIndex = 21;
            this.lblDLZaterdag.Text = "Zaterdag";
            // 
            // lblDLZondag
            // 
            this.lblDLZondag.AutoSize = true;
            this.lblDLZondag.Location = new System.Drawing.Point(815, 74);
            this.lblDLZondag.Name = "lblDLZondag";
            this.lblDLZondag.Size = new System.Drawing.Size(44, 13);
            this.lblDLZondag.TabIndex = 22;
            this.lblDLZondag.Text = "Zondag";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(9, 9);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(54, 17);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "lblError";
            // 
            // DL
            // 
            this.DL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.Firstname, this.Monday, this.Tuesday, this.Wednesday, this.Thursday, this.Friday, this.Saterday, this.Sunday, this.Zitplaatsen
            });
            this.DL.Location = new System.Drawing.Point(10, 137);
            this.DL.MultiSelect = false;
            this.DL.Name = "DL";
            this.DL.ReadOnly = true;
            this.DL.RowHeadersVisible = false;
            this.DL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DL.Size = new System.Drawing.Size(884, 232);
            this.DL.TabIndex = 12;
            this.DL.TabStop = false;
            this.DL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DL_CellClick);
            // 
            // DLData
            // 
            this.DLData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DLData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DLData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.Date, this.Weekdag
            });
            this.DLData.Location = new System.Drawing.Point(324, 20);
            this.DLData.Name = "DLData";
            this.DLData.RowHeadersVisible = false;
            this.DLData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DLData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DLData.Size = new System.Drawing.Size(210, 140);
            this.DLData.TabIndex = 37;
            this.DLData.TabStop = false;
            // 
            // Date
            // 
            this.Date.HeaderText = "Datum";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Weekdag
            // 
            this.Weekdag.HeaderText = "Weekdag";
            this.Weekdag.Name = "Weekdag";
            this.Weekdag.ReadOnly = true;
            // 
            // btnAddSpecific
            // 
            this.btnAddSpecific.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSpecific.Location = new System.Drawing.Point(237, 20);
            this.btnAddSpecific.Name = "btnAddSpecific";
            this.btnAddSpecific.Size = new System.Drawing.Size(71, 38);
            this.btnAddSpecific.TabIndex = 13;
            this.btnAddSpecific.Text = "Voeg toe";
            this.btnAddSpecific.UseVisualStyleBackColor = true;
            this.btnAddSpecific.Click += new System.EventHandler(this.btnAddSpecific_Click);
            // 
            // btnRemoveSpecific
            // 
            this.btnRemoveSpecific.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSpecific.Location = new System.Drawing.Point(237, 73);
            this.btnRemoveSpecific.Name = "btnRemoveSpecific";
            this.btnRemoveSpecific.Size = new System.Drawing.Size(71, 38);
            this.btnRemoveSpecific.TabIndex = 40;
            this.btnRemoveSpecific.TabStop = false;
            this.btnRemoveSpecific.Text = "Verwijder";
            this.btnRemoveSpecific.UseVisualStyleBackColor = true;
            this.btnRemoveSpecific.Click += new System.EventHandler(this.btnRemoveSpecific_Click);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.label5);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.dateTimePicker2);
            this.pnlData.Controls.Add(this.dateTimePicker1);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Controls.Add(this.lblCZondag);
            this.pnlData.Controls.Add(this.lblCZaterdag);
            this.pnlData.Controls.Add(this.lblCVrijdag);
            this.pnlData.Controls.Add(this.lblCDonderdag);
            this.pnlData.Controls.Add(this.lblCWoensdag);
            this.pnlData.Controls.Add(this.lblCDinsdag);
            this.pnlData.Controls.Add(this.btnSortData);
            this.pnlData.Controls.Add(this.btnAddSpecific);
            this.pnlData.Controls.Add(this.btnRemoveSpecific);
            this.pnlData.Controls.Add(this.lblCMaandag);
            this.pnlData.Controls.Add(this.DLData);
            this.pnlData.Location = new System.Drawing.Point(2, 427);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(571, 166);
            this.pnlData.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Van";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Tot";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(20, 122);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 51;
            this.dateTimePicker2.Value = new System.DateTime(2023, 9, 12, 14, 9, 47, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(20, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 50;
            this.dateTimePicker1.Value = new System.DateTime(2023, 9, 12, 14, 9, 41, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Alle data wanneer er gereden moet worden";
            // 
            // lblCZondag
            // 
            this.lblCZondag.AutoSize = true;
            this.lblCZondag.Location = new System.Drawing.Point(500, 7);
            this.lblCZondag.Name = "lblCZondag";
            this.lblCZondag.Size = new System.Drawing.Size(62, 13);
            this.lblCZondag.TabIndex = 44;
            this.lblCZondag.Text = "Zondagen: ";
            // 
            // lblCZaterdag
            // 
            this.lblCZaterdag.AutoSize = true;
            this.lblCZaterdag.Location = new System.Drawing.Point(421, 7);
            this.lblCZaterdag.Name = "lblCZaterdag";
            this.lblCZaterdag.Size = new System.Drawing.Size(68, 13);
            this.lblCZaterdag.TabIndex = 45;
            this.lblCZaterdag.Text = "Zaterdagen: ";
            // 
            // lblCVrijdag
            // 
            this.lblCVrijdag.AutoSize = true;
            this.lblCVrijdag.Location = new System.Drawing.Point(349, 7);
            this.lblCVrijdag.Name = "lblCVrijdag";
            this.lblCVrijdag.Size = new System.Drawing.Size(57, 13);
            this.lblCVrijdag.TabIndex = 46;
            this.lblCVrijdag.Text = "Vrijdagen: ";
            // 
            // lblCDonderdag
            // 
            this.lblCDonderdag.AutoSize = true;
            this.lblCDonderdag.Location = new System.Drawing.Point(253, 7);
            this.lblCDonderdag.Name = "lblCDonderdag";
            this.lblCDonderdag.Size = new System.Drawing.Size(78, 13);
            this.lblCDonderdag.TabIndex = 47;
            this.lblCDonderdag.Text = "Donderdagen: ";
            // 
            // lblCWoensdag
            // 
            this.lblCWoensdag.AutoSize = true;
            this.lblCWoensdag.Location = new System.Drawing.Point(165, 7);
            this.lblCWoensdag.Name = "lblCWoensdag";
            this.lblCWoensdag.Size = new System.Drawing.Size(77, 13);
            this.lblCWoensdag.TabIndex = 48;
            this.lblCWoensdag.Text = "Woensdagen: ";
            // 
            // lblCDinsdag
            // 
            this.lblCDinsdag.AutoSize = true;
            this.lblCDinsdag.Location = new System.Drawing.Point(81, 7);
            this.lblCDinsdag.Name = "lblCDinsdag";
            this.lblCDinsdag.Size = new System.Drawing.Size(64, 13);
            this.lblCDinsdag.TabIndex = 49;
            this.lblCDinsdag.Text = "Dinsdagen: ";
            // 
            // btnSortData
            // 
            this.btnSortData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSortData.Location = new System.Drawing.Point(237, 122);
            this.btnSortData.Name = "btnSortData";
            this.btnSortData.Size = new System.Drawing.Size(71, 38);
            this.btnSortData.TabIndex = 44;
            this.btnSortData.TabStop = false;
            this.btnSortData.Text = "Sorteer";
            this.btnSortData.UseVisualStyleBackColor = true;
            this.btnSortData.Click += new System.EventHandler(this.btnSortData_Click);
            // 
            // lblCMaandag
            // 
            this.lblCMaandag.AutoSize = true;
            this.lblCMaandag.Location = new System.Drawing.Point(-1, 7);
            this.lblCMaandag.Name = "lblCMaandag";
            this.lblCMaandag.Size = new System.Drawing.Size(70, 13);
            this.lblCMaandag.TabIndex = 43;
            this.lblCMaandag.Text = "Maandagen: ";
            // 
            // pnlPersonen
            // 
            this.pnlPersonen.Controls.Add(this.label1);
            this.pnlPersonen.Controls.Add(this.cmbNotCombineWith);
            this.pnlPersonen.Controls.Add(this.btnEdit);
            this.pnlPersonen.Controls.Add(this.btnAddPerson);
            this.pnlPersonen.Controls.Add(this.btnRemove);
            this.pnlPersonen.Controls.Add(this.DL);
            this.pnlPersonen.Controls.Add(this.txtName);
            this.pnlPersonen.Controls.Add(this.cmbMaandag);
            this.pnlPersonen.Controls.Add(this.cmbZondag);
            this.pnlPersonen.Controls.Add(this.cmbZaterdag);
            this.pnlPersonen.Controls.Add(this.cmbVrijdag);
            this.pnlPersonen.Controls.Add(this.cmbDonderdag);
            this.pnlPersonen.Controls.Add(this.lblDLZondag);
            this.pnlPersonen.Controls.Add(this.cmbWoensdag);
            this.pnlPersonen.Controls.Add(this.lblDLZaterdag);
            this.pnlPersonen.Controls.Add(this.cmbDinsdag);
            this.pnlPersonen.Controls.Add(this.lblDLVrijdag);
            this.pnlPersonen.Controls.Add(this.lblDLName);
            this.pnlPersonen.Controls.Add(this.lblDLDonderdag);
            this.pnlPersonen.Controls.Add(this.lblDLMaandag);
            this.pnlPersonen.Controls.Add(this.lblDLWoensdag);
            this.pnlPersonen.Controls.Add(this.lblDLDinsdag);
            this.pnlPersonen.Location = new System.Drawing.Point(2, 38);
            this.pnlPersonen.Name = "pnlPersonen";
            this.pnlPersonen.Size = new System.Drawing.Size(904, 383);
            this.pnlPersonen.TabIndex = 0;
            this.pnlPersonen.TabStop = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Niet samenrijden met:";
            // 
            // cmbNotCombineWith
            // 
            this.cmbNotCombineWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotCombineWith.FormattingEnabled = true;
            this.cmbNotCombineWith.Location = new System.Drawing.Point(265, 28);
            this.cmbNotCombineWith.Name = "cmbNotCombineWith";
            this.cmbNotCombineWith.Size = new System.Drawing.Size(121, 21);
            this.cmbNotCombineWith.TabIndex = 23;
            // 
            // pnlGenerate
            // 
            this.pnlGenerate.Controls.Add(this.cbCarsDIfferent);
            this.pnlGenerate.Controls.Add(this.label3);
            this.pnlGenerate.Controls.Add(this.cmbMixen);
            this.pnlGenerate.Controls.Add(this.cmbMaxPassagiers);
            this.pnlGenerate.Controls.Add(this.lblMaxPassagiers);
            this.pnlGenerate.Controls.Add(this.cbZondag);
            this.pnlGenerate.Controls.Add(this.cbDinsdag);
            this.pnlGenerate.Controls.Add(this.btnGenerateZonderNamen);
            this.pnlGenerate.Controls.Add(this.cbShortMaand);
            this.pnlGenerate.Controls.Add(this.cbWoensdag);
            this.pnlGenerate.Controls.Add(this.cbVrijdag);
            this.pnlGenerate.Controls.Add(this.cbShowYear);
            this.pnlGenerate.Controls.Add(this.cbMaandag);
            this.pnlGenerate.Controls.Add(this.btnGenerateMetNamen);
            this.pnlGenerate.Controls.Add(this.cmbAantalAutos);
            this.pnlGenerate.Controls.Add(this.cbZaterdag);
            this.pnlGenerate.Controls.Add(this.lblAantalAutos);
            this.pnlGenerate.Controls.Add(this.cbDonderdag);
            this.pnlGenerate.Location = new System.Drawing.Point(579, 427);
            this.pnlGenerate.Name = "pnlGenerate";
            this.pnlGenerate.Size = new System.Drawing.Size(317, 166);
            this.pnlGenerate.TabIndex = 42;
            this.pnlGenerate.TabStop = true;
            // 
            // cbCarsDIfferent
            // 
            this.cbCarsDIfferent.AutoSize = true;
            this.cbCarsDIfferent.Location = new System.Drawing.Point(84, 7);
            this.cbCarsDIfferent.Name = "cbCarsDIfferent";
            this.cbCarsDIfferent.Size = new System.Drawing.Size(233, 17);
            this.cbCarsDIfferent.TabIndex = 62;
            this.cbCarsDIfferent.Text = "Heen & terug dezelfde bestuurder/passagiers";
            this.cbCarsDIfferent.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Extra mixen voor";
            // 
            // cmbMixen
            // 
            this.cmbMixen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMixen.FormattingEnabled = true;
            this.cmbMixen.Items.AddRange(new object[]
            {
                "Standaard", "Bestuurders", "Passagiers", "Bestuurders & Passagiers"
            });
            this.cmbMixen.Location = new System.Drawing.Point(16, 99);
            this.cmbMixen.Name = "cmbMixen";
            this.cmbMixen.Size = new System.Drawing.Size(101, 21);
            this.cmbMixen.TabIndex = 61;
            // 
            // cmbMaxPassagiers
            // 
            this.cmbMaxPassagiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaxPassagiers.FormattingEnabled = true;
            this.cmbMaxPassagiers.Items.AddRange(new object[]
            {
                "1", "2", "3", "4", "5"
            });
            this.cmbMaxPassagiers.Location = new System.Drawing.Point(16, 139);
            this.cmbMaxPassagiers.Name = "cmbMaxPassagiers";
            this.cmbMaxPassagiers.Size = new System.Drawing.Size(66, 21);
            this.cmbMaxPassagiers.TabIndex = 60;
            // 
            // lblMaxPassagiers
            // 
            this.lblMaxPassagiers.AutoSize = true;
            this.lblMaxPassagiers.Location = new System.Drawing.Point(6, 123);
            this.lblMaxPassagiers.Name = "lblMaxPassagiers";
            this.lblMaxPassagiers.Size = new System.Drawing.Size(112, 13);
            this.lblMaxPassagiers.TabIndex = 59;
            this.lblMaxPassagiers.Text = "Max aantal passagiers";
            // 
            // cbZondag
            // 
            this.cbZondag.AutoSize = true;
            this.cbZondag.Location = new System.Drawing.Point(123, 125);
            this.cbZondag.Name = "cbZondag";
            this.cbZondag.Size = new System.Drawing.Size(63, 17);
            this.cbZondag.TabIndex = 58;
            this.cbZondag.Text = "Zondag";
            this.cbZondag.UseVisualStyleBackColor = true;
            // 
            // cbDinsdag
            // 
            this.cbDinsdag.AutoSize = true;
            this.cbDinsdag.Location = new System.Drawing.Point(123, 45);
            this.cbDinsdag.Name = "cbDinsdag";
            this.cbDinsdag.Size = new System.Drawing.Size(65, 17);
            this.cbDinsdag.TabIndex = 54;
            this.cbDinsdag.Text = "Dinsdag";
            this.cbDinsdag.UseVisualStyleBackColor = true;
            // 
            // btnGenerateZonderNamen
            // 
            this.btnGenerateZonderNamen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateZonderNamen.Location = new System.Drawing.Point(211, 29);
            this.btnGenerateZonderNamen.Name = "btnGenerateZonderNamen";
            this.btnGenerateZonderNamen.Size = new System.Drawing.Size(90, 55);
            this.btnGenerateZonderNamen.TabIndex = 23;
            this.btnGenerateZonderNamen.TabStop = false;
            this.btnGenerateZonderNamen.Text = "Genereer zonder namen";
            this.btnGenerateZonderNamen.UseVisualStyleBackColor = true;
            this.btnGenerateZonderNamen.Click += new System.EventHandler(this.btnGenerateCSV_Click);
            // 
            // cbShortMaand
            // 
            this.cbShortMaand.AutoSize = true;
            this.cbShortMaand.Location = new System.Drawing.Point(0, 38);
            this.cbShortMaand.Name = "cbShortMaand";
            this.cbShortMaand.Size = new System.Drawing.Size(101, 17);
            this.cbShortMaand.TabIndex = 47;
            this.cbShortMaand.Text = "Maand afkorten";
            this.cbShortMaand.UseVisualStyleBackColor = true;
            // 
            // cbWoensdag
            // 
            this.cbWoensdag.AutoSize = true;
            this.cbWoensdag.Location = new System.Drawing.Point(123, 61);
            this.cbWoensdag.Name = "cbWoensdag";
            this.cbWoensdag.Size = new System.Drawing.Size(78, 17);
            this.cbWoensdag.TabIndex = 49;
            this.cbWoensdag.Text = "Woensdag";
            this.cbWoensdag.UseVisualStyleBackColor = true;
            // 
            // cbVrijdag
            // 
            this.cbVrijdag.AutoSize = true;
            this.cbVrijdag.Location = new System.Drawing.Point(123, 93);
            this.cbVrijdag.Name = "cbVrijdag";
            this.cbVrijdag.Size = new System.Drawing.Size(58, 17);
            this.cbVrijdag.TabIndex = 57;
            this.cbVrijdag.Text = "Vrijdag";
            this.cbVrijdag.UseVisualStyleBackColor = true;
            // 
            // cbShowYear
            // 
            this.cbShowYear.AutoSize = true;
            this.cbShowYear.Location = new System.Drawing.Point(0, 61);
            this.cbShowYear.Name = "cbShowYear";
            this.cbShowYear.Size = new System.Drawing.Size(115, 17);
            this.cbShowYear.TabIndex = 46;
            this.cbShowYear.Text = "Schrijf jaartallen op";
            this.cbShowYear.UseVisualStyleBackColor = true;
            // 
            // cbMaandag
            // 
            this.cbMaandag.AutoSize = true;
            this.cbMaandag.Location = new System.Drawing.Point(123, 29);
            this.cbMaandag.Name = "cbMaandag";
            this.cbMaandag.Size = new System.Drawing.Size(71, 17);
            this.cbMaandag.TabIndex = 48;
            this.cbMaandag.Text = "Maandag";
            this.cbMaandag.UseVisualStyleBackColor = true;
            // 
            // btnGenerateMetNamen
            // 
            this.btnGenerateMetNamen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateMetNamen.Location = new System.Drawing.Point(211, 93);
            this.btnGenerateMetNamen.Name = "btnGenerateMetNamen";
            this.btnGenerateMetNamen.Size = new System.Drawing.Size(90, 55);
            this.btnGenerateMetNamen.TabIndex = 45;
            this.btnGenerateMetNamen.TabStop = false;
            this.btnGenerateMetNamen.Text = "Genereer met namen";
            this.btnGenerateMetNamen.UseVisualStyleBackColor = true;
            this.btnGenerateMetNamen.Click += new System.EventHandler(this.btnGenerateCSV_Click);
            // 
            // cmbAantalAutos
            // 
            this.cmbAantalAutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAantalAutos.FormattingEnabled = true;
            this.cmbAantalAutos.Items.AddRange(new object[]
            {
                "1", "2", "3", "4", "5"
            });
            this.cmbAantalAutos.Location = new System.Drawing.Point(16, 14);
            this.cmbAantalAutos.Name = "cmbAantalAutos";
            this.cmbAantalAutos.Size = new System.Drawing.Size(66, 21);
            this.cmbAantalAutos.TabIndex = 44;
            // 
            // cbZaterdag
            // 
            this.cbZaterdag.AutoSize = true;
            this.cbZaterdag.Location = new System.Drawing.Point(123, 109);
            this.cbZaterdag.Name = "cbZaterdag";
            this.cbZaterdag.Size = new System.Drawing.Size(69, 17);
            this.cbZaterdag.TabIndex = 56;
            this.cbZaterdag.Text = "Zaterdag";
            this.cbZaterdag.UseVisualStyleBackColor = true;
            // 
            // lblAantalAutos
            // 
            this.lblAantalAutos.AutoSize = true;
            this.lblAantalAutos.Location = new System.Drawing.Point(13, 0);
            this.lblAantalAutos.Name = "lblAantalAutos";
            this.lblAantalAutos.Size = new System.Drawing.Size(69, 13);
            this.lblAantalAutos.TabIndex = 43;
            this.lblAantalAutos.Text = "Aantal Auto\'s";
            // 
            // cbDonderdag
            // 
            this.cbDonderdag.AutoSize = true;
            this.cbDonderdag.Location = new System.Drawing.Point(123, 77);
            this.cbDonderdag.Name = "cbDonderdag";
            this.cbDonderdag.Size = new System.Drawing.Size(79, 17);
            this.cbDonderdag.TabIndex = 55;
            this.cbDonderdag.Text = "Donderdag";
            this.cbDonderdag.UseVisualStyleBackColor = true;
            // 
            // Firstname
            // 
            this.Firstname.HeaderText = "Voornaam";
            this.Firstname.Name = "Firstname";
            this.Firstname.ReadOnly = true;
            this.Firstname.ToolTipText = "Voornaam";
            // 
            // Monday
            // 
            this.Monday.HeaderText = "Maandag";
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "Dinsdag";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "Woensdag";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "Donderdag";
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            // 
            // Friday
            // 
            this.Friday.HeaderText = "Vrijdag";
            this.Friday.Name = "Friday";
            this.Friday.ReadOnly = true;
            // 
            // Saterday
            // 
            this.Saterday.HeaderText = "Zaterdag";
            this.Saterday.Name = "Saterday";
            this.Saterday.ReadOnly = true;
            // 
            // Sunday
            // 
            this.Sunday.HeaderText = "Zondag";
            this.Sunday.Name = "Sunday";
            this.Sunday.ReadOnly = true;
            // 
            // Zitplaatsen
            // 
            this.Zitplaatsen.HeaderText = "Zitplaatsen";
            this.Zitplaatsen.Name = "Zitplaatsen";
            this.Zitplaatsen.ReadOnly = true;
            // 
            // Schematiseren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(903, 605);
            this.Controls.Add(this.pnlGenerate);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlPersonen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Schematiseren";
            this.Text = "Schematiseren";
            ((System.ComponentModel.ISupportInitialize)(this.DL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLData)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlPersonen.ResumeLayout(false);
            this.pnlPersonen.PerformLayout();
            this.pnlGenerate.ResumeLayout(false);
            this.pnlGenerate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.CheckBox cbCarsDIfferent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox cmbNotCombineWith;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        #endregion
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbMaandag;
        private System.Windows.Forms.ComboBox cmbZondag;
        private System.Windows.Forms.ComboBox cmbZaterdag;
        private System.Windows.Forms.ComboBox cmbVrijdag;
        private System.Windows.Forms.ComboBox cmbDonderdag;
        private System.Windows.Forms.ComboBox cmbWoensdag;
        private System.Windows.Forms.ComboBox cmbDinsdag;
        private System.Windows.Forms.Label lblDLName;
        private System.Windows.Forms.Label lblDLMaandag;
        private System.Windows.Forms.Label lblDLDinsdag;
        private System.Windows.Forms.Label lblDLWoensdag;
        private System.Windows.Forms.Label lblDLDonderdag;
        private System.Windows.Forms.Label lblDLVrijdag;
        private System.Windows.Forms.Label lblDLZaterdag;
        private System.Windows.Forms.Label lblDLZondag;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridView DL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saterday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zitplaatsen;
        private System.Windows.Forms.DataGridView DLData;
        private System.Windows.Forms.Button btnAddSpecific;
        private System.Windows.Forms.Button btnRemoveSpecific;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Panel pnlPersonen;
        private System.Windows.Forms.Panel pnlGenerate;
        private System.Windows.Forms.ComboBox cmbAantalAutos;
        private System.Windows.Forms.Label lblAantalAutos;
        private System.Windows.Forms.Button btnGenerateMetNamen;
        private System.Windows.Forms.Button btnGenerateZonderNamen;
        private System.Windows.Forms.CheckBox cbShowYear;
        private System.Windows.Forms.CheckBox cbShortMaand;
        private System.Windows.Forms.CheckBox cbZondag;
        private System.Windows.Forms.CheckBox cbDinsdag;
        private System.Windows.Forms.CheckBox cbWoensdag;
        private System.Windows.Forms.CheckBox cbVrijdag;
        private System.Windows.Forms.CheckBox cbMaandag;
        private System.Windows.Forms.CheckBox cbZaterdag;
        private System.Windows.Forms.CheckBox cbDonderdag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weekdag;
        private System.Windows.Forms.Button btnSortData;
        private System.Windows.Forms.ComboBox cmbMaxPassagiers;
        private System.Windows.Forms.Label lblMaxPassagiers;
        private System.Windows.Forms.Label lblCMaandag;
        private System.Windows.Forms.Label lblCZondag;
        private System.Windows.Forms.Label lblCZaterdag;
        private System.Windows.Forms.Label lblCVrijdag;
        private System.Windows.Forms.Label lblCDonderdag;
        private System.Windows.Forms.Label lblCWoensdag;
        private System.Windows.Forms.Label lblCDinsdag;
        private System.Windows.Forms.ComboBox cmbMixen;
    }
}

