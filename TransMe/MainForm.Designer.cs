
namespace TransMe
{
    partial class MainForm
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
            this.textClipboard = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemJoinLines = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxTranslation = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuItemTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textClipboard
            // 
            this.textClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textClipboard.ContextMenuStrip = this.contextMenu;
            this.textClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textClipboard.Location = new System.Drawing.Point(3, 3);
            this.textClipboard.Multiline = true;
            this.textClipboard.Name = "textClipboard";
            this.textClipboard.Size = new System.Drawing.Size(184, 92);
            this.textClipboard.TabIndex = 0;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTranslate,
            this.menuItemJoinLines});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // menuItemJoinLines
            // 
            this.menuItemJoinLines.CheckOnClick = true;
            this.menuItemJoinLines.Name = "menuItemJoinLines";
            this.menuItemJoinLines.Size = new System.Drawing.Size(148, 22);
            this.menuItemJoinLines.Text = "翻译前合并行";
            this.menuItemJoinLines.CheckStateChanged += new System.EventHandler(this.menuItemJoinLines_CheckStateChanged);
            // 
            // textBoxTranslation
            // 
            this.textBoxTranslation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTranslation.Location = new System.Drawing.Point(3, 101);
            this.textBoxTranslation.Multiline = true;
            this.textBoxTranslation.Name = "textBoxTranslation";
            this.textBoxTranslation.Size = new System.Drawing.Size(184, 92);
            this.textBoxTranslation.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxTranslation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textClipboard, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 196);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // menuItemTranslate
            // 
            this.menuItemTranslate.Name = "menuItemTranslate";
            this.menuItemTranslate.Size = new System.Drawing.Size(148, 22);
            this.menuItemTranslate.Text = "翻译";
            this.menuItemTranslate.Click += new System.EventHandler(this.menuItemTranslate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(190, 196);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textClipboard;
        private System.Windows.Forms.TextBox textBoxTranslation;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemJoinLines;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem menuItemTranslate;
    }
}

