namespace WFAKartEslestirmeOyunu.UI
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            flpKartAlani = new FlowLayoutPanel();
            tmrYanlisKartlariKapat = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // flpKartAlani
            // 
            flpKartAlani.BackColor = Color.Black;
            flpKartAlani.Location = new Point(34, 25);
            flpKartAlani.Name = "flpKartAlani";
            flpKartAlani.Size = new Size(1028, 773);
            flpKartAlani.TabIndex = 0;
            // 
            // tmrYanlisKartlariKapat
            // 
            tmrYanlisKartlariKapat.Interval = 1000;
            tmrYanlisKartlariKapat.Tick += tmrYanlisKartlariKapat_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1098, 830);
            Controls.Add(flpKartAlani);
            Name = "Form1";
            Text = "Kart Eşleştirme Oyunu";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpKartAlani;
        private System.Windows.Forms.Timer tmrYanlisKartlariKapat;
    }
}
