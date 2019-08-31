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
using System.Collections;
using System.Reflection;

namespace IdiomExam
{
    public partial class frmInfo : Form
    {


        #region Definitions



        #endregion

        #region Properties
        
        frmMain rSystem;


        #endregion

        #region Methods - Initialization



        #endregion

        #region Methods - Other support function

        public Int32 SetInfo(ArrayList info)
        {
            int iRet=0;
            try
            {
                txtHanyuPhonetic.Text= info[(int)frmMain.IdiomColumn.hanyuPhonetic].ToString();
                txtSynonymous.Text= info[(int)frmMain.IdiomColumn.synonymous].ToString();
                txtAntonym.Text= info[(int)frmMain.IdiomColumn.antonym].ToString();
                txtRefwords.Text= info[(int)frmMain.IdiomColumn.refWords].ToString();
                txtOtherInfo.Text= "典源:"+ info[(int)frmMain.IdiomColumn.source].ToString()+"\r\n\r\n"+
                    "典故說明:"+info[(int)frmMain.IdiomColumn.sourceIntro].ToString()+"\r\n\r\n"+
                    "書證:"+info[(int)frmMain.IdiomColumn.prove].ToString()+"\r\n\r\n"+
                    "用法說明"+info[(int)frmMain.IdiomColumn.method].ToString();
                txtOtherInfo.Select(0,0);
            }
            catch (Exception ex)
            {
                iRet=-1;
                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
            return iRet;
        }


        #endregion

        #region Events - Form
        public frmInfo(frmMain sys )
        {
            
            try
            {
                InitializeComponent();
                rSystem= sys;
            }
            catch (Exception ex)
            {

                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

         private void frmInfo_Move(object sender, EventArgs e)
        {
            try
            {
                //if((this.Location.X - rSystem.Location.X <=10) && 
                //    (this.Location.Y-(rSystem.Location.Y+rSystem.Height)<=10))
                //{
                //    rSystem.SetDesktopLocation(this.Location.X,this.Location.Y- rSystem.Height+7);
                //} 
                
                //if(((this.Location.X - (rSystem.Location.X + rSystem.Width)) <=10) && 
                //    (this.Location.Y-rSystem.Location.Y<=10))
                //{
                //    rSystem.SetDesktopLocation(this.Location.X-rSystem.Width+11,this.Location.Y);
                //}

            }
            catch (Exception ex)
            {

                LogWriter.Write(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
            }
        }

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



        #endregion

        #region Events - GroupBox



        #endregion

        #region Events - ToolStrip



        #endregion

        #region Events - MenuStrip



        #endregion

       
    }
}
