namespace Monopol
{
    partial class FormGrad
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
            this.btnDa = new System.Windows.Forms.Button();
            this.btnNe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDa
            // 
            this.btnDa.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDa.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDa.Location = new System.Drawing.Point(14, 318);
            this.btnDa.Name = "btnDa";
            this.btnDa.Size = new System.Drawing.Size(60, 23);
            this.btnDa.TabIndex = 3;
            this.btnDa.Text = "Да";
            this.btnDa.UseVisualStyleBackColor = true;
            this.btnDa.Click += new System.EventHandler(this.btnDa_Click);
            // 
            // btnNe
            // 
            this.btnNe.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNe.ForeColor = System.Drawing.Color.Firebrick;
            this.btnNe.Location = new System.Drawing.Point(101, 318);
            this.btnNe.Name = "btnNe";
            this.btnNe.Size = new System.Drawing.Size(58, 23);
            this.btnNe.TabIndex = 4;
            this.btnNe.Text = "Не";
            this.btnNe.UseVisualStyleBackColor = true;
            this.btnNe.Click += new System.EventHandler(this.btnNe_Click);
            // 
            // FormGrad
            // 
            this.AcceptButton = this.btnDa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.btnNe);
            this.Controls.Add(this.btnDa);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGrad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormGrad_Paint_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDa;
        private System.Windows.Forms.Button btnNe;
    }
}