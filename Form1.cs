using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaussianFormula
{
    public partial class Form1 : Form
    {
        private IntegralCalculator integralCalculator = new IntegralCalculator();
        public Form1()
        {
            InitializeComponent();
        }


        private void CalcButton_Click(object sender, EventArgs e)
        {
            ResultWriter resultWriter = null;
            try
            {
                uint nodesCount = 0;
                if (!uint.TryParse(this.NodesCountTextBox.Text, out nodesCount))
                    throw new Exception("Указанное количество узлов не является числом");
                double value = integralCalculator.Calc((double x) =>
                {
                        return 1 / Math.Sqrt(x * x + 4);
                }, 0.8, 1.6, nodesCount);
                this.ResultLabel.Text = "Реузльтат = " + value.ToString();
                resultWriter = new ResultWriter(@"h:\integral" + nodesCount.ToString() + ".out");
                resultWriter.Log(nodesCount, value);
             }
             catch (Exception ex)
             {
                MessageBox.Show(ex.Message, "Ошибка");
             }
            if (resultWriter != null)
                resultWriter.Close();
        }
    }
}
