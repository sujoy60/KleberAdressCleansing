namespace TextExcel
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
            this.btn_Execute = new System.Windows.Forms.Button();
            this.btn_BrowseDestinationFile = new System.Windows.Forms.Button();
            this.btn_BrowseSource = new System.Windows.Forms.Button();
            this.txt_SourceFileLocation = new System.Windows.Forms.TextBox();
            this.txt_DestinationFileLocation = new System.Windows.Forms.TextBox();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Execute
            // 
            this.btn_Execute.Location = new System.Drawing.Point(420, 193);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(138, 23);
            this.btn_Execute.TabIndex = 0;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_BrowseDestinationFile
            // 
            this.btn_BrowseDestinationFile.Location = new System.Drawing.Point(420, 146);
            this.btn_BrowseDestinationFile.Name = "btn_BrowseDestinationFile";
            this.btn_BrowseDestinationFile.Size = new System.Drawing.Size(138, 23);
            this.btn_BrowseDestinationFile.TabIndex = 1;
            this.btn_BrowseDestinationFile.Text = "Browse Destination File";
            this.btn_BrowseDestinationFile.UseVisualStyleBackColor = true;
            this.btn_BrowseDestinationFile.Click += new System.EventHandler(this.btn_BrowseDestinationFile_Click);
            // 
            // btn_BrowseSource
            // 
            this.btn_BrowseSource.Location = new System.Drawing.Point(420, 99);
            this.btn_BrowseSource.Name = "btn_BrowseSource";
            this.btn_BrowseSource.Size = new System.Drawing.Size(138, 23);
            this.btn_BrowseSource.TabIndex = 2;
            this.btn_BrowseSource.Text = "Browse Source File";
            this.btn_BrowseSource.UseVisualStyleBackColor = true;
            this.btn_BrowseSource.Click += new System.EventHandler(this.btn_BrowseSourceFile_Click);
            // 
            // txt_SourceFileLocation
            // 
            this.txt_SourceFileLocation.Location = new System.Drawing.Point(206, 101);
            this.txt_SourceFileLocation.Name = "txt_SourceFileLocation";
            this.txt_SourceFileLocation.Size = new System.Drawing.Size(188, 20);
            this.txt_SourceFileLocation.TabIndex = 3;
            // 
            // txt_DestinationFileLocation
            // 
            this.txt_DestinationFileLocation.Location = new System.Drawing.Point(206, 146);
            this.txt_DestinationFileLocation.Name = "txt_DestinationFileLocation";
            this.txt_DestinationFileLocation.Size = new System.Drawing.Size(188, 20);
            this.txt_DestinationFileLocation.TabIndex = 4;
            // 
            // lbl_Result
            // 
            this.lbl_Result.AutoSize = true;
            this.lbl_Result.ForeColor = System.Drawing.Color.Red;
            this.lbl_Result.Location = new System.Drawing.Point(49, 212);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(0, 13);
            this.lbl_Result.TabIndex = 5;
            this.lbl_Result.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(79, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kleber Utility Tool";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(203, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 91);
            this.label2.TabIndex = 7;
            this.label2.Text = "Column Header\r\n-----------------\r\nAddressLine\r\nCity\r\nPostCode\r\nState\r\nDPID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(289, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 91);
            this.label3.TabIndex = 8;
            this.label3.Text = "Position\r\n---------\r\n10\r\n13\r\n15\r\n14\r\n16";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 368);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Result);
            this.Controls.Add(this.txt_DestinationFileLocation);
            this.Controls.Add(this.txt_SourceFileLocation);
            this.Controls.Add(this.btn_BrowseSource);
            this.Controls.Add(this.btn_BrowseDestinationFile);
            this.Controls.Add(this.btn_Execute);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Button btn_BrowseDestinationFile;
        private System.Windows.Forms.Button btn_BrowseSource;
        private System.Windows.Forms.TextBox txt_SourceFileLocation;
        private System.Windows.Forms.TextBox txt_DestinationFileLocation;
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

