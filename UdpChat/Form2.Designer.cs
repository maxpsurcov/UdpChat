namespace UdpChat
{
    partial class Form2
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
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fontButton = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.localPortTextBox = new System.Windows.Forms.TextBox();
            this.remotePortTextBox = new System.Windows.Forms.TextBox();
            this.fontLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(384, 333);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(201, 56);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Зберегти";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(384, 409);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(201, 61);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(384, 256);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(201, 56);
            this.fontButton.TabIndex = 2;
            this.fontButton.Text = "font";
            this.fontButton.UseVisualStyleBackColor = true;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(42, 60);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(184, 29);
            this.addressTextBox.TabIndex = 3;
            // 
            // localPortTextBox
            // 
            this.localPortTextBox.Location = new System.Drawing.Point(42, 117);
            this.localPortTextBox.Name = "localPortTextBox";
            this.localPortTextBox.Size = new System.Drawing.Size(184, 29);
            this.localPortTextBox.TabIndex = 4;
            // 
            // remotePortTextBox
            // 
            this.remotePortTextBox.Location = new System.Drawing.Point(42, 172);
            this.remotePortTextBox.Name = "remotePortTextBox";
            this.remotePortTextBox.Size = new System.Drawing.Size(184, 29);
            this.remotePortTextBox.TabIndex = 5;
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(37, 240);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(92, 25);
            this.fontLabel.TabIndex = 6;
            this.fontLabel.Text = "fontLabel";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 566);
            this.Controls.Add(this.fontLabel);
            this.Controls.Add(this.remotePortTextBox);
            this.Controls.Add(this.localPortTextBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.fontButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox localPortTextBox;
        private System.Windows.Forms.TextBox remotePortTextBox;
        private System.Windows.Forms.Label fontLabel;
    }
}