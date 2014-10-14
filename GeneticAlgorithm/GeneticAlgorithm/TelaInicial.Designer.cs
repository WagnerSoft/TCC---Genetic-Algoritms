namespace GeneticAlgorithm
{
    partial class TelaInicial
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
            this.label1 = new System.Windows.Forms.Label();
            this.QuantidadeIndividuos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TaxaCruzamento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TaxaMutacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ListaMelhorIndividuo = new System.Windows.Forms.ListBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.GenerationNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quantidade de individuos: ";
            // 
            // QuantidadeIndividuos
            // 
            this.QuantidadeIndividuos.Location = new System.Drawing.Point(143, 5);
            this.QuantidadeIndividuos.Name = "QuantidadeIndividuos";
            this.QuantidadeIndividuos.Size = new System.Drawing.Size(100, 20);
            this.QuantidadeIndividuos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Taxa de Cruzamento:";
            // 
            // TaxaCruzamento
            // 
            this.TaxaCruzamento.Location = new System.Drawing.Point(143, 31);
            this.TaxaCruzamento.Name = "TaxaCruzamento";
            this.TaxaCruzamento.Size = new System.Drawing.Size(28, 20);
            this.TaxaCruzamento.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 8;
            // 
            // TaxaMutacao
            // 
            this.TaxaMutacao.Location = new System.Drawing.Point(143, 57);
            this.TaxaMutacao.Name = "TaxaMutacao";
            this.TaxaMutacao.Size = new System.Drawing.Size(28, 20);
            this.TaxaMutacao.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Taxa de Mutação:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "%";
            // 
            // ListaMelhorIndividuo
            // 
            this.ListaMelhorIndividuo.FormattingEnabled = true;
            this.ListaMelhorIndividuo.Location = new System.Drawing.Point(249, 5);
            this.ListaMelhorIndividuo.Name = "ListaMelhorIndividuo";
            this.ListaMelhorIndividuo.Size = new System.Drawing.Size(530, 108);
            this.ListaMelhorIndividuo.TabIndex = 12;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(16, 89);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(227, 23);
            this.StartButton.TabIndex = 13;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // GenerationNumber
            // 
            this.GenerationNumber.AutoSize = true;
            this.GenerationNumber.Location = new System.Drawing.Point(746, 123);
            this.GenerationNumber.Name = "GenerationNumber";
            this.GenerationNumber.Size = new System.Drawing.Size(13, 13);
            this.GenerationNumber.TabIndex = 14;
            this.GenerationNumber.Text = "0";
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 162);
            this.Controls.Add(this.GenerationNumber);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ListaMelhorIndividuo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TaxaMutacao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TaxaCruzamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuantidadeIndividuos);
            this.Controls.Add(this.label1);
            this.Name = "TelaInicial";
            this.Text = "Genetic Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TaxaCruzamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TaxaMutacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button StartButton;
        public System.Windows.Forms.TextBox QuantidadeIndividuos;
        public System.Windows.Forms.ListBox ListaMelhorIndividuo;
        private System.Windows.Forms.Label GenerationNumber;

    }
}

