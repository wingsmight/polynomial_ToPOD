using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Term : IEquatable<Term>
    {
        private const double EPS = 0.0001d;


        private double coef;
        private int degree;


        public Term() : this(0, 0)
        {

        }
        public Term(double coef, int degree)
        {
            this.coef = coef;
            this.degree = degree;
        }


        public bool Equals(Term otherTerm)
        {
            return coef.Equals(otherTerm.coef) && degree.Equals(otherTerm.degree);
        }
        public Term CalcDerivative()
        {
            return new Term(coef * degree, degree - 1);
        }
        public double GetValue(double x)
        {
            return coef * Math.Pow(x, degree);
        }

        public override string ToString()
        {
            return coef + "*x^" + degree;
        }


        public static bool operator >(Term p1, Term p2)
        {
            return (p1.degree > p2.degree);
        }
        public static bool operator <(Term p1, Term p2)
        {
            return (p1.degree < p2.degree);
        }
        public static Term operator *(Term p1, Term p2)
        {
            return new Term(p1.Coef * p2.Coef, p1.Degree + p2.Degree);
        }


        public int Degree { get => degree; set => degree = value; }
        public double Coef { get => coef; set => coef = value; }
        public bool IsZero => Math.Abs(coef) < EPS;
    }
}
