
namespace tcp_client
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_send = new System.Windows.Forms.Button();
            this.button_sync = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.text_port = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.text_message = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_ip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(37, 191);
            this.button_send.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(65, 26);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_sync
            // 
            this.button_sync.Location = new System.Drawing.Point(37, 17);
            this.button_sync.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_sync.Name = "button_sync";
            this.button_sync.Size = new System.Drawing.Size(65, 26);
            this.button_sync.TabIndex = 1;
            this.button_sync.Text = "connect";
            this.button_sync.UseVisualStyleBackColor = true;
            this.button_sync.Click += new System.EventHandler(this.button_sync_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(106, 17);
            this.button_close.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(87, 26);
            this.button_close.TabIndex = 2;
            this.button_close.Text = "disconnect";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(309, 55);
            this.text_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(97, 19);
            this.text_port.TabIndex = 3;
            this.text_port.Text = "11111";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(258, 55);
            this.label_port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(31, 12);
            this.label_port.TabIndex = 4;
            this.label_port.Text = "port: ";
            // 
            // text_message
            // 
            this.text_message.Location = new System.Drawing.Point(37, 90);
            this.text_message.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_message.Multiline = true;
            this.text_message.Name = "text_message";
            this.text_message.Size = new System.Drawing.Size(537, 99);
            this.text_message.TabIndex = 5;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_status.Location = new System.Drawing.Point(503, 17);
            this.label_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(57, 33);
            this.label_status.TabIndex = 6;
            this.label_status.Text = " □";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "ip address: ";
            // 
            // text_ip
            // 
            this.text_ip.Location = new System.Drawing.Point(309, 21);
            this.text_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(97, 19);
            this.text_ip.TabIndex = 7;
            this.text_ip.Text = "127.0.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_ip);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.text_message);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.text_port);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_sync);
            this.Controls.Add(this.button_send);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "tcp client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_sync;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox text_message;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_ip;
    }
}

