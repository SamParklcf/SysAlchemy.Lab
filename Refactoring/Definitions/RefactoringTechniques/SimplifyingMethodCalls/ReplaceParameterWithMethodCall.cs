namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.SimplifyingMethodCalls;

/// <summary>
/// Problem: Calling a query method and passing its results as the parameters of another method,
/// while that method could call the query directly. <para/>
/// Solution: Instead of passing the value through a parameter, try placing a query call inside the method body. <para/>
/// See also <a href="https://refactoring.guru/replace-parameter-with-method-call">replace-parameter-with-method-call</a>
/// </summary>
public class ReplaceParameterWithMethodCall : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Parameter with Method Call";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"Calling a query method and passing its results as the parameters of another method, " +
            $"while that method could call the query directly." +
            $"{Environment.NewLine}" +
            $"int basePrice = quantity * itemPrice;\ndouble seasonDiscount = this.GetSeasonalDiscount();\ndouble fees = this.GetFees();\ndouble finalPrice = DiscountedPrice(basePrice, seasonDiscount, fees);";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Instead of passing the value through a parameter, try placing a query call inside the method body." +
               $"{Environment.NewLine}" +
               $"int basePrice = quantity * itemPrice;\ndouble finalPrice = DiscountedPrice(basePrice);";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"A long list of parameters is hard to understand. In addition, " +
            $"calls to such methods often resemble a series of cascades, " +
            $"with winding and exhilarating value calculations that are hard to navigate yet have to be passed to the method. " +
            $"So if a parameter value can be calculated with the help of a method, " +
            $"do this inside the method itself and get rid of the parameter.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"We get rid of unneeded parameters and simplify method calls. " +
            $"Such parameters are often created not for the project as it’s now, " +
            $"but with an eye for future needs that may never come.";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return $"You may need the parameter tomorrow for other needs... making you rewrite the method.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Make sure that the value-getting code does’t use parameters from the current method, " +
            $"since they’ll be unavailable from inside another method. If so, moving the code isn’t possible." +
            $"{Environment.NewLine}" +
            $"2. If the relevant code is more complicated than a single method or function call, " +
            $"use Extract Method to isolate this code in a new method and make the call simple." +
            $"{Environment.NewLine}" +
            $"3. In the code of the main method, replace all references to the parameter being replaced " +
            $"with calls to the method that gets the value." +
            $"{Environment.NewLine}" +
            $"4. Use Remove Parameter to eliminate the now-unused parameter.";
    }
}