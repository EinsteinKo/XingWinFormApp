namespace XingWinFormApp
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btn_connect = new System.Windows.Forms.Button();
			this.btn_login = new System.Windows.Forms.Button();
			this.txt_log = new System.Windows.Forms.RichTextBox();
			this.FlexGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.txt_account_info = new System.Windows.Forms.RichTextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btn_T8430 = new Telerik.WinControls.UI.RadButton();
			this.btn_GridToDB = new Telerik.WinControls.UI.RadButton();
			this.btn_T1427 = new Telerik.WinControls.UI.RadButton();
			this.btn_T1422 = new Telerik.WinControls.UI.RadButton();
			((System.ComponentModel.ISupportInitialize)(this.FlexGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_T8430)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_GridToDB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_T1427)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_T1422)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_connect
			// 
			this.btn_connect.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_connect.Location = new System.Drawing.Point(12, 16);
			this.btn_connect.Name = "btn_connect";
			this.btn_connect.Size = new System.Drawing.Size(102, 47);
			this.btn_connect.TabIndex = 0;
			this.btn_connect.Text = "Connect";
			this.btn_connect.UseVisualStyleBackColor = true;
			this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
			// 
			// btn_login
			// 
			this.btn_login.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_login.Location = new System.Drawing.Point(12, 89);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(102, 47);
			this.btn_login.TabIndex = 1;
			this.btn_login.Text = "Log in";
			this.btn_login.UseVisualStyleBackColor = true;
			this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
			// 
			// txt_log
			// 
			this.txt_log.Location = new System.Drawing.Point(138, 555);
			this.txt_log.Name = "txt_log";
			this.txt_log.Size = new System.Drawing.Size(719, 309);
			this.txt_log.TabIndex = 2;
			this.txt_log.Text = "";
			// 
			// FlexGrid
			// 
			this.FlexGrid.ColumnInfo = resources.GetString("FlexGrid.ColumnInfo");
			this.FlexGrid.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.FlexGrid.Location = new System.Drawing.Point(138, 89);
			this.FlexGrid.Name = "FlexGrid";
			this.FlexGrid.Rows.Count = 18;
			this.FlexGrid.Rows.DefaultSize = 24;
			this.FlexGrid.Size = new System.Drawing.Size(1142, 430);
			this.FlexGrid.TabIndex = 3;
			// 
			// txt_account_info
			// 
			this.txt_account_info.Location = new System.Drawing.Point(863, 555);
			this.txt_account_info.Name = "txt_account_info";
			this.txt_account_info.Size = new System.Drawing.Size(417, 309);
			this.txt_account_info.TabIndex = 5;
			this.txt_account_info.Text = "";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(138, 526);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(1142, 23);
			this.progressBar1.Step = 1;
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 7;
			this.progressBar1.Value = 5;
			// 
			// btn_T8430
			// 
			this.btn_T8430.Location = new System.Drawing.Point(138, 16);
			this.btn_T8430.Name = "btn_T8430";
			this.btn_T8430.Size = new System.Drawing.Size(116, 58);
			this.btn_T8430.TabIndex = 10;
			this.btn_T8430.Text = "<html><span style=\"font-family: 나눔고딕\"><strong><span style=\"font-size: 10pt\">주식 종목" +
    " 조회</span></strong><br />(t8436)</span></html>";
			this.btn_T8430.Click += new System.EventHandler(this.btn_T8430_Click);
			// 
			// btn_GridToDB
			// 
			this.btn_GridToDB.Location = new System.Drawing.Point(1164, 41);
			this.btn_GridToDB.Name = "btn_GridToDB";
			this.btn_GridToDB.Size = new System.Drawing.Size(116, 48);
			this.btn_GridToDB.TabIndex = 11;
			this.btn_GridToDB.Text = "<html><span style=\"font-family: 나눔고딕\"><strong><span style=\"font-size: 10pt\">Grid " +
    "To DB</span></strong></span></html>";
			this.btn_GridToDB.Click += new System.EventHandler(this.btn_GridToDB_Click);
			// 
			// btn_T1427
			// 
			this.btn_T1427.Location = new System.Drawing.Point(288, 16);
			this.btn_T1427.Name = "btn_T1427";
			this.btn_T1427.Size = new System.Drawing.Size(116, 58);
			this.btn_T1427.TabIndex = 11;
			this.btn_T1427.Text = "<html><span style=\"font-family: 나눔고딕\"><strong><span style=\"font-size: 10pt\">상/하 한" +
    "가 직전</span></strong><br />(t1427)</span></html>";
			this.btn_T1427.Click += new System.EventHandler(this.btn_T1427_Click);
			// 
			// btn_T1422
			// 
			this.btn_T1422.Location = new System.Drawing.Point(410, 16);
			this.btn_T1422.Name = "btn_T1422";
			this.btn_T1422.Size = new System.Drawing.Size(116, 58);
			this.btn_T1422.TabIndex = 12;
			this.btn_T1422.Text = "<html><span style=\"font-family: 나눔고딕\"><strong><span style=\"font-size: 10pt\">상/하 한" +
    "가</span></strong><br />(t1422)</span></html>";
			this.btn_T1422.Click += new System.EventHandler(this.btn_T1422_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1292, 876);
			this.Controls.Add(this.btn_T1422);
			this.Controls.Add(this.btn_T1427);
			this.Controls.Add(this.btn_GridToDB);
			this.Controls.Add(this.btn_T8430);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.txt_account_info);
			this.Controls.Add(this.FlexGrid);
			this.Controls.Add(this.txt_log);
			this.Controls.Add(this.btn_login);
			this.Controls.Add(this.btn_connect);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.FlexGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_T8430)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_GridToDB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_T1427)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_T1422)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_connect;
		private System.Windows.Forms.Button btn_login;
		private System.Windows.Forms.RichTextBox txt_log;
		private C1.Win.C1FlexGrid.C1FlexGrid FlexGrid;
		private System.Windows.Forms.RichTextBox txt_account_info;
		private System.Windows.Forms.ProgressBar progressBar1;
		private Telerik.WinControls.UI.RadButton btn_T8430;
		private Telerik.WinControls.UI.RadButton btn_GridToDB;
		private Telerik.WinControls.UI.RadButton btn_T1427;
		private Telerik.WinControls.UI.RadButton btn_T1422;
	}
}

