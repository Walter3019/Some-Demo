namespace ASQL_Final_Yoyo
{
    partial class frmUserPage
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
            this.chkboxDefectsFilter = new System.Windows.Forms.CheckBox();
            this.chkboxColoursFilter = new System.Windows.Forms.CheckBox();
            this.chkboxProductsFilter = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTable)).BeginInit();
            this.SuspendLayout();
            // 
            // chkboxDefectsFilter
            // 
            this.chkboxDefectsFilter.AutoSize = true;
            this.chkboxDefectsFilter.Location = new System.Drawing.Point(352, 132);
            this.chkboxDefectsFilter.Name = "chkboxDefectsFilter";
            this.chkboxDefectsFilter.Size = new System.Drawing.Size(15, 14);
            this.chkboxDefectsFilter.TabIndex = 80;
            this.chkboxDefectsFilter.UseVisualStyleBackColor = true;
            // 
            // chkboxColoursFilter
            // 
            this.chkboxColoursFilter.AutoSize = true;
            this.chkboxColoursFilter.Location = new System.Drawing.Point(352, 101);
            this.chkboxColoursFilter.Name = "chkboxColoursFilter";
            this.chkboxColoursFilter.Size = new System.Drawing.Size(15, 14);
            this.chkboxColoursFilter.TabIndex = 79;
            this.chkboxColoursFilter.UseVisualStyleBackColor = true;
            // 
            // chkboxProductsFilter
            // 
            this.chkboxProductsFilter.AutoSize = true;
            this.chkboxProductsFilter.Location = new System.Drawing.Point(352, 70);
            this.chkboxProductsFilter.Name = "chkboxProductsFilter";
            this.chkboxProductsFilter.Size = new System.Drawing.Size(15, 14);
            this.chkboxProductsFilter.TabIndex = 78;
            this.chkboxProductsFilter.UseVisualStyleBackColor = true;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(412, 113);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(77, 13);
            this.lblEndDate.TabIndex = 77;
            this.lblEndDate.Text = "Schedule End:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(412, 67);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(80, 13);
            this.lblStartDate.TabIndex = 76;
            this.lblStartDate.Text = "Schedule Start:";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "dd/MM/yyyy    |    hh:mm:ss tt";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(495, 109);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(199, 20);
            this.dateTimeEnd.TabIndex = 75;
            this.dateTimeEnd.ValueChanged += new System.EventHandler(this.dateTimeEnd_ValueChanged);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "dd/MM/yyyy    |    hh:mm:ss tt";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(493, 63);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(199, 20);
            this.dateTimeStart.TabIndex = 74;
            this.dateTimeStart.ValueChanged += new System.EventHandler(this.dateTimeStart_ValueChanged);
            // 
            // lblFeedBack
            // 
            this.lblFeedBack.AutoSize = true;
            this.lblFeedBack.ForeColor = System.Drawing.Color.Red;
            this.lblFeedBack.Location = new System.Drawing.Point(332, 224);
            this.lblFeedBack.Name = "lblFeedBack";
            this.lblFeedBack.Size = new System.Drawing.Size(0, 13);
            this.lblFeedBack.TabIndex = 73;
            // 
            // chkboxDateFilter
            // 
            this.chkboxDateFilter.AutoSize = true;
            this.chkboxDateFilter.Location = new System.Drawing.Point(415, 164);
            this.chkboxDateFilter.Name = "chkboxDateFilter";
            this.chkboxDateFilter.Size = new System.Drawing.Size(103, 17);
            this.chkboxDateFilter.TabIndex = 72;
            this.chkboxDateFilter.Text = "Apply Date Filter";
            this.chkboxDateFilter.UseVisualStyleBackColor = true;
            // 
            // chartResults
            // 
            chartArea5.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartResults.Legends.Add(legend5);
            this.chartResults.Location = new System.Drawing.Point(384, 224);
            this.chartResults.Name = "chartResults";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartResults.Series.Add(series5);
            this.chartResults.Size = new System.Drawing.Size(381, 309);
            this.chartResults.TabIndex = 71;
            this.chartResults.Text = "Display Results";
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Location = new System.Drawing.Point(384, 29);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(1, 152);
            this.lblSeparator.TabIndex = 70;
            // 
            // comboDefects
            // 
            this.comboDefects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefects.FormattingEnabled = true;
            this.comboDefects.Location = new System.Drawing.Point(224, 129);
            this.comboDefects.Name = "comboDefects";
            this.comboDefects.Size = new System.Drawing.Size(121, 21);
            this.comboDefects.Sorted = true;
            this.comboDefects.TabIndex = 69;
            // 
            // lblDefects
            // 
            this.lblDefects.AutoSize = true;
            this.lblDefects.Location = new System.Drawing.Point(171, 129);
            this.lblDefects.Name = "lblDefects";
            this.lblDefects.Size = new System.Drawing.Size(47, 13);
            this.lblDefects.TabIndex = 68;
            this.lblDefects.Text = "Defects:";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(171, 68);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(49, 13);
            this.lblProducts.TabIndex = 67;
            this.lblProducts.Text = "Products";
            // 
            // lblColours
            // 
            this.lblColours.AutoSize = true;
            this.lblColours.Location = new System.Drawing.Point(171, 98);
            this.lblColours.Name = "lblColours";
            this.lblColours.Size = new System.Drawing.Size(45, 13);
            this.lblColours.TabIndex = 66;
            this.lblColours.Text = "Colours:";
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilters.Location = new System.Drawing.Point(169, 29);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(77, 25);
            this.lblFilters.TabIndex = 65;
            this.lblFilters.Text = "Filters:";
            // 
            // comboColours
            // 
            this.comboColours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColours.FormattingEnabled = true;
            this.comboColours.Location = new System.Drawing.Point(224, 98);
            this.comboColours.Name = "comboColours";
            this.comboColours.Size = new System.Drawing.Size(121, 21);
            this.comboColours.Sorted = true;
            this.comboColours.TabIndex = 64;
            // 
            // comboProducts
            // 
            this.comboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProducts.FormattingEnabled = true;
            this.comboProducts.Location = new System.Drawing.Point(224, 67);
            this.comboProducts.Name = "comboProducts";
            this.comboProducts.Size = new System.Drawing.Size(121, 21);
            this.comboProducts.Sorted = true;
            this.comboProducts.TabIndex = 63;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(25, 198);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(740, 23);
            this.btnUpdate.TabIndex = 62;
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
            this.datagridTable.Location = new System.Drawing.Point(25, 227);
            this.datagridTable.Name = "datagridTable";
            this.datagridTable.ReadOnly = true;
            this.datagridTable.Size = new System.Drawing.Size(353, 306);
            this.datagridTable.TabIndex = 61;
            // 
            // radioPareto
            // 
            this.radioPareto.AutoSize = true;
            this.radioPareto.Location = new System.Drawing.Point(22, 111);
            this.radioPareto.Name = "radioPareto";
            this.radioPareto.Size = new System.Drawing.Size(56, 17);
            this.radioPareto.TabIndex = 60;
            this.radioPareto.Text = "Pareto";
            this.radioPareto.UseVisualStyleBackColor = true;
            // 
            // radioFinalYield
            // 
            this.radioFinalYield.AutoSize = true;
            this.radioFinalYield.Location = new System.Drawing.Point(22, 88);
            this.radioFinalYield.Name = "radioFinalYield";
            this.radioFinalYield.Size = new System.Drawing.Size(73, 17);
            this.radioFinalYield.TabIndex = 59;
            this.radioFinalYield.Text = "Final Yield";
            this.radioFinalYield.UseVisualStyleBackColor = true;
            // 
            // radioFirstTimeYield
            // 
            this.radioFirstTimeYield.AutoSize = true;
            this.radioFirstTimeYield.Checked = true;
            this.radioFirstTimeYield.Location = new System.Drawing.Point(22, 65);
            this.radioFirstTimeYield.Name = "radioFirstTimeYield";
            this.radioFirstTimeYield.Size = new System.Drawing.Size(96, 17);
            this.radioFirstTimeYield.TabIndex = 58;
            this.radioFirstTimeYield.TabStop = true;
            this.radioFirstTimeYield.Text = "First Time Yield";
            this.radioFirstTimeYield.UseVisualStyleBackColor = true;
            // 
            // lblDiagram
            // 
            this.lblDiagram.AutoSize = true;
            this.lblDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagram.Location = new System.Drawing.Point(19, 29);
            this.lblDiagram.Name = "lblDiagram";
            this.lblDiagram.Size = new System.Drawing.Size(109, 25);
            this.lblDiagram.TabIndex = 57;
            this.lblDiagram.Text = "Diagrams:";
            // 
            // frmUserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.chkboxDefectsFilter);
            this.Controls.Add(this.chkboxColoursFilter);
            this.Controls.Add(this.chkboxProductsFilter);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.lblFeedBack);
            this.Controls.Add(this.chkboxDateFilter);
            this.Controls.Add(this.chartResults);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.comboDefects);
            this.Controls.Add(this.lblDefects);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblColours);
            this.Controls.Add(this.lblFilters);
            this.Controls.Add(this.comboColours);
            this.Controls.Add(this.comboProducts);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.datagridTable);
            this.Controls.Add(this.radioPareto);
            this.Controls.Add(this.radioFinalYield);
            this.Controls.Add(this.radioFirstTimeYield);
            this.Controls.Add(this.lblDiagram);
            this.Name = "frmUserPage";
            this.Text = "UserPage";
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkboxDefectsFilter;
        private System.Windows.Forms.CheckBox chkboxColoursFilter;
        private System.Windows.Forms.CheckBox chkboxProductsFilter;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
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






    }
}