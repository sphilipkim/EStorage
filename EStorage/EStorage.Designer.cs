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
            comboBox_com = new ComboBox();
            groupBox_scanner = new GroupBox();
            label_scanner_status = new Label();
            progressBar_com = new ProgressBar();
            label_com = new Label();
            bindingSource1 = new BindingSource(components);
            groupBox_item = new GroupBox();
            button_add_item = new Button();
            button_remove_item = new Button();
            groupBox_add_sub = new GroupBox();
            textBox_add_sub = new TextBox();
            button_item_add = new Button();
            button_item_remove = new Button();
            button_item_admin = new Button();
            button_item_update = new Button();
            comboBox_item_category = new ComboBox();
            comboBox_item_size = new ComboBox();
            label_item_category = new Label();
            label_item_size = new Label();
            label_item_count = new Label();
            textBox_item_count = new TextBox();
            label_item_name = new Label();
            textBox_item_name = new TextBox();
            listBox_search = new ListBox();
            groupBox_search = new GroupBox();
            comboBox_search_category = new ComboBox();
            comboBox_search_size = new ComboBox();
            label_search_category = new Label();
            label_search_size = new Label();
            label_search_name = new Label();
            textBox_search_name = new TextBox();
            groupBox_history = new GroupBox();
            listBox_history = new ListBox();
            groupBox_scanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            groupBox_item.SuspendLayout();
            groupBox_add_sub.SuspendLayout();
            groupBox_search.SuspendLayout();
            groupBox_history.SuspendLayout();
            SuspendLayout();
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
            groupBox_scanner.Controls.Add(label_scanner_status);
            groupBox_scanner.Controls.Add(progressBar_com);
            groupBox_scanner.Controls.Add(label_com);
            groupBox_scanner.Controls.Add(comboBox_com);
            groupBox_scanner.Location = new Point(387, 348);
            groupBox_scanner.Name = "groupBox_scanner";
            groupBox_scanner.Size = new Size(210, 98);
            groupBox_scanner.TabIndex = 2;
            groupBox_scanner.TabStop = false;
            groupBox_scanner.Text = "Scanner";
            // 
            // label_scanner_status
            // 
            label_scanner_status.AutoSize = true;
            label_scanner_status.Location = new Point(14, 66);
            label_scanner_status.Name = "label_scanner_status";
            label_scanner_status.Size = new Size(48, 15);
            label_scanner_status.TabIndex = 3;
            label_scanner_status.Text = "No Port";
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
            // groupBox_item
            // 
            groupBox_item.Controls.Add(button_add_item);
            groupBox_item.Controls.Add(button_remove_item);
            groupBox_item.Controls.Add(groupBox_add_sub);
            groupBox_item.Controls.Add(button_item_admin);
            groupBox_item.Controls.Add(button_item_update);
            groupBox_item.Controls.Add(comboBox_item_category);
            groupBox_item.Controls.Add(comboBox_item_size);
            groupBox_item.Controls.Add(label_item_category);
            groupBox_item.Controls.Add(label_item_size);
            groupBox_item.Controls.Add(label_item_count);
            groupBox_item.Controls.Add(textBox_item_count);
            groupBox_item.Controls.Add(label_item_name);
            groupBox_item.Controls.Add(textBox_item_name);
            groupBox_item.Location = new Point(12, 12);
            groupBox_item.Name = "groupBox_item";
            groupBox_item.Size = new Size(369, 223);
            groupBox_item.TabIndex = 3;
            groupBox_item.TabStop = false;
            groupBox_item.Text = "Item";
            // 
            // button_add_item
            // 
            button_add_item.Enabled = false;
            button_add_item.Location = new Point(228, 158);
            button_add_item.Name = "button_add_item";
            button_add_item.Size = new Size(60, 25);
            button_add_item.TabIndex = 20;
            button_add_item.Text = "Add";
            button_add_item.UseVisualStyleBackColor = true;
            button_add_item.Click += button_add_item_Click;
            // 
            // button_remove_item
            // 
            button_remove_item.Enabled = false;
            button_remove_item.Location = new Point(228, 187);
            button_remove_item.Name = "button_remove_item";
            button_remove_item.Size = new Size(60, 25);
            button_remove_item.TabIndex = 19;
            button_remove_item.Text = "Remove";
            button_remove_item.UseVisualStyleBackColor = true;
            button_remove_item.Click += button_remove_item_Click;
            // 
            // groupBox_add_sub
            // 
            groupBox_add_sub.Controls.Add(textBox_add_sub);
            groupBox_add_sub.Controls.Add(button_item_add);
            groupBox_add_sub.Controls.Add(button_item_remove);
            groupBox_add_sub.Location = new Point(19, 154);
            groupBox_add_sub.Name = "groupBox_add_sub";
            groupBox_add_sub.Size = new Size(203, 58);
            groupBox_add_sub.TabIndex = 18;
            groupBox_add_sub.TabStop = false;
            groupBox_add_sub.Text = "Add/Subtract";
            // 
            // textBox_add_sub
            // 
            textBox_add_sub.Enabled = false;
            textBox_add_sub.Location = new Point(6, 24);
            textBox_add_sub.Name = "textBox_add_sub";
            textBox_add_sub.Size = new Size(100, 23);
            textBox_add_sub.TabIndex = 17;
            // 
            // button_item_add
            // 
            button_item_add.Enabled = false;
            button_item_add.Location = new Point(112, 24);
            button_item_add.Name = "button_item_add";
            button_item_add.Size = new Size(39, 23);
            button_item_add.TabIndex = 12;
            button_item_add.Text = "+";
            button_item_add.UseVisualStyleBackColor = true;
            button_item_add.Click += button_item_add_Click;
            // 
            // button_item_remove
            // 
            button_item_remove.Enabled = false;
            button_item_remove.Location = new Point(157, 24);
            button_item_remove.Name = "button_item_remove";
            button_item_remove.Size = new Size(39, 23);
            button_item_remove.TabIndex = 13;
            button_item_remove.Text = "-";
            button_item_remove.UseVisualStyleBackColor = true;
            button_item_remove.Click += button_item_remove_Click;
            // 
            // button_item_admin
            // 
            button_item_admin.Location = new Point(294, 158);
            button_item_admin.Name = "button_item_admin";
            button_item_admin.Size = new Size(54, 54);
            button_item_admin.TabIndex = 16;
            button_item_admin.Text = "Admin Mode";
            button_item_admin.UseVisualStyleBackColor = true;
            button_item_admin.Click += button_item_admin_Click;
            // 
            // button_item_update
            // 
            button_item_update.Enabled = false;
            button_item_update.Location = new Point(273, 92);
            button_item_update.Name = "button_item_update";
            button_item_update.Size = new Size(75, 51);
            button_item_update.TabIndex = 15;
            button_item_update.Text = "Update";
            button_item_update.UseVisualStyleBackColor = true;
            button_item_update.Click += button_item_update_Click;
            // 
            // comboBox_item_category
            // 
            comboBox_item_category.Enabled = false;
            comboBox_item_category.FormattingEnabled = true;
            comboBox_item_category.Items.AddRange(new object[] { "", "Christmas", "Halloween", "Thanksgiving", "Easter", "Valentines", "New Years" });
            comboBox_item_category.Location = new Point(87, 121);
            comboBox_item_category.Name = "comboBox_item_category";
            comboBox_item_category.Size = new Size(180, 23);
            comboBox_item_category.TabIndex = 11;
            // 
            // comboBox_item_size
            // 
            comboBox_item_size.Enabled = false;
            comboBox_item_size.FormattingEnabled = true;
            comboBox_item_size.Items.AddRange(new object[] { "Large", "Medium", "Small", "Large Tumbler", "Medium Tumbler", "Small Tumbler" });
            comboBox_item_size.Location = new Point(87, 92);
            comboBox_item_size.Name = "comboBox_item_size";
            comboBox_item_size.Size = new Size(180, 23);
            comboBox_item_size.TabIndex = 10;
            // 
            // label_item_category
            // 
            label_item_category.AutoSize = true;
            label_item_category.Location = new Point(19, 124);
            label_item_category.Name = "label_item_category";
            label_item_category.Size = new Size(55, 15);
            label_item_category.TabIndex = 7;
            label_item_category.Text = "Category";
            // 
            // label_item_size
            // 
            label_item_size.AutoSize = true;
            label_item_size.Location = new Point(19, 95);
            label_item_size.Name = "label_item_size";
            label_item_size.Size = new Size(27, 15);
            label_item_size.TabIndex = 5;
            label_item_size.Text = "Size";
            // 
            // label_item_count
            // 
            label_item_count.AutoSize = true;
            label_item_count.Location = new Point(19, 66);
            label_item_count.Name = "label_item_count";
            label_item_count.Size = new Size(51, 15);
            label_item_count.TabIndex = 3;
            label_item_count.Text = "Amount";
            // 
            // textBox_item_count
            // 
            textBox_item_count.Location = new Point(87, 63);
            textBox_item_count.Name = "textBox_item_count";
            textBox_item_count.ReadOnly = true;
            textBox_item_count.Size = new Size(261, 23);
            textBox_item_count.TabIndex = 2;
            // 
            // label_item_name
            // 
            label_item_name.AutoSize = true;
            label_item_name.Location = new Point(19, 37);
            label_item_name.Name = "label_item_name";
            label_item_name.Size = new Size(39, 15);
            label_item_name.TabIndex = 1;
            label_item_name.Text = "Name";
            // 
            // textBox_item_name
            // 
            textBox_item_name.Location = new Point(87, 34);
            textBox_item_name.Name = "textBox_item_name";
            textBox_item_name.ReadOnly = true;
            textBox_item_name.Size = new Size(261, 23);
            textBox_item_name.TabIndex = 0;
            // 
            // listBox_search
            // 
            listBox_search.FormattingEnabled = true;
            listBox_search.ItemHeight = 15;
            listBox_search.Location = new Point(6, 22);
            listBox_search.Name = "listBox_search";
            listBox_search.Size = new Size(389, 214);
            listBox_search.TabIndex = 4;
            listBox_search.DoubleClick += listBox_DoubleClick;
            // 
            // groupBox_search
            // 
            groupBox_search.Controls.Add(comboBox_search_category);
            groupBox_search.Controls.Add(comboBox_search_size);
            groupBox_search.Controls.Add(label_search_category);
            groupBox_search.Controls.Add(label_search_size);
            groupBox_search.Controls.Add(label_search_name);
            groupBox_search.Controls.Add(textBox_search_name);
            groupBox_search.Controls.Add(listBox_search);
            groupBox_search.Location = new Point(387, 12);
            groupBox_search.Name = "groupBox_search";
            groupBox_search.Size = new Size(401, 330);
            groupBox_search.TabIndex = 5;
            groupBox_search.TabStop = false;
            groupBox_search.Text = "Search";
            // 
            // comboBox_search_category
            // 
            comboBox_search_category.FormattingEnabled = true;
            comboBox_search_category.Items.AddRange(new object[] { "", "Christmas", "Halloween", "Thanksgiving", "Easter", "Valentines", "New Years" });
            comboBox_search_category.Location = new Point(75, 300);
            comboBox_search_category.Name = "comboBox_search_category";
            comboBox_search_category.Size = new Size(149, 23);
            comboBox_search_category.TabIndex = 17;
            comboBox_search_category.SelectedIndexChanged += comboBox_search_category_SelectedIndexChanged;
            // 
            // comboBox_search_size
            // 
            comboBox_search_size.FormattingEnabled = true;
            comboBox_search_size.Items.AddRange(new object[] { "", "Large", "Medium", "Small", "Large Tumbler", "Medium Tumbler", "Small Tumbler" });
            comboBox_search_size.Location = new Point(75, 271);
            comboBox_search_size.Name = "comboBox_search_size";
            comboBox_search_size.Size = new Size(149, 23);
            comboBox_search_size.TabIndex = 16;
            comboBox_search_size.SelectedIndexChanged += comboBox_search_size_SelectedIndexChanged;
            // 
            // label_search_category
            // 
            label_search_category.AutoSize = true;
            label_search_category.Location = new Point(7, 303);
            label_search_category.Name = "label_search_category";
            label_search_category.Size = new Size(55, 15);
            label_search_category.TabIndex = 15;
            label_search_category.Text = "Category";
            // 
            // label_search_size
            // 
            label_search_size.AutoSize = true;
            label_search_size.Location = new Point(7, 274);
            label_search_size.Name = "label_search_size";
            label_search_size.Size = new Size(27, 15);
            label_search_size.TabIndex = 14;
            label_search_size.Text = "Size";
            // 
            // label_search_name
            // 
            label_search_name.AutoSize = true;
            label_search_name.Location = new Point(7, 245);
            label_search_name.Name = "label_search_name";
            label_search_name.Size = new Size(39, 15);
            label_search_name.TabIndex = 13;
            label_search_name.Text = "Name";
            // 
            // textBox_search_name
            // 
            textBox_search_name.Location = new Point(75, 242);
            textBox_search_name.Name = "textBox_search_name";
            textBox_search_name.Size = new Size(320, 23);
            textBox_search_name.TabIndex = 12;
            textBox_search_name.TextChanged += textBox_search_name_TextChanged;
            // 
            // groupBox_history
            // 
            groupBox_history.Controls.Add(listBox_history);
            groupBox_history.Location = new Point(12, 242);
            groupBox_history.Name = "groupBox_history";
            groupBox_history.Size = new Size(369, 204);
            groupBox_history.TabIndex = 6;
            groupBox_history.TabStop = false;
            groupBox_history.Text = "History";
            // 
            // listBox_history
            // 
            listBox_history.FormattingEnabled = true;
            listBox_history.ItemHeight = 15;
            listBox_history.Location = new Point(6, 22);
            listBox_history.Name = "listBox_history";
            listBox_history.Size = new Size(357, 169);
            listBox_history.TabIndex = 0;
            // 
            // title
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox_history);
            Controls.Add(groupBox_search);
            Controls.Add(groupBox_item);
            Controls.Add(groupBox_scanner);
            Name = "title";
            Text = "E-Storage";
            FormClosing += title_FormClosing;
            Load += title_Load;
            groupBox_scanner.ResumeLayout(false);
            groupBox_scanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            groupBox_item.ResumeLayout(false);
            groupBox_item.PerformLayout();
            groupBox_add_sub.ResumeLayout(false);
            groupBox_add_sub.PerformLayout();
            groupBox_search.ResumeLayout(false);
            groupBox_search.PerformLayout();
            groupBox_history.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ComboBox comboBox_com;
        private GroupBox groupBox_scanner;
        private Label label_com;
        private ProgressBar progressBar_com;
        private Label label_scanner_status;
        private BindingSource bindingSource1;
        private GroupBox groupBox_item;
        private Label label_item_name;
        private TextBox textBox_item_name;
        private Label label_item_category;
        private Label label_item_size;
        private Label label_item_count;
        private TextBox textBox_item_count;
        private ComboBox comboBox_item_size;
        private ComboBox comboBox_item_category;
        private Button button_item_update_size;
        private Button button_item_remove;
        private Button button_item_add;
        private Button button_item_update;
        private Button button_item_admin;
        private ListBox listBox_search;
        private GroupBox groupBox_search;
        private ComboBox comboBox_search_category;
        private ComboBox comboBox_search_size;
        private Label label_search_category;
        private Label label_search_size;
        private Label label_search_name;
        private TextBox textBox_search_name;
        private GroupBox groupBox_history;
        private ListBox listBox_history;
        private TextBox textBox_add_sub;
        private GroupBox groupBox_add_sub;
        private Button button_remove_item;
        private Button button_add_item;
    }
}