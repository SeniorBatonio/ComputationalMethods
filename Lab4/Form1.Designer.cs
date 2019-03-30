namespace Newton_Interpolate
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.picturebox1 = new System.Windows.Forms.PictureBox();
            this.Drawbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picturebox1
            // 
            this.picturebox1.Location = new System.Drawing.Point(3, 2);
            this.picturebox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picturebox1.Name = "picturebox1";
            this.picturebox1.Size = new System.Drawing.Size(800, 738);
            this.picturebox1.TabIndex = 0;
            this.picturebox1.TabStop = false;
            // 
            // Drawbtn
            // 
            this.Drawbtn.Location = new System.Drawing.Point(811, 26);
            this.Drawbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Drawbtn.Name = "Drawbtn";
            this.Drawbtn.Size = new System.Drawing.Size(120, 28);
            this.Drawbtn.TabIndex = 3;
            this.Drawbtn.Text = "Нарисовать";
            this.Drawbtn.UseVisualStyleBackColor = true;
            this.Drawbtn.Click += new System.EventHandler(this.Draw_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 746);
            this.Controls.Add(this.Drawbtn);
            this.Controls.Add(this.picturebox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox1;
        private System.Windows.Forms.Button Drawbtn;
    }
}

