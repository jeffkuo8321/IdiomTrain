using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Net.Http;
using NPOI.HSSF.UserModel;
using NPOI.XSSF;
using System.IO;
using System.Reflection;
using System.Diagnostics;


namespace IdiomTrainer
{

    public partial class frmMain:Form
    {


        #region Definitions
        
        

        public enum IdiomColumn
        {
            id,
            idiom,
            phonetic,
            hanyuPhonetic,
            interpretation,
            source,
            sourceIntro,
            prove,
            method,
            synonymous,
            antonym,
            identifi,
            refWords
        }

        public Point[] mFirstInterPos= new Point[2];
        public Point[] mSecInterPos= new Point[2];

        #endregion

        #region Properties
        
        public ArrayList mCtrlSize;

        public DataSet mDs;
        public frmData mCtrlData;
        public frmInfo mCtrlInfo;

        
        public Size mMainExpandSize;
        public Size mMainCollapseSize;
        public bool mExpandStt;

        public bool mAutoChange;
        public bool mAutoSaveImg;
        public string mAutoSaveImgPath;

        // --  variable of configuration 
        public enum Config
        {
            AutochangeFlg,
            TopMostFlg,
            AutoSaveImgFlg,
            TransparentValue,
            SaveFilePath,
            AutoChangeTimeValue,
            CurrDataRow
        }

        public ArrayList mIdiomData= new ArrayList();
        #endregion

        #region Methods - Initialization
        
        public frmMain()
        {
            try
            {
                InitializeComponent();
                mMainExpandSize= new Size(1166,298);
                mMainCollapseSize= new Size(767,298);
            
                mCtrlData= new frmData(this);
                mCtrlInfo= new frmInfo(this);
                GetConfig();

                mDs= mCtrlData.mDs;
                ChangeFormSize();
                GetnextIdiom();
                
            }
            catch (Exception ex)
            {

                LogWriter.Write(System.Reflection.MethodBase.GetCurrentMethod().Name,ex.StackTrace);
            }
            
            
        }
    
        #endregion

        #region Methods - Other support function

        public Int32 GetConfig()
        {
            Int32 iRet=0;
            try
            {
                ArrayList arylstConfig= new ArrayList();
                foreach(string strTmp in Enum.GetNames(typeof(Config)))
                {
                    arylstConfig.Add("");
                }

                
                arylstConfig[(int)Config.AutochangeFlg]= 
                    Properties.Settings.Default.autoChange.ToString();
                
                arylstConfig[(int)Config.AutoChangeTimeValue]= 
                    Properties.Settings.Default.autoChangeTime.ToString();
                
                arylstConfig[(int)Config.AutoSaveImgFlg]= 
                    Properties.Settings.Default.autoSaveImg.ToString();
                
                arylstConfig[(int)Config.SaveFilePath]= 
                    Properties.Settings.Default.saveImgPath.ToString();
                
                arylstConfig[(int)Config.TopMostFlg]= 
                    Properties.Settings.Default.topMost.ToString();
                
                arylstConfig[(int)Config.TransparentValue]= 
                    Properties.Settings.Default.transparent.ToString();

                arylstConfig[(int)Config.CurrDataRow]=
                    Properties.Settings.Default.currentDataRow.ToString();
               
                chkAutoChange.Checked=
                    Convert.ToBoolean(
                    Convert.ToInt32(
                        arylstConfig[(int)Config.AutochangeFlg].ToString()));

                chkEnableTop.Checked= 
                    Convert.ToBoolean(
                    Convert.ToInt32(
                        arylstConfig[(int)Config.TopMostFlg].ToString()));

                chkSaveImg.Checked=
                    Convert.ToBoolean(
                    Convert.ToInt32(
                        arylstConfig[(int)Config.AutoSaveImgFlg].ToString()));
                
                mAutoChange=chkAutoChange.Checked;
                
                mAutoSaveImg=chkSaveImg.Checked;

                txtCountDown.Text= arylstConfig[(int)Config.AutoChangeTimeValue].ToString();

                sldAutoChange.Value= Convert.ToInt32(txtCountDown.Text);
                
                sldTransparent.Value=Convert.ToInt32( txtTransparent.Text);

                txtSaveFilePath.Text= arylstConfig[(int)Config.SaveFilePath].ToString();
                mAutoSaveImgPath= txtSaveFilePath.Text.TrimEnd('\\')+"\\";

                txtTransparent.Text= arylstConfig[(int)Config.TransparentValue].ToString();

                Int32 iCurDataRow= Convert.ToInt32(arylstConfig[(int)Config.CurrDataRow]);
                mCtrlData.SetCurrDataRow(iCurDataRow);

                tmrAutoChange.Enabled=false;
                tmrAutoChange.Interval=Convert.ToInt32( arylstConfig[(int)Config.AutoChangeTimeValue])*1000;
                tmrAutoChange.Enabled= mAutoChange;

                

            }
            catch (Exception ex)
            {

                iRet=-1;
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }

            return iRet;
        }

        public Int32 SaveConfig()
        {
            Int32 iRet=0;
            try
            {
                // -- Get config parameters from each control and save to settings.
                ArrayList arylstConfig= new ArrayList();
                foreach(string strTmp in Enum.GetNames(typeof(Config)))
                {
                    arylstConfig.Add("");
                }

                arylstConfig[(int)Config.AutochangeFlg]=
                    Convert.ToInt32(chkAutoChange.CheckState).ToString();
                
                arylstConfig[(int)Config.AutoChangeTimeValue]=txtCountDown.Text;

                arylstConfig[(int)Config.AutoSaveImgFlg]=
                    Convert.ToInt32(chkSaveImg.CheckState).ToString();
                
                arylstConfig[(int)Config.SaveFilePath]= txtSaveFilePath.Text;

                arylstConfig[(int)Config.TopMostFlg]=
                    Convert.ToInt32(chkEnableTop.CheckState).ToString();
                
                arylstConfig[(int)Config.TransparentValue]=
                    Convert.ToDouble(txtTransparent.Text).ToString();
                
                arylstConfig[(int)Config.CurrDataRow]= mCtrlData.GetCurrDataRow().ToString();
                
                Properties.Settings.Default.autoChange= arylstConfig[(int)Config.AutochangeFlg].ToString();
                Properties.Settings.Default.autoChangeTime= arylstConfig[(int)Config.AutoChangeTimeValue].ToString();
                Properties.Settings.Default.autoSaveImg= arylstConfig[(int)Config.AutoSaveImgFlg].ToString();
                Properties.Settings.Default.saveImgPath= arylstConfig[(int)Config.SaveFilePath].ToString();
                Properties.Settings.Default.topMost= arylstConfig[(int)Config.TopMostFlg].ToString();
                Properties.Settings.Default.transparent= arylstConfig[(int)Config.TransparentValue].ToString();
                Properties.Settings.Default.currentDataRow= arylstConfig[(int)Config.CurrDataRow].ToString();

                Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                iRet=-1;
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }

            return iRet;
        }

        public Int32 GetOneIdiom(string width,string height,string fontsize,string bgColor,
                string frontColor,string text,ArrayList aryPhoetics,bool SaveBmp=false)
        {
            Int32 stt=0;
            try
            {
                
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                stt=-1;
            }
        
            return stt;
        }

        private void GetSelIdiom(int selRowIdx ,ref ArrayList idiomList)
        {
            try
            {
                ArrayList aryTmp= new ArrayList();

                string strIdiom="";
                //int iSel= dgvData.SelectedRows[selRowIdx].Index;
                
                for (int i=0;i<=Enum.GetNames(typeof(IdiomColumn)).Length-1;i++)
                {
                    aryTmp.Add(mDs.Tables[0].Rows[selRowIdx][i].ToString());
                }
                strIdiom= mDs.Tables[0].Rows[selRowIdx][2].ToString();
                
                idiomList= aryTmp;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }
        
        public void ChangeFormSize()
        {
            try
            {
                
                if(mExpandStt)
                {
                    
                    this.Size= mMainExpandSize;
                }else
                {
                    this.Size= mMainCollapseSize;
                }

                mExpandStt=!mExpandStt;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        
        }
        
        public Int32 GetIdiom(Int32 iDataRow)
        {
            Int32 iRet=0;
            try
            {
                int iSelRow=iDataRow;
                ArrayList aryIdiomLst= new ArrayList();
                GetSelIdiom(iSelRow,ref aryIdiomLst);
                mIdiomData=aryIdiomLst;
                mCtrlInfo.SetInfo(mIdiomData);
                string strIdiom=aryIdiomLst[(int)IdiomColumn.idiom].ToString();

                string strPhonetic=aryIdiomLst[(int)IdiomColumn.phonetic].ToString();

                ArrayList aryBmp= new ArrayList();
            
            mCtrlData.GenerateIdiomPic("850","50","28","E4F4E4","000000",strIdiom,strPhonetic,ref aryBmp,mAutoSaveImg,mAutoSaveImgPath);
            PictureBox[] picS= new PictureBox[2];
            picS[0]= picFirstIdiom;
            picS[1]= picSecIdiom;;

            for(int i=0;i<=aryBmp.Count-1;i++)
            {
                picS[i].Image=((Bitmap)aryBmp[i]);
            }

                //mCtrlData.GenerateIdiomPic("450","50","24","E4F4E4","000000",strIdiom,aryTmp,ref pic,true);
                //mCtrlData.ProcessRequest("450","50","24","E4F4E4","000000",strIdiom,strTmp,ref pic,true);
                txtInterpretation.Text= aryIdiomLst[(int)IdiomColumn.interpretation].ToString();
            }
            catch (Exception ex)
            {
                iRet=-1;
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
            return  iRet;
        }

        public Int32 GetnextIdiom()
        {
            Int32 iRet=0;
            try
            {
                
                picSecIdiom.Image=null;
                // set the current record to first record index if current row is the last recrod.
                if(mCtrlData.mCurrentSelectRow>=mDs.Tables[0].Rows.Count)
                {
                    mCtrlData.mCurrentSelectRow=0;
                }else
                {
                    mCtrlData.mCurrentSelectRow++;
                }

                int iDataRow=mCtrlData.mCurrentSelectRow;
                
                GetIdiom(iDataRow);
            }
            catch (Exception ex)
            {

                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
            return iRet;
        }
        public Int32 GetPrevidiom()
        {
            Int32 iRet=0;
            try
            {
                picSecIdiom.Image=null;

                // set current row number to last record index if current row is the first record.
                if(mCtrlData.mCurrentSelectRow<=0)
                {
                    mCtrlData.mCurrentSelectRow=mDs.Tables[0].Rows.Count-1;
                }else
                {
                    mCtrlData.mCurrentSelectRow--;
                }

                int iDataRow=mCtrlData.mCurrentSelectRow;
                
                GetIdiom(iDataRow);
            }
            catch (Exception ex)
            {
                iRet=-1;
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
            return  iRet;
        }


        public void Run()
        {
            try
            {
                mCtrlData.mCurrentSelectRow++;
                int iDataRow=mCtrlData.mCurrentSelectRow;
                
                GetIdiom(iDataRow);
                
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                tmrAutoChange.Enabled=false;

                GetPrevidiom();

                tmrAutoChange.Enabled=mAutoChange;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                tmrAutoChange.Enabled=false;
                GetnextIdiom();
                tmrAutoChange.Enabled= mAutoChange;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        #endregion

        #region Events - Form
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(this.Height.ToString()+":"+this.Width.ToString());
            //Debug.WriteLine(dgvData.Height.ToString()+":"+dgvData.Width.ToString());
            

            //dgvData.Width = tabData.Width - 44;
            //dgvData.Height = tabData.Height - 100;
            
            mFirstInterPos[0]= new Point(19,74);
            mFirstInterPos[1]= new Point(79,60);

            mSecInterPos[0]= new Point(19,170);
            mSecInterPos[1]= new Point(500,92);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SaveConfig();
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        private void frmMain_Move(object sender, EventArgs e)
        {
            try
            {
                //if((this.Location.X - mCtrlInfo.Location.X  <=10) && 
                //    ( mCtrlInfo.Location.Y-(this.Location.Y+this.Height) <=10))
                //{
                    mCtrlInfo.SetDesktopLocation(this.Location.X,this.Location.Y+ this.Height-5);
                //}

                //if(((mCtrlInfo.Location.X + mCtrlInfo.Width)-this.Location.X <=10) && 
                //    (this.Location.Y-mCtrlInfo.Location.Y<=10))
                //{
                //    mCtrlInfo.SetDesktopLocation(this.Location.Y+mCtrlInfo.Width+11,this.Location.Y);
                //}
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        #endregion

        #region Events - Button
        private void buttonX1_Click(object sender, EventArgs e)
        {
            picFirstIdiom.Height=picFirstIdiom.Height-5;
        }
       
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                
                Run();
            }
            catch (Exception  ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
                
        }

        
        private void btnExpCol_Click(object sender, EventArgs e)
        {
            ChangeFormSize();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                
                 if (mCtrlInfo.IsDisposed)
                {
                    mCtrlInfo = new frmInfo( this);
                }

                mCtrlInfo.SetInfo(mIdiomData);

                mCtrlInfo.Visible=!mCtrlInfo.Visible;
                //mCtrlInfo.Show();
                mCtrlInfo.SetBounds(this.Location.X,this.Location.Y+ this.Height-5,mCtrlInfo.Width,mCtrlInfo.Height);
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }
        
        private void btnSaveFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fd= new FolderBrowserDialog();
                fd.ShowDialog();
                txtSaveFilePath.Text= fd.SelectedPath;
                mAutoSaveImgPath=txtSaveFilePath.Text.TrimEnd('\\')+"\\";

            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                int iRet=0;
                iRet=SaveConfig();
                if(iRet==0)
                {
                    MessageBox.Show("設定儲存成功");
                }else
                {
                    MessageBox.Show("設定儲存失敗");
                }

            }
            catch (Exception ex)
            {

                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        #endregion

        #region Events - ComboBox

        #endregion

        #region Events - TextBox

        
        private void txtCountDown_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int iTime=0;
                try
                {
                    iTime=Convert.ToInt32(txtCountDown.Text);
                }
                catch (Exception ex)
                {
                    LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                    return;
                }
                
                if(iTime>= sldAutoChange.Minimum)
                {
                    sldAutoChange.Value=iTime;
                    tmrAutoChange.Enabled=false;
                    tmrAutoChange.Interval= iTime*1000;
                    tmrAutoChange.Enabled=chkAutoChange.Checked;
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }

        }

        private void txtCountDown_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtTransparent_Validated(object sender, EventArgs e)
        {

        }

        private void txtTransparent_TextChanged(object sender, EventArgs e)
        {
            Int32 iTmp=Convert.ToInt32(txtTransparent.Text);
            if(iTmp>= sldTransparent.Minimum && iTmp<= sldTransparent.Maximum)
            {
                sldTransparent.Value= Convert.ToInt32(txtTransparent.Text);
                this.Opacity= Convert.ToDouble(txtTransparent.Text)/100;
            }
                
        }

        #endregion

        #region Events - CheckBox

        private void chkAutoChange_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tmrAutoChange.Enabled= chkAutoChange.Checked;
                mAutoChange=tmrAutoChange.Enabled;
                
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        private void chkEnableTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost= chkEnableTop.Checked;
        }
        
        private void chkSaveImg_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                mAutoSaveImg=chkSaveImg.Checked;
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        #endregion

        #region Events - RadioButton
               
        #endregion

        #region Events - Timer
        private void tmrAutoChange_Tick(object sender, EventArgs e)
        {
            try
            {
               
                GetnextIdiom();
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        #endregion
        
        #region Events - Slider

        private void sldTransparent_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                txtTransparent.Text= sldTransparent.Value.ToString();
               
                this.Opacity= Convert.ToDouble(sldTransparent.Value)/100;
                
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

        private void sliderAutoChange_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtCountDown.Text= sldAutoChange.Value.ToString();
            }
            catch (Exception ex)
            {
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }


        #endregion

        #region Events - DatagGidView

        #endregion

        #region Events - GroupBox


        #endregion

        #region Events - ToolStrip



        #endregion

        #region Events - MenuStrip



        #endregion

        private void picFirstIdiom_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                tmrAutoChange.Enabled=!tmrAutoChange.Enabled;
                if(tmrAutoChange.Enabled)
                {
                    
                }else
                {
                    
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(System.Reflection.MethodBase.GetCurrentMethod().Name,ex.StackTrace);
            }
        }
    }
}
