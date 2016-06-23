namespace ASQL_Final_Yoyo
{
    partial class frmAdminPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabManagement = new System.Windows.Forms.TabPage();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.lblScheduleMaintenance = new System.Windows.Forms.Label();
            this.lblWorkArea = new System.Windows.Forms.Label();
            this.txtboxWorkArea = new System.Windows.Forms.TextBox();
            this.txtboxModifyPassword = new System.Windows.Forms.TextBox();
            this.txtboxUsername = new System.Windows.Forms.TextBox();
            this.txtboxPassword = new System.Windows.Forms.TextBox();
            this.lblScheduleEnd = new System.Windows.Forms.Label();
            this.lblScheduleStart = new System.Windows.Forms.Label();
            this.lblAdminProducts = new System.Windows.Forms.Label();
            this.comboAdminProducts = new System.Windows.Forms.ComboBox();
            this.datetimeScheduleEnd = new System.Windows.Forms.DateTimePicker();
            this.datetimeScheduleStart = new System.Windows.Forms.DateTimePicker();
            this.lblSeparator2 = new System.Windows.Forms.Label();
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.radioModifyAdministrator = new System.Windows.Forms.RadioButton();
            this.radioModifyGeneral = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectAUser = new System.Windows.Forms.Label();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.radioAdministrator = new System.Windows.Forms.RadioButton();
            this.radioGeneral = new System.Windows.Forms.RadioButton();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblModifyDeleteUser = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.tabMainPage = new System.Windows.Forms.TabPage();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.lblFeedBack = new System.Windows.Forms.Label();
            this.chkboxDateFilter = new System.Windows.Forms.CheckBox();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.comboDefects = new System.Windows.Forms.ComboBox();
            this.lblDefects = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblColours = new System.Windows.Forms.Label();
            this.lblFilters = new System.Windows.Forms.Label();
            this.comboColours = new System.Windows.Forms.ComboBox();
            this.comboProducts = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.datagridTable = new System.Windows.Forms.DataGridView();
            this.radioPareto = new System.Windows.Forms.RadioButton();
            this.radioFinalYield = new System.Windows.Forms.RadioButton();
            this.radioFirstTimeYield = new System.Windows.Forms.RadioButton();
            this.lblDiagram = new System.Windows.Forms.Label();
            this.tabController = new System.Windows.Forms.TabControl();
            this.chkboxProductsFilter = new System.Windows.Forms.CheckBox();
            this.chkboxColoursFilter = new System.Windows.Forms.CheckBox();
            this.chkboxDefectsFilter = new System.Windows.Forms.CheckBox();
            this.tabManagement.SuspendLayout();
            this.tabMainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTable)).BeginInit();
            this.tabController.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabManagement
            // 
            this.tabManagement.Controls.Add(this.btnAddSchedule);
            this.tabManagement.Controls.Add(this.lblScheduleMaintenance);
            this.tabManagement.Controls.Add(this.lblWorkArea);
            this.tabManagement.Controls.Add(this.txtboxWorkArea);
            this.tabManagement.Controls.Add(this.txtboxModifyPassword);
            this.tabManagement.Controls.Add(this.txtboxUsername);
            this.tabManagement.Controls.Add(this.txtboxPassword);
            this.tabManagement.Controls.Add(this.lblScheduleEnd);
            this.tabManagement.Controls.Add(this.lblScheduleStart);
            this.tabManagement.Controls.Add(this.lblAdminProducts);
            this.tabManagement.Controls.Add(this.comboAdminProducts);
            this.tabManagement.Controls.Add(this.datetimeScheduleEnd);
            this.tabManagement.Controls.Add(this.datetimeScheduleStart);
            this.tabManagement.Controls.Add(this.lblSeparator2);
            this.tabManagement.Controls.Add(this.btnModifyUser);
            this.tabManagement.Controls.Add(this.radioModifyAdministrator);
            this.tabManagement.Controls.Add(this.radioModifyGeneral);
            this.tabManagement.Controls.Add(this.label1);
            this.tabManagement.Controls.Add(this.lblSelectAUser);
            this.tabManagement.Controls.Add(this.btnDeleteUser);
            this.tabManagement.Controls.Add(this.comboUsers);
            this.tabManagement.Controls.Add(this.radioAdministrator);
            this.tabManagement.Controls.Add(this.radioGeneral);
            this.tabManagement.Controls.Add(this.btnAddUser);
            this.tabManagement.Controls.Add(this.lblPassword);
            this.tabManagement.Controls.Add(this.lblUsername);
            this.tabManagement.Controls.Add(this.lblModifyDeleteUser);
            this.tabManagement.Controls.Add(this.lblCreateUser);
            this.tabManagement.Location = new System.Drawing.Point(4, 22);
            this.tabManagement.Name = "tabManagement";
            this.tabManagement.Size = new System.Drawing.Size(752, 512);
            this.tabManagement.TabIndex = 2;
            this.tabManagement.Text = "Database Management";
            this.tabManagement.UseVisualStyleBackColor = true;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.Location = new System.Drawing.Point(17, 481);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(177, 23);
            this.btnAddSchedule.TabIndex = 53;
            this.btnAddSchedule.Text = "Add Schedule";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // lblScheduleMaintenance
            // 
            this.lblScheduleMaintenance.AutoSize = true;
            this.lblScheduleMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblScheduleMaintenance.Location = new System.Drawing.Point(1, 237);
            this.lblScheduleMaintenance.Name = "lblScheduleMaintenance";
            this.lblScheduleMaintenance.Size = new System.Drawing.Size(232, 25);
            this.lblScheduleMaintenance.TabIndex = 52;
            this.lblScheduleMaintenance.Text = "Schedule Maintenance";
            // 
            // lblWorkArea
            // 
            this.lblWorkArea.AutoSize = true;
            this.lblWorkArea.Location = new System.Drawing.Point(5, 378);
            this.lblWorkArea.Name = "lblWorkArea";
            this.lblWorkArea.Size = new System.Drawing.Size(61, 13);
            this.lblWorkArea.TabIndex = 51;
            this.lblWorkArea.Text = "Work Area:";
            // 
            // txtboxWorkArea
            // 
            this.txtboxWorkArea.Location = new System.Drawing.Point(17, 397);
            this.txtboxWorkArea.Name = "txtboxWorkArea";
            this.txtboxWorkArea.Size = new System.Drawing.Size(177, 20);
            this.txtboxWorkArea.TabIndex = 50;
            this.txtboxWorkArea.Text = "Work Area 1";
            // 
            // txtboxModifyPassword
            // 
            this.txtboxModifyPassword.Location = new System.Drawing.Point(367, 87);
            this.txtboxModifyPassword.Name = "txtboxModifyPassword";
            this.txtboxModifyPassword.Size = new System.Drawing.Size(118, 20);
            this.txtboxModifyPassword.TabIndex = 32;
            // 
            // txtboxUsername
            // 
            this.txtboxUsername.Location = new System.Drawing.Point(86, 50);
            this.txtboxUsername.Name = "txtboxUsername";
            this.txtboxUsername.Size = new System.Drawing.Size(108, 20);
            this.txtboxUsername.TabIndex = 22;
            // 
            // txtboxPassword
            // 
            this.txtboxPassword.Location = new System.Drawing.Point(86, 87);
            this.txtboxPassword.Name = "txtboxPassword";
            this.txtboxPassword.Size = new System.Drawing.Size(108, 20);
            this.txtboxPassword.TabIndex = 23;
            // 
            // lblScheduleEnd
            // 
            this.lblScheduleEnd.AutoSize = true;
            this.lblScheduleEnd.Location = new System.Drawing.Point(5, 326);
            this.lblScheduleEnd.Name = "lblScheduleEnd";
            this.lblScheduleEnd.Size = new System.Drawing.Size(77, 13);
            this.lblScheduleEnd.TabIndex = 49;
            this.lblScheduleEnd.Text = "Schedule End:";
            // 
            // lblScheduleStart
            // 
            this.lblScheduleStart.AutoSize = true;
            this.lblScheduleStart.Location = new System.Drawing.Point(5, 274);
            this.lblScheduleStart.Name = "lblScheduleStart";
            this.lblScheduleStart.Size = new System.Drawing.Size(80, 13);
            this.lblScheduleStart.TabIndex = 48;
            this.lblScheduleStart.Text = "Schedule Start:";
            // 
            // lblAdminProducts
            // 
            this.lblAdminProducts.AutoSize = true;
            this.lblAdminProducts.Location = new System.Drawing.Point(5, 429);
            this.lblAdminProducts.Name = "lblAdminProducts";
            this.lblAdminProducts.Size = new System.Drawing.Size(52, 13);
            this.lblAdminProducts.TabIndex = 47;
            this.lblAdminProducts.Text = "Products:";
            // 
            // comboAdminProducts
            // 
            this.comboAdminProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAdminProducts.FormattingEnabled = true;
            this.comboAdminProducts.Location = new System.Drawing.Point(17, 447);
            this.comboAdminProducts.Name = "comboAdminProducts";
            this.comboAdminProducts.Size = new System.Drawing.Size(177, 21);
            this.comboAdminProducts.Sorted = true;
            this.comboAdminProducts.TabIndex = 46;
            // 
            // datetimeScheduleEnd
            // 
            this.datetimeScheduleEnd.CustomFormat = "dd/MM/yyyy    |    hh:mm:ss tt";
            this.datetimeScheduleEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeScheduleEnd.Location = new System.Drawing.Point(17, 342);
            this.datetimeScheduleEnd.Name = "datetimeScheduleEnd";
            this.datetimeScheduleEnd.Size = new System.Drawing.Size(199, 20);
            this.datetimeScheduleEnd.TabIndex = 45;
            this.datetimeScheduleEnd.ValueChanged += new System.EventHandler(this.datetimeScheduleEnd_ValueChanged);
            // 
            // datetimeScheduleStart
            // 
            this.datetimeScheduleStart.CustomFormat = "dd/MM/yyyy    |    hh:mm:ss tt";
            this.datetimeScheduleStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeScheduleStart.Location = new System.Drawing.Point(17, 290);
            this.datetimeScheduleStart.Name = "datetimeScheduleStart";
            this.datetimeScheduleStart.Size = new System.Drawing.Size(199, 20);
            this.datetimeScheduleStart.TabIndex = 44;
            this.datetimeScheduleStart.ValueChanged += new System.EventHandler(this.datetimeScheduleStart_ValueChanged);
            // 
            // lblSeparator2
            // 
            this.lblSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator2.Location = new System.Drawing.Point(243, 23);
            this.lblSeparator2.Name = "lblSeparator2";
            this.lblSeparator2.Size = new System.Drawing.Size(1, 152);
            this.lblSeparator2.TabIndex = 37;
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Location = new System.Drawing.Point(292, 153);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(85, 23);
            this.btnModifyUser.TabIndex = 36;
            this.btnModifyUser.Text = "Modify User";
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Click += new System.EventHandler(this.btnModifyUser_Click);
            // 
            // radioModifyAdministrator
            // 
            this.radioModifyAdministrator.AutoSize = true;
            this.radioModifyAdministrator.Location = new System.Drawing.Point(383, 120);
            this.radioModifyAdministrator.Name = "radioModifyAdministrator";
            this.radioModifyAdministrator.Size = new System.Drawing.Size(85, 17);
            this.radioModifyAdministrator.TabIndex = 35;
            this.radioModifyAdministrator.TabStop = true;
            this.radioModifyAdministrator.Text = "Administrator";
            this.radioModifyAdministrator.UseVisualStyleBackColor = true;
            // 
            // radioModifyGeneral
            // 
            this.radioModifyGeneral.AutoSize = true;
            this.radioModifyGeneral.Location = new System.Drawing.Point(309, 120);
            this.radioModifyGeneral.Name = "radioModifyGeneral";
            this.radioModifyGeneral.Size = new System.Drawing.Size(62, 17);
            this.radioModifyGeneral.TabIndex = 34;
            this.radioModifyGeneral.TabStop = true;
            this.radioModifyGeneral.Text = "General";
            this.radioModifyGeneral.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Password   :";
            // 
            // lblSelectAUser
            // 
            this.lblSelectAUser.AutoSize = true;
            this.lblSelectAUser.Location = new System.Drawing.Point(292, 54);
            this.lblSelectAUser.Name = "lblSelectAUser";
            this.lblSelectAUser.Size = new System.Drawing.Size(69, 13);
            this.lblSelectAUser.TabIndex = 31;
            this.lblSelectAUser.Text = "Select a user";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(399, 153);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(86, 23);
            this.btnDeleteUser.TabIndex = 30;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // comboUsers
            // 
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(367, 50);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(118, 21);
            this.comboUsers.TabIndex = 29;
            this.comboUsers.Click += new System.EventHandler(this.comboUsers_Click);
            // 
            // radioAdministrator
            // 
            this.radioAdministrator.AutoSize = true;
            this.radioAdministrator.Location = new System.Drawing.Point(86, 120);
            this.radioAdministrator.Name = "radioAdministrator";
            this.radioAdministrator.Size = new System.Drawing.Size(85, 17);
            this.radioAdministrator.TabIndex = 28;
            this.radioAdministrator.TabStop = true;
            this.radioAdministrator.Text = "Administrator";
            this.radioAdministrator.UseVisualStyleBackColor = true;
            // 
            // radioGeneral
            // 
            this.radioGeneral.AutoSize = true;
            this.radioGeneral.Location = new System.Drawing.Point(12, 120);
            this.radioGeneral.Name = "radioGeneral";
            this.radioGeneral.Size = new System.Drawing.Size(62, 17);
            this.radioGeneral.TabIndex = 27;
            this.radioGeneral.TabStop = true;
            this.radioGeneral.Text = "General";
            this.radioGeneral.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(17, 153);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(177, 23);
            this.btnAddUser.TabIndex = 26;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(5, 91);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 13);
            this.lblPassword.TabIndex = 25;
            this.lblPassword.Text = "Password   :";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(5, 54);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(66, 13);
            this.lblUsername.TabIndex = 24;
            this.lblUsername.Text = "User Name :";
            // 
            // lblModifyDeleteUser
            // 
            this.lblModifyDeleteUser.AutoSize = true;
            this.lblModifyDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblModifyDeleteUser.Location = new System.Drawing.Point(290, 15);
            this.lblModifyDeleteUser.Name = "lblModifyDeleteUser";
            this.lblModifyDeleteUser.Size = new System.Drawing.Size(195, 25);
            this.lblModifyDeleteUser.TabIndex = 2;
            this.lblModifyDeleteUser.Text = "Modify/Delete User";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblCreateUser.Location = new System.Drawing.Point(1, 15);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(127, 25);
            this.lblCreateUser.TabIndex = 1;
            this.lblCreateUser.Text = "Create User";
            // 
            // tabMainPage
            // 
            this.tabMainPage.Controls.Add(this.chkboxDefectsFilter);
            this.tabMainPage.Controls.Add(this.chkboxColoursFilter);
            this.tabMainPage.Controls.Add(this.chkboxProductsFilter);
            this.tabMainPage.Controls.Add(this.lblEndDate);
            this.tabMainPage.Controls.Add(this.lblStartDate);
            this.tabMainPage.Controls.Add(this.dateTimeEnd);
            this.tabMainPage.Controls.Add(this.dateTimeStart);
            this.tabMainPage.Controls.Add(this.lblFeedBack);
            this.tabMainPage.Controls.Add(this.chkboxDateFilter);
            this.tabMainPage.Controls.Add(this.chartResults);
            this.tabMainPage.Controls.Add(this.lblSeparator);
            this.tabMainPage.Controls.Add(this.comboDefects);
            this.tabMainPage.Controls.Add(this.lblDefects);
            this.tabMainPage.Controls.Add(this.lblProducts);
            this.tabMainPage.Controls.Add(this.lblColours);
            this.tabMainPage.Controls.Add(this.lblFilters);
            this.tabMainPage.Controls.Add(this.comboColours);
            this.tabMainPage.Controls.Add(this.comboProducts);
            this.tabMainPage.Controls.Add(this.btnUpdate);
            this.tabMainPage.Controls.Add(this.datagridTable);
            this.tabMainPage.Controls.Add(this.radioPareto);
            this.tabMainPage.Controls.Add(this.radioFinalYield);
            this.tabMainPage.Controls.Add(this.radioFirstTimeYield);
            this.tabMainPage.Controls.Add(this.lblDiagram);
            this.tabMainPage.Location = new System.Drawing.Point(4, 22);
            this.tabMainPage.Name = "tabMainPage";
            this.tabMainPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainPage.Size = new System.Drawing.Size(752, 512);
            this.tabMainPage.TabIndex = 0;
            this.tabMainPage.Text = "Main View";
            this.tabMainPage.UseVisualStyleBackColor = true;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(393, 86);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(77, 13);
            this.lblEndDate.TabIndex = 53;
            this.lblEndDate.Text = "Schedule End:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(393, 40);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(80, 13);
            this.lblStartDate.TabIndex = 52;
            this.lblStartDate.Text = "Schedule Start:";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "dd/MM/yyyy    |    hh:mm:ss tt";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(476, 82);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(199, 20);
            this.dateTimeEnd.TabIndex = 51;
            this.dateTimeEnd.ValueChanged += new System.EventHandler(this.dateTimeEnd_ValueChanged);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "dd/MM/yyyy    |    hh:mm:ss tt";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(474, 36);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(199, 20);
            this.dateTimeStart.TabIndex = 50;
            this.dateTimeStart.ValueChanged += new System.EventHandler(this.dateTimeStart_ValueChanged);
            // 
            // lblFeedBack
            // 
            this.lblFeedBack.AutoSize = true;
            this.lblFeedBack.ForeColor = System.Drawing.Color.Red;
            this.lblFeedBack.Location = new System.Drawing.Point(313, 197);
            this.lblFeedBack.Name = "lblFeedBack";
            this.lblFeedBack.Size = new System.Drawing.Size(0, 13);
            this.lblFeedBack.TabIndex = 46;
            // 
            // chkboxDateFilter
            // 
            this.chkboxDateFilter.AutoSize = true;
            this.chkboxDateFilter.Location = new System.Drawing.Point(396, 137);
            this.chkboxDateFilter.Name = "chkboxDateFilter";
            this.chkboxDateFilter.Size = new System.Drawing.Size(103, 17);
            this.chkboxDateFilter.TabIndex = 45;
            this.chkboxDateFilter.Text = "Apply Date Filter";
            this.chkboxDateFilter.UseVisualStyleBackColor = true;
            // 
            // chartResults
            // 
            chartArea5.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartResults.Legends.Add(legend5);
            this.chartResults.Location = new System.Drawing.Point(365, 197);
            this.chartResults.Name = "chartResults";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartResults.Series.Add(series5);
            this.chartResults.Size = new System.Drawing.Size(381, 309);
            this.chartResults.TabIndex = 44;
            this.chartResults.Text = "Display Results";
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Location = new System.Drawing.Point(365, 2);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(1, 152);
            this.lblSeparator.TabIndex = 43;
            // 
            // comboDefects
            // 
            this.comboDefects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefects.FormattingEnabled = true;
            this.comboDefects.Location = new System.Drawing.Point(205, 102);
            this.comboDefects.Name = "comboDefects";
            this.comboDefects.Size = new System.Drawing.Size(121, 21);
            this.comboDefects.Sorted = true;
            this.comboDefects.TabIndex = 39;
            // 
            // lblDefects
            // 
            this.lblDefects.AutoSize = true;
            this.lblDefects.Location = new System.Drawing.Point(152, 102);
            this.lblDefects.Name = "lblDefects";
            this.lblDefects.Size = new System.Drawing.Size(47, 13);
            this.lblDefects.TabIndex = 36;
            this.lblDefects.Text = "Defects:";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(152, 41);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(49, 13);
            this.lblProducts.TabIndex = 35;
            this.lblProducts.Text = "Products";
            // 
            // lblColours
            // 
            this.lblColours.AutoSize = true;
            this.lblColours.Location = new System.Drawing.Point(152, 71);
            this.lblColours.Name = "lblColours";
            this.lblColours.Size = new System.Drawing.Size(45, 13);
            this.lblColours.TabIndex = 34;
            this.lblColours.Text = "Colours:";
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilters.Location = new System.Drawing.Point(150, 2);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(77, 25);
            this.lblFilters.TabIndex = 33;
            this.lblFilters.Text = "Filters:";
            // 
            // comboColours
            // 
            this.comboColours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColours.FormattingEnabled = true;
            this.comboColours.Location = new System.Drawing.Point(205, 71);
            this.comboColours.Name = "comboColours";
            this.comboColours.Size = new System.Drawing.Size(121, 21);
            this.comboColours.Sorted = true;
            this.comboColours.TabIndex = 32;
            // 
            // comboProducts
            // 
            this.comboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProducts.FormattingEnabled = true;
            this.comboProducts.Location = new System.Drawing.Point(205, 40);
            this.comboProducts.Name = "comboProducts";
            this.comboProducts.Size = new System.Drawing.Size(121, 21);
            this.comboProducts.Sorted = true;
            this.comboProducts.TabIndex = 31;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(6, 171);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(740, 23);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // datagridTable
            // 
            this.datagridTable.AllowUserToAddRows = false;
            this.datagridTable.AllowUserToDeleteRows = false;
            this.datagridTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.datagridTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.datagridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridTable.Location = new System.Drawing.Point(6, 200);
            this.datagridTable.Name = "datagridTable";
            this.datagridTable.ReadOnly = true;
            this.datagridTable.Size = new System.Drawing.Size(353, 306);
            this.datagridTable.TabIndex = 29;
            // 
            // radioPareto
            // 
            this.radioPareto.AutoSize = true;
            this.radioPareto.Location = new System.Drawing.Point(3, 84);
            this.radioPareto.Name = "radioPareto";
            this.radioPareto.Size = new System.Drawing.Size(56, 17);
            this.radioPareto.TabIndex = 28;
            this.radioPareto.Text = "Pareto";
            this.radioPareto.UseVisualStyleBackColor = true;
            // 
            // radioFinalYield
            // 
            this.radioFinalYield.AutoSize = true;
            this.radioFinalYield.Location = new System.Drawing.Point(3, 61);
            this.radioFinalYield.Name = "radioFinalYield";
            this.radioFinalYield.Size = new System.Drawing.Size(73, 17);
            this.radioFinalYield.TabIndex = 27;
            this.radioFinalYield.Text = "Final Yield";
            this.radioFinalYield.UseVisualStyleBackColor = true;
            // 
            // radioFirstTimeYield
            // 
            this.radioFirstTimeYield.AutoSize = true;
            this.radioFirstTimeYield.Checked = true;
            this.radioFirstTimeYield.Location = new System.Drawing.Point(3, 38);
            this.radioFirstTimeYield.Name = "radioFirstTimeYield";
            this.radioFirstTimeYield.Size = new System.Drawing.Size(96, 17);
            this.radioFirstTimeYield.TabIndex = 26;
            this.radioFirstTimeYield.TabStop = true;
            this.radioFirstTimeYield.Text = "First Time Yield";
            this.radioFirstTimeYield.UseVisualStyleBackColor = true;
            // 
            // lblDiagram
            // 
            this.lblDiagram.AutoSize = true;
            this.lblDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagram.Location = new System.Drawing.Point(0, 2);
            this.lblDiagram.Name = "lblDiagram";
            this.lblDiagram.Size = new System.Drawing.Size(109, 25);
            this.lblDiagram.TabIndex = 25;
            this.lblDiagram.Text = "Diagrams:";
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.tabMainPage);
            this.tabController.Controls.Add(this.tabManagement);
            this.tabController.Location = new System.Drawing.Point(12, 12);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(760, 538);
            this.tabController.TabIndex = 16;
            // 
            // chkboxProductsFilter
            // 
            this.chkboxProductsFilter.AutoSize = true;
            this.chkboxProductsFilter.Location = new System.Drawing.Point(333, 43);
            this.chkboxProductsFilter.Name = "chkboxProductsFilter";
            this.chkboxProductsFilter.Size = new System.Drawing.Size(15, 14);
            this.chkboxProductsFilter.TabIndex = 54;
            this.chkboxProductsFilter.UseVisualStyleBackColor = true;
            // 
            // chkboxColoursFilter
            // 
            this.chkboxColoursFilter.AutoSize = true;
            this.chkboxColoursFilter.Location = new System.Drawing.Point(333, 74);
            this.chkboxColoursFilter.Name = "chkboxColoursFilter";
            this.chkboxColoursFilter.Size = new System.Drawing.Size(15, 14);
            this.chkboxColoursFilter.TabIndex = 55;
            this.chkboxColoursFilter.UseVisualStyleBackColor = true;
            // 
            // chkboxDefectsFilter
            // 
            this.chkboxDefectsFilter.AutoSize = true;
            this.chkboxDefectsFilter.Location = new System.Drawing.Point(333, 105);
            this.chkboxDefectsFilter.Name = "chkboxDefectsFilter";
            this.chkboxDefectsFilter.Size = new System.Drawing.Size(15, 14);
            this.chkboxDefectsFilter.TabIndex = 56;
            this.chkboxDefectsFilter.UseVisualStyleBackColor = true;
            // 
            // frmAdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabController);
            this.Name = "frmAdminPage";
            this.Text = "AdminPage";
            this.tabManagement.ResumeLayout(false);
            this.tabManagement.PerformLayout();
            this.tabMainPage.ResumeLayout(false);
            this.tabMainPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTable)).EndInit();
            this.tabController.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabManagement;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Label lblScheduleMaintenance;
        private System.Windows.Forms.Label lblWorkArea;
        private System.Windows.Forms.TextBox txtboxWorkArea;
        private System.Windows.Forms.TextBox txtboxModifyPassword;
        private System.Windows.Forms.TextBox txtboxUsername;
        private System.Windows.Forms.TextBox txtboxPassword;
        private System.Windows.Forms.Label lblScheduleEnd;
        private System.Windows.Forms.Label lblScheduleStart;
        private System.Windows.Forms.Label lblAdminProducts;
        private System.Windows.Forms.ComboBox comboAdminProducts;
        private System.Windows.Forms.DateTimePicker datetimeScheduleEnd;
        private System.Windows.Forms.DateTimePicker datetimeScheduleStart;
        private System.Windows.Forms.Label lblSeparator2;
        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.RadioButton radioModifyAdministrator;
        private System.Windows.Forms.RadioButton radioModifyGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectAUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.ComboBox comboUsers;
        private System.Windows.Forms.RadioButton radioAdministrator;
        private System.Windows.Forms.RadioButton radioGeneral;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblModifyDeleteUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TabPage tabMainPage;
        private System.Windows.Forms.Label lblFeedBack;
        private System.Windows.Forms.CheckBox chkboxDateFilter;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.ComboBox comboDefects;
        private System.Windows.Forms.Label lblDefects;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblColours;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.ComboBox comboColours;
        private System.Windows.Forms.ComboBox comboProducts;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView datagridTable;
        private System.Windows.Forms.RadioButton radioPareto;
        private System.Windows.Forms.RadioButton radioFinalYield;
        private System.Windows.Forms.RadioButton radioFirstTimeYield;
        private System.Windows.Forms.Label lblDiagram;
        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.CheckBox chkboxDefectsFilter;
        private System.Windows.Forms.CheckBox chkboxColoursFilter;
        private System.Windows.Forms.CheckBox chkboxProductsFilter;

    }
}