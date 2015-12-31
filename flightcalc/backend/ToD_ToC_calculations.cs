using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace backend
{
    public static class ToD_ToC_calculations
    {
        /***
            This function returns the covered ground in miles per minute, depending on IAS.
        ***/
        public static int dp_min(int IAS)
        {
            return (int)Round((double)IAS / 60.0);
        }

        /***
            This function returns the rate of descent in ft/min for a given speed, altitude difference and descent distance
        ***/
        public static int calculate_rate_of_descent(int IAS, int alt, int target_alt, int target_distance)
        {
            int dalt = alt - target_alt;
            int dpmin = dp_min(IAS);

            double dt = target_distance / dpmin;
            double rod = dalt / dt;

            return (int)rod;
        }
    }
}
