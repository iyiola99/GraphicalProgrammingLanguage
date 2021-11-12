
namespace GraphicalProgrammingLanguage
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.programWindow = new System.Windows.Forms.RichTextBox();
            this.commandLine = new System.Windows.Forms.TextBox();
            this.displayWindow = new System.Windows.Forms.PictureBox();
            this.runButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.displayWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // programWindow
            // 
            this.programWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.programWindow.Location = new System.Drawing.Point(12, 42);
            this.programWindow.Name = "programWindow";
            this.programWindow.Size = new System.Drawing.Size(331, 276);
            this.programWindow.TabIndex = 0;
            this.programWindow.Text = "";
            // 
            // commandLine
            // 
            this.commandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandLine.Location = new System.Drawing.Point(12, 356);
            this.commandLine.Name = "commandLine";
            this.commandLine.Size = new System.Drawing.Size(331, 22);
            this.commandLine.TabIndex = 1;
            // 
            // displayWindow
            // 
            this.displayWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayWindow.Location = new System.Drawing.Point(364, 42);
            this.displayWindow.Name = "displayWindow";
            this.displayWindow.Size = new System.Drawing.Size(350, 276);
            this.displayWindow.TabIndex = 2;
            this.displayWindow.TabStop = false;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(13, 398);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(97, 23);
            this.runButton.TabIndex = 3;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 491);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.displayWindow);
            this.Controls.Add(this.commandLine);
            this.Controls.Add(this.programWindow);
            this.Name = "Form1";
            this.Text = "Graphical Programming Language Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox programWindow;
        private System.Windows.Forms.TextBox commandLine;
        private System.Windows.Forms.PictureBox displayWindow;
        private System.Windows.Forms.Button runButton;
    }
}

