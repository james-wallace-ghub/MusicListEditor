namespace MusOTron;

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
        Open = new Button();
        button2 = new Button();
        textBox2 = new TextBox();
        button5 = new Button();
        textBox3 = new TextBox();
        textBox4 = new TextBox();
        textBox5 = new TextBox();
        textBox7 = new TextBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label13 = new Label();
        label14 = new Label();
        button6 = new Button();
        textBox14 = new TextBox();
        numericUpDown1 = new NumericUpDown();
        label15 = new Label();
        label11 = new Label();
        label17 = new Label();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // Open
        // 
        Open.Location = new Point(-1, 4);
        Open.Margin = new Padding(5, 4, 5, 4);
        Open.Name = "Open";
        Open.Size = new Size(101, 36);
        Open.TabIndex = 0;
        Open.Text = "Open";
        Open.UseVisualStyleBackColor = true;
        Open.Click += Open_Click;
        // 
        // button2
        // 
        button2.Location = new Point(965, 4);
        button2.Margin = new Padding(5, 4, 5, 4);
        button2.Name = "button2";
        button2.Size = new Size(101, 36);
        button2.TabIndex = 1;
        button2.Text = "Save";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(91, 77);
        textBox2.Margin = new Padding(5, 4, 5, 4);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(217, 27);
        textBox2.TabIndex = 5;
        textBox2.TextAlign = HorizontalAlignment.Right;
        // 
        // button5
        // 
        button5.Location = new Point(-1, 69);
        button5.Margin = new Padding(5, 4, 5, 4);
        button5.Name = "button5";
        button5.Size = new Size(94, 44);
        button5.TabIndex = 6;
        button5.Text = "Search";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // textBox3
        // 
        textBox3.Enabled = false;
        textBox3.Location = new Point(920, 168);
        textBox3.Margin = new Padding(5, 4, 5, 4);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(145, 27);
        textBox3.TabIndex = 7;
        textBox3.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox4
        // 
        textBox4.Enabled = false;
        textBox4.Location = new Point(-1, 168);
        textBox4.Margin = new Padding(5, 4, 5, 4);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(303, 27);
        textBox4.TabIndex = 8;
        textBox4.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox5
        // 
        textBox5.Enabled = false;
        textBox5.Location = new Point(322, 168);
        textBox5.Margin = new Padding(5, 4, 5, 4);
        textBox5.Name = "textBox5";
        textBox5.Size = new Size(287, 27);
        textBox5.TabIndex = 9;
        textBox5.TextAlign = HorizontalAlignment.Right;
        // 
        // textBox7
        // 
        textBox7.Location = new Point(619, 168);
        textBox7.Margin = new Padding(5, 4, 5, 4);
        textBox7.Name = "textBox7";
        textBox7.Size = new Size(287, 27);
        textBox7.TabIndex = 11;
        textBox7.TextAlign = HorizontalAlignment.Right;
        textBox7.TextChanged += textBox7_TextChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(70, 144);
        label1.Margin = new Padding(5, 0, 5, 0);
        label1.Name = "label1";
        label1.Size = new Size(177, 20);
        label1.TabIndex = 13;
        label1.Text = "Slot Name (used in Suite)";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(398, 144);
        label2.Margin = new Padding(5, 0, 5, 0);
        label2.Name = "label2";
        label2.Size = new Size(177, 20);
        label2.TabIndex = 14;
        label2.Text = "Track Name (internal use)";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(965, 144);
        label3.Margin = new Padding(5, 0, 5, 0);
        label3.Name = "label3";
        label3.Size = new Size(78, 20);
        label3.TabIndex = 15;
        label3.Text = "Internal ID";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(665, 144);
        label4.Margin = new Padding(5, 0, 5, 0);
        label4.Name = "label4";
        label4.Size = new Size(194, 20);
        label4.TabIndex = 16;
        label4.Text = "Cue Point (seconds, as float)";
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new Point(114, 52);
        label13.Margin = new Padding(5, 0, 5, 0);
        label13.Name = "label13";
        label13.Size = new Size(175, 20);
        label13.TabIndex = 30;
        label13.Text = "By slot name (starts with)";
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(946, 52);
        label14.Margin = new Padding(5, 0, 5, 0);
        label14.Name = "label14";
        label14.Size = new Size(98, 20);
        label14.TabIndex = 33;
        label14.Text = "By Internal ID";
        // 
        // button6
        // 
        button6.Location = new Point(829, 69);
        button6.Margin = new Padding(5, 4, 5, 4);
        button6.Name = "button6";
        button6.Size = new Size(94, 44);
        button6.TabIndex = 32;
        button6.Text = "Search";
        button6.UseVisualStyleBackColor = true;
        button6.Click += button6_Click;
        // 
        // textBox14
        // 
        textBox14.Location = new Point(920, 76);
        textBox14.Margin = new Padding(5, 4, 5, 4);
        textBox14.Name = "textBox14";
        textBox14.Size = new Size(145, 27);
        textBox14.TabIndex = 31;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new Point(473, 69);
        numericUpDown1.Margin = new Padding(3, 4, 3, 4);
        numericUpDown1.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new Size(137, 27);
        numericUpDown1.TabIndex = 36;
        numericUpDown1.UpDownAlign = LeftRightAlignment.Left;
        numericUpDown1.ValueChanged += textBox1_TextChanged;
        // 
        // label15
        // 
        label15.AutoSize = true;
        label15.Location = new Point(416, 76);
        label15.Name = "label15";
        label15.Size = new Size(62, 20);
        label15.TabIndex = 37;
        label15.Text = "Slot No.";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(432, 4);
        label11.Name = "label11";
        label11.Size = new Size(79, 20);
        label11.TabIndex = 38;
        label11.Text = "Total slots:";
        // 
        // label17
        // 
        label17.AutoSize = true;
        label17.Location = new Point(544, 4);
        label17.Name = "label17";
        label17.Size = new Size(17, 20);
        label17.TabIndex = 40;
        label17.Text = "0";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1066, 238);
        Controls.Add(label17);
        Controls.Add(label11);
        Controls.Add(label15);
        Controls.Add(numericUpDown1);
        Controls.Add(label14);
        Controls.Add(button6);
        Controls.Add(textBox14);
        Controls.Add(label13);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(textBox7);
        Controls.Add(textBox5);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(button5);
        Controls.Add(textBox2);
        Controls.Add(button2);
        Controls.Add(Open);
        Margin = new Padding(5, 4, 5, 4);
        Name = "Form1";
        Text = "MusicList editor (2K22)";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private Button Open;
    private Button button2;
    private TextBox textBox2;
    private Button button5;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private TextBox textBox7;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label13;
    private Label label14;
    private Button button6;
    private TextBox textBox14;
    private NumericUpDown numericUpDown1;
    private Label label15;
    private Label label11;
    private Label label17;
}
