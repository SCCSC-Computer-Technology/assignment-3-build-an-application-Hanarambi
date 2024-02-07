
namespace russo50states
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.kryptonSearchButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.textBoxSearchTerms = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kryptonSearchButton
            // 
            this.kryptonSearchButton.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.kryptonSearchButton.Location = new System.Drawing.Point(148, 207);
            this.kryptonSearchButton.Name = "kryptonSearchButton";
            this.kryptonSearchButton.Size = new System.Drawing.Size(90, 25);
            this.kryptonSearchButton.TabIndex = 0;
            this.kryptonSearchButton.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonSearchButton.Values.Image")));
            this.kryptonSearchButton.Values.Text = "Search";
            this.kryptonSearchButton.Click += new System.EventHandler(this.kryptonSearchButton_Click);
            // 
            // textBoxSearchTerms
            // 
            this.textBoxSearchTerms.Location = new System.Drawing.Point(56, 97);
            this.textBoxSearchTerms.Multiline = true;
            this.textBoxSearchTerms.Name = "textBoxSearchTerms";
            this.textBoxSearchTerms.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSearchTerms.Size = new System.Drawing.Size(260, 68);
            this.textBoxSearchTerms.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search for key words";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 340);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearchTerms);
            this.Controls.Add(this.kryptonSearchButton);
            this.Name = "SearchForm";
            this.Text = " keywords";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonSearchButton;
        private System.Windows.Forms.TextBox textBoxSearchTerms;
        private System.Windows.Forms.Label label1;
    }
}