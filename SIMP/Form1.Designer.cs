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
            this.b_delete_selected_layers = new System.Windows.Forms.Button();
            this.b_new_folder = new System.Windows.Forms.Button();
            this.documentStructureViewer1 = new WindowsFormsControlLibrary1.DocumentStructureViewer();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.b_new_layer = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.b_tool_pointer = new System.Windows.Forms.Button();
            this.b_tool_shape = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.b_tool_line = new System.Windows.Forms.Button();
            this.b_tool_move = new System.Windows.Forms.Button();
            this.b_tool_select = new System.Windows.Forms.Button();
            this.central_panel = new System.Windows.Forms.Panel();
            this.main_viewport = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_debug = new System.Windows.Forms.CheckBox();
            this.p_debug_panel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.right_panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.central_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.p_debug_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // right_panel
            // 
            this.right_panel.Controls.Add(this.b_delete_selected_layers);
            this.right_panel.Controls.Add(this.b_new_folder);
            this.right_panel.Controls.Add(this.documentStructureViewer1);
            this.right_panel.Controls.Add(this.button6);
            this.right_panel.Controls.Add(this.button5);
            this.right_panel.Controls.Add(this.b_new_layer);
            this.right_panel.Controls.Add(this.button3);
            this.right_panel.Controls.Add(this.b_tool_pointer);
            this.right_panel.Controls.Add(this.b_tool_shape);
            this.right_panel.Controls.Add(this.groupBox1);
            this.right_panel.Controls.Add(this.button4);
            this.right_panel.Controls.Add(this.label1);
            this.right_panel.Controls.Add(this.b_tool_line);
            this.right_panel.Controls.Add(this.b_tool_move);
            this.right_panel.Controls.Add(this.b_tool_select);
            this.right_panel.Location = new System.Drawing.Point(608, 27);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(262, 666);
            this.right_panel.TabIndex = 0;
            // 
            // b_delete_selected_layers
            // 
            this.b_delete_selected_layers.Image = global::SIMP.Properties.Resources.minus;
            this.b_delete_selected_layers.Location = new System.Drawing.Point(67, 632);
            this.b_delete_selected_layers.Name = "b_delete_selected_layers";
            this.b_delete_selected_layers.Size = new System.Drawing.Size(26, 25);
            this.b_delete_selected_layers.TabIndex = 19;
            this.b_delete_selected_layers.UseVisualStyleBackColor = true;
            this.b_delete_selected_layers.Click += new System.EventHandler(this.b_delete_selected_layers_Click);
            // 
            // b_new_folder
            // 
            this.b_new_folder.Image = global::SIMP.Properties.Resources.add_folder;
            this.b_new_folder.Location = new System.Drawing.Point(35, 632);
            this.b_new_folder.Name = "b_new_folder";
            this.b_new_folder.Size = new System.Drawing.Size(26, 25);
            this.b_new_folder.TabIndex = 18;
            this.b_new_folder.UseVisualStyleBackColor = true;
            this.b_new_folder.Click += new System.EventHandler(this.b_new_folder_Click);
            // 
            // documentStructureViewer1
            // 
            this.documentStructureViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.documentStructureViewer1.Location = new System.Drawing.Point(3, 332);
            this.documentStructureViewer1.Name = "documentStructureViewer1";
            this.documentStructureViewer1.Size = new System.Drawing.Size(227, 294);
            this.documentStructureViewer1.TabIndex = 17;
            this.documentStructureViewer1.OnSetCurrentEntity += new WindowsFormsControlLibrary1.DocumentStructureViewer.DocumentStructureHandler(this.documentStructureViewer1_OnSetCurrentEntity);
            this.documentStructureViewer1.OnAddChilds += new WindowsFormsControlLibrary1.DocumentStructureViewer.DocumentStructureHandler(this.documentStructureViewer1_OnAddChilds);
            this.documentStructureViewer1.OnVisibleChanged_ += new WindowsFormsControlLibrary1.DocumentStructureViewer.DocumentStructureHandler(this.documentStructureViewer1_OnVisibleChanged_);
            this.documentStructureViewer1.OnUnsetChilds += new WindowsFormsControlLibrary1.DocumentStructureViewer.DocumentStructureHandler(this.documentStructureViewer1_OnUnsetChilds);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(172, 176);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 16;
            this.button6.Text = "Show center";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(172, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Rotate _";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // b_new_layer
            // 
            this.b_new_layer.Image = global::SIMP.Properties.Resources.new_layer2;
            this.b_new_layer.Location = new System.Drawing.Point(3, 632);
            this.b_new_layer.Name = "b_new_layer";
            this.b_new_layer.Size = new System.Drawing.Size(26, 25);
            this.b_new_layer.TabIndex = 2;
            this.b_new_layer.UseVisualStyleBackColor = true;
            this.b_new_layer.Click += new System.EventHandler(this.b_new_layer_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(172, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Scale _";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
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
            // b_tool_shape
            // 
            this.b_tool_shape.Location = new System.Drawing.Point(15, 92);
            this.b_tool_shape.Name = "b_tool_shape";
            this.b_tool_shape.Size = new System.Drawing.Size(75, 23);
            this.b_tool_shape.TabIndex = 12;
            this.b_tool_shape.Text = "Shape _";
            this.b_tool_shape.UseVisualStyleBackColor = true;
            this.b_tool_shape.Click += new System.EventHandler(this.b_tool_shape_Click);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 121);
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
            this.label1.Location = new System.Drawing.Point(12, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // b_tool_line
            // 
            this.b_tool_line.Location = new System.Drawing.Point(15, 63);
            this.b_tool_line.Name = "b_tool_line";
            this.b_tool_line.Size = new System.Drawing.Size(75, 23);
            this.b_tool_line.TabIndex = 7;
            this.b_tool_line.Text = "Line _";
            this.b_tool_line.UseVisualStyleBackColor = true;
            this.b_tool_line.Click += new System.EventHandler(this.b_tool_line_Click);
            // 
            // b_tool_move
            // 
            this.b_tool_move.Location = new System.Drawing.Point(172, 55);
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
            // central_panel
            // 
            this.central_panel.Controls.Add(this.p_debug_panel);
            this.central_panel.Controls.Add(this.main_viewport);
            this.central_panel.Location = new System.Drawing.Point(12, 27);
            this.central_panel.Name = "central_panel";
            this.central_panel.Size = new System.Drawing.Size(579, 666);
            this.central_panel.TabIndex = 1;
            // 
            // main_viewport
            // 
            this.main_viewport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_viewport.Location = new System.Drawing.Point(0, 0);
            this.main_viewport.Name = "main_viewport";
            this.main_viewport.Size = new System.Drawing.Size(579, 666);
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
            this.selectionToolStripMenuItem,
            this.layerToolStripMenuItem});
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
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
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
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
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
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.unselectAllToolStripMenuItem.Text = "Unselect all";
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // layerToolStripMenuItem
            // 
            this.layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            this.layerToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.layerToolStripMenuItem.Text = "Layer";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Clear lp";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_debug
            // 
            this.cb_debug.AutoSize = true;
            this.cb_debug.Location = new System.Drawing.Point(866, 689);
            this.cb_debug.Name = "cb_debug";
            this.cb_debug.Size = new System.Drawing.Size(15, 14);
            this.cb_debug.TabIndex = 21;
            this.cb_debug.UseVisualStyleBackColor = true;
            this.cb_debug.CheckedChanged += new System.EventHandler(this.cb_debug_CheckedChanged);
            // 
            // p_debug_panel
            // 
            this.p_debug_panel.Controls.Add(this.button2);
            this.p_debug_panel.Controls.Add(this.button1);
            this.p_debug_panel.Location = new System.Drawing.Point(384, 3);
            this.p_debug_panel.Name = "p_debug_panel";
            this.p_debug_panel.Size = new System.Drawing.Size(192, 247);
            this.p_debug_panel.TabIndex = 22;
            this.p_debug_panel.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Restore lp";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 705);
            this.Controls.Add(this.cb_debug);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.central_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_viewport)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.p_debug_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel right_panel;
        private System.Windows.Forms.Panel central_panel;
        private System.Windows.Forms.PictureBox main_viewport;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button b_new_layer;
        private WindowsFormsControlLibrary1.DocumentStructureViewer documentStructureViewer1;
        private System.Windows.Forms.Button b_new_folder;
        private System.Windows.Forms.Button b_delete_selected_layers;
        private System.Windows.Forms.ToolStripMenuItem layerToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cb_debug;
        private System.Windows.Forms.Panel p_debug_panel;
        private System.Windows.Forms.Button button2;
    }
}

