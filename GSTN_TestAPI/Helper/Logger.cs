using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN_TestAPI.Helper
{

    public class Logger
    {
        private static Logger _logger = null;
        private string _fileName = string.Empty;

        private Logger()
        {
            _fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (!Directory.Exists(_fileName + "\\GSTNApi"))
            {
                Directory.CreateDirectory(_fileName + "\\GSTNApi");
            }

            _fileName = Path.Combine(_fileName, "GSTNApi", "log.txt");

        }

        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }

        public void Log(string text)
        {
            string newText = string.Format("Logged At {1} \r \r {0} \r \r", text, DateTime.Now.ToString());
            File.AppendAllText(_fileName, newText);
        }

        public void LogException(Exception ex)
        {
            string exceptionText = GetExceptionStack(ex);
        }

        public string GetExceptionStack(Exception ex)
        {
            string exceptionText = "";

            if (ex == null)
            {
                return "";
            }
            else
            {
                string innerText = GetExceptionStack(ex.InnerException);
                string currentExText = "";


                exceptionText = string.IsNullOrEmpty(innerText) ?

                                    currentExText = "---------------------------------------" +
                                    Environment.NewLine +
                                    ex.Message +
                                    Environment.NewLine +
                                    ex.StackTrace +
                                    Environment.NewLine +
                                    "---------------------------------------" :

                                    currentExText = "---------------------------------------" +
                                    Environment.NewLine +
                                    ex.Message +
                                    Environment.NewLine +
                                    ex.StackTrace +
                                    Environment.NewLine +
                                    innerText +
                                    Environment.NewLine +
                                    "---------------------------------------";




            }

            return exceptionText;


        }

    }
}
