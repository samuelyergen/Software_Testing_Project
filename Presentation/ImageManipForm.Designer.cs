
namespace Presentation
{
    partial class ImageManipForm
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
            this.image_pictureBox = new System.Windows.Forms.PictureBox();
            this.bwFilter_button = new System.Windows.Forms.Button();
            this.swap_filter_button = new System.Windows.Forms.Button();
            this.hell_filter_button = new System.Windows.Forms.Button();
            this.load_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.save_textbox = new System.Windows.Forms.TextBox();
            this.algo_listbox = new System.Windows.Forms.ListBox();
            this.apply_edge_button = new System.Windows.Forms.Button();
            this.reset_button = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // image_pictureBox
            // 
            this.image_pictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.image_pictureBox.Location = new System.Drawing.Point(32, 24);
            this.image_pictureBox.Name = "image_pictureBox";
            this.image_pictureBox.Size = new System.Drawing.Size(406, 529);
            this.image_pictureBox.TabIndex = 0;
            this.image_pictureBox.TabStop = false;
            // 
            // bwFilter_button
            // 
            this.bwFilter_button.Location = new System.Drawing.Point(472, 24);
            this.bwFilter_button.Name = "bwFilter_button";
            this.bwFilter_button.Size = new System.Drawing.Size(134, 61);
            this.bwFilter_button.TabIndex = 1;
            this.bwFilter_button.Text = "Black and white filter";
            this.bwFilter_button.UseVisualStyleBackColor = true;
            this.bwFilter_button.Click += new System.EventHandler(this.BwFilter_button_Click);
            // 
            // swap_filter_button
            // 
            this.swap_filter_button.Location = new System.Drawing.Point(630, 24);
            this.swap_filter_button.Name = "swap_filter_button";
            this.swap_filter_button.Size = new System.Drawing.Size(158, 61);
            this.swap_filter_button.TabIndex = 2;
            this.swap_filter_button.Text = "Swap filter";
            this.swap_filter_button.UseVisualStyleBackColor = true;
            this.swap_filter_button.Click += new System.EventHandler(this.Swap_filter_button_Click);
            // 
            // hell_filter_button
            // 
            this.hell_filter_button.Location = new System.Drawing.Point(821, 26);
            this.hell_filter_button.Name = "hell_filter_button";
            this.hell_filter_button.Size = new System.Drawing.Size(176, 59);
            this.hell_filter_button.TabIndex = 3;
            this.hell_filter_button.Text = "Hell filter";
            this.hell_filter_button.UseVisualStyleBackColor = true;
            this.hell_filter_button.Click += new System.EventHandler(this.Hell_filter_button_Click);
            // 
            // load_button
            // 
            this.load_button.Location = new System.Drawing.Point(32, 559);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(406, 44);
            this.load_button.TabIndex = 4;
            this.load_button.Text = "Load image";
            this.load_button.UseVisualStyleBackColor = true;
            this.load_button.Click += new System.EventHandler(this.Load_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(610, 432);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(137, 33);
            this.save_button.TabIndex = 5;
            this.save_button.Text = "Save image";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // save_textbox
            // 
            this.save_textbox.Location = new System.Drawing.Point(760, 432);
            this.save_textbox.Name = "save_textbox";
            this.save_textbox.Size = new System.Drawing.Size(237, 23);
            this.save_textbox.TabIndex = 6;
            // 
            // algo_listbox
            // 
            this.algo_listbox.FormattingEnabled = true;
            this.algo_listbox.ItemHeight = 15;
            this.algo_listbox.Items.AddRange(new object[] {
            "Laplacian3x3",
            "Laplacian5x5",
            "Gaussian3x3"});
            this.algo_listbox.Location = new System.Drawing.Point(658, 150);
            this.algo_listbox.Name = "algo_listbox";
            this.algo_listbox.Size = new System.Drawing.Size(169, 49);
            this.algo_listbox.TabIndex = 7;
            // 
            // apply_edge_button
            // 
            this.apply_edge_button.Location = new System.Drawing.Point(670, 210);
            this.apply_edge_button.Name = "apply_edge_button";
            this.apply_edge_button.Size = new System.Drawing.Size(147, 57);
            this.apply_edge_button.TabIndex = 8;
            this.apply_edge_button.Text = "Apply edge detection";
            this.apply_edge_button.UseVisualStyleBackColor = true;
            this.apply_edge_button.Click += new System.EventHandler(this.Apply_edge_button_Click);
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(696, 329);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(104, 46);
            this.reset_button.TabIndex = 9;
            this.reset_button.Text = "Reset";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.Reset_button_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInfo.Location = new System.Drawing.Point(650, 522);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 25);
            this.labelInfo.TabIndex = 10;
            // 
            // ImageManipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 654);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.apply_edge_button);
            this.Controls.Add(this.algo_listbox);
            this.Controls.Add(this.save_textbox);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.load_button);
            this.Controls.Add(this.hell_filter_button);
            this.Controls.Add(this.swap_filter_button);
            this.Controls.Add(this.bwFilter_button);
            this.Controls.Add(this.image_pictureBox);
            this.Name = "ImageManipForm";
            this.Text = "ImageManipForm";
            ((System.ComponentModel.ISupportInitialize)(this.image_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image_pictureBox;
        private System.Windows.Forms.Button bwFilter_button;
        private System.Windows.Forms.Button swap_filter_button;
        private System.Windows.Forms.Button hell_filter_button;
        private System.Windows.Forms.Button load_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TextBox save_textbox;
        private System.Windows.Forms.ListBox algo_listbox;
        private System.Windows.Forms.Button apply_edge_button;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Label labelInfo;
    }
}