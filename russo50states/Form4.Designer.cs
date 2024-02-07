
namespace russo50states
{
    partial class SortForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDesc = new System.Windows.Forms.RadioButton();
            this.radioButtonAsc = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.yoMama = new System.Windows.Forms.RadioButton();
            this.radioButtonCompJobPercent = new System.Windows.Forms.RadioButton();
            this.radioButtonMedIncome = new System.Windows.Forms.RadioButton();
            this.radioButtonPopulation = new System.Windows.Forms.RadioButton();
            this.radioButtonState = new System.Windows.Forms.RadioButton();
            this.goButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.closeButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Controls.Add(this.radioButtonDesc);
            this.groupBox1.Controls.Add(this.radioButtonAsc);
            this.groupBox1.Location = new System.Drawing.Point(48, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort Order";
            // 
            // radioButtonDesc
            // 
            this.radioButtonDesc.AutoSize = true;
            this.radioButtonDesc.Location = new System.Drawing.Point(7, 43);
            this.radioButtonDesc.Name = "radioButtonDesc";
            this.radioButtonDesc.Size = new System.Drawing.Size(76, 17);
            this.radioButtonDesc.TabIndex = 1;
            this.radioButtonDesc.TabStop = true;
            this.radioButtonDesc.Text = "Desending";
            this.radioButtonDesc.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsc
            // 
            this.radioButtonAsc.AutoSize = true;
            this.radioButtonAsc.Location = new System.Drawing.Point(7, 20);
            this.radioButtonAsc.Name = "radioButtonAsc";
            this.radioButtonAsc.Size = new System.Drawing.Size(75, 17);
            this.radioButtonAsc.TabIndex = 0;
            this.radioButtonAsc.TabStop = true;
            this.radioButtonAsc.Text = "Ascending";
            this.radioButtonAsc.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DimGray;
            this.groupBox2.Controls.Add(this.yoMama);
            this.groupBox2.Controls.Add(this.radioButtonCompJobPercent);
            this.groupBox2.Controls.Add(this.radioButtonMedIncome);
            this.groupBox2.Controls.Add(this.radioButtonPopulation);
            this.groupBox2.Controls.Add(this.radioButtonState);
            this.groupBox2.Location = new System.Drawing.Point(48, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sort By";
            // 
            // yoMama
            // 
            this.yoMama.AutoSize = true;
            this.yoMama.Location = new System.Drawing.Point(7, 112);
            this.yoMama.Name = "yoMama";
            this.yoMama.Size = new System.Drawing.Size(73, 17);
            this.yoMama.TabIndex = 4;
            this.yoMama.TabStop = true;
            this.yoMama.Text = "Yo Mama!";
            this.yoMama.UseVisualStyleBackColor = true;
            // 
            // radioButtonCompJobPercent
            // 
            this.radioButtonCompJobPercent.AutoSize = true;
            this.radioButtonCompJobPercent.Location = new System.Drawing.Point(7, 89);
            this.radioButtonCompJobPercent.Name = "radioButtonCompJobPercent";
            this.radioButtonCompJobPercent.Size = new System.Drawing.Size(110, 17);
            this.radioButtonCompJobPercent.TabIndex = 3;
            this.radioButtonCompJobPercent.TabStop = true;
            this.radioButtonCompJobPercent.Text = "Tech Job Percent";
            this.radioButtonCompJobPercent.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedIncome
            // 
            this.radioButtonMedIncome.AutoSize = true;
            this.radioButtonMedIncome.Location = new System.Drawing.Point(7, 66);
            this.radioButtonMedIncome.Name = "radioButtonMedIncome";
            this.radioButtonMedIncome.Size = new System.Drawing.Size(98, 17);
            this.radioButtonMedIncome.TabIndex = 2;
            this.radioButtonMedIncome.TabStop = true;
            this.radioButtonMedIncome.Text = "Median Income";
            this.radioButtonMedIncome.UseVisualStyleBackColor = true;
            // 
            // radioButtonPopulation
            // 
            this.radioButtonPopulation.AutoSize = true;
            this.radioButtonPopulation.Location = new System.Drawing.Point(7, 43);
            this.radioButtonPopulation.Name = "radioButtonPopulation";
            this.radioButtonPopulation.Size = new System.Drawing.Size(75, 17);
            this.radioButtonPopulation.TabIndex = 1;
            this.radioButtonPopulation.TabStop = true;
            this.radioButtonPopulation.Text = "Population";
            this.radioButtonPopulation.UseVisualStyleBackColor = true;
            // 
            // radioButtonState
            // 
            this.radioButtonState.AutoSize = true;
            this.radioButtonState.Location = new System.Drawing.Point(7, 20);
            this.radioButtonState.Name = "radioButtonState";
            this.radioButtonState.Size = new System.Drawing.Size(50, 17);
            this.radioButtonState.TabIndex = 0;
            this.radioButtonState.TabStop = true;
            this.radioButtonState.Text = "State";
            this.radioButtonState.UseVisualStyleBackColor = true;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(12, 337);
            this.goButton.Name = "goButton";
            this.goButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.goButton.Size = new System.Drawing.Size(90, 25);
            this.goButton.TabIndex = 2;
            this.goButton.Values.Text = "Enter";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(134, 337);
            this.closeButton.Name = "closeButton";
            this.closeButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.closeButton.Size = new System.Drawing.Size(90, 25);
            this.closeButton.TabIndex = 3;
            this.closeButton.Values.Text = "Close";
            // 
            // SortForm
            // 
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(238, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SortForm";
            this.Text = "Form4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonDesc;
        private System.Windows.Forms.RadioButton radioButtonAsc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton yoMama;
        private System.Windows.Forms.RadioButton radioButtonCompJobPercent;
        private System.Windows.Forms.RadioButton radioButtonMedIncome;
        private System.Windows.Forms.RadioButton radioButtonPopulation;
        private System.Windows.Forms.RadioButton radioButtonState;
        private ComponentFactory.Krypton.Toolkit.KryptonButton goButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton closeButton;
    }
}