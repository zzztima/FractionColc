using System.Collections.Generic;

namespace Calc
{
    struct Fraction
    {
        //      numerator  
        // Count-----------
        //      denominator
        public int numerator;
        public int denominator;
        public int count;

        public static Fraction[] Equally(Fraction fraction1, Fraction fraction2)
        {
            Fraction[] r = new Fraction[2];

            r[0].denominator = fraction1.denominator * fraction2.denominator;
            r[1].denominator = fraction1.denominator * fraction2.denominator;

            r[0].count = fraction1.count;
            r[1].count = fraction2.count;

            r[0].numerator = fraction1.numerator * fraction2.denominator;
            r[1].numerator = fraction2.numerator * fraction1.denominator;

            return r;
        }

        public static Fraction operator +(Fraction fra1, Fraction fra2)
        {
            Fraction f1;
            Fraction f2;

            Fraction[] tmp = Equally(fra1, fra2);

            f1 = tmp[0];
            f2 = tmp[1];

            Fraction r = f1;
            r.numerator = f1.numerator + f2.numerator;
            r.count = f1.count + f2.count;

            return r;
        }
        
        public static Fraction operator -(Fraction fra1, Fraction fra2)
        {
            Fraction f1;
            Fraction f2;

            Fraction[] tmp = Equally(fra1, fra2);

            f1 = tmp[0];
            f2 = tmp[1];

            Fraction r = f1;
            r.numerator = f1.numerator - f2.numerator;
            r.count = f1.count - f2.count;

            return r;
        }
        
        public static Fraction operator *(Fraction fra1, Fraction fra2)
        {
            Fraction r = fra1;
            r.numerator = fra1.numerator * fra2.numerator;
            r.denominator = fra1.denominator * fra1.denominator;

            return r;
        }
        
        public static Fraction operator /(Fraction fra1, Fraction fra2)
        {
            Fraction r = fra1;
            r.numerator = fra1.numerator * fra2.denominator;
            r.denominator = fra1.denominator * fra1.numerator;

            return r;
        }

        public override string ToString()
        {
            string[] r = new string[3];

            int len = ((denominator.ToString().Length < numerator.ToString().Length) ? numerator.ToString().Length : denominator.ToString().Length) + 2;

            r[0] = " " + numerator.ToString() + " ";
            r[2] = " " + denominator.ToString() + " ";

            for (int i = 0; i < len; i++)
            {
                r[1] += "-";
            }

            return r[0] + "\n" + r[1] + "\n" + r[2];
        }
    }
}
