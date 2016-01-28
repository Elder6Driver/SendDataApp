namespace SendDataApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnComRefresh = new System.Windows.Forms.Button();
            this.cbxCom = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pbxConnect = new System.Windows.Forms.PictureBox();
            this.lbxData = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFinish = new System.Windows.Forms.Button();
            this.tbtime = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbtime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnComRefresh
            // 
            this.btnComRefresh.Location = new System.Drawing.Point(32, 25);
            this.btnComRefresh.Name = "btnComRefresh";
            this.btnComRefresh.Size = new System.Drawing.Size(85, 23);
            this.btnComRefresh.TabIndex = 0;
            this.btnComRefresh.Text = "COM刷新";
            this.btnComRefresh.UseVisualStyleBackColor = true;
            this.btnComRefresh.Click += new System.EventHandler(this.btnComRefresh_Click);
            // 
            // cbxCom
            // 
            this.cbxCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCom.FormattingEnabled = true;
            this.cbxCom.Location = new System.Drawing.Point(121, 27);
            this.cbxCom.Name = "cbxCom";
            this.cbxCom.Size = new System.Drawing.Size(121, 20);
            this.cbxCom.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(261, 24);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(83, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Arduino连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(681, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbxConnect
            // 
            this.pbxConnect.BackColor = System.Drawing.Color.Red;
            this.pbxConnect.Location = new System.Drawing.Point(348, 24);
            this.pbxConnect.Name = "pbxConnect";
            this.pbxConnect.Size = new System.Drawing.Size(108, 24);
            this.pbxConnect.TabIndex = 5;
            this.pbxConnect.TabStop = false;
            // 
            // lbxData
            // 
            this.lbxData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbxData.FormattingEnabled = true;
            this.lbxData.HorizontalScrollbar = true;
            this.lbxData.ItemHeight = 16;
            this.lbxData.Location = new System.Drawing.Point(32, 77);
            this.lbxData.Name = "lbxData";
            this.lbxData.Size = new System.Drawing.Size(816, 484);
            this.lbxData.TabIndex = 6;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(773, 24);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "结束";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // tbtime
            // 
            this.tbtime.Location = new System.Drawing.Point(549, 24);
            this.tbtime.Minimum = 1;
            this.tbtime.Name = "tbtime";
            this.tbtime.Size = new System.Drawing.Size(104, 45);
            this.tbtime.TabIndex = 8;
            this.tbtime.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "时间间隔";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 595);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbtime);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lbxData);
            this.Controls.Add(this.pbxConnect);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbxCom);
            this.Controls.Add(this.btnComRefresh);
            this.Name = "Form1";
            this.Text = "SendDataApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbtime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComRefresh;
        private System.Windows.Forms.ComboBox cbxCom;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pbxConnect;
        private System.Windows.Forms.ListBox lbxData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TrackBar tbtime;
        private System.Windows.Forms.Label label1;
    }
}

