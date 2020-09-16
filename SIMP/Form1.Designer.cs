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
            this.button3 = new System.Windows.Forms.Button();
            this.b_tool_line = new System.Windows.Forms.Button();
            this.b_tool_move = new System.Windows.Forms.Button();
            this.b_tool_select = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.b_new_layer = new System.Windows.Forms.Button();
            this.cb_layer_visible = new System.Windows.Forms.CheckBox();
            this.lb_layers = new System.Windows.Forms.ListBox();
            this.central_panel = new System.Windows.Forms.Panel();
            this.main_viewport = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.right_panel.SuspendLayout();
            this.central_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).BeginInit();
            this.SuspendLayout();
            // 
            // right_panel
            // 
            this.right_panel.Controls.Add(this.button4);
            this.right_panel.Controls.Add(this.label1);
            this.right_panel.Controls.Add(this.button3);
            this.right_panel.Controls.Add(this.b_tool_line);
            this.right_panel.Controls.Add(this.b_tool_move);
            this.right_panel.Controls.Add(this.b_tool_select);
            this.right_panel.Controls.Add(this.button2);
            this.right_panel.Controls.Add(this.button1);
            this.right_panel.Controls.Add(this.b_new_layer);
            this.right_panel.Controls.Add(this.cb_layer_visible);
            this.right_panel.Controls.Add(this.lb_layers);
            this.right_panel.Location = new System.Drawing.Point(608, 12);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(262, 458);
            this.right_panel.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(111, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Unselect all";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // b_tool_line
            // 
            this.b_tool_line.Location = new System.Drawing.Point(15, 120);
            this.b_tool_line.Name = "b_tool_line";
            this.b_tool_line.Size = new System.Drawing.Size(75, 23);
            this.b_tool_line.TabIndex = 7;
            this.b_tool_line.Text = "Line _";
            this.b_tool_line.UseVisualStyleBackColor = true;
            this.b_tool_line.Click += new System.EventHandler(this.b_tool_line_Click);
            // 
            // b_tool_move
            // 
            this.b_tool_move.Location = new System.Drawing.Point(15, 61);
            this.b_tool_move.Name = "b_tool_move";
            this.b_tool_move.Size = new System.Drawing.Size(75, 23);
            this.b_tool_move.TabIndex = 6;
            this.b_tool_move.Text = "Move _";
            this.b_tool_move.UseVisualStyleBackColor = true;
            this.b_tool_move.Click += new System.EventHandler(this.b_tool_move_Click);
            // 
            // b_tool_select
            // 
            this.b_tool_select.Location = new System.Drawing.Point(15, 32);
            this.b_tool_select.Name = "b_tool_select";
            this.b_tool_select.Size = new System.Drawing.Size(75, 23);
            this.b_tool_select.TabIndex = 5;
            this.b_tool_select.Text = "Select _";
            this.b_tool_select.UseVisualStyleBackColor = true;
            this.b_tool_select.Click += new System.EventHandler(this.b_tool_select_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // b_new_layer
            // 
            this.b_new_layer.Location = new System.Drawing.Point(130, 371);
            this.b_new_layer.Name = "b_new_layer";
            this.b_new_layer.Size = new System.Drawing.Size(75, 23);
            this.b_new_layer.TabIndex = 2;
            this.b_new_layer.Text = "New";
            this.b_new_layer.UseVisualStyleBackColor = true;
            this.b_new_layer.Click += new System.EventHandler(this.b_new_layer_Click);
            // 
            // cb_layer_visible
            // 
            this.cb_layer_visible.AutoSize = true;
            this.cb_layer_visible.Location = new System.Drawing.Point(130, 347);
            this.cb_layer_visible.Name = "cb_layer_visible";
            this.cb_layer_visible.Size = new System.Drawing.Size(56, 17);
            this.cb_layer_visible.TabIndex = 1;
            this.cb_layer_visible.Text = "Visible";
            this.cb_layer_visible.UseVisualStyleBackColor = true;
            this.cb_layer_visible.CheckedChanged += new System.EventHandler(this.cb_layer_visible_CheckedChanged);
            // 
            // lb_layers
            // 
            this.lb_layers.FormattingEnabled = true;
            this.lb_layers.Location = new System.Drawing.Point(3, 347);
            this.lb_layers.Name = "lb_layers";
            this.lb_layers.Size = new System.Drawing.Size(120, 108);
            this.lb_layers.TabIndex = 0;
            this.lb_layers.SelectedIndexChanged += new System.EventHandler(this.lb_layers_SelectedIndexChanged);
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
            this.main_viewport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseClick);
            this.main_viewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseDown);
            this.main_viewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseMove);
            this.main_viewport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 265);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Formula _";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.right_panel.ResumeLayout(false);
            this.right_panel.PerformLayout();
            this.central_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel right_panel;
        private System.Windows.Forms.Panel central_panel;
        private System.Windows.Forms.PictureBox main_viewport;
        private System.Windows.Forms.ListBox lb_layers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_new_layer;
        private System.Windows.Forms.CheckBox cb_layer_visible;
        private System.Windows.Forms.Button b_tool_line;
        private System.Windows.Forms.Button b_tool_move;
        private System.Windows.Forms.Button b_tool_select;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
    }
}

