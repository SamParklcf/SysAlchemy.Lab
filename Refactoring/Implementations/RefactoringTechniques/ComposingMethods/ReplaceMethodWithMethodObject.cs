using System.Diagnostics.CodeAnalysis;
using SysAlchemy.Lab.Refactoring.Definitions;
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable CS0169 // Field is never used

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.ReplaceMethodWithMethodObject"/>
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
[SuppressMessage("ReSharper", "UnusedParameter.Local")]
public class ReplaceMethodWithMethodObject: IRefactoringImplementation
{
    public class BeforeRefactoring
    {
        public class Order 
        {
            // ...
            public double Price() 
            {
                // Do you like fatness? I don't.
                // It would be great to have this calculation in a separate class to isolate the operation of 
                // calculating price, instead of having utilities to do that.
                // Also we tightly coupled the price calculation within the 'Order' class, let's the class be worried
                // of ordering issues only.
                double primaryBasePrice;
                double secondaryBasePrice;
                double tertiaryBasePrice;
                // Perform long computation.

                return default;
            }
        }
    }
    
    public class AfterRefactoring
    {
        public class Order 
        {
            // ...
            public double Price() 
            {
                // Ok, we have a class that is responsible for calculating the price.
                // more extensible, isn't it?
                return new PriceCalculator(this).Compute();
            }
        }

        // Hello price calculator, so you get an order and try to calculate the price? cool!
        // Do your job then, with any worries about ordering stuffs. perfect.
        public class PriceCalculator 
        {
            private double _primaryBasePrice;
            private double _secondaryBasePrice;
            private double _tertiaryBasePrice;
  
            public PriceCalculator(Order order) 
            {
                // Copy relevant information from the
                // order object.
            }
  
            public double Compute() 
            {
                // Perform long computation.
                return default;
            }
        }
    }
    
    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.ReplaceMethodWithMethodObject();
    }
}