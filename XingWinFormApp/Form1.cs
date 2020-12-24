using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Xing Com 명시 
using XA_SESSIONLib;
using XA_DATASETLib;

using System.Threading;


namespace XingWinFormApp
{
	public partial class Form1 : Form
	{
		// Xing 객체 선언
		XASessionClass myXASessionClass = new XASessionClass();
		XAQueryClass myXAQueryClass = new XAQueryClass();
		string XingResPath = "C:\\eBEST\\xingAPI\\Res\\";

		private BackgroundWorker trWorker;
		bool bTrRunIng = false;

		public Form1()
		{
			InitializeComponent();
			LogWrite("---------------------- Xing Start ----------------------");

			XingObjectInit();

		}


		// Xing 객체 생성 및 초기화 
		private void XingObjectInit()
		{
			myXASessionClass._IXASessionEvents_Event_Login += new _IXASessionEvents_LoginEventHandler(myXASessionClass__Event_Login);
			myXASessionClass.Disconnect += myXASessionClass__Event_Disconnect;
			

			myXAQueryClass.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_ReceiveData);
			myXAQueryClass.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_ReceiveMessage);


		}

		private void btn_connect_Click(object sender, EventArgs e)
		{
			string SVR_Domain = "hts.etrade.co.kr"; //  "demo.etrade.co.kr";
			if( myXASessionClass.ConnectServer("", 20001))
			{
				LogWrite(">"+SVR_Domain+" Connect success");
			}
			else
			{
				
				LogWrite(">" + SVR_Domain + " Connect failed");
				LogWrite(">" + myXASessionClass.GetErrorMessage(myXASessionClass.GetLastError()));
			}

		}

		void myXASessionClass__Event_Login(string szCode, string szMsg)
		{
			if (szCode == "0000")
			{
				LogWrite(">Login OK");
				LogWrite(">My Account list begin......");

				int AccountMyList = myXASessionClass.GetAccountListCount();
				
				txt_account_info.AppendText("Einstin 계좌 정보:"+Environment.NewLine);
				for (int i = 0; i < AccountMyList; i++)
				{
					txt_account_info.AppendText("계좌 번호:" + myXASessionClass.GetAccountList(i)	+Environment.NewLine);
				}
				LogWrite(">My Account list end......");

			}
			else
			{
				LogWrite(">Login Failed....");
				LogWrite(">Result code:["+szCode+"] Msg:["+szMsg+"]");
			}
		}

		private void myXASessionClass__Event_Disconnect()
		{
			LogWrite("----------------- myXASessionClass__Event_Disconnect -----------------");
		}

		void myXAQueryClass_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
		{
			if (bIsSystemError)
			{
				MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
			}
		}

		string CurTrCode = "";
		void myXAQueryClass_ReceiveData(string szTrCode)
		{
			CurTrCode = szTrCode;
			LogWrite(">>> [" + szTrCode + "] Data receive begin.........!");

			switch (CurTrCode)
			{
				case "t8430":
					TRreceive_t8430();
					break;

				case "t8436":
					TRreceive_t8436();
					break;

				case "t1427":
					TRreceive_t1427();
					break;

				case "t1422":
					TRreceive_t1422();
					break;

				case "t1234":
					break;
			}

			LogWrite(">>> ["+szTrCode+"] Data receive end.........!");
			//if(CurTrCode=="t1427")
			//	Thread.Sleep(1000);
		}


		private void Grid_HeaderInit()
		{
			switch (CurTrCode)
			{
				case "t8346":
					FlexGrid[0, 1] = "종목명"; FlexGrid[0, 2] = "종코코드"; FlexGrid[0, 3] = "상한가"; FlexGrid[0, 4] = "하한가"; FlexGrid[0, 5] = "전일종가";
					FlexGrid[0, 6] = "주문단위 수량"; FlexGrid[0, 7] = "기준가"; FlexGrid[0, 8] = "구분"; FlexGrid[0, 9] = "증권그룹";
					break;

				case "t1427": // 상하한가 직전
					FlexGrid[0, 1] = "종목명"; FlexGrid[0, 2] = "종코코드"; FlexGrid[0, 3] = "현재가"; FlexGrid[0, 4] = "전일대비구분"; FlexGrid[0, 5] = "전일대비";
					FlexGrid[0, 6] = "등락율"; FlexGrid[0, 7] = "누적거래량"; FlexGrid[0, 8] = "거래증가율"; FlexGrid[0, 9] = "상/하한가"; FlexGrid[0, 10] = "대비율";
					//FlexGrid[0, 11] = "전일거래량"; FlexGrid[0, 12] = "시가"; FlexGrid[0, 13] = "고가"; FlexGrid[0, 14] = "저가"; FlexGrid[0, 15] = "연속"; FlexGrid[0, 16] = "거래대금";
					break;

				case "t1422": // 상하한가
					FlexGrid[0, 1] = "종목명"; FlexGrid[0, 2] = "종코코드"; FlexGrid[0, 3] = "현재가"; FlexGrid[0, 4] = "전일대비구분"; FlexGrid[0, 5] = "전일대비";
					FlexGrid[0, 6] = "등락율"; FlexGrid[0, 7] = "누적거래량"; FlexGrid[0, 8] = "거래증가율"; FlexGrid[0, 9] = "매도잔량"; FlexGrid[0, 10] = "매수잔량";
					FlexGrid[0, 11] = "최종진입"; FlexGrid[0, 12] = "연속";
					break;

				case "": // 상하한가 직전
					break;
			}

		}

		private void TRreceive_t8430()
		{

		}


		private void TRreceive_t8436()
		{
			//string hname = myXAQueryClass.GetBlockData("t8430OutBlock");
			int count = myXAQueryClass.GetBlockCount("t8436OutBlock");
			//object[] objs = new object[count+1];
			Grid_HeaderInit();
			FlexGrid.Rows.Count = count+1;
			for (int ii = 0; ii <count; ii++)
			{ 
				FlexGrid[ii+1, 0] = (ii+1).ToString();
				FlexGrid[ii+1, 1] = myXAQueryClass.GetFieldData("t8436OutBlock", "hname", ii);// 종목명
				FlexGrid[ii+1, 2] = myXAQueryClass.GetFieldData("t8436OutBlock", "shcode", ii);// 종목코드
				FlexGrid[ii+1, 3] = myXAQueryClass.GetFieldData("t8436OutBlock", "uplmtprice", ii);// 상한가
				FlexGrid[ii+1, 4] = myXAQueryClass.GetFieldData("t8436OutBlock", "dnlmtprice", ii);// 하한가
				FlexGrid[ii+1, 5] = myXAQueryClass.GetFieldData("t8436OutBlock", "jnilclose", ii);// 전일종가
				FlexGrid[ii+1, 6] = myXAQueryClass.GetFieldData("t8436OutBlock", "memedan", ii);// 주문단위 수량 
				FlexGrid[ii+1, 7] = myXAQueryClass.GetFieldData("t8436OutBlock", "recprice", ii);//기준가		
				FlexGrid[ii+1, 8] = myXAQueryClass.GetFieldData("t8436OutBlock", "gubun", ii);//구분

				if (CurTrCode.Equals("t8436"))
					FlexGrid[ii + 1, 9] = myXAQueryClass.GetFieldData("t8436OutBlock", "bu12gubun", ii); // 증권그룹 


				//FlexGrid.AddItem(objs, ii+1, 0);//  .AddItem(objs,ii+1, 0);
				//FlexGrid[ii+1, 0] = objs;
			}			

		}

		int receiveRow = 0;
		private void TRreceive_t1427()
		{
			//string hname = myXAQueryClass.GetBlockData("t8430OutBlock");
			int count = int.Parse(myXAQueryClass.GetFieldData("t1427OutBlock", "cnt", 0).ToString());
			//object[] objs = new object[count+1];
			Grid_HeaderInit();
			FlexGrid.Rows.Count = receiveRow+ count + 1; // receiveRow 상/하한 연속 콜을 위해서.......
			for (int ii = receiveRow; ii < count+ receiveRow; ii++)
			{
				FlexGrid[ii+ 1, 0] = (ii +1).ToString();
				FlexGrid[ii +1, 1] = myXAQueryClass.GetFieldData("t1427OutBlock1", "hname", ii- receiveRow);// 종목명
				FlexGrid[ii +1, 2] = myXAQueryClass.GetFieldData("t1427OutBlock1", "shcode", ii - receiveRow);// 종목코드
				FlexGrid[ii +1, 3] = myXAQueryClass.GetFieldData("t1427OutBlock1", "price", ii - receiveRow);// 상한가
				FlexGrid[ii +1, 4] = myXAQueryClass.GetFieldData("t1427OutBlock1", "sign", ii - receiveRow);// 하한가
				FlexGrid[ii +1, 5] = myXAQueryClass.GetFieldData("t1427OutBlock1", "change", ii - receiveRow);// 전일종가
				FlexGrid[ii +1, 6] = myXAQueryClass.GetFieldData("t1427OutBlock1", "diff", ii - receiveRow);// 주문단위 수량 
				FlexGrid[ii +1, 7] = myXAQueryClass.GetFieldData("t1427OutBlock1", "volume", ii - receiveRow);//기준가		
				FlexGrid[ii +1, 8] = myXAQueryClass.GetFieldData("t1427OutBlock1", "diff_vol", ii - receiveRow);//구분
				FlexGrid[ii +1, 9] = myXAQueryClass.GetFieldData("t1427OutBlock1", "lmtprice", ii - receiveRow);//구분
				FlexGrid[ii +1, 10] = myXAQueryClass.GetFieldData("t1427OutBlock1", "rate", ii - receiveRow);//구분

				
				// API에서 지원 안하는듯......
				//FlexGrid[ii + 1, 11] = myXAQueryClass.GetFieldData("t8436OutBlock", "jnilvolume", ii); // 증권그룹 
				//FlexGrid[ii + 1, 12] = myXAQueryClass.GetFieldData("t8436OutBlock", "_open", ii); // 증권그룹 
				//FlexGrid[ii + 1, 13] = myXAQueryClass.GetFieldData("t8436OutBlock", "high", ii); // 증권그룹 
				//FlexGrid[ii + 1, 14] = myXAQueryClass.GetFieldData("t8436OutBlock", "low", ii); // 증권그룹 
				//FlexGrid[ii + 1, 15] = myXAQueryClass.GetFieldData("t8436OutBlock", "연속", ii); // 증권그룹 
				//FlexGrid[ii + 1, 16] = myXAQueryClass.GetFieldData("t8436OutBlock", "거래대금", ii); // 증권그룹 


				//FlexGrid.AddItem(objs, ii+1, 0);//  .AddItem(objs,ii+1, 0);
				//FlexGrid[ii+1, 0] = objs;
			}
			receiveRow = count;
		}

		private void TRreceive_t1422()
		{
			//string hname = myXAQueryClass.GetBlockData("t8430OutBlock");
			int count = int.Parse(myXAQueryClass.GetFieldData("t1422OutBlock", "cnt", 0).ToString());
			//object[] objs = new object[count+1];
			Grid_HeaderInit();
			FlexGrid.Rows.Count = receiveRow + count + 1; // receiveRow 상/하한 연속 콜을 위해서.......
			for (int ii = receiveRow; ii < count + receiveRow; ii++)
			{
				FlexGrid[ii + 1, 0] = (ii + 1).ToString();
				FlexGrid[ii + 1, 1] = myXAQueryClass.GetFieldData("t1422OutBlock1", "hname", ii - receiveRow);// 종목명
				FlexGrid[ii + 1, 2] = myXAQueryClass.GetFieldData("t1422OutBlock1", "shcode", ii - receiveRow);// 종목코드
				FlexGrid[ii + 1, 3] = myXAQueryClass.GetFieldData("t1422OutBlock1", "price", ii - receiveRow);// 현재가
				FlexGrid[ii + 1, 4] = myXAQueryClass.GetFieldData("t1422OutBlock1", "sign", ii - receiveRow);// 전일대비 구분
				FlexGrid[ii + 1, 5] = myXAQueryClass.GetFieldData("t1422OutBlock1", "change", ii - receiveRow);// 전일대비
				FlexGrid[ii + 1, 6] = myXAQueryClass.GetFieldData("t1422OutBlock1", "diff", ii - receiveRow);// 등락율 
				FlexGrid[ii + 1, 7] = myXAQueryClass.GetFieldData("t1422OutBlock1", "volume", ii - receiveRow);//누적거래량
				FlexGrid[ii + 1, 8] = myXAQueryClass.GetFieldData("t1422OutBlock1", "diff_vol", ii - receiveRow);//거래증가율
				FlexGrid[ii + 1, 9] = myXAQueryClass.GetFieldData("t1422OutBlock1", "offerrem1", ii - receiveRow);//매도잔량
				FlexGrid[ii + 1, 10] = myXAQueryClass.GetFieldData("t1422OutBlock1", "bidrem1", ii - receiveRow);//배수잔량

				FlexGrid[ii + 1, 11] = myXAQueryClass.GetFieldData("t1422OutBlock1", "last", ii - receiveRow);//진입
				FlexGrid[ii + 1, 12] = myXAQueryClass.GetFieldData("t1422OutBlock1", "lmtdaycnt", ii - receiveRow);//연속

			}
			receiveRow = count;
		}


		private delegate void SafeCallDelegate(string log);
		private void LogWrite(string log)
		{			
			//txt_log.AppendText(log + Environment.NewLine);

			if (txt_log.InvokeRequired)
			{
				var d = new SafeCallDelegate(LogWrite);
				txt_log.Invoke(d, new object[] { log });
			}
			else
			{
				txt_log.AppendText("["+DateTime.Now.ToShortDateString()+" "+DateTime.Now.ToLongTimeString() +"] \t"+ log + Environment.NewLine);
			}
		}

		private void btn_login_Click(object sender, EventArgs e)
		{

			if (myXASessionClass.Login(Properties.Resources.Xing_id, Properties.Resources.Xing_pw, Properties.Resources.Xing_cert_pw, 0, false))
			{
				LogWrite("Login Begin....."); 
			}
			else
			{
				LogWrite("Login Begin Failed.....");
			}
		}

		private void btn_T8430_Click(object sender, EventArgs e)
		{
			FlexGrid.Clear();
			myXAQueryClass.ResFileName = XingResPath + "t8436.res";
			myXAQueryClass.SetFieldData("t8436InBlock", "gubun", 0, "0"); //0: 전체 , 1:코스피  2:코스닥
			myXAQueryClass.Request(false);
		}

		private void btn_T1427_Click(object sender, EventArgs e)
		{
			FlexGrid.Clear();
			receiveRow = 0; // 상/하 한가 연속 콜을 위해서.....

			// 상한 리스트 리퀘스트 
			myXAQueryClass.ResFileName = XingResPath + "t1427.res";
			myXAQueryClass.SetFieldData("t1427InBlock", "qrygb", 0, "0"); //0: 전체  1: 20종목씩 조회 
			myXAQueryClass.SetFieldData("t1427InBlock", "gubun", 0, "0"); //0: 전체 , 1:코스피  2:코스닥
			myXAQueryClass.SetFieldData("t1427InBlock", "signgubun", 0, "1"); //1 :상한직전  2: 하한직전

			myXAQueryClass.Request(false);

			Thread.Sleep(2000);

			// 하한 리스트 리퀘스트
			myXAQueryClass.ResFileName = XingResPath + "t1427.res";
			myXAQueryClass.SetFieldData("t1427InBlock", "qrygb", 0, "0"); //0: 전체  1: 20종목씩 조회 
			myXAQueryClass.SetFieldData("t1427InBlock", "gubun", 0, "0"); //0: 전체 , 1:코스피  2:코스닥
			myXAQueryClass.SetFieldData("t1427InBlock", "signgubun", 0, "2"); //1 :상한직전  2: 하한직전

			myXAQueryClass.Request(false);

		}


		private void btn_T1422_Click(object sender, EventArgs e)
		{
			FlexGrid.Clear();
			receiveRow = 0; // 상/하 한가 연속 콜을 위해서.....

			// 상한 리스트 리퀘스트 
			myXAQueryClass.ResFileName = XingResPath + "t1422.res";
			myXAQueryClass.SetFieldData("t1422InBlock", "qrygb", 0, "0"); //0: 전체  1: 20종목씩 조회 
			myXAQueryClass.SetFieldData("t1422InBlock", "gubun", 0, "0"); //0: 전체 , 1:코스피  2:코스닥
			myXAQueryClass.SetFieldData("t1422InBlock", "jnilgubun", 0, "0"); //0 : 댱일, 1:전일 
			myXAQueryClass.SetFieldData("t1422InBlock", "sign", 0, "1"); //1 :상한  4: 하한


			myXAQueryClass.Request(false);

			Thread.Sleep(2000);

			// 하한 리스트 리퀘스트
			myXAQueryClass.ResFileName = XingResPath + "t1422.res";
			myXAQueryClass.SetFieldData("t1422InBlock", "qrygb", 0, "0"); //0: 전체  1: 20종목씩 조회 
			myXAQueryClass.SetFieldData("t1422InBlock", "gubun", 0, "0"); //0: 전체 , 1:코스피  2:코스닥
			myXAQueryClass.SetFieldData("t1422InBlock", "jnilgubun", 0, "0"); //0 : 댱일, 1:전일 
			myXAQueryClass.SetFieldData("t1422InBlock", "sign", 0, "4"); //1 :상한  4: 하한
			myXAQueryClass.Request(false);

		}


		private void btn_GridToDB_Click(object sender, EventArgs e)
		{

			if(MessageBox.Show("["+CurTrCode.ToUpper()+"]의 조회 결과를 DB화 하시겠습니까?","Database",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1, 0 ,false)==DialogResult.Yes)
			{
				// 쓰레드 
				bTrRunIng = true;
				trWorker = new BackgroundWorker();
				trWorker.WorkerSupportsCancellation = true;

				trWorker.WorkerReportsProgress = true;
				trWorker.ProgressChanged += new ProgressChangedEventHandler(trWorkerProgressChanged);
				trWorker.DoWork += new DoWorkEventHandler(trWorkerDoWork);
				trWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(trWorkerCompleted);

				trWorker.RunWorkerAsync();
			}
		}


		int loop = 0;
		int totalcount = 0;
		int insertCnt = 0, updateCnt = 0;
		void trWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			// 디비 저장 
			loop = 0;
			totalcount = FlexGrid.Rows.Count - 1;

			//trCode = CurTrCode;// e.Argument as string;
			LogWrite("[" + CurTrCode + "] DB Transaction begin");

			insertCnt = 0; updateCnt = 0;
			switch (CurTrCode)
			{
				case "t8346":
					tr8436DBFunction();
					break;

				case "t1427":
					tr1427DBFunction();
					break;

				case "t1422":
					tr1422DBFunction();
					break;


					//case "t1422":
					//	tr8436Function();
					//	break;

					//case "":
					//	tr8436Function();
					//	break;
			}

		}

		// 8436 결과 디비 인서트 
		void tr8436DBFunction()
		{
			SystemTradingEntities db = new SystemTradingEntities();
			string today = DateTime.Today.ToShortDateString();
			do
			{

				TR8436 t8436 = new TR8436
				{
					regdate = today,
					hname = FlexGrid[loop + 1, 1].ToString(),
					shcode = FlexGrid[loop + 1, 2].ToString(),
					jnilclose = int.Parse(FlexGrid[loop + 1, 5].ToString()),
					recprice = int.Parse(FlexGrid[loop + 1, 7].ToString()),
					gubun = FlexGrid[loop + 1, 8].ToString(),
					bu12gubun = FlexGrid[loop + 1, 9].ToString()
				};

				if (db.TR8436.Any(x => x.regdate == today && x.shcode == t8436.shcode))
				{
					// 중복 케이스 
					//LogWrite("item duplicate.......[" + t8436.shcode + "][" + t8436.hname + "]");
					updateCnt++;
					// udpate code 
				}
				else
				{
					insertCnt++;
					db.TR8436.Add(t8436);
				}

				++loop;
				trWorker.ReportProgress(loop / totalcount * 90);

			}
			while (totalcount > loop);

			if (insertCnt > 0)
			{
				//progressBar1.Value = loop / totalcount * 100;
				db.SaveChanges();
			}
			trWorker.ReportProgress(loop / totalcount *100);

		}

		//
		// 1427 결과 디비 인서트 
		void tr1427DBFunction()
		{
			SystemTradingEntities db = new SystemTradingEntities();
			string today = DateTime.Today.ToShortDateString();
			do
			{

				TR1427 t1427 = new TR1427
				{
					regdate = today,
					hname = FlexGrid[loop + 1, 1].ToString(),
					shcode = FlexGrid[loop + 1, 2].ToString(),
					price = int.Parse(FlexGrid[loop + 1, 3].ToString()),
					sign = FlexGrid[loop + 1, 4].ToString(),
					change =int.Parse(FlexGrid[loop + 1, 5].ToString()),
					diff= float.Parse(FlexGrid[loop + 1, 6].ToString()),
					volume= int.Parse(FlexGrid[loop + 1, 7].ToString()),
					diff_vol = float.Parse(FlexGrid[loop + 1, 8].ToString()),
					lmtprice= int.Parse(FlexGrid[loop + 1, 9].ToString()),
					rate= float.Parse(FlexGrid[loop + 1, 8].ToString())
				};

				if (db.TR1427.Any(x => x.regdate == today && x.shcode == t1427.shcode))
				{
					// 중복 케이스 
					//LogWrite("item duplicate.......[" + t8436.shcode + "][" + t8436.hname + "]");
					updateCnt++;
					// udpate code 
				}
				else
				{
					insertCnt++;
					db.TR1427.Add(t1427);
				}

				++loop;
				trWorker.ReportProgress(loop / totalcount * 90);

			}
			while (totalcount > loop);

			if (insertCnt > 0)
			{
				//progressBar1.Value = loop / totalcount * 100;
				db.SaveChanges();
			}
			trWorker.ReportProgress(loop / totalcount * 100);

		}

		//
		// 1427 결과 디비 인서트 
		void tr1422DBFunction()
		{
			SystemTradingEntities db = new SystemTradingEntities();
			string today = DateTime.Today.ToShortDateString();
			do
			{
				TR1422 t1422 = new TR1422
				{
					regdate = today,
					hname = FlexGrid[loop + 1, 1].ToString(),
					shcode = FlexGrid[loop + 1, 2].ToString(),
					price = int.Parse(FlexGrid[loop + 1, 3].ToString()),
					sign = FlexGrid[loop + 1, 4].ToString(),
					change = int.Parse(FlexGrid[loop + 1, 5].ToString()),
					diff = float.Parse(FlexGrid[loop + 1, 6].ToString()),
					volume = int.Parse(FlexGrid[loop + 1, 7].ToString()),
					diff_vol = float.Parse(FlexGrid[loop + 1, 8].ToString()),
					offerrem1 = int.Parse(FlexGrid[loop + 1, 9].ToString()),
					bidrem1 = int.Parse(FlexGrid[loop + 1, 10].ToString()),
					last = FlexGrid[loop + 1, 11].ToString(),
					lmtdaycnt = int.Parse(FlexGrid[loop + 1, 12].ToString()),
				};

				if (db.TR1422.Any(x => x.regdate == today && x.shcode == t1422.shcode))
				{
					// 중복 케이스 
					//LogWrite("item duplicate.......[" + t8436.shcode + "][" + t8436.hname + "]");
					updateCnt++;
					// udpate code 
				}
				else
				{
					insertCnt++;
					db.TR1422.Add(t1422);
				}

				++loop;
				trWorker.ReportProgress(loop / totalcount * 90);

			}
			while (totalcount > loop);

			if (insertCnt > 0)
			{
				//progressBar1.Value = loop / totalcount * 100;
				db.SaveChanges();
			}
			trWorker.ReportProgress(loop / totalcount * 100);

		}


		void trWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.progressBar1.Value = e.ProgressPercentage;
		}

		void trWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			LogWrite("DB Update complete.....!");
			LogWrite("Result: [total count=" + loop + "][insert count=" + insertCnt + "][update count=" + updateCnt + "]");
			LogWrite("[" + CurTrCode + "] DB Transaction end");

			MessageBox.Show("Complete....!");
		}


	}
}
