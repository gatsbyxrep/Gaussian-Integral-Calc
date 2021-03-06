using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianFormula
{
    class ResultWriter
    {
        private StreamWriter streamWriter = null;
        public ResultWriter(String fileName)
        {
            try
            {
                streamWriter = new StreamWriter(@fileName);
            }
            catch (Exception e)
            {
                throw new IOException("Неудалось создать файл для записи");
            }
        }

        public void Log(string strToLog)
        {
            streamWriter.WriteLine(strToLog);
        }
        public void Log(uint nodesCount, double integralValue)
        {
            streamWriter.WriteLine(" Квадратурная формула Гаусса:");
            streamWriter.WriteLine("Кол-во узлов интегрирования = {0,1:d}", nodesCount);
            streamWriter.WriteLine("Приближенное значение интеграла = {0,21:e14}", integralValue);
        }

        public void Close()
        {
            streamWriter.Close();
        }
    }
}
