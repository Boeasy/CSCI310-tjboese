/*
Take the Fraction class I created and overload the multiply (*) operator and divide operator (/). 
Demonstrate with 2 different Fractions.
*/
public class Fraction
{
  private int numerator;
  private int denominator;

  public Fraction(int numerator, int denominator)
  {
      this.Numerator = numerator;
      this.Denominator = denominator;
  }

  private int Numerator
  {
      get { return this.numerator; }
      set { this.numerator = value; }
  }
 
  private int Denominator
  {
      get { return this.denominator; }
      set { this.denominator = value; }
  }

  public void PrintFraction()
  {
      Console.WriteLine($"{this.Numerator}/{this.Denominator}");
  }

  public override string ToString()
  {
      return $"{this.Numerator}/{this.Denominator}";
  }

  public static Fraction operator +(Fraction leftHandSide, Fraction rightHandSide)
  {
      int newNumerator, newDenominator;
      int product1, product2;

      Fraction newFrac = new Fraction(0, 0);
     
      if (leftHandSide.Denominator == rightHandSide.Denominator)
      {
          newNumerator = leftHandSide.Numerator + rightHandSide.Numerator;
          newFrac.Numerator = newNumerator;
          newFrac.Denominator = leftHandSide.Denominator;
          newFrac = Simplify(newFrac);
          return newFrac;
      }
     
      product1 = leftHandSide.Numerator * rightHandSide.Denominator;
      product2 = leftHandSide.Denominator * rightHandSide.Numerator;

      newNumerator = product1 + product2;
      newDenominator = leftHandSide.Denominator * rightHandSide.Denominator;

      newFrac.Numerator = newNumerator;
      newFrac.Denominator = newDenominator;
      newFrac = Simplify(newFrac);
      return newFrac;
  }

    public static Fraction operator *(Fraction leftHandSide, Fraction rightHandSide)
    {
        int newNumerator, newDenominator;
    
        newNumerator = leftHandSide.Numerator * rightHandSide.Numerator;
        newDenominator = leftHandSide.Denominator * rightHandSide.Denominator;
    
        Fraction newFrac = new Fraction(newNumerator, newDenominator);
        newFrac = Simplify(newFrac);
        return newFrac;
    }

    public static Fraction operator /(Fraction leftHandSide, Fraction rightHandSide)
    {
        int newNumerator, newDenominator;
    
        newNumerator = leftHandSide.Numerator * rightHandSide.Denominator;
        newDenominator = leftHandSide.Denominator * rightHandSide.Numerator;
    
        Fraction newFrac = new Fraction(newNumerator, newDenominator);
        newFrac = Simplify(newFrac);
        return newFrac;
    }

  public static Fraction Simplify(Fraction inputFraction)
  {
      int greatestCommonDivisor;
      greatestCommonDivisor = GCD(inputFraction.Numerator, inputFraction.Denominator);

      return new Fraction(inputFraction.Numerator / greatestCommonDivisor,
          inputFraction.Denominator / greatestCommonDivisor);
  }
  private static int GCD(int a, int b)
  {
      if (b == 0)
      {
          return a;
      }

      return GCD(b, a % b);
  }

  public static bool operator ==(Fraction leftHandSide, Fraction rightHandSide)
  {
      if (leftHandSide.Numerator == rightHandSide.Numerator &&
          leftHandSide.Denominator == rightHandSide.Denominator)
      {
          return true;
      }

      return false;
  }
 
  public static bool operator !=(Fraction leftHandSide, Fraction rightHandSide)
  {
      return !(leftHandSide == rightHandSide);
  }
}
public class CSFractions
{
  static void Main(string[] args)
  {
      Fraction frac1 = new Fraction(3, 5);
      frac1.PrintFraction();
      Console.WriteLine($"This fraction is: {frac1.ToString()}");
      Fraction frac2 = new Fraction(1, 5);
      frac2.PrintFraction();
      Console.WriteLine($"This other fraction is: {frac2}");

      Fraction frac3 = frac1 + frac2;
      frac3.PrintFraction();

      //This works because the operator is static
      Fraction frac4 = new Fraction(1, 3) + new Fraction(2, 6);
      frac4.PrintFraction();
     
     
      Console.WriteLine(frac1 == frac2); // False
      Console.WriteLine(frac3 != frac4); // True
  }
}