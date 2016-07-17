namespace PaperRockScissors
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.Host_Textbox = new System.Windows.Forms.TextBox();
            this.Name_Textbox = new System.Windows.Forms.TextBox();
            this.Ready_Button = new System.Windows.Forms.Button();
            this.Rock_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.Time_Lable = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Bottle = new System.Windows.Forms.Button();
            this.Button_Gun = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Checkbox_BottleCooldown = new System.Windows.Forms.CheckBox();
            this.Checkbox_GunCooldown = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Host_Textbox
            // 
            this.Host_Textbox.Location = new System.Drawing.Point(6, 32);
            this.Host_Textbox.Name = "Host_Textbox";
            this.Host_Textbox.Size = new System.Drawing.Size(100, 20);
            this.Host_Textbox.TabIndex = 1;
            this.Host_Textbox.Text = "127.0.0.1";
            // 
            // Name_Textbox
            // 
            this.Name_Textbox.Location = new System.Drawing.Point(6, 6);
            this.Name_Textbox.Name = "Name_Textbox";
            this.Name_Textbox.Size = new System.Drawing.Size(100, 20);
            this.Name_Textbox.TabIndex = 2;
            this.Name_Textbox.Text = "dark1103";
            // 
            // Ready_Button
            // 
            this.Ready_Button.Enabled = false;
            this.Ready_Button.Location = new System.Drawing.Point(9, 35);
            this.Ready_Button.Name = "Ready_Button";
            this.Ready_Button.Size = new System.Drawing.Size(79, 53);
            this.Ready_Button.TabIndex = 4;
            this.Ready_Button.Text = "Ready";
            this.Ready_Button.UseVisualStyleBackColor = true;
            this.Ready_Button.Click += new System.EventHandler(this.Ready_Button_Click);
            // 
            // Rock_Button
            // 
            this.Rock_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rock_Button.Location = new System.Drawing.Point(173, 3);
            this.Rock_Button.Name = "Rock_Button";
            this.Rock_Button.Size = new System.Drawing.Size(84, 62);
            this.Rock_Button.TabIndex = 5;
            this.Rock_Button.Tag = "Rock";
            this.Rock_Button.Text = "Rock";
            this.Rock_Button.UseVisualStyleBackColor = true;
            this.Rock_Button.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Rock_Button, 0, 0);
            this.tableLayoutPanel1.Enabled = false;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 142);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 130);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(3, 71);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(79, 56);
            this.button7.TabIndex = 10;
            this.button7.Tag = "Fuck";
            this.button7.Text = "Fuck";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(88, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(79, 56);
            this.button6.TabIndex = 9;
            this.button6.Tag = "Fig";
            this.button6.Text = "Fig";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(173, 71);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 56);
            this.button5.TabIndex = 8;
            this.button5.Tag = "Goat";
            this.button5.Text = "Козлорог";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(88, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 62);
            this.button3.TabIndex = 7;
            this.button3.Tag = "Scissors";
            this.button3.Text = "Scissors";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 62);
            this.button2.TabIndex = 6;
            this.button2.Tag = "Paper";
            this.button2.Text = "Paper";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 310);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Name_Textbox);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.Host_Textbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.Time_Lable);
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.Ready_Button);
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Header});
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.LargeImageList = this.imageList;
            this.listView1.Location = new System.Drawing.Point(272, 6);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(159, 263);
            this.listView1.SmallImageList = this.imageList;
            this.listView1.StateImageList = this.imageList;
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // Header
            // 
            this.Header.Width = 200;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Time_Lable
            // 
            this.Time_Lable.AutoSize = true;
            this.Time_Lable.Font = new System.Drawing.Font("David", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time_Lable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Time_Lable.Location = new System.Drawing.Point(31, 101);
            this.Time_Lable.Name = "Time_Lable";
            this.Time_Lable.Size = new System.Drawing.Size(30, 32);
            this.Time_Lable.TabIndex = 9;
            this.Time_Lable.Text = "0";
            this.Time_Lable.Click += new System.EventHandler(this.Time_Lable_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.56522F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.43478F));
            this.tableLayoutPanel2.Controls.Add(this.Checkbox_BottleCooldown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.Button_Bottle, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Button_Gun, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Checkbox_GunCooldown, 1, 0);
            this.tableLayoutPanel2.Enabled = false;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(94, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.07692F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.92308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(172, 130);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // Button_Bottle
            // 
            this.Button_Bottle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Bottle.Location = new System.Drawing.Point(3, 71);
            this.Button_Bottle.Name = "Button_Bottle";
            this.Button_Bottle.Size = new System.Drawing.Size(113, 56);
            this.Button_Bottle.TabIndex = 11;
            this.Button_Bottle.Tag = "Bottle";
            this.Button_Bottle.Text = "Bottle";
            this.Button_Bottle.UseVisualStyleBackColor = true;
            this.Button_Bottle.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // Button_Gun
            // 
            this.Button_Gun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Gun.Location = new System.Drawing.Point(3, 3);
            this.Button_Gun.Name = "Button_Gun";
            this.Button_Gun.Size = new System.Drawing.Size(113, 62);
            this.Button_Gun.TabIndex = 9;
            this.Button_Gun.Tag = "Gun";
            this.Button_Gun.Text = "Gun";
            this.Button_Gun.UseVisualStyleBackColor = true;
            this.Button_Gun.Click += new System.EventHandler(this.ItemButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(79, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Disconnect";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Checkbox_BottleCooldown
            // 
            this.Checkbox_BottleCooldown.AutoSize = true;
            this.Checkbox_BottleCooldown.Checked = true;
            this.Checkbox_BottleCooldown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_BottleCooldown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Checkbox_BottleCooldown.Enabled = false;
            this.Checkbox_BottleCooldown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Checkbox_BottleCooldown.Location = new System.Drawing.Point(127, 71);
            this.Checkbox_BottleCooldown.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.Checkbox_BottleCooldown.Name = "Checkbox_BottleCooldown";
            this.Checkbox_BottleCooldown.Size = new System.Drawing.Size(37, 56);
            this.Checkbox_BottleCooldown.TabIndex = 13;
            this.Checkbox_BottleCooldown.UseVisualStyleBackColor = true;
            this.Checkbox_BottleCooldown.CheckedChanged += new System.EventHandler(this.Checkbox_BottleCooldown_CheckedChanged);
            // 
            // Checkbox_GunCooldown
            // 
            this.Checkbox_GunCooldown.AutoSize = true;
            this.Checkbox_GunCooldown.Checked = true;
            this.Checkbox_GunCooldown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_GunCooldown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Checkbox_GunCooldown.Enabled = false;
            this.Checkbox_GunCooldown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Checkbox_GunCooldown.Location = new System.Drawing.Point(127, 3);
            this.Checkbox_GunCooldown.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.Checkbox_GunCooldown.Name = "Checkbox_GunCooldown";
            this.Checkbox_GunCooldown.Size = new System.Drawing.Size(37, 62);
            this.Checkbox_GunCooldown.TabIndex = 12;
            this.Checkbox_GunCooldown.UseVisualStyleBackColor = true;
            this.Checkbox_GunCooldown.CheckedChanged += new System.EventHandler(this.Checkbox_GunCooldown_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 310);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Host_Textbox;
        private System.Windows.Forms.TextBox Name_Textbox;
        private System.Windows.Forms.Button Ready_Button;
        private System.Windows.Forms.Button Rock_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label Time_Lable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Button_Gun;
        private System.Windows.Forms.Button Button_Bottle;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader Header;
        private System.Windows.Forms.CheckBox Checkbox_BottleCooldown;
        private System.Windows.Forms.CheckBox Checkbox_GunCooldown;
    }
}

