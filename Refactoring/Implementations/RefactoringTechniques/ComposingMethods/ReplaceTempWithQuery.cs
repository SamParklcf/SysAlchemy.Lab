using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.ReplaceTempWithQuery"/>
/// </summary>
public class ReplaceTempWithQuery : IRefactoringImplementation
{
    public class BeforeRefactoring(double quantity, double itemPrice)
    {
        public double CalculateTotal()
        {
            // It looks good, why? because we have just one method that uses this expression.
            // BUT, BIG BUT: what if we have another method that need to use this expression?
            // do you want to repeat yourself and having code deduplication? definitely no.
            var basePrice = quantity * itemPrice;

            if (basePrice > 1000)
            {
                return basePrice * 0.95;
            }

            return basePrice * 0.98;
        }
    }
    
    public class BeforeRefactoringHaveCodeDeduplication(double quantity, double itemPrice)
    {
        public double CalculateTotal()
        {
            // It looks good, why? because we have just one method that uses this expression.
            // BUT, BIG BUT: what if we have another method that need to use this expression?
            // do you want to repeat yourself and having code deduplication? definitely no.
            var basePrice = quantity * itemPrice;

            if (basePrice > 1000)
            {
                return basePrice * 0.95;
            }

            return basePrice * 0.98;
        }
        
        public double CalculateDiscount()
        {
            // Really? another place that uses the same expression as the previous method?
            // No, we do not want this, do you?
            var basePrice = quantity * itemPrice;
            double discountAmount;

            if (basePrice < 1000)
                discountAmount = 100;
            else if (basePrice < 2000)
                discountAmount = basePrice * 10 / 100;
            else
                discountAmount = basePrice * 25 / 100;

            return discountAmount;
        }
    }

    public class AfterRefactoring(double quantity, double itemPrice)
    {
        // This expression is also used in another method, so it would be great to have it in a common method and 
        // use it in all of the class sections.
        private double BasePrice() => quantity * itemPrice;

        public double CalculateTotal()
        {
            // As you see we extract the expression into a common method, but we still use the variable inside 
            // this method and the next one, why? (dig into other refactoring techniques in ComposingMethods techniques
            // and try to find an answer.
            // Common, don't be lazy.
            var basePrice = BasePrice();

            if (basePrice > 1000)
            {
                return basePrice * 0.95;
            }

            return basePrice * 0.98;
        }

        public double CalculateDiscount()
        {
            var basePrice = BasePrice();
            double discountAmount;

            if (basePrice < 1000)
                discountAmount = 100;
            else if (basePrice < 2000)
                discountAmount = basePrice * 10 / 100;
            else
                discountAmount = basePrice * 25 / 100;

            return discountAmount;
        }
    }
    
    //NOTE: what if the expression change the state of the object?
    // Let's have an example
    // Todo: Let's have an example ReplaceTempWithQuery
    

    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.ReplaceTempWithQuery();
    }
}