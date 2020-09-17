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
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.b_tool_shape = new System.Windows.Forms.Button();
            this.b_tool_pointer = new System.Windows.Forms.Button();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.right_panel.SuspendLayout();
            this.central_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // right_panel
            // 
            this.right_panel.Controls.Add(this.b_tool_pointer);
            this.right_panel.Controls.Add(this.b_tool_shape);
            this.right_panel.Controls.Add(this.groupBox1);
            this.right_panel.Controls.Add(this.button4);
            this.right_panel.Controls.Add(this.label1);
            this.right_panel.Controls.Add(this.b_tool_line);
            this.right_panel.Controls.Add(this.b_tool_move);
            this.right_panel.Controls.Add(this.b_tool_select);
            this.right_panel.Controls.Add(this.button2);
            this.right_panel.Controls.Add(this.button1);
            this.right_panel.Controls.Add(this.b_new_layer);
            this.right_panel.Controls.Add(this.cb_layer_visible);
            this.right_panel.Controls.Add(this.lb_layers);
            this.right_panel.Location = new System.Drawing.Point(608, 27);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(262, 461);
            this.right_panel.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
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
            this.b_tool_move.Location = new System.Drawing.Point(172, 103);
            this.b_tool_move.Name = "b_tool_move";
            this.b_tool_move.Size = new System.Drawing.Size(75, 23);
            this.b_tool_move.TabIndex = 6;
            this.b_tool_move.Text = "Move _";
            this.b_tool_move.UseVisualStyleBackColor = true;
            this.b_tool_move.Click += new System.EventHandler(this.b_tool_move_Click);
            // 
            // b_tool_select
            // 
            this.b_tool_select.Location = new System.Drawing.Point(15, 5);
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
            this.central_panel.Location = new System.Drawing.Point(12, 27);
            this.central_panel.Name = "central_panel";
            this.central_panel.Size = new System.Drawing.Size(579, 461);
            this.central_panel.TabIndex = 1;
            // 
            // main_viewport
            // 
            this.main_viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_viewport.Location = new System.Drawing.Point(0, 0);
            this.main_viewport.Name = "main_viewport";
            this.main_viewport.Size = new System.Drawing.Size(579, 461);
            this.main_viewport.TabIndex = 0;
            this.main_viewport.TabStop = false;
            this.main_viewport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseClick);
            this.main_viewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseDown);
            this.main_viewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseMove);
            this.main_viewport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.main_viewport_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.selectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.selectionToolStripMenuItem.Text = "Selection";
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.unselectAllToolStripMenuItem.Text = "Unselect all";
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(96, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 44);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "points";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(65, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "shapes";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // b_tool_shape
            // 
            this.b_tool_shape.Location = new System.Drawing.Point(15, 149);
            this.b_tool_shape.Name = "b_tool_shape";
            this.b_tool_shape.Size = new System.Drawing.Size(75, 23);
            this.b_tool_shape.TabIndex = 12;
            this.b_tool_shape.Text = "Shape _";
            this.b_tool_shape.UseVisualStyleBackColor = true;
            this.b_tool_shape.Click += new System.EventHandler(this.b_tool_shape_Click);
            // 
            // b_tool_pointer
            // 
            this.b_tool_pointer.Location = new System.Drawing.Point(15, 34);
            this.b_tool_pointer.Name = "b_tool_pointer";
            this.b_tool_pointer.Size = new System.Drawing.Size(75, 23);
            this.b_tool_pointer.TabIndex = 13;
            this.b_tool_pointer.Text = "Pointer _";
            this.b_tool_pointer.UseVisualStyleBackColor = true;
            this.b_tool_pointer.Click += new System.EventHandler(this.b_tool_pointer_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 500);
            this.Controls.Add(this.central_panel);
            this.Controls.Add(this.right_panel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "SIMP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.right_panel.ResumeLayout(false);
            this.right_panel.PerformLayout();
            this.central_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button b_tool_shape;
        private System.Windows.Forms.Button b_tool_pointer;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

