namespace WindowsFormsControlLibrary1
{
    partial class DocumentStructureViewer
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.add_folder = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // add_folder
            // 
            this.add_folder.Image = global::WindowsFormsControlLibrary1.Properties.Resources.add_folder;
            this.add_folder.Location = new System.Drawing.Point(4, 291);
            this.add_folder.Name = "add_folder";
            this.add_folder.Size = new System.Drawing.Size(40, 37);
            this.add_folder.TabIndex = 3;
            this.add_folder.UseVisualStyleBackColor = true;
            this.add_folder.Click += new System.EventHandler(this.add_folder_Click);
            // 
            // button2
            // 
            this.button2.Image = global::WindowsFormsControlLibrary1.Properties.Resources.new_layer2;
            this.button2.Location = new System.Drawing.Point(50, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 37);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(96, 291);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(142, 291);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 37);
            this.button4.TabIndex = 6;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 282);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // DocumentStructureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.add_folder);
            this.Name = "DocumentStructureViewer";
            this.Size = new System.Drawing.Size(227, 331);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button add_folder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private Panel userControl21;
    }
}
