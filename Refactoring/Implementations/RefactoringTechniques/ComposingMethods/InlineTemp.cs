using System.Diagnostics.CodeAnalysis;
using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.InlineTemp"/>
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class InlineTemp:IRefactoringImplementation
{
    public class Order
    {
        public double BasePrice()
        {
            //...
            return default;
        }
    }
    
    public class BeforeRefactoring
    {
        public bool HasDiscount(Order order)
        {
            if (order is null)
                throw new ArgumentNullException(nameof(order));
            
            // Really? having a variable that doing just a simple operation that it can be replaced in the second line?
            // however the order.BasePrice() tell us what it does.
            // please get rid of this variable. common!!
            var basePrice = order.BasePrice();
            return basePrice > 1000;
        }
    }
    
    public class AfterRefactoring
    {
        public bool HasDiscount(Order order)
        {
            // Better now? straightforward coding.
            // BUT, a BIG BUT: what if the previous variable used to cache the result of an expensive operation,
            // that in here may be the order.BasePrice()?
            // This situation express itself when you want to use the result of the expensive operation
            // in the following codes. (Let's have an example in another class).
            // YOU NEED TO KEEP THE VARIABLE TO AVOID THIS INLINE TEMPING.
            return order.BasePrice() > 1000;
        }
    }
    
    public class AfterRefactoringHasPerformanceImpact
    {
        public double CalculateDiscount(Order order)
        {
            // Let's assume that the order.BasePrice() is an expensive operation.
            // oh dear Lord, we use this expensive operation over and over. Lord helps the CPU!!!.
            // please go back to the original approach. PLEASE.
            double discountAmount;
            
            if (order.BasePrice() < 1000)
                discountAmount = 100;
            else if (order.BasePrice() < 2000)
                discountAmount = order.BasePrice() * 10 / 100;
            else
                discountAmount = order.BasePrice() * 25 / 100;
            
            return discountAmount;
        }
    }
    
    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.InlineTemp();
    }
}