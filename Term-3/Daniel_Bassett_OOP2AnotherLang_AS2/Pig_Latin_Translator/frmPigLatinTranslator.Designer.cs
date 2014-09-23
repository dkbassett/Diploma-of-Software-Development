namespace Pig_Latin_Translator
{
    partial class frmPigLatinTranslator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPigLatinTranslator));
            this.lblEnglish = new System.Windows.Forms.Label();
            this.txtEnglish = new System.Windows.Forms.TextBox();
            this.lblPigLatin = new System.Windows.Forms.Label();
            this.txtPigLatin = new System.Windows.Forms.TextBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Location = new System.Drawing.Point(22, 26);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(116, 13);
            this.lblEnglish.TabIndex = 0;
            this.lblEnglish.Text = "Enter English text here:";
            // 
            // txtEnglish
            // 
            this.txtEnglish.Location = new System.Drawing.Point(22, 51);
            this.txtEnglish.Multiline = true;
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEnglish.Size = new System.Drawing.Size(334, 89);
            this.txtEnglish.TabIndex = 1;
            this.txtEnglish.Text = resources.GetString("txtEnglish.Text");
            this.txtEnglish.TextChanged += new System.EventHandler(this.txtEnglish_TextChanged);
            // 
            // lblPigLatin
            // 
            this.lblPigLatin.AutoSize = true;
            this.lblPigLatin.Location = new System.Drawing.Point(22, 169);
            this.lblPigLatin.Name = "lblPigLatin";
            this.lblPigLatin.Size = new System.Drawing.Size(102, 13);
            this.lblPigLatin.TabIndex = 2;
            this.lblPigLatin.Text = "Pig Latin translation:";
            // 
            // txtPigLatin
            // 
            this.txtPigLatin.Location = new System.Drawing.Point(22, 195);
            this.txtPigLatin.Multiline = true;
            this.txtPigLatin.Name = "txtPigLatin";
            this.txtPigLatin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPigLatin.Size = new System.Drawing.Size(334, 89);
            this.txtPigLatin.TabIndex = 3;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(22, 303);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(75, 23);
            this.btnTranslate.TabIndex = 4;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(123, 302);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(281, 302);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmPigLatinTranslator
            // 
            this.AcceptButton = this.btnTranslate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(380, 347);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.txtPigLatin);
            this.Controls.Add(this.lblPigLatin);
            this.Controls.Add(this.txtEnglish);
            this.Controls.Add(this.lblEnglish);
            this.Name = "frmPigLatinTranslator";
            this.Text = "Pig Latin Translator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.TextBox txtEnglish;
        private System.Windows.Forms.Label lblPigLatin;
        private System.Windows.Forms.TextBox txtPigLatin;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
    }
}

