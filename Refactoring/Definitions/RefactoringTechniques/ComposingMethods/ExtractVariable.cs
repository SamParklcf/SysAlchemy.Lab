namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.ComposingMethods;

/// <summary>
/// Problem: You have an expression that’s hard to understand. <para/>
/// Solution: Place the result of the expression or its parts in separate variables that are self-explanatory. <para/>
/// See also <a href="https://refactoring.guru/extract-variable">extract-variable</a>
/// </summary>
public class ExtractVariable : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Extract Variable";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have an expression that’s hard to understand." +
               $"{Environment.NewLine}" +
               $"void RenderBanner() \n{{\n  if ((platform.ToUpper().IndexOf(\"MAC\") > -1) &&\n       (browser.ToUpper().IndexOf(\"IE\") > -1) &&\n        wasInitialized() && resize > 0 )\n  {{\n    // do something\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Place the result of the expression or its parts in separate variables that are self-explanatory." +
               $"{Environment.NewLine}" +
               $"void RenderBanner() \n{{\n  readonly bool isMacOs = platform.ToUpper().IndexOf(\"MAC\") > -1;\n  readonly bool isIE = browser.ToUpper().IndexOf(\"IE\") > -1;\n  readonly bool wasResized = resize > 0;\n\n  if (isMacOs && isIE && wasInitialized() && wasResized) \n  {{\n    // do something\n  }}\n}}";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"The main reason for extracting variables is to make a complex expression more understandable, " +
            $"by dividing it into its intermediate parts. These could be:" +
            $"{Environment.NewLine}" +
            $"- Condition of the if() operator or a part of the ?: operator in C-based languages" +
            $"{Environment.NewLine}" +
            $"- A long arithmetic expression without intermediate results" +
            $"{Environment.NewLine}" +
            $"- Long multipart lines" +
            $"{Environment.NewLine}" +
            $"Extracting a variable may be the first step towards performing Extract Method if you see that " +
            $"the extracted expression is used in other places in your code.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"More readable code! Try to give the extracted variables good names that announce the variable’s purpose loud and clear. " +
            $"More readability, fewer long-winded comments. " +
            $"Go for names like customerTaxValue, cityUnemploymentRate, clientSalutationString, etc.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"- More variables are present in your code. But this is counterbalanced by the ease of reading your code." +
            $"{Environment.NewLine}" +
            $"- When refactoring conditional expressions, remember that the compiler will most likely optimize it to " +
            $"minimize the amount of calculations needed to establish the resulting value. Say you have a following expression " +
            $"if (a() || b()) .... The program won’t call the method b if the method a returns true because " +
            $"the resulting value will still be true, no matter what value returns b." +
            $"{Environment.NewLine}" +
            $"However, if you extract parts of this expression into variables, both methods will always be called, " +
            $"which might hurt performance of the program, especially if these methods do some heavyweight work.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Insert a new line before the relevant expression and declare a new variable there. " +
               $"Assign part of the complex expression to this variable." +
               $"{Environment.NewLine}" +
               $"2. Replace that part of the expression with the new variable." +
               $"{Environment.NewLine}" +
               $"3. Repeat the process for all complex parts of the expression.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"1. The main reason for extracting variables is to make a complex expression more understandable, " +
        $"by dividing it into its intermediate parts." +
        $"{Environment.NewLine}" +
        $"2. More readable code!" +
        $"{Environment.NewLine}" +
        $"3. More readability, fewer long-winded comments. " +
        $"when you want to explain what is the purpose of the expression!!!" +
        $"{Environment.NewLine}" +
        $"4. Applying this refactoring causes More variables present in your code." +
        $"{Environment.NewLine}" +
        $"5. This refactoring technique may cause performance impacts, " +
        $"Say you have a following expression 'if (a() || b()) ....' The program won’t call the method 'b' " +
        $"if the method 'a' returns true because the resulting value will still be true, " +
        $"no matter what value returns 'b'. (Example provided in the technique implementation)";
}