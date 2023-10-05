
namespace lab4_windowsApp
{
    partial class startForm
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
            newClientCreation = new Button();
            oldClientFinding = new Button();
            SuspendLayout();
            // 
            // newClientCreation
            // 
            newClientCreation.Location = new Point(22, 12);
            newClientCreation.MinimumSize = new Size(100, 45);
            newClientCreation.Name = "newClientCreation";
            newClientCreation.Size = new Size(100, 45);
            newClientCreation.TabIndex = 0;
            newClientCreation.Text = "Создать нового пользователя";
            newClientCreation.UseVisualStyleBackColor = true;
            newClientCreation.Click += newClientCreation_Click;
            // 
            // oldClientFinding
            // 
            oldClientFinding.Location = new Point(147, 12);
            oldClientFinding.MinimumSize = new Size(100, 45);
            oldClientFinding.Name = "oldClientFinding";
            oldClientFinding.Size = new Size(100, 45);
            oldClientFinding.TabIndex = 1;
            oldClientFinding.Text = "Найти пользователя";
            oldClientFinding.UseVisualStyleBackColor = true;
            oldClientFinding.Click += oldClientFinding_Click;
            // 
            // startForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 76);
            Controls.Add(oldClientFinding);
            Controls.Add(newClientCreation);
            MaximumSize = new Size(295, 115);
            MinimumSize = new Size(295, 93);
            Name = "startForm";
            Text = "Банковская система";
            ResumeLayout(false);
        }

        #endregion

        private Button newClientCreation;
        private Button oldClientFinding;
    }
}

