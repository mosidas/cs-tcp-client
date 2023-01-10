
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
            this.label2 = new System.Windows.Forms.Label();
            this.text_responce = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_send.Location = new System.Drawing.Point(62, 323);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(108, 39);
            this.button_send.TabIndex = 99;
            this.button_send.Text = "send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_sync
            // 
            this.button_sync.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_sync.Location = new System.Drawing.Point(62, 26);
            this.button_sync.Name = "button_sync";
            this.button_sync.Size = new System.Drawing.Size(108, 39);
            this.button_sync.TabIndex = 97;
            this.button_sync.Text = "connect";
            this.button_sync.UseVisualStyleBackColor = true;
            this.button_sync.Click += new System.EventHandler(this.button_sync_Click);
            // 
            // button_close
            // 
            this.button_close.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_close.Location = new System.Drawing.Point(177, 26);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(145, 39);
            this.button_close.TabIndex = 98;
            this.button_close.Text = "disconnect";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // text_port
            // 
            this.text_port.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.text_port.Location = new System.Drawing.Point(527, 82);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(185, 30);
            this.text_port.TabIndex = 2;
            this.text_port.Text = "44333";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_port.Location = new System.Drawing.Point(430, 82);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(60, 23);
            this.label_port.TabIndex = 4;
            this.label_port.Text = "port: ";
            // 
            // text_message
            // 
            this.text_message.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_message.Location = new System.Drawing.Point(62, 135);
            this.text_message.Multiline = true;
            this.text_message.Name = "text_message";
            this.text_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_message.Size = new System.Drawing.Size(892, 173);
            this.text_message.TabIndex = 3;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_status.Location = new System.Drawing.Point(838, 26);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(34, 23);
            this.label_status.TabIndex = 6;
            this.label_status.Text = " □";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(402, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "ip address: ";
            // 
            // text_ip
            // 
            this.text_ip.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.text_ip.Location = new System.Drawing.Point(527, 31);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(179, 30);
            this.text_ip.TabIndex = 1;
            this.text_ip.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(59, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 100;
            this.label2.Text = "message";
            // 
            // text_responce
            // 
            this.text_responce.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_responce.Location = new System.Drawing.Point(62, 454);
            this.text_responce.Multiline = true;
            this.text_responce.Name = "text_responce";
            this.text_responce.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_responce.Size = new System.Drawing.Size(892, 173);
            this.text_responce.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(59, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 102;
            this.label3.Text = "responce";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 684);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_responce);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_ip);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.text_message);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.text_port);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_sync);
            this.Controls.Add(this.button_send);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_responce;
        private System.Windows.Forms.Label label3;
    }
}

