namespace SIMP
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
            this.right_panel = new System.Windows.Forms.Panel();
            this.central_panel = new System.Windows.Forms.Panel();
            this.main_viewport = new System.Windows.Forms.PictureBox();
            this.central_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).BeginInit();
            this.SuspendLayout();
            // 
            // right_panel
            // 
            this.right_panel.Location = new System.Drawing.Point(608, 12);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(262, 458);
            this.right_panel.TabIndex = 0;
            // 
            // central_panel
            // 
            this.central_panel.Controls.Add(this.main_viewport);
            this.central_panel.Location = new System.Drawing.Point(12, 12);
            this.central_panel.Name = "central_panel";
            this.central_panel.Size = new System.Drawing.Size(579, 458);
            this.central_panel.TabIndex = 1;
            // 
            // main_viewport
            // 
            this.main_viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_viewport.Location = new System.Drawing.Point(0, 0);
            this.main_viewport.Name = "main_viewport";
            this.main_viewport.Size = new System.Drawing.Size(579, 458);
            this.main_viewport.TabIndex = 0;
            this.main_viewport.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 482);
            this.Controls.Add(this.central_panel);
            this.Controls.Add(this.right_panel);
            this.Name = "Form1";
            this.Text = "SIMP";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.central_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel right_panel;
        private System.Windows.Forms.Panel central_panel;
        private System.Windows.Forms.PictureBox main_viewport;
    }
}

