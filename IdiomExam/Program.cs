using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Text;
namespace IdiomExam
{
    public class LogWriter
    {
        
	        
        #region Definitions
        
			
			
        #endregion
        
        #region Properties

		
		
        #endregion
        
        #region Methods - Initialization
        public static void Write(string  functionName,string log)
        {
            string strFn= Application.StartupPath +"\\"+ DateTime.Now.ToString("yyyy-MM-dd")+".Log";
            FileStream fs= new FileStream(strFn, FileMode.Append);
            using(StreamWriter sw= new StreamWriter(fs,Encoding.UTF8))
            {
                // <<2019-08-31 21:15>> [function] log content
                string strLog="<<"+ DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:ffff") +">> ["+ functionName+"] "+ log;
                sw.WriteLine(strLog);
                MessageBox.Show(strLog);
            }
            
            
        }
		
        #endregion

        #region Methods - Other support function

		
		
        #endregion
    
    }


    static class Program
    {
        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
