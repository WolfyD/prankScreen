namespace prankScreen.Screens
{
    partial class f_Install_w98
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
            this.components = new System.ComponentModel.Container();
            this.t_Progress = new System.Windows.Forms.Timer(this.components);
            this.p_Stencil = new System.Windows.Forms.Panel();
            this.lbl_Text = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.p_Progress = new System.Windows.Forms.Panel();
            this.p_Stencil.SuspendLayout();
            this.SuspendLayout();
            // 
            // t_Progress
            // 
            this.t_Progress.Enabled = true;
            this.t_Progress.Interval = 1000;
            this.t_Progress.Tick += new System.EventHandler(this.t_Progress_Tick);
            // 
            // p_Stencil
            // 
            this.p_Stencil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_Stencil.BackgroundImage = global::prankScreen.Properties.Resources.win98_Setup_Stencil;
            this.p_Stencil.Controls.Add(this.lbl_Text);
            this.p_Stencil.Controls.Add(this.lbl_Title);
            this.p_Stencil.Controls.Add(this.p_Progress);
            this.p_Stencil.Location = new System.Drawing.Point(0, 0);
            this.p_Stencil.Name = "p_Stencil";
            this.p_Stencil.Size = new System.Drawing.Size(640, 480);
            this.p_Stencil.TabIndex = 0;
            // 
            // lbl_Text
            // 
            this.lbl_Text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Text.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Text.ForeColor = System.Drawing.Color.White;
            this.lbl_Text.Location = new System.Drawing.Point(186, 155);
            this.lbl_Text.Name = "lbl_Text";
            this.lbl_Text.Size = new System.Drawing.Size(412, 267);
            this.lbl_Text.TabIndex = 2;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Title.ForeColor = System.Drawing.Color.White;
            this.lbl_Title.Location = new System.Drawing.Point(185, 114);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(413, 29);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Welcome to Microsoft Windows 98";
            // 
            // p_Progress
            // 
            this.p_Progress.BackColor = System.Drawing.Color.White;
            this.p_Progress.Location = new System.Drawing.Point(9, 381);
            this.p_Progress.Name = "p_Progress";
            this.p_Progress.Size = new System.Drawing.Size(116, 17);
            this.p_Progress.TabIndex = 0;
            // 
            // f_Install_w98
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.p_Stencil);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_Install_w98";
            this.Text = "f_Install_w98";
            this.TopMost = true;
            this.MouseEnter += new System.EventHandler(this.f_Install_w98_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.f_Install_w98_MouseLeave);
            this.p_Stencil.ResumeLayout(false);
            this.p_Stencil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Stencil;
        private System.Windows.Forms.Panel p_Progress;
        private System.Windows.Forms.Timer t_Progress;
        private System.Windows.Forms.Label lbl_Text;
        private System.Windows.Forms.Label lbl_Title;
    }
}