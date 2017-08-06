namespace prankScreen.Screens
{
	partial class f_Firefox_Google
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
			this.lbl_SearchText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbl_SearchText
			// 
			this.lbl_SearchText.AutoSize = true;
			this.lbl_SearchText.BackColor = System.Drawing.Color.Transparent;
			this.lbl_SearchText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_SearchText.Location = new System.Drawing.Point(682, 328);
			this.lbl_SearchText.Name = "lbl_SearchText";
			this.lbl_SearchText.Size = new System.Drawing.Size(0, 24);
			this.lbl_SearchText.TabIndex = 0;
			// 
			// f_Firefox_Google
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::prankScreen.Properties.Resources.google;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1046, 650);
			this.ControlBox = false;
			this.Controls.Add(this.lbl_SearchText);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "f_Firefox_Google";
			this.Text = "f_Firefox_Google";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_SearchText;
	}
}