using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF;
using System.Collections;
using System.Drawing.Text;
using System.Reflection;
namespace IdiomTrainer
{
    public partial class frmData : Form
    {


        #region Definitions
        public const string Fn_IDIOM="idioms_2011_20190329.xls";

        // 暫時保留之前參考黑暗執行緒大大直接使用注音字型的code.目前實際只使用到標楷體一種字型.
        static string[] PhonFonts = new string[] 
        {
          "標楷體","王漢宗中楷體注音", "王漢宗中楷體破音一",
          "王漢宗中楷體破音二", "王漢宗中楷體破音三"
        };


        #endregion

        #region Properties
        private frmMain rSystem;

        public Int32 mCurrentSelectRow=0;

        public DataSet mDs;

        public ArrayList mIdiomPic= new ArrayList();
        #endregion

        #region Methods - Initialization
        public frmData( frmMain sys)
        {
            try
            {
                rSystem= sys;
                GetIdiomData();
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        
        
        }


        #endregion

        #region Methods - Other support function
        private void GetIdiomData()
        {
            try
            {
                DataSet ds=new DataSet();
                string strFn= Application.StartupPath+"\\"+ Fn_IDIOM;
                GetRawData(strFn,ref ds);
                if(ds.Tables[0].Rows.Count>0)
                {
                    mCurrentSelectRow=1056;
                }
                
                mDs=ds;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
             
        }

        public Int32 GetCurrDataRow()
        {
            int iCurRow=0;

            try
            {
                iCurRow= mCurrentSelectRow;
            
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
            return iCurRow;
        }

        public void SetCurrDataRow(int currDataRow)
        {
            try
            {
                mCurrentSelectRow=currDataRow;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        
        }


        public Int32 GetRawData(string fn,ref DataSet dsDest)
        {
            Int32 iRet=0;
            try
            {
                string strFn=fn;
                bool blFileExist=false;
               
                blFileExist=File.Exists(strFn);
                if (!blFileExist)
                {
                    blFileExist=false;
                    MessageBox.Show("檔案["+strFn +"]不存在");
                    iRet=-1;
                    return iRet;
                }

                if(blFileExist)
                {
                    FileStream fs= new FileStream(strFn, FileMode.Open);

                    HSSFWorkbook ws= new HSSFWorkbook(fs);


                    var sheet= ws.GetSheet("工作表");

                    DataSet ds= new DataSet();
                    ds.Tables.Add("newTable");
                    for(int i=0;i<=sheet.GetRow(0).LastCellNum;i++)
                    {
                        string strColName="";
                        if(sheet.GetRow(0).GetCell(i)!=null)
                        {
                            strColName= sheet.GetRow(0).GetCell(i).ToString();
                        }
                    

                        if(ds.Tables[0].Columns.Contains(strColName))
                        {
                            strColName= strColName+"_1";
                        }
                        ds.Tables[0].Columns.Add(strColName);
                    }
                
                

                    for(int i=1;i<=sheet.LastRowNum;i++)
                    {
                    
                        DataRow dr= ds.Tables[0].NewRow();
                        for( int j=0;j<=sheet.GetRow(0).LastCellNum;j++)
                        {
                        
                            if(sheet.GetRow(i).GetCell(j)!=null)
                            {
                               dr[j]=sheet.GetRow(i).GetCell(j).ToString();
                            }else
                            {
                                dr[j]="";
                            }
                        
                        
                            //
                        }
                        ds.Tables[0].Rows.Add(dr);
                    }
                    //BindingSource bs= new BindingSource();
                    //bs.DataSource= ds.Tables[0];
                    
                    dsDest=ds;
                }
            }
            catch (Exception ex)
            {
                iRet=-1;
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }

            return iRet;
        }

        
        public void GenerateIdiomPic(string width,string height,string fontsize,string bgColor,
                string frontColor,string text,string  phonetic,ref ArrayList aryPic,bool saveImg=false,string saveImgPath="")
        {
            try
            {
                
                ArrayList arylstPic=new ArrayList();
                string[] strTmp= phonetic.Split(';');

                for(int k=0;k<=strTmp.Length-1;k++)
                {
                    string[] strPhonetic=strTmp[k].Split('　');
                    ArrayList alIdioimPos= new ArrayList();
                    ArrayList alPhoneticPos= new ArrayList();
                
                    int w = int.Parse(width);
                    int h = int.Parse(height);
                    float fs = float.Parse(fontsize);
                    Color bc = ColorTranslator.FromHtml("0x" +bgColor );
                    Color fc = ColorTranslator.FromHtml("0x" + frontColor);
                    string txt = text;
                
                    //string af = strAf ?? text.Length.ToString();
                    //建立畫布
                    Bitmap bmp = new Bitmap(w, h);

                    Graphics g= Graphics.FromImage(bmp);

                    //取得字數，測量並計算寬度，決定置中用的位移
                    //塗上背景色
                    Brush p = new SolidBrush(bc);
                    g.FillRectangle(p, 0, 0, bmp.Width, bmp.Height);
                    //使用"王漢宗細明體繁"
                    Font fnt = new Font(PhonFonts[0], fs);
                    Font fntPhonetic= new Font(PhonFonts[0],fs/3);
                    
                    var sz = g.MeasureString(txt, fnt);
                    //var szPhonetic=g.MeasureString(strTmp[k].TrimEnd(),fntPhonetic);

                    //設定文字反鋸齒
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    //取得每個字的寬度
                    float widthPerChar = (sz.Width / txt.Length)+20; 
                    float heightChar=sz.Height/txt.Length;
                    //計算置中用的位移     
                    float offsetX = 20;//(bmp.Width - (sz.Width+szPhonetic.Width)) / 2;
                    float offsetY = (bmp.Height - sz.Height) / 2;
                
                    //用迴圈一次畫一個字元
                
                    for(int i=0;i<= txt.Length-1;i++)
                    {
                        float flCharX=offsetX +widthPerChar*i;
                        float flCharY= offsetY +heightChar;
                        g.DrawString(
                            txt[i].ToString(), 
                            new Font(PhonFonts[0], fs),
                            new SolidBrush(fc),
                            new PointF(flCharX,flCharY)
                            );

                        // 計算注音符號字串高度
                        float flOffSetPhoneticY=bmp.Height/2;
                    

                        for (int j = 0; j < strPhonetic[i].Length; j++)
                        {
                            float flHeight=0;
                        
                            int iPhoneticCnt;
                        
                            //計算總共有幾個注音符號(不包含音調).
                            if(strPhonetic[i][strPhonetic[i].Length-1]=='ˊ' || 
                                strPhonetic[i][strPhonetic[i].Length-1]=='ˇ' || 
                                strPhonetic[i][strPhonetic[i].Length-1]=='ˋ')
                            {
                               iPhoneticCnt =strPhonetic[i].Length-1;
                            }else
                            {
                               iPhoneticCnt =strPhonetic[i].Length;
                            }
                        
                            var fontPerSz=g.MeasureString(strPhonetic[i][0].ToString(),fntPhonetic,int.MaxValue,StringFormat.GenericTypographic);
                            var phoneticDiffHight=fontPerSz.Height;
                            //判斷是否已抓取到注音符號音調的部份
                            if(strPhonetic[i][j]=='ˊ' || strPhonetic[i][j]=='ˇ' || strPhonetic[i][j]=='ˋ')
                            {
                        
                                //計算要加音調的注音符號有幾個字串並計算出要加上音調符號的位置
                                switch(j)
                                {
                                    case 1:
                                        flHeight=flOffSetPhoneticY-(phoneticDiffHight/2);
                                    break;

                                    case 2:
                                        flHeight=flOffSetPhoneticY;
                                    break;
                            
                            
                                    case 3:
                                        flHeight=flOffSetPhoneticY+(phoneticDiffHight/2);
                                    break;
                                }
                                g.DrawString(
                                strPhonetic[i][j].ToString(), 
                                new Font(PhonFonts[0], fs/3),
                                new SolidBrush(fc),
                                new PointF(
                                    flCharX+(widthPerChar)-10 , //+ widthPerChar * i 
                                    flHeight));
                            }else
                            {
                                //準備開始輸出注音符號
                                float flPhoneticHeight=0;

                                switch(iPhoneticCnt)
                                {
                                    case 1:
                                    switch(j)
                                        {
                                        case 0:
                                        flPhoneticHeight= flOffSetPhoneticY;
                                        break;
                                        }                                    
                                    
                                    break;

                                    case 2:
                                        switch(j)
                                        {
                                        case 0:
                                        flPhoneticHeight= flOffSetPhoneticY-(fs/3)+2;
                                        break;
                                    
                                    
                                        case 1:
                                        flPhoneticHeight= flOffSetPhoneticY+(fs/3)-2;
                                        break;

                                        } 
                                    break;

                                    case 3:
                                        switch(j)
                                        {
                                        case 0:
                                        flPhoneticHeight= flOffSetPhoneticY-(fs/3)-3;
                                        break;
                                    
                                    
                                        case 1:
                                        flPhoneticHeight= flOffSetPhoneticY;
                                        break;

                                        case 2:
                                        flPhoneticHeight= flOffSetPhoneticY+(fs/3)+3;
                                        break;

                                        }
                                    
                                    break;

                            
                                }

                                // 因注音符號有包含標點符號，所以在輸出音調符號時如果有標點符則用空白取代。
                                String strOutput=strPhonetic[i][j].ToString();
                                if(strPhonetic[i][j].ToString()=="，")
                                {
                                    strOutput="";
                                }

                                g.DrawString(
                                strOutput, 
                                new Font(PhonFonts[0], fs/3),
                                new SolidBrush(fc),
                                new PointF(
                                    flCharX+(widthPerChar)-18 , //+ widthPerChar * i 
                                    flPhoneticHeight));
                            }

                    
                            //for(int j=0;j<=aryPhonetic.Count-1;j++)
                            //{
                        
                            //}
                            //查第i個字元的破音字指定
                            //int fntIdx = (byte)af[i] - 0x30;
                            //以前景色寫上文件
                    
                        }

                        
                        if (saveImg)
                        {
                            String strSavePath="";
                            if(String.IsNullOrEmpty(saveImgPath))
                            {
                                strSavePath=Application.StartupPath+"\\";
                            }else
                            {
                                strSavePath=saveImgPath.TrimEnd('\\')+"\\";
                            }
                            //將結果存為檔案
                            bmp.Save(strSavePath+text+"_"+k.ToString()+".bmp",System.Drawing.Imaging.ImageFormat.Png);
                            
                        }
                        else
                        {
                            ////將結果以PNG格式傳回
                            //context.Response.ContentType = "image/png";
                            //bmp.Save(context.Response.OutputStream, ImageFormat.Png);
                        }
                    }

                    arylstPic.Add(bmp);
                }
                aryPic=arylstPic;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        
        }

        public void ProcessRequest ( string width,string height,string fontsize,string bgColor,
                string frontColor,string text,string strAf,ref Bitmap pic,bool SaveBmp=false) 
        {
            //忽略參數檢查
            
            int w = int.Parse(width);
            int h = int.Parse(height);
            float fs = float.Parse(fontsize);
            Color bc = ColorTranslator.FromHtml("0x" +bgColor );
            Color fc = ColorTranslator.FromHtml("0x" + frontColor);
            string txt = text;
            //允許不同的字指定破音字，如四個字第三個字要用破音字一 af=0010
            string af="";
            if(strAf=="0")
            {
                for(int i=0;i<=txt.Length-1;i++)
                {
                    af+=strAf;
                }
            }else
            {
                af=strAf;
            }
            //string af = strAf ?? text.Length.ToString();
            //建立畫布
            Bitmap bmp = new Bitmap(w, h);
            //取得字數，測量並計算寬度，決定置中用的位移
            Graphics g = Graphics.FromImage(bmp);
            //塗上背景色
            Brush p = new SolidBrush(bc);
            g.FillRectangle(p, 0, 0, bmp.Width, bmp.Height);
            //使用"王漢宗中楷體"
            Font fnt = new Font(PhonFonts[0], fs);
            var sz = g.MeasureString(txt, fnt);
            //設定文字反鋸齒
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //取得每個字的寬度
            float widthPerChar = sz.Width / txt.Length;   
            //計算置中用的位移     
            float offsetX = (bmp.Width - sz.Width) / 2;
            float offsetY = (bmp.Height - sz.Height) / 2;
            //考量破音字要換字型，每個字元可用不同字型
            //用迴圈一次畫一個字元
            for (int i = 0; i < txt.Length; i++)
            {
                //查第i個字元的破音字指定
                int fntIdx = (byte)af[i] - 0x30;
                //以前景色寫上文件
                g.DrawString(
                    txt[i].ToString(), 
                    new Font(PhonFonts[fntIdx], fs),
                    new SolidBrush(fc),
                    new PointF(
                        offsetX + widthPerChar * i, 
                        offsetY+5));
            }
            if (SaveBmp)
            {
                //將結果存為檔案
                bmp.Save(Application.StartupPath+"\\"+text+".bmp");
                pic= bmp;
            }
            else
            {
                ////將結果以PNG格式傳回
                //context.Response.ContentType = "image/png";
                //bmp.Save(context.Response.OutputStream, ImageFormat.Png);
            }
        }

        public bool IsReusable 
        {
            get {
                return false;
            }
        }


        #endregion

        #region Events - Form



        #endregion

        #region Events - Button



        #endregion

        #region Events - ComboBox



        #endregion

        #region Events - TextBox



        #endregion

        #region Events - CheckBox



        #endregion

        #region Events - RadioButton



        #endregion

        #region Events - Timer



        #endregion

        #region Events - DatagGidView
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if(mDs.Tables[0].Rows.Count>0)
                //{
                //    mCurrentSelectRow= mDs.Tables[0].SelectedCells[0].RowIndex;
                //}
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }


        #endregion

        #region Events - GroupBox



        #endregion

        #region Events - ToolStrip



        #endregion

        #region Events - MenuStrip



        #endregion



        public frmData()
        {
            InitializeComponent();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            try
            {
                GetIdiomData();
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }
    }
}
