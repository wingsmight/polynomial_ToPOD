using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynomial : List<Term>
    {
        public Polynomial() : this (0, 0)
        {

        }
        public Polynomial(double coef, int degree) : base()
        {
            Add(new Term(coef, degree));
        }


        public double GetCoeff(int degree)
        {
            for (int i = 0; i < Count; i++)
            {
                Term term = base[i];

                if (term.Degree == degree)
                {
                    return term.Coef;
                }
            }

            return 0;
        }
        public double GetValue(double x)
        {
            double value = 0;
            for (int i = 0; i < Count; i++)
            {
                Term term = base[i];
                value += term.Coef * Math.Pow(x, term.Degree);
            }
            return value;
        }
        public Polynomial CalcDerivative()
        {
            Polynomial derivative = new Polynomial();

            for (int i = 0; i < Count; i++)
            {
                Term term = base[i];
                term = term.CalcDerivative();

                derivative += new Polynomial(term.Coef, term.Degree);
            }
            return derivative;
        }
        public new void Clear()
        {
            base.Clear();
        }
        public Term GetTermAt(int index)
        {
            return base[index];
        }
        public new void Add(Term newTerm)
        {
            if (!newTerm.IsZero)
            {
                base.Add(newTerm);
            }
        }

        public override string ToString()
        {
            if (Count == 0)
                return new Term().ToString();

            string text = "";

            for (int i = 0; i < Count; i++)
            {
                Term term = base[i];

                if (i > 0 && term.Coef > 0)
                {
                    text += " + ";
                }

                int termLength = term.ToString().Length;
                text += term.ToString();

                if (i > 0 && term.Coef < 0)
                {
                    text = text.Insert(text.Length - termLength, " ");
                    text = text.Insert(text.Length - termLength + 1, " ");
                }
            }

            return text;
        }


        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            for (int i = 0; i < p1.Count; i++)
            {
                if (!p1[i].Equals(p2[i]))
                {
                    return false;
                }
            }

            return true;
        }
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            Polynomial result = new Polynomial();

            int maxDegree = Math.Max(p1.MaxDegree, p2.MaxDegree);
            for (int degree = 0; degree <= maxDegree; degree++)
            {
                double coef = p1.GetCoeff(degree) + p2.GetCoeff(degree);

                result.Add(new Term(coef, degree));
            }

            return result;
        }
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            Polynomial result = new Polynomial();

            int maxDegree = Math.Max(p1.MaxDegree, p2.MaxDegree);
            for (int degree = 0; degree <= maxDegree; degree++)
            {
                double coef = p1.GetCoeff(degree) - p2.GetCoeff(degree);

                result.Add(new Term(coef, degree));
            }

            return result;
        }
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            Polynomial result = new Polynomial();

            for (int degree1 = 0; degree1 <= p1.MaxDegree; degree1++)
            {
                for (int degree2 = 0; degree2 <= p2.MaxDegree; degree2++)
                {
                    double coef = p1.GetCoeff(degree1) * p2.GetCoeff(degree2);
                    int degree = degree1 + degree2;

                    result += new Polynomial(coef, degree);
                }
            }

            return result;
        }


        public int MaxDegree
        {
            get
            {
                int maxDegree = 0;

                for (int i = 0; i < Count; i++)
                {
                    Term term = base[i];

                    if (term.Degree > maxDegree)
                    {
                        maxDegree = term.Degree;
                    }
                }

                return maxDegree;
            }
        }
    }
}
