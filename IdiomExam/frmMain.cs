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


namespace IdiomExam
{
    public partial class frmMain:Form
    {
        public frmMain()
        {
            
            InitializeComponent();
        }
    
        static string[] PhonFonts = new string[] 
    {
      "王漢宗中楷體注音", "王漢宗中楷體破音一",
      "王漢宗中楷體破音二", "王漢宗中楷體破音三"
    };

     public void ProcessRequest ( string width,string height,string fontsize,string bgColor,
                string frontColor,string text,string strAf,bool SaveBmp=true) 
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
                        offsetY));
            }
            if (SaveBmp)
            {
                //將結果存為檔案
                bmp.Save(Application.StartupPath+"\\"+text+".bmp");
                this.pictureBox1.Image= bmp;
            }
            else
            {
                ////將結果以PNG格式傳回
                //context.Response.ContentType = "image/png";
                //bmp.Save(context.Response.OutputStream, ImageFormat.Png);
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessRequest("420","70","36","ffffff","000000","揠苗助長","0000",true);
        }
    }

    

}
