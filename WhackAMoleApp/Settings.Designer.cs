namespace WhackAMoleApp
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabGeneralSettings = new System.Windows.Forms.TabPage();
            this.btnClearScores = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBGMVolume = new System.Windows.Forms.TrackBar();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDifficulty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSFXVolume = new System.Windows.Forms.TrackBar();
            this.lnkLoadDefaults = new System.Windows.Forms.LinkLabel();
            this.tabGeneralSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBGMVolume)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSFXVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(273, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(192, 258);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tabGeneralSettings
            // 
            this.tabGeneralSettings.Controls.Add(this.label4);
            this.tabGeneralSettings.Controls.Add(this.tbSFXVolume);
            this.tabGeneralSettings.Controls.Add(this.btnClearScores);
            this.tabGeneralSettings.Controls.Add(this.label3);
            this.tabGeneralSettings.Controls.Add(this.tbBGMVolume);
            this.tabGeneralSettings.Controls.Add(this.txtPlayerName);
            this.tabGeneralSettings.Controls.Add(this.label2);
            this.tabGeneralSettings.Controls.Add(this.cmbDifficulty);
            this.tabGeneralSettings.Controls.Add(this.label1);
            this.tabGeneralSettings.Location = new System.Drawing.Point(4, 22);
            this.tabGeneralSettings.Name = "tabGeneralSettings";
            this.tabGeneralSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralSettings.Size = new System.Drawing.Size(328, 214);
            this.tabGeneralSettings.TabIndex = 0;
            this.tabGeneralSettings.Text = "General";
            this.tabGeneralSettings.UseVisualStyleBackColor = true;
            // 
            // btnClearScores
            // 
            this.btnClearScores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearScores.Location = new System.Drawing.Point(9, 185);
            this.btnClearScores.Name = "btnClearScores";
            this.btnClearScores.Size = new System.Drawing.Size(313, 23);
            this.btnClearScores.TabIndex = 4;
            this.btnClearScores.Text = "Clear High Scores";
            this.btnClearScores.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "BGM Volume";
            // 
            // tbBGMVolume
            // 
            this.tbBGMVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBGMVolume.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbBGMVolume.Location = new System.Drawing.Point(176, 78);
            this.tbBGMVolume.Maximum = 100;
            this.tbBGMVolume.Name = "tbBGMVolume";
            this.tbBGMVolume.Size = new System.Drawing.Size(146, 45);
            this.tbBGMVolume.TabIndex = 4;
            this.tbBGMVolume.TickFrequency = 10;
            this.tbBGMVolume.Value = 50;
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlayerName.Location = new System.Drawing.Point(176, 51);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(146, 20);
            this.txtPlayerName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player  Name";
            // 
            // cmbDifficulty
            // 
            this.cmbDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulty.FormattingEnabled = true;
            this.cmbDifficulty.Location = new System.Drawing.Point(176, 23);
            this.cmbDifficulty.Name = "cmbDifficulty";
            this.cmbDifficulty.Size = new System.Drawing.Size(146, 21);
            this.cmbDifficulty.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Difficulty";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGeneralSettings);
            this.tabControl.Controls.Add(this.tabAbout);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(336, 240);
            this.tabControl.TabIndex = 3;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.textBox1);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(328, 214);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(322, 208);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "SFX Volume";
            // 
            // tbSFXVolume
            // 
            this.tbSFXVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSFXVolume.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbSFXVolume.Location = new System.Drawing.Point(176, 116);
            this.tbSFXVolume.Maximum = 100;
            this.tbSFXVolume.Name = "tbSFXVolume";
            this.tbSFXVolume.Size = new System.Drawing.Size(146, 45);
            this.tbSFXVolume.TabIndex = 6;
            this.tbSFXVolume.TickFrequency = 10;
            this.tbSFXVolume.Value = 50;
            // 
            // lnkLoadDefaults
            // 
            this.lnkLoadDefaults.AutoSize = true;
            this.lnkLoadDefaults.Location = new System.Drawing.Point(9, 263);
            this.lnkLoadDefaults.Name = "lnkLoadDefaults";
            this.lnkLoadDefaults.Size = new System.Drawing.Size(46, 13);
            this.lnkLoadDefaults.TabIndex = 4;
            this.lnkLoadDefaults.TabStop = true;
            this.lnkLoadDefaults.Text = "Defaults";
            // 
            // Settings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 293);
            this.Controls.Add(this.lnkLoadDefaults);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.tabGeneralSettings.ResumeLayout(false);
            this.tabGeneralSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBGMVolume)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSFXVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabGeneralSettings;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbBGMVolume;
        private System.Windows.Forms.Button btnClearScores;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbSFXVolume;
        private System.Windows.Forms.LinkLabel lnkLoadDefaults;
    }
}