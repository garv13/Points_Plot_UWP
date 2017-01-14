using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points_Plot_UWP
{
    class MatrixClass
    {
        double q1, q2, q3, q0;
        double sq1, sq2, sq3, sq0;
        public int ch0, ch1, ch2, ch3; //compared values
        public double[,] rotation_matrix = new double [3,3];

        public MatrixClass(double x, double y, double z, double q_0)
        {
            q1 = x;
            q2 = y;
            q3 = z;
            q0 = q_0;
        }

        public void convert()
        {
            rotation_matrix[0, 0] = (q0 * q0) + (q1 * q1) - (q2 * q2) - (q3 * q3);
            rotation_matrix[0, 1] = 2 * (-q0 * q3 + q1 * q2);
            rotation_matrix[0, 2] = 2 * (q0 * q2 + q1 * q3);
            rotation_matrix[1, 0] = 2 * (q0 * q3 + q2 * q1);
            rotation_matrix[1, 1] = (q0 * q0) - (q1 * q1) + (q2 * q2) - (q3 * q3);
            rotation_matrix[1, 2] = 2 * (-q0 * q1 + q2 * q3);
            rotation_matrix[2, 0] = 2 * (-q0 * q2 + q1 * q3);
            rotation_matrix[2, 1] = 2 * (q0 * q1 + q2 * q3);
            rotation_matrix[2, 2] = (q0 * q0) - (q1 * q1) - (q2 * q2) + (q3 * q3);
        }

        public void reverse()
        {
            sq0 = (1 + rotation_matrix[0, 0] + rotation_matrix[1, 1] + rotation_matrix[2, 2]) / 4;
            sq1 = (1 + rotation_matrix[0, 0] - rotation_matrix[1, 1] - rotation_matrix[2, 2]) / 4;
            sq2 = (1 - rotation_matrix[0, 0] + rotation_matrix[1, 1] - rotation_matrix[2, 2]) / 4;
            sq3 = (1 - rotation_matrix[0, 0] - rotation_matrix[1, 1] + rotation_matrix[2, 2]) / 4;

            ch0 = sq0.CompareTo((q0 * q0));
            ch1 = sq1.CompareTo((q1 * q1));
            ch2 = sq2.CompareTo((q2 * q2));
            ch3 = sq3.CompareTo((q3 * q3));

        }
    }
}
