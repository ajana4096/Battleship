using System.Drawing;
using System.Windows.Forms;

namespace Battleship
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
            this.SuspendLayout();           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 550);            
            this.Name = "Battleship";
            this.Text = "Battleship";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.AliceBlue;
            this.ResumeLayout(false);

            //Label - banner
            Label top_banner = new Label();
            top_banner.Size = new System.Drawing.Size(500, 40);
            top_banner.Name = "top_banner";
            top_banner.Location = new System.Drawing.Point(0, 10);
            top_banner.Font= new System.Drawing.Font("Arail", 18); ;
            Controls.Add(top_banner);
        }

        #endregion
    }
}

