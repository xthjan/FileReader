namespace ExerciseFiles {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.gvData = new System.Windows.Forms.DataGridView();
            this.pcLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // ofDialog
            // 
            this.ofDialog.FileName = "openFileDialog1";
            this.ofDialog.Filter = "TXT files (*.txt)|*.txt";
            this.ofDialog.Title = "Open First File To Read";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(36, 29);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(154, 34);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 13);
            this.lblFileName.TabIndex = 1;
            // 
            // gvData
            // 
            this.gvData.AllowUserToAddRows = false;
            this.gvData.AllowUserToDeleteRows = false;
            this.gvData.AllowUserToResizeColumns = false;
            this.gvData.AllowUserToResizeRows = false;
            this.gvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvData.Location = new System.Drawing.Point(36, 79);
            this.gvData.Name = "gvData";
            this.gvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvData.Size = new System.Drawing.Size(930, 464);
            this.gvData.TabIndex = 2;
            // 
            // pcLoading
            // 
            this.pcLoading.Image = ((System.Drawing.Image)(resources.GetObject("pcLoading.Image")));
            this.pcLoading.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcLoading.InitialImage")));
            this.pcLoading.Location = new System.Drawing.Point(122, 33);
            this.pcLoading.Name = "pcLoading";
            this.pcLoading.Size = new System.Drawing.Size(18, 18);
            this.pcLoading.TabIndex = 3;
            this.pcLoading.TabStop = false;
            this.pcLoading.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 588);
            this.Controls.Add(this.pcLoading);
            this.Controls.Add(this.gvData);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "File Sum Test";
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.DataGridView gvData;
        private System.Windows.Forms.PictureBox pcLoading;
    }
}

