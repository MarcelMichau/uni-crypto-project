namespace CryptoSpade
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
            this.DescriptionGroupBox = new System.Windows.Forms.GroupBox();
            this.AlgorithmInfoTextBox = new System.Windows.Forms.TextBox();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ClearAllFileButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FileKeyBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.KeyLengthLabel = new System.Windows.Forms.Label();
            this.TextLengthLabel = new System.Windows.Forms.Label();
            this.ClearAllTextButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextKeyBox = new System.Windows.Forms.TextBox();
            this.PlainTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EncryptedTextBox = new System.Windows.Forms.TextBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EncryptionAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.EncryptionStrengthComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileRadioButton = new System.Windows.Forms.RadioButton();
            this.TextRadioButton = new System.Windows.Forms.RadioButton();
            this.DescriptionGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DescriptionGroupBox
            // 
            this.DescriptionGroupBox.Controls.Add(this.AlgorithmInfoTextBox);
            this.DescriptionGroupBox.Location = new System.Drawing.Point(632, 12);
            this.DescriptionGroupBox.Name = "DescriptionGroupBox";
            this.DescriptionGroupBox.Size = new System.Drawing.Size(223, 451);
            this.DescriptionGroupBox.TabIndex = 20;
            this.DescriptionGroupBox.TabStop = false;
            this.DescriptionGroupBox.Text = "Algorithm Description";
            // 
            // AlgorithmInfoTextBox
            // 
            this.AlgorithmInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlgorithmInfoTextBox.Location = new System.Drawing.Point(6, 19);
            this.AlgorithmInfoTextBox.Multiline = true;
            this.AlgorithmInfoTextBox.Name = "AlgorithmInfoTextBox";
            this.AlgorithmInfoTextBox.ReadOnly = true;
            this.AlgorithmInfoTextBox.Size = new System.Drawing.Size(211, 426);
            this.AlgorithmInfoTextBox.TabIndex = 0;
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(18, 297);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(97, 23);
            this.DecryptButton.TabIndex = 19;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ClearAllFileButton);
            this.groupBox3.Controls.Add(this.OpenFileButton);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.FileKeyBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.FilePathTextBox);
            this.groupBox3.Location = new System.Drawing.Point(254, 258);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(372, 205);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File";
            // 
            // ClearAllFileButton
            // 
            this.ClearAllFileButton.Location = new System.Drawing.Point(284, 167);
            this.ClearAllFileButton.Name = "ClearAllFileButton";
            this.ClearAllFileButton.Size = new System.Drawing.Size(75, 23);
            this.ClearAllFileButton.TabIndex = 10;
            this.ClearAllFileButton.Text = "Clear All";
            this.ClearAllFileButton.UseVisualStyleBackColor = true;
            this.ClearAllFileButton.Click += new System.EventHandler(this.ClearAllFileButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(329, 40);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(30, 23);
            this.OpenFileButton.TabIndex = 9;
            this.OpenFileButton.Text = "...";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "File Location:";
            // 
            // FileKeyBox
            // 
            this.FileKeyBox.Location = new System.Drawing.Point(8, 134);
            this.FileKeyBox.Name = "FileKeyBox";
            this.FileKeyBox.Size = new System.Drawing.Size(264, 20);
            this.FileKeyBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Key:";
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(8, 42);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(315, 20);
            this.FilePathTextBox.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.KeyLengthLabel);
            this.groupBox2.Controls.Add(this.TextLengthLabel);
            this.groupBox2.Controls.Add(this.ClearAllTextButton);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TextKeyBox);
            this.groupBox2.Controls.Add(this.PlainTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.EncryptedTextBox);
            this.groupBox2.Location = new System.Drawing.Point(254, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 240);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // KeyLengthLabel
            // 
            this.KeyLengthLabel.AutoSize = true;
            this.KeyLengthLabel.Location = new System.Drawing.Point(272, 94);
            this.KeyLengthLabel.Name = "KeyLengthLabel";
            this.KeyLengthLabel.Size = new System.Drawing.Size(0, 13);
            this.KeyLengthLabel.TabIndex = 9;
            // 
            // TextLengthLabel
            // 
            this.TextLengthLabel.AutoSize = true;
            this.TextLengthLabel.Location = new System.Drawing.Point(272, 35);
            this.TextLengthLabel.Name = "TextLengthLabel";
            this.TextLengthLabel.Size = new System.Drawing.Size(0, 13);
            this.TextLengthLabel.TabIndex = 9;
            // 
            // ClearAllTextButton
            // 
            this.ClearAllTextButton.Location = new System.Drawing.Point(283, 206);
            this.ClearAllTextButton.Name = "ClearAllTextButton";
            this.ClearAllTextButton.Size = new System.Drawing.Size(75, 23);
            this.ClearAllTextButton.TabIndex = 8;
            this.ClearAllTextButton.Text = "Clear All";
            this.ClearAllTextButton.UseVisualStyleBackColor = true;
            this.ClearAllTextButton.Click += new System.EventHandler(this.ClearAllTextButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Plaintext String:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encrypted String:";
            // 
            // TextKeyBox
            // 
            this.TextKeyBox.Location = new System.Drawing.Point(8, 91);
            this.TextKeyBox.Name = "TextKeyBox";
            this.TextKeyBox.Size = new System.Drawing.Size(258, 20);
            this.TextKeyBox.TabIndex = 7;
            this.TextKeyBox.TextChanged += new System.EventHandler(this.TextKeyBox_TextChanged);
            // 
            // PlainTextBox
            // 
            this.PlainTextBox.Location = new System.Drawing.Point(7, 32);
            this.PlainTextBox.Name = "PlainTextBox";
            this.PlainTextBox.Size = new System.Drawing.Size(259, 20);
            this.PlainTextBox.TabIndex = 5;
            this.PlainTextBox.TextChanged += new System.EventHandler(this.PlainTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Key:";
            // 
            // EncryptedTextBox
            // 
            this.EncryptedTextBox.Location = new System.Drawing.Point(8, 153);
            this.EncryptedTextBox.Name = "EncryptedTextBox";
            this.EncryptedTextBox.Size = new System.Drawing.Size(258, 20);
            this.EncryptedTextBox.TabIndex = 5;
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(18, 258);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(97, 23);
            this.EncryptButton.TabIndex = 16;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Encryption Algorithm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Encryption Strength:";
            // 
            // EncryptionAlgorithmComboBox
            // 
            this.EncryptionAlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncryptionAlgorithmComboBox.FormattingEnabled = true;
            this.EncryptionAlgorithmComboBox.Items.AddRange(new object[] {
            "Basic Encryption",
            "Strong Encryption"});
            this.EncryptionAlgorithmComboBox.Location = new System.Drawing.Point(18, 220);
            this.EncryptionAlgorithmComboBox.Name = "EncryptionAlgorithmComboBox";
            this.EncryptionAlgorithmComboBox.Size = new System.Drawing.Size(180, 21);
            this.EncryptionAlgorithmComboBox.TabIndex = 12;
            this.EncryptionAlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.EncryptionAlgorithmComboBox_SelectedIndexChanged);
            // 
            // EncryptionStrengthComboBox
            // 
            this.EncryptionStrengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncryptionStrengthComboBox.FormattingEnabled = true;
            this.EncryptionStrengthComboBox.Items.AddRange(new object[] {
            "Basic Encryption",
            "Strong Encryption"});
            this.EncryptionStrengthComboBox.Location = new System.Drawing.Point(18, 165);
            this.EncryptionStrengthComboBox.Name = "EncryptionStrengthComboBox";
            this.EncryptionStrengthComboBox.Size = new System.Drawing.Size(180, 21);
            this.EncryptionStrengthComboBox.TabIndex = 13;
            this.EncryptionStrengthComboBox.SelectedIndexChanged += new System.EventHandler(this.EncryptionStrengthComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FileRadioButton);
            this.groupBox1.Controls.Add(this.TextRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 118);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Please select your type of encryption:";
            // 
            // FileRadioButton
            // 
            this.FileRadioButton.AutoSize = true;
            this.FileRadioButton.Location = new System.Drawing.Point(6, 65);
            this.FileRadioButton.Name = "FileRadioButton";
            this.FileRadioButton.Size = new System.Drawing.Size(94, 17);
            this.FileRadioButton.TabIndex = 2;
            this.FileRadioButton.TabStop = true;
            this.FileRadioButton.Text = "File Encryption";
            this.FileRadioButton.UseVisualStyleBackColor = true;
            this.FileRadioButton.CheckedChanged += new System.EventHandler(this.FileRadioButton_CheckedChanged);
            // 
            // TextRadioButton
            // 
            this.TextRadioButton.AutoSize = true;
            this.TextRadioButton.Location = new System.Drawing.Point(6, 30);
            this.TextRadioButton.Name = "TextRadioButton";
            this.TextRadioButton.Size = new System.Drawing.Size(99, 17);
            this.TextRadioButton.TabIndex = 2;
            this.TextRadioButton.TabStop = true;
            this.TextRadioButton.Text = "Text Encryption";
            this.TextRadioButton.UseVisualStyleBackColor = true;
            this.TextRadioButton.CheckedChanged += new System.EventHandler(this.TextRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 477);
            this.Controls.Add(this.DescriptionGroupBox);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EncryptionAlgorithmComboBox);
            this.Controls.Add(this.EncryptionStrengthComboBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "CryptoSpade";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DescriptionGroupBox.ResumeLayout(false);
            this.DescriptionGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox DescriptionGroupBox;
        private System.Windows.Forms.TextBox AlgorithmInfoTextBox;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ClearAllFileButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FileKeyBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label KeyLengthLabel;
        private System.Windows.Forms.Label TextLengthLabel;
        private System.Windows.Forms.Button ClearAllTextButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextKeyBox;
        private System.Windows.Forms.TextBox PlainTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EncryptedTextBox;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EncryptionAlgorithmComboBox;
        private System.Windows.Forms.ComboBox EncryptionStrengthComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton FileRadioButton;
        private System.Windows.Forms.RadioButton TextRadioButton;
    }
}

