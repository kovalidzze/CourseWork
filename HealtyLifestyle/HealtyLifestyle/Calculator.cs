using System;
namespace HealtyLifestyle
{
    public static class Calculator
    {
        public static double CalorieCalculation(int weight,int grow,int old,double k,goal goal)
        {
            const double const1 = 9.99;
            const double const2 = 6.25;
            const double const3 = 4.92;
            const int const4 = 161;
            double result = const1 * weight + const2 * grow - const3 * old - const4;
            result *= k;
            switch (goal)
            {
                case goal.sliming:
                    return result - (result * 20) / 100;
                case goal.keeping:
                    return result;
                case goal.setting:
                    return result + (result * 15) / 100;
                default:
                    throw new ArgumentException("kek");
            }
        }
    }
}
