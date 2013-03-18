namespace NoisyKeys {
	partial class NoisyForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.attackTimeBox = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.releaseTimeBox = new System.Windows.Forms.NumericUpDown();
			this.unmuteButton = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.attackTimeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.releaseTimeBox)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// attackTimeBox
			// 
			this.attackTimeBox.Location = new System.Drawing.Point(115, 12);
			this.attackTimeBox.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.attackTimeBox.Name = "attackTimeBox";
			this.attackTimeBox.Size = new System.Drawing.Size(120, 20);
			this.attackTimeBox.TabIndex = 0;
			this.attackTimeBox.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Attack time (ms)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Release time (ms)";
			// 
			// releaseTimeBox
			// 
			this.releaseTimeBox.Location = new System.Drawing.Point(115, 44);
			this.releaseTimeBox.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.releaseTimeBox.Name = "releaseTimeBox";
			this.releaseTimeBox.Size = new System.Drawing.Size(120, 20);
			this.releaseTimeBox.TabIndex = 2;
			this.releaseTimeBox.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
			// 
			// unmuteButton
			// 
			this.unmuteButton.Location = new System.Drawing.Point(15, 75);
			this.unmuteButton.Name = "unmuteButton";
			this.unmuteButton.Size = new System.Drawing.Size(220, 43);
			this.unmuteButton.TabIndex = 4;
			this.unmuteButton.Text = "Unmute";
			this.unmuteButton.UseVisualStyleBackColor = true;
			this.unmuteButton.Click += new System.EventHandler(this.UnmuteClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 136);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(249, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// NoisyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(249, 158);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.unmuteButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.releaseTimeBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.attackTimeBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NoisyForm";
			this.ShowIcon = false;
			this.Text = "noisy keys :(";
			((System.ComponentModel.ISupportInitialize)(this.attackTimeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.releaseTimeBox)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown attackTimeBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown releaseTimeBox;
		private System.Windows.Forms.Button unmuteButton;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;

	}
}

