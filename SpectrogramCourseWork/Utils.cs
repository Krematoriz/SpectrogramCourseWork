using System.Drawing;

namespace SpectrogramCourseWork
{
    public static class Utils
    {
        public static Color HeatMapColor(double value, double maxValue)
        {
            if (maxValue < 1)
                return Color.Black;

            double val = value / maxValue;
            if (val > 0.9)
                return Color.Red;
            else if (val > 0.7)
                return Color.Yellow;
            else if (val > 0.6)
                return Color.Green;
            else if (val > 0.5)
                return Color.Cyan;
            else if (val > 0.4)
                return Color.Blue;
            else
                return Color.Black;
        }
    }
}
