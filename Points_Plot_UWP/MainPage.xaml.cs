using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Points_Plot_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        float prev_X = 100, prev_Y = 100;
        public MainPage()
        {
            this.InitializeComponent();
        }
        int NumberOfPositions = 90;
        private void button_Click(object sender, RoutedEventArgs e)
        {
                double xStep = 1.0 / NumberOfPositions;
                double[] yValues = new double[NumberOfPositions + 1];
                double[] xValues = new double[NumberOfPositions + 1];
                for (int i = 0; i < NumberOfPositions + 1; i++)
                {
                    xValues[i] = (i * xStep) ;
                    yValues[i] = (Math.Sin(xValues[i] * 2 * Math.PI)) ; // Since you want 2*PI to be @ 1
                }
            for (int i = 0; i < NumberOfPositions + 1; i++)
            {
                draw_Line((float)xValues[i],(float)yValues[i]);
            }
        }

        public void draw_Line(float x,float y)
        {
            var line1 = new Line();
            line1.Stroke = new SolidColorBrush(Windows.UI.Colors.Red);
            line1.X1 = prev_X;
            line1.Y1 = prev_Y;
            line1.X2 = x;
            line1.Y2 = y;
            prev_X = x;
            prev_Y = y;
            layoutRoot.Children.Add(line1);
        }
    }
}
