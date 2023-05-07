namespace EStorage
{
    partial class title
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
            components = new System.ComponentModel.Container();
            button_search = new Button();
            comboBox_com = new ComboBox();
            groupBox_scanner = new GroupBox();
            label1 = new Label();
            progressBar_com = new ProgressBar();
            label_com = new Label();
            bindingSource1 = new BindingSource(components);
            textBox_test = new TextBox();
            groupBox_scanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // button_search
            // 
            button_search.Location = new Point(25, 33);
            button_search.Name = "button_search";
            button_search.Size = new Size(186, 57);
            button_search.TabIndex = 0;
            button_search.Text = "Search Item";
            button_search.UseVisualStyleBackColor = true;
            button_search.Click += button1_Click;
            // 
            // comboBox_com
            // 
            comboBox_com.FormattingEnabled = true;
            comboBox_com.Location = new Point(68, 22);
            comboBox_com.Name = "comboBox_com";
            comboBox_com.Size = new Size(136, 23);
            comboBox_com.TabIndex = 1;
            comboBox_com.SelectedIndexChanged += comboBox_com_SelectedIndexChanged;
            // 
            // groupBox_scanner
            // 
            groupBox_scanner.Controls.Add(label1);
            groupBox_scanner.Controls.Add(progressBar_com);
            groupBox_scanner.Controls.Add(label_com);
            groupBox_scanner.Controls.Add(comboBox_com);
            groupBox_scanner.Location = new Point(25, 338);
            groupBox_scanner.Name = "groupBox_scanner";
            groupBox_scanner.Size = new Size(210, 100);
            groupBox_scanner.TabIndex = 2;
            groupBox_scanner.TabStop = false;
            groupBox_scanner.Text = "Scanner";
            groupBox_scanner.Enter += groupBox1_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 66);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Ready";
            label1.Click += label1_Click;
            // 
            // progressBar_com
            // 
            progressBar_com.Location = new Point(68, 62);
            progressBar_com.Name = "progressBar_com";
            progressBar_com.Size = new Size(136, 23);
            progressBar_com.TabIndex = 3;
            // 
            // label_com
            // 
            label_com.AutoSize = true;
            label_com.Location = new Point(6, 25);
            label_com.Name = "label_com";
            label_com.Size = new Size(60, 15);
            label_com.TabIndex = 3;
            label_com.Text = "COM Port";
            // 
            // textBox_test
            // 
            textBox_test.Location = new Point(370, 355);
            textBox_test.Name = "textBox_test";
            textBox_test.Size = new Size(314, 23);
            textBox_test.TabIndex = 3;
            // 
            // title
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox_test);
            Controls.Add(groupBox_scanner);
            Controls.Add(button_search);
            Name = "title";
            Text = "E-Storage";
            FormClosing += title_FormClosing;
            Load += title_Load;
            groupBox_scanner.ResumeLayout(false);
            groupBox_scanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_search;
        private ComboBox comboBox_com;
        private GroupBox groupBox_scanner;
        private Label label_com;
        private ProgressBar progressBar_com;
        private Label label1;
        private BindingSource bindingSource1;
        private TextBox textBox_test;
    }
}