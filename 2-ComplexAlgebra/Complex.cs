using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double re, double im)
        {
            Real = re;
            Imaginary = im;
        }

        public double Modulus
        {
            get => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));
        }

        // TODO
        public double Phase => Math.Atan2(Imaginary, Real);

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex c) => new Complex(Real + c.Real, Imaginary + c.Imaginary);

        public Complex Minus(Complex c) => new Complex(Real - c.Real, Imaginary - c.Imaginary);

        public override string ToString()
        {
            string res = Real == 0 ? "" : Real.ToString();
            string sign;
            if (Imaginary == 0d)
            {
                return res;
            }
            sign = Imaginary > 0 ? "+" : "";
            return res += sign + Imaginary.ToString() + "i";
        }

        public bool Equals(Complex obj) => Real == obj.Real && Imaginary == obj.Imaginary;

        public override bool Equals(object obj) => obj is Complex complex && Equals(complex);

        public override int GetHashCode() => base.GetHashCode();
    }
}