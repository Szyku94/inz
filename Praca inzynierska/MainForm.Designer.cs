namespace Praca_inzynierska
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.SortTabPage = new System.Windows.Forms.TabPage();
            this.SortStartingDataLabel = new System.Windows.Forms.Label();
            this.SortAlgorithmLabel = new System.Windows.Forms.Label();
            this.SortStartingDataComboBox = new System.Windows.Forms.ComboBox();
            this.SortAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.SortStartButton = new System.Windows.Forms.Button();
            this.PathfindingTabPage = new System.Windows.Forms.TabPage();
            this.SortNumberOfElementsLabel = new System.Windows.Forms.Label();
            this.SortNumberOfElementsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PathfindingAlgorithmLabel = new System.Windows.Forms.Label();
            this.PathfindingAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.PathfindingStartButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.SortTabPage.SuspendLayout();
            this.PathfindingTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SortNumberOfElementsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.SortTabPage);
            this.tabControl.Controls.Add(this.PathfindingTabPage);
            this.tabControl.Location = new System.Drawing.Point(2, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(274, 256);
            this.tabControl.TabIndex = 0;
            // 
            // SortTabPage
            // 
            this.SortTabPage.Controls.Add(this.SortNumberOfElementsNumericUpDown);
            this.SortTabPage.Controls.Add(this.SortNumberOfElementsLabel);
            this.SortTabPage.Controls.Add(this.SortStartingDataLabel);
            this.SortTabPage.Controls.Add(this.SortAlgorithmLabel);
            this.SortTabPage.Controls.Add(this.SortStartingDataComboBox);
            this.SortTabPage.Controls.Add(this.SortAlgorithmComboBox);
            this.SortTabPage.Controls.Add(this.SortStartButton);
            this.SortTabPage.Location = new System.Drawing.Point(4, 22);
            this.SortTabPage.Name = "SortTabPage";
            this.SortTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SortTabPage.Size = new System.Drawing.Size(266, 230);
            this.SortTabPage.TabIndex = 0;
            this.SortTabPage.Text = "Sortowanie";
            this.SortTabPage.UseVisualStyleBackColor = true;
            // 
            // SortStartingDataLabel
            // 
            this.SortStartingDataLabel.AutoSize = true;
            this.SortStartingDataLabel.Location = new System.Drawing.Point(16, 64);
            this.SortStartingDataLabel.Name = "SortStartingDataLabel";
            this.SortStartingDataLabel.Size = new System.Drawing.Size(93, 13);
            this.SortStartingDataLabel.TabIndex = 4;
            this.SortStartingDataLabel.Text = "Początkowe dane";
            // 
            // SortAlgorithmLabel
            // 
            this.SortAlgorithmLabel.AutoSize = true;
            this.SortAlgorithmLabel.Location = new System.Drawing.Point(16, 14);
            this.SortAlgorithmLabel.Name = "SortAlgorithmLabel";
            this.SortAlgorithmLabel.Size = new System.Drawing.Size(101, 13);
            this.SortAlgorithmLabel.TabIndex = 3;
            this.SortAlgorithmLabel.Text = "Algorytm sortowania";
            // 
            // SortStartingDataComboBox
            // 
            this.SortStartingDataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortStartingDataComboBox.FormattingEnabled = true;
            this.SortStartingDataComboBox.Items.AddRange(new object[] {
            "Losowe",
            "Kilka unikatowych",
            "Posortowane odwrotnie"});
            this.SortStartingDataComboBox.Location = new System.Drawing.Point(19, 80);
            this.SortStartingDataComboBox.Name = "SortStartingDataComboBox";
            this.SortStartingDataComboBox.Size = new System.Drawing.Size(121, 21);
            this.SortStartingDataComboBox.TabIndex = 2;
            this.SortStartingDataComboBox.SelectedIndex = 0;
            // 
            // SortAlgorithmComboBox
            // 
            this.SortAlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortAlgorithmComboBox.FormattingEnabled = true;
            this.SortAlgorithmComboBox.Items.AddRange(new object[] {
            "Bubble",
            "Cocktail",
            "Comb",
            "Counting",
            "Heap",
            "Insertion",
            "Merge",
            "Quick",
            "Selection",
            "Shell"});
            this.SortAlgorithmComboBox.Location = new System.Drawing.Point(19, 31);
            this.SortAlgorithmComboBox.Name = "SortAlgorithmComboBox";
            this.SortAlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.SortAlgorithmComboBox.TabIndex = 1;
            this.SortAlgorithmComboBox.SelectedIndex = 0;
            // 
            // SortStartButton
            // 
            this.SortStartButton.Location = new System.Drawing.Point(94, 175);
            this.SortStartButton.Name = "SortStartButton";
            this.SortStartButton.Size = new System.Drawing.Size(75, 23);
            this.SortStartButton.TabIndex = 0;
            this.SortStartButton.Text = "Start";
            this.SortStartButton.UseVisualStyleBackColor = true;
            this.SortStartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PathfindingTabPage
            // 
            this.PathfindingTabPage.Controls.Add(this.PathfindingAlgorithmLabel);
            this.PathfindingTabPage.Controls.Add(this.PathfindingAlgorithmComboBox);
            this.PathfindingTabPage.Controls.Add(this.PathfindingStartButton);
            this.PathfindingTabPage.Location = new System.Drawing.Point(4, 22);
            this.PathfindingTabPage.Name = "PathfindingTabPage";
            this.PathfindingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PathfindingTabPage.Size = new System.Drawing.Size(266, 230);
            this.PathfindingTabPage.TabIndex = 1;
            this.PathfindingTabPage.Text = "Pathfinding";
            this.PathfindingTabPage.UseVisualStyleBackColor = true;
            // 
            // SortNumberOfElementsLabel
            // 
            this.SortNumberOfElementsLabel.AutoSize = true;
            this.SortNumberOfElementsLabel.Location = new System.Drawing.Point(16, 114);
            this.SortNumberOfElementsLabel.Name = "SortNumberOfElementsLabel";
            this.SortNumberOfElementsLabel.Size = new System.Drawing.Size(83, 13);
            this.SortNumberOfElementsLabel.TabIndex = 5;
            this.SortNumberOfElementsLabel.Text = "Ilość elementów";
            // 
            // SortNumberOfElementsNumericUpDown
            // 
            this.SortNumberOfElementsNumericUpDown.Location = new System.Drawing.Point(19, 130);
            this.SortNumberOfElementsNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SortNumberOfElementsNumericUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SortNumberOfElementsNumericUpDown.Name = "SortNumberOfElementsNumericUpDown";
            this.SortNumberOfElementsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.SortNumberOfElementsNumericUpDown.TabIndex = 6;
            this.SortNumberOfElementsNumericUpDown.ThousandsSeparator = true;
            this.SortNumberOfElementsNumericUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // PathfindingAlgorithmLabel
            // 
            this.PathfindingAlgorithmLabel.AutoSize = true;
            this.PathfindingAlgorithmLabel.Location = new System.Drawing.Point(13, 11);
            this.PathfindingAlgorithmLabel.Name = "PathfindingAlgorithmLabel";
            this.PathfindingAlgorithmLabel.Size = new System.Drawing.Size(115, 13);
            this.PathfindingAlgorithmLabel.TabIndex = 10;
            this.PathfindingAlgorithmLabel.Text = "Algorytm wyszukiwania";
            // 
            // PathfindingAlgorithmComboBox
            // 
            this.PathfindingAlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PathfindingAlgorithmComboBox.FormattingEnabled = true;
            this.PathfindingAlgorithmComboBox.Items.AddRange(new object[] {
            "A*",
            "BFS",
            "Dwukierunkowe BFS",
            "Dijkstra"});
            this.PathfindingAlgorithmComboBox.Location = new System.Drawing.Point(16, 28);
            this.PathfindingAlgorithmComboBox.Name = "PathfindingAlgorithmComboBox";
            this.PathfindingAlgorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.PathfindingAlgorithmComboBox.TabIndex = 8;
            this.PathfindingAlgorithmComboBox.SelectedIndex = 0;
            // 
            // PathfindingStartButton
            // 
            this.PathfindingStartButton.Location = new System.Drawing.Point(91, 172);
            this.PathfindingStartButton.Name = "PathfindingStartButton";
            this.PathfindingStartButton.Size = new System.Drawing.Size(75, 23);
            this.PathfindingStartButton.TabIndex = 7;
            this.PathfindingStartButton.Text = "Start";
            this.PathfindingStartButton.UseVisualStyleBackColor = true;
            this.PathfindingStartButton.Click += new System.EventHandler(this.PathfindingStartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 259);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Program";
            this.tabControl.ResumeLayout(false);
            this.SortTabPage.ResumeLayout(false);
            this.SortTabPage.PerformLayout();
            this.PathfindingTabPage.ResumeLayout(false);
            this.PathfindingTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SortNumberOfElementsNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage SortTabPage;
        private System.Windows.Forms.TabPage PathfindingTabPage;
        private System.Windows.Forms.Button SortStartButton;
        private System.Windows.Forms.ComboBox SortStartingDataComboBox;
        private System.Windows.Forms.ComboBox SortAlgorithmComboBox;
        private System.Windows.Forms.Label SortStartingDataLabel;
        private System.Windows.Forms.Label SortAlgorithmLabel;
        private System.Windows.Forms.NumericUpDown SortNumberOfElementsNumericUpDown;
        private System.Windows.Forms.Label SortNumberOfElementsLabel;
        private System.Windows.Forms.Label PathfindingAlgorithmLabel;
        private System.Windows.Forms.ComboBox PathfindingAlgorithmComboBox;
        private System.Windows.Forms.Button PathfindingStartButton;
    }
}

