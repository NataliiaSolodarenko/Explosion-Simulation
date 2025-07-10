namespace course_work
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.line = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.play_pause = new System.Windows.Forms.Button();
            this.point = new System.Windows.Forms.Button();
            this.arrow = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cord_x = new System.Windows.Forms.Label();
            this.cord_y = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.White;
            this.line.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.line.Location = new System.Drawing.Point(12, 104);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(40, 40);
            this.line.TabIndex = 3;
            this.line.UseVisualStyleBackColor = false;
            this.line.Click += new System.EventHandler(this.line_Click);
            this.line.Paint += new System.Windows.Forms.PaintEventHandler(this.line_Paint);
            this.line.MouseLeave += new System.EventHandler(this.line_MouseLeave);
            this.line.MouseHover += new System.EventHandler(this.line_MouseHover);
            this.line.MouseMove += new System.Windows.Forms.MouseEventHandler(this.line_MouseMove);
            // 
            // refresh
            // 
            this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refresh.BackColor = System.Drawing.Color.White;
            this.refresh.BackgroundImage = global::course_work.Properties.Resources.Refresh;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refresh.Location = new System.Drawing.Point(12, 398);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(40, 40);
            this.refresh.TabIndex = 8;
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // play_pause
            // 
            this.play_pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.play_pause.BackColor = System.Drawing.Color.White;
            this.play_pause.BackgroundImage = global::course_work.Properties.Resources.Play;
            this.play_pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.play_pause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.play_pause.Location = new System.Drawing.Point(12, 352);
            this.play_pause.Name = "play_pause";
            this.play_pause.Size = new System.Drawing.Size(40, 40);
            this.play_pause.TabIndex = 7;
            this.play_pause.UseVisualStyleBackColor = false;
            this.play_pause.Click += new System.EventHandler(this.play_pause_Click);
            // 
            // point
            // 
            this.point.BackColor = System.Drawing.Color.White;
            this.point.BackgroundImage = global::course_work.Properties.Resources.Cursor;
            this.point.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.point.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.point.Location = new System.Drawing.Point(12, 58);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(40, 40);
            this.point.TabIndex = 2;
            this.point.UseVisualStyleBackColor = false;
            this.point.Click += new System.EventHandler(this.point_Click);
            this.point.MouseLeave += new System.EventHandler(this.point_MouseLeave);
            this.point.MouseHover += new System.EventHandler(this.point_MouseHover);
            this.point.MouseMove += new System.Windows.Forms.MouseEventHandler(this.point_MouseMove);
            // 
            // arrow
            // 
            this.arrow.BackColor = System.Drawing.Color.White;
            this.arrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("arrow.BackgroundImage")));
            this.arrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.arrow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.arrow.Location = new System.Drawing.Point(12, 12);
            this.arrow.Name = "arrow";
            this.arrow.Size = new System.Drawing.Size(40, 40);
            this.arrow.TabIndex = 1;
            this.arrow.UseVisualStyleBackColor = false;
            this.arrow.Click += new System.EventHandler(this.arrow_Click);
            this.arrow.MouseLeave += new System.EventHandler(this.arrow_MouseLeave);
            this.arrow.MouseHover += new System.EventHandler(this.arrow_MouseHover);
            this.arrow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.arrow_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(64, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(724, 426);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cord_x
            // 
            this.cord_x.AutoSize = true;
            this.cord_x.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cord_x.ForeColor = System.Drawing.Color.White;
            this.cord_x.Location = new System.Drawing.Point(9, 147);
            this.cord_x.Name = "cord_x";
            this.cord_x.Size = new System.Drawing.Size(22, 17);
            this.cord_x.TabIndex = 9;
            this.cord_x.Text = "x: ";
            // 
            // cord_y
            // 
            this.cord_y.AutoSize = true;
            this.cord_y.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cord_y.ForeColor = System.Drawing.Color.White;
            this.cord_y.Location = new System.Drawing.Point(9, 164);
            this.cord_y.Name = "cord_y";
            this.cord_y.Size = new System.Drawing.Size(22, 17);
            this.cord_y.TabIndex = 10;
            this.cord_y.Text = "y: ";
            // 
            // speed
            // 
            this.speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speed.BackColor = System.Drawing.Color.White;
            this.speed.BackgroundImage = global::course_work.Properties.Resources.Speed_1;
            this.speed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.speed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.speed.Location = new System.Drawing.Point(12, 324);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(40, 25);
            this.speed.TabIndex = 12;
            this.speed.UseVisualStyleBackColor = false;
            this.speed.Visible = false;
            this.speed.Click += new System.EventHandler(this.speed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(113)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.cord_y);
            this.Controls.Add(this.cord_x);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.play_pause);
            this.Controls.Add(this.line);
            this.Controls.Add(this.point);
            this.Controls.Add(this.arrow);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Explosion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button arrow;
        private System.Windows.Forms.Button point;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button play_pause;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label cord_x;
        private System.Windows.Forms.Label cord_y;
        private System.Windows.Forms.Button speed;
    }
}

