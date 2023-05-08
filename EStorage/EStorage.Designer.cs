using System.Drawing;
using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            this.comboBox_com = new System.Windows.Forms.ComboBox();
            this.groupBox_scanner = new System.Windows.Forms.GroupBox();
            this.label_scanner_status = new System.Windows.Forms.Label();
            this.progressBar_com = new System.Windows.Forms.ProgressBar();
            this.label_com = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox_item = new System.Windows.Forms.GroupBox();
            this.button_add_item = new System.Windows.Forms.Button();
            this.button_remove_item = new System.Windows.Forms.Button();
            this.groupBox_add_sub = new System.Windows.Forms.GroupBox();
            this.textBox_add_sub = new System.Windows.Forms.TextBox();
            this.button_item_add = new System.Windows.Forms.Button();
            this.button_item_remove = new System.Windows.Forms.Button();
            this.button_item_admin = new System.Windows.Forms.Button();
            this.button_item_update = new System.Windows.Forms.Button();
            this.comboBox_item_category = new System.Windows.Forms.ComboBox();
            this.comboBox_item_size = new System.Windows.Forms.ComboBox();
            this.label_item_category = new System.Windows.Forms.Label();
            this.label_item_size = new System.Windows.Forms.Label();
            this.label_item_count = new System.Windows.Forms.Label();
            this.textBox_item_count = new System.Windows.Forms.TextBox();
            this.label_item_name = new System.Windows.Forms.Label();
            this.textBox_item_name = new System.Windows.Forms.TextBox();
            this.listBox_search = new System.Windows.Forms.ListBox();
            this.groupBox_search = new System.Windows.Forms.GroupBox();
            this.comboBox_search_category = new System.Windows.Forms.ComboBox();
            this.comboBox_search_size = new System.Windows.Forms.ComboBox();
            this.label_search_category = new System.Windows.Forms.Label();
            this.label_search_size = new System.Windows.Forms.Label();
            this.label_search_name = new System.Windows.Forms.Label();
            this.textBox_search_name = new System.Windows.Forms.TextBox();
            this.groupBox_history = new System.Windows.Forms.GroupBox();
            this.listBox_history = new System.Windows.Forms.ListBox();
            this.groupBox_scanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox_item.SuspendLayout();
            this.groupBox_add_sub.SuspendLayout();
            this.groupBox_search.SuspendLayout();
            this.groupBox_history.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_com
            // 
            this.comboBox_com.FormattingEnabled = true;
            this.comboBox_com.Location = new System.Drawing.Point(58, 19);
            this.comboBox_com.Name = "comboBox_com";
            this.comboBox_com.Size = new System.Drawing.Size(117, 21);
            this.comboBox_com.TabIndex = 1;
            // 
            // groupBox_scanner
            // 
            this.groupBox_scanner.Controls.Add(this.label_scanner_status);
            this.groupBox_scanner.Controls.Add(this.progressBar_com);
            this.groupBox_scanner.Controls.Add(this.label_com);
            this.groupBox_scanner.Controls.Add(this.comboBox_com);
            this.groupBox_scanner.Location = new System.Drawing.Point(332, 302);
            this.groupBox_scanner.Name = "groupBox_scanner";
            this.groupBox_scanner.Size = new System.Drawing.Size(180, 85);
            this.groupBox_scanner.TabIndex = 2;
            this.groupBox_scanner.TabStop = false;
            this.groupBox_scanner.Text = "Scanner";
            // 
            // label_scanner_status
            // 
            this.label_scanner_status.AutoSize = true;
            this.label_scanner_status.Location = new System.Drawing.Point(12, 57);
            this.label_scanner_status.Name = "label_scanner_status";
            this.label_scanner_status.Size = new System.Drawing.Size(43, 13);
            this.label_scanner_status.TabIndex = 3;
            this.label_scanner_status.Text = "No Port";
            // 
            // progressBar_com
            // 
            this.progressBar_com.Location = new System.Drawing.Point(58, 54);
            this.progressBar_com.Name = "progressBar_com";
            this.progressBar_com.Size = new System.Drawing.Size(117, 20);
            this.progressBar_com.TabIndex = 3;
            // 
            // label_com
            // 
            this.label_com.AutoSize = true;
            this.label_com.Location = new System.Drawing.Point(5, 22);
            this.label_com.Name = "label_com";
            this.label_com.Size = new System.Drawing.Size(53, 13);
            this.label_com.TabIndex = 3;
            this.label_com.Text = "COM Port";
            // 
            // groupBox_item
            // 
            this.groupBox_item.Controls.Add(this.button_add_item);
            this.groupBox_item.Controls.Add(this.button_remove_item);
            this.groupBox_item.Controls.Add(this.groupBox_add_sub);
            this.groupBox_item.Controls.Add(this.button_item_admin);
            this.groupBox_item.Controls.Add(this.button_item_update);
            this.groupBox_item.Controls.Add(this.comboBox_item_category);
            this.groupBox_item.Controls.Add(this.comboBox_item_size);
            this.groupBox_item.Controls.Add(this.label_item_category);
            this.groupBox_item.Controls.Add(this.label_item_size);
            this.groupBox_item.Controls.Add(this.label_item_count);
            this.groupBox_item.Controls.Add(this.textBox_item_count);
            this.groupBox_item.Controls.Add(this.label_item_name);
            this.groupBox_item.Controls.Add(this.textBox_item_name);
            this.groupBox_item.Location = new System.Drawing.Point(10, 10);
            this.groupBox_item.Name = "groupBox_item";
            this.groupBox_item.Size = new System.Drawing.Size(316, 193);
            this.groupBox_item.TabIndex = 3;
            this.groupBox_item.TabStop = false;
            this.groupBox_item.Text = "Item";
            // 
            // button_add_item
            // 
            this.button_add_item.Enabled = false;
            this.button_add_item.Location = new System.Drawing.Point(195, 137);
            this.button_add_item.Name = "button_add_item";
            this.button_add_item.Size = new System.Drawing.Size(51, 22);
            this.button_add_item.TabIndex = 20;
            this.button_add_item.Text = "Add";
            this.button_add_item.UseVisualStyleBackColor = true;
            // 
            // button_remove_item
            // 
            this.button_remove_item.Enabled = false;
            this.button_remove_item.Location = new System.Drawing.Point(195, 162);
            this.button_remove_item.Name = "button_remove_item";
            this.button_remove_item.Size = new System.Drawing.Size(51, 22);
            this.button_remove_item.TabIndex = 19;
            this.button_remove_item.Text = "Remove";
            this.button_remove_item.UseVisualStyleBackColor = true;
            // 
            // groupBox_add_sub
            // 
            this.groupBox_add_sub.Controls.Add(this.textBox_add_sub);
            this.groupBox_add_sub.Controls.Add(this.button_item_add);
            this.groupBox_add_sub.Controls.Add(this.button_item_remove);
            this.groupBox_add_sub.Location = new System.Drawing.Point(16, 133);
            this.groupBox_add_sub.Name = "groupBox_add_sub";
            this.groupBox_add_sub.Size = new System.Drawing.Size(174, 50);
            this.groupBox_add_sub.TabIndex = 18;
            this.groupBox_add_sub.TabStop = false;
            this.groupBox_add_sub.Text = "Add/Subtract";
            // 
            // textBox_add_sub
            // 
            this.textBox_add_sub.Enabled = false;
            this.textBox_add_sub.Location = new System.Drawing.Point(5, 21);
            this.textBox_add_sub.Name = "textBox_add_sub";
            this.textBox_add_sub.Size = new System.Drawing.Size(86, 20);
            this.textBox_add_sub.TabIndex = 17;
            // 
            // button_item_add
            // 
            this.button_item_add.Enabled = false;
            this.button_item_add.Location = new System.Drawing.Point(96, 21);
            this.button_item_add.Name = "button_item_add";
            this.button_item_add.Size = new System.Drawing.Size(33, 20);
            this.button_item_add.TabIndex = 12;
            this.button_item_add.Text = "+";
            this.button_item_add.UseVisualStyleBackColor = true;
            // 
            // button_item_remove
            // 
            this.button_item_remove.Enabled = false;
            this.button_item_remove.Location = new System.Drawing.Point(135, 21);
            this.button_item_remove.Name = "button_item_remove";
            this.button_item_remove.Size = new System.Drawing.Size(33, 20);
            this.button_item_remove.TabIndex = 13;
            this.button_item_remove.Text = "-";
            this.button_item_remove.UseVisualStyleBackColor = true;
            // 
            // button_item_admin
            // 
            this.button_item_admin.Location = new System.Drawing.Point(252, 137);
            this.button_item_admin.Name = "button_item_admin";
            this.button_item_admin.Size = new System.Drawing.Size(46, 47);
            this.button_item_admin.TabIndex = 16;
            this.button_item_admin.Text = "Admin Mode";
            this.button_item_admin.UseVisualStyleBackColor = true;
            // 
            // button_item_update
            // 
            this.button_item_update.Enabled = false;
            this.button_item_update.Location = new System.Drawing.Point(234, 80);
            this.button_item_update.Name = "button_item_update";
            this.button_item_update.Size = new System.Drawing.Size(64, 44);
            this.button_item_update.TabIndex = 15;
            this.button_item_update.Text = "Update";
            this.button_item_update.UseVisualStyleBackColor = true;
            // 
            // comboBox_item_category
            // 
            this.comboBox_item_category.Enabled = false;
            this.comboBox_item_category.FormattingEnabled = true;
            this.comboBox_item_category.Items.AddRange(new object[] {
            "",
            "Christmas",
            "Halloween",
            "Thanksgiving",
            "Easter",
            "Valentines",
            "New Years"});
            this.comboBox_item_category.Location = new System.Drawing.Point(75, 105);
            this.comboBox_item_category.Name = "comboBox_item_category";
            this.comboBox_item_category.Size = new System.Drawing.Size(155, 21);
            this.comboBox_item_category.TabIndex = 11;
            // 
            // comboBox_item_size
            // 
            this.comboBox_item_size.Enabled = false;
            this.comboBox_item_size.FormattingEnabled = true;
            this.comboBox_item_size.Items.AddRange(new object[] {
            "Large",
            "Medium",
            "Small",
            "Large Tumbler",
            "Medium Tumbler",
            "Small Tumbler"});
            this.comboBox_item_size.Location = new System.Drawing.Point(75, 80);
            this.comboBox_item_size.Name = "comboBox_item_size";
            this.comboBox_item_size.Size = new System.Drawing.Size(155, 21);
            this.comboBox_item_size.TabIndex = 10;
            // 
            // label_item_category
            // 
            this.label_item_category.AutoSize = true;
            this.label_item_category.Location = new System.Drawing.Point(16, 107);
            this.label_item_category.Name = "label_item_category";
            this.label_item_category.Size = new System.Drawing.Size(49, 13);
            this.label_item_category.TabIndex = 7;
            this.label_item_category.Text = "Category";
            // 
            // label_item_size
            // 
            this.label_item_size.AutoSize = true;
            this.label_item_size.Location = new System.Drawing.Point(16, 82);
            this.label_item_size.Name = "label_item_size";
            this.label_item_size.Size = new System.Drawing.Size(27, 13);
            this.label_item_size.TabIndex = 5;
            this.label_item_size.Text = "Size";
            // 
            // label_item_count
            // 
            this.label_item_count.AutoSize = true;
            this.label_item_count.Location = new System.Drawing.Point(16, 57);
            this.label_item_count.Name = "label_item_count";
            this.label_item_count.Size = new System.Drawing.Size(43, 13);
            this.label_item_count.TabIndex = 3;
            this.label_item_count.Text = "Amount";
            // 
            // textBox_item_count
            // 
            this.textBox_item_count.Location = new System.Drawing.Point(75, 55);
            this.textBox_item_count.Name = "textBox_item_count";
            this.textBox_item_count.ReadOnly = true;
            this.textBox_item_count.Size = new System.Drawing.Size(224, 20);
            this.textBox_item_count.TabIndex = 2;
            // 
            // label_item_name
            // 
            this.label_item_name.AutoSize = true;
            this.label_item_name.Location = new System.Drawing.Point(16, 32);
            this.label_item_name.Name = "label_item_name";
            this.label_item_name.Size = new System.Drawing.Size(35, 13);
            this.label_item_name.TabIndex = 1;
            this.label_item_name.Text = "Name";
            // 
            // textBox_item_name
            // 
            this.textBox_item_name.Location = new System.Drawing.Point(75, 29);
            this.textBox_item_name.Name = "textBox_item_name";
            this.textBox_item_name.ReadOnly = true;
            this.textBox_item_name.Size = new System.Drawing.Size(224, 20);
            this.textBox_item_name.TabIndex = 0;
            // 
            // listBox_search
            // 
            this.listBox_search.FormattingEnabled = true;
            this.listBox_search.Location = new System.Drawing.Point(5, 19);
            this.listBox_search.Name = "listBox_search";
            this.listBox_search.Size = new System.Drawing.Size(334, 186);
            this.listBox_search.TabIndex = 4;
            // 
            // groupBox_search
            // 
            this.groupBox_search.Controls.Add(this.comboBox_search_category);
            this.groupBox_search.Controls.Add(this.comboBox_search_size);
            this.groupBox_search.Controls.Add(this.label_search_category);
            this.groupBox_search.Controls.Add(this.label_search_size);
            this.groupBox_search.Controls.Add(this.label_search_name);
            this.groupBox_search.Controls.Add(this.textBox_search_name);
            this.groupBox_search.Controls.Add(this.listBox_search);
            this.groupBox_search.Location = new System.Drawing.Point(332, 10);
            this.groupBox_search.Name = "groupBox_search";
            this.groupBox_search.Size = new System.Drawing.Size(344, 286);
            this.groupBox_search.TabIndex = 5;
            this.groupBox_search.TabStop = false;
            this.groupBox_search.Text = "Search";
            // 
            // comboBox_search_category
            // 
            this.comboBox_search_category.FormattingEnabled = true;
            this.comboBox_search_category.Items.AddRange(new object[] {
            "",
            "Christmas",
            "Halloween",
            "Thanksgiving",
            "Easter",
            "Valentines",
            "New Years"});
            this.comboBox_search_category.Location = new System.Drawing.Point(64, 260);
            this.comboBox_search_category.Name = "comboBox_search_category";
            this.comboBox_search_category.Size = new System.Drawing.Size(128, 21);
            this.comboBox_search_category.TabIndex = 17;
            // 
            // comboBox_search_size
            // 
            this.comboBox_search_size.FormattingEnabled = true;
            this.comboBox_search_size.Items.AddRange(new object[] {
            "",
            "Large",
            "Medium",
            "Small",
            "Large Tumbler",
            "Medium Tumbler",
            "Small Tumbler"});
            this.comboBox_search_size.Location = new System.Drawing.Point(64, 235);
            this.comboBox_search_size.Name = "comboBox_search_size";
            this.comboBox_search_size.Size = new System.Drawing.Size(128, 21);
            this.comboBox_search_size.TabIndex = 16;
            // 
            // label_search_category
            // 
            this.label_search_category.AutoSize = true;
            this.label_search_category.Location = new System.Drawing.Point(6, 263);
            this.label_search_category.Name = "label_search_category";
            this.label_search_category.Size = new System.Drawing.Size(49, 13);
            this.label_search_category.TabIndex = 15;
            this.label_search_category.Text = "Category";
            // 
            // label_search_size
            // 
            this.label_search_size.AutoSize = true;
            this.label_search_size.Location = new System.Drawing.Point(6, 237);
            this.label_search_size.Name = "label_search_size";
            this.label_search_size.Size = new System.Drawing.Size(27, 13);
            this.label_search_size.TabIndex = 14;
            this.label_search_size.Text = "Size";
            // 
            // label_search_name
            // 
            this.label_search_name.AutoSize = true;
            this.label_search_name.Location = new System.Drawing.Point(6, 212);
            this.label_search_name.Name = "label_search_name";
            this.label_search_name.Size = new System.Drawing.Size(35, 13);
            this.label_search_name.TabIndex = 13;
            this.label_search_name.Text = "Name";
            // 
            // textBox_search_name
            // 
            this.textBox_search_name.Location = new System.Drawing.Point(64, 210);
            this.textBox_search_name.Name = "textBox_search_name";
            this.textBox_search_name.Size = new System.Drawing.Size(275, 20);
            this.textBox_search_name.TabIndex = 12;
            // 
            // groupBox_history
            // 
            this.groupBox_history.Controls.Add(this.listBox_history);
            this.groupBox_history.Location = new System.Drawing.Point(10, 210);
            this.groupBox_history.Name = "groupBox_history";
            this.groupBox_history.Size = new System.Drawing.Size(316, 177);
            this.groupBox_history.TabIndex = 6;
            this.groupBox_history.TabStop = false;
            this.groupBox_history.Text = "History";
            // 
            // listBox_history
            // 
            this.listBox_history.FormattingEnabled = true;
            this.listBox_history.Location = new System.Drawing.Point(5, 19);
            this.listBox_history.Name = "listBox_history";
            this.listBox_history.Size = new System.Drawing.Size(307, 147);
            this.listBox_history.TabIndex = 0;
            // 
            // title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.groupBox_history);
            this.Controls.Add(this.groupBox_search);
            this.Controls.Add(this.groupBox_item);
            this.Controls.Add(this.groupBox_scanner);
            this.Name = "title";
            this.Text = "E-Storage";
            this.groupBox_scanner.ResumeLayout(false);
            this.groupBox_scanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox_item.ResumeLayout(false);
            this.groupBox_item.PerformLayout();
            this.groupBox_add_sub.ResumeLayout(false);
            this.groupBox_add_sub.PerformLayout();
            this.groupBox_search.ResumeLayout(false);
            this.groupBox_search.PerformLayout();
            this.groupBox_history.ResumeLayout(false);
            this.ResumeLayout(false);

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