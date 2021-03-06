using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianFormula
{
    class IntegralCalculator
    {
        // A
        private double[][] WeightsCoefficients = new double[][]
        {
            new double[] { 0.555555555555556, 0.888888888888889, 0.555555555555556 },
            new double[] { 0.347854845137454, 0.652145154862546, 0.652145154862546, 0.347854845137454 },
            new double[] { 0.236926885056189, 0.478628670499366, 0.568888888888889, 
                            0.478628670499366, 0.236926885056189 },
            new double[] { 0.171324492379170, 0.360761573048139, 0.467913934572691,
                            0.467913934572691, 0.360761573048139, 0.17132449237917 }
        };
        // T 
        private double[][] LegendreNulls = new double[][]
        {
            new double[] { -0.774596669241483, 0.0, 0.774596669241483 },
            new double[] { -0.861136311594053, -0.339981043584856, 0.339981043584856, 0.861136311594053 },
            new double[] { -0.906179845938664, -0.538469310105683, 0.0, 0.538469310105683, 0.906179845938664 },
            new double[] { -0.932469514203152, -0.661209386466265, -0.238619186083197,
                            0.238619186083197, 0.661209386466265, 0.932469514203152 }
        };

        public delegate double Func(double x);
        public double Calc(Func function, double a, double b, uint integrationNodesCount)
        {
            if (integrationNodesCount < 3 || integrationNodesCount > 6)
                throw new Exception("Неверное количество узлов интегрирования");
            var c1 = (b + a) / 2.0;
            var c2 = (b - a) / 2.0;
            double s = 0.0;
            double xi = 0.0;

            for(int i = 0; i < integrationNodesCount; i++)
            {
                xi = c1 + c2 * LegendreNulls[integrationNodesCount - 3][i];
                s += WeightsCoefficients[integrationNodesCount - 3][i] * function(xi);
            }

            s *= c2;

            return s;
        }
        
    }
}
