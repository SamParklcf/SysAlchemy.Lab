using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.InlineMethod"/>
/// </summary>
public class InlineMethod : IRefactoringImplementation
{
    public class BeforeRefactoring
    {
        private bool MoreThanFiveLateDeliveries(int numberOfLateDeliveries)
        {
            return numberOfLateDeliveries > 5;
        }

        // ...
        public int GetRating()
        {
            //NOTE: Consider having such these methods too much,
            //      this will become a confusing tangle that’s hard to sort through.
            //      so by minimizing these methods, you make your code more straightforward.
            
            // BUT, yes we have a BIG BUT: if this method used in other sub-classes, it may of this reason that the
            // developer wanted to reduce code duplications and take advantage of the code reuse-ability. so be aware
            // of that.
            return MoreThanFiveLateDeliveries(6) ? 2 : 1;
        }
    }

    public class AfterRefactoring
    {
        public int GetRating(int numberOfLateDeliveries)
        {
            // More straightforward code, isn't it?
            return numberOfLateDeliveries > 5 ? 2 : 1;
        }
    }

    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.InlineMethod();
    }
}