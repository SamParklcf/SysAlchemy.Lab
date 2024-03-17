using SysAlchemy.Lab.Refactoring.Definitions;

namespace SysAlchemy.Lab.Refactoring.Implementations.RefactoringTechniques.ComposingMethods;

/// <summary>
/// This class is an implementation of
/// <see cref="SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods.ExtractVariable"/>
/// </summary>
public class ExtractVariable : IRefactoringImplementation
{
    public class BeforeRefactoring
    {
        private bool WasInitialized()
        {
            //...

            return default;
        }

        public void RenderBanner(string platform, string browser, int resize)
        {
            // Where is the readability of the code? oh, common developer!
            // The other developers need more readability of this code, aren't you?
            // It's better to have well-known variables that describe the functionality than to have so many conditions
            // checking and put some long-winded comments around the code. NO YOU SHOULD NOT DO THIS. 
            if ((platform.ToUpper().IndexOf("MAC", StringComparison.Ordinal) > -1) &&
                (browser.ToUpper().IndexOf("IE", StringComparison.Ordinal) > -1) &&
                WasInitialized() && resize > 0)
            {
                // do something
            }
        }
    }
    
    public class AfterRefactoring
    {
        private bool WasInitialized()
        {
            //...

            return default;
        }
        
        public void RenderBanner(string platform, string browser, int resize) 
        {
            //NOTE: if you have complex checking or calculations, you may need to extract this variables into
            //      separate methods, so the compiler can avoid extra calculations on the other checks.
            //      Let's see the example in another class.
            var isMacOs = platform.ToUpper().IndexOf("MAC", StringComparison.Ordinal) > -1;
            var isIE = browser.ToUpper().IndexOf("IE", StringComparison.Ordinal) > -1;
            var wasResized = resize > 0;

            if (isMacOs && isIE && WasInitialized() && wasResized) 
            {
                // do something
            }
        }
    }
    
    public class AfterRefactoringFixPerformanceImpact
    {
        private bool WasInitialized()
        {
            //...

            return default;
        }
        
        public void RenderBanner(string platform, string browser, int resize) 
        {
            //NOTE: Having methods here, can make sure that the compiler won't run the 'IsIE' and the other methods,
            //      if 'IsMacOS' method returns false, because there is no matter to resolve the other methods results,
            //      as the result of the condition will be false anyway.
            if (IsMacOs() && IsIE() && WasInitialized() && WasResized()) 
            {
                // do something
            }

            return;

            bool IsMacOs() => platform.ToUpper().IndexOf("MAC", StringComparison.Ordinal) > -1;
            bool IsIE() => browser.ToUpper().IndexOf("IE", StringComparison.Ordinal) > -1;
            bool WasResized() => resize > 0;
        }
    }

    /// <inheritdoc/>
    public IRefactoringDefinitionInstruction GetDefinitionInstruction()
    {
        return new Definitions.RefactoringTechniques.ComposingMethods.ExtractVariable();
    }
}