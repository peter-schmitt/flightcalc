using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace backend.ToD_ToC_calculations
{
    public static class ToD_ToC_calculations
    {
        /// <summary>
        /// This function returns the covered ground in miles per minute, depending on IAS.
        /// </summary>
        public static int dp_min(int IAS)
        {
            return (int)Round((double)IAS / 60.0);
        }

        /// <summary>
        /// This function returns the difference altitude
        /// </summary>
        private static int d_alt(int start_alt, int target_alt)
        {
            return target_alt - start_alt;
        }

        /// <summary>
        /// This function returns the rate of descent in ft/min for a given speed, altitude difference and descent distance
        /// </summary>
        public static int calculate_rate_of_descent(int IAS, int alt, int target_alt, int target_distance)
        {
            // distance travelled per minute
            int dpmin = dp_min(IAS);

            // time to travel the desired distance
            double dt = target_distance / dpmin;
            // desired rate of descent
            double rod = d_alt(alt, target_alt) / dt;

            return (int)rod;
        }

        /// <summary>
        /// This function returns descent rate for 3° standard glide path for current speed.
        /// </summary>
        public static int calculate_rate_of_descent(int IAS)
        {
            // ROD = 5.307 * IAS found under http://walter.bislins.ch/blog/index.asp?page=Aviatik+Faustformel%3A+Sinkrate+auf+dem+Gleitpfad
            // * -1 to get a negative result for descent.
            return (int)(5.307 * IAS) * -1;
        }

        /// <summary>
        /// This fuction calculates the time in minutes to reach the target altitude with a given rate of descent.
        /// </summary>
        public static int calculate_time_to_target_altitude(int alt, int target_alt, int target_rod)
        {
            double descent_time = d_alt(alt, target_alt) / target_rod;

            // minutes can never be negative, therefore only absolute values are allowed
            return (int)Math.Abs(descent_time);
        }

        /// <summary>
        /// This fuction calculates the distance in miles to reach the target altitude with a given rate of descent.
        /// </summary>
        public static int calculate_distance_to_target_altitude(int IAS, int alt, int target_alt, int target_rod)
        {
            return calculate_time_to_target_altitude(alt, target_alt, target_rod) * dp_min(IAS);
        }
    }

}