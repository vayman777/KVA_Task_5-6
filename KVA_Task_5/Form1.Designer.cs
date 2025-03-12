namespace KVA_Task_5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _loadButton = new Button();
            _checkButton = new Button();
            _сomboBox = new ComboBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            SuspendLayout();
            // 
            // _loadButton
            // 
            _loadButton.Location = new Point(515, 608);
            _loadButton.Name = "_loadButton";
            _loadButton.Size = new Size(100, 38);
            _loadButton.TabIndex = 0;
            _loadButton.Text = "Загрузить";
            _loadButton.Click += LoadButton_Click;
            // 
            // _checkButton
            // 
            _checkButton.Location = new Point(390, 610);
            _checkButton.Name = "_checkButton";
            _checkButton.Size = new Size(101, 36);
            _checkButton.TabIndex = 1;
            _checkButton.Text = "Проверить";
            _checkButton.Click += CheckButton_Click;
            // 
            // _сomboBox
            // 
            _сomboBox.Items.AddRange(new object[] { "Легкий", "Средний", "Сложный" });
            _сomboBox.Location = new Point(233, 614);
            _сomboBox.Name = "_сomboBox";
            _сomboBox.Size = new Size(121, 28);
            _сomboBox.TabIndex = 2;
            _сomboBox.Text = "Легкий";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(315, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 538);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(495, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 538);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaptionText;
            panel3.Location = new Point(139, 236);
            panel3.Name = "panel3";
            panel3.Size = new Size(546, 10);
            panel3.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaptionText;
            panel4.Location = new Point(139, 418);
            panel4.Name = "panel4";
            panel4.Size = new Size(546, 10);
            panel4.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 649);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(_loadButton);
            Controls.Add(_checkButton);
            Controls.Add(_сomboBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}
