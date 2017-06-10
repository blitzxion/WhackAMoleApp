namespace WhackAMoleApp
{
    partial class HighScores
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Entered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Missed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entered,
            this.PlayerName,
            this.Difficulty,
            this.Moles,
            this.Hit,
            this.Missed,
            this.Score});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(769, 278);
            this.dataGrid.TabIndex = 0;
            // 
            // Entered
            // 
            this.Entered.HeaderText = "Entered";
            this.Entered.Name = "Entered";
            this.Entered.ReadOnly = true;
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "Player Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            // 
            // Difficulty
            // 
            this.Difficulty.HeaderText = "Difficulty";
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.ReadOnly = true;
            // 
            // Moles
            // 
            this.Moles.HeaderText = "Moles";
            this.Moles.Name = "Moles";
            this.Moles.ReadOnly = true;
            // 
            // Hit
            // 
            this.Hit.HeaderText = "Hit";
            this.Hit.Name = "Hit";
            this.Hit.ReadOnly = true;
            // 
            // Missed
            // 
            this.Missed.HeaderText = "Missed";
            this.Missed.Name = "Missed";
            this.Missed.ReadOnly = true;
            // 
            // Score
            // 
            this.Score.HeaderText = "Total Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 278);
            this.Controls.Add(this.dataGrid);
            this.MinimumSize = new System.Drawing.Size(498, 317);
            this.Name = "HighScores";
            this.Text = "HighScores";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entered;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Missed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
    }
}