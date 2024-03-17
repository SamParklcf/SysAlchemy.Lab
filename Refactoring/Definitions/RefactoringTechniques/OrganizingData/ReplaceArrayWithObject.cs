namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: You have an array that contains various types of data. <para/>
/// Solution: Replace the array with an object that will have separate fields for each element. <para/>
/// See also <a href="https://refactoring.guru/replace-array-with-object">replace-array-with-object</a><para/>
/// This refactoring technique is a special case of <see cref="ReplaceDataValueWithObject"/>.
/// </summary>
public class ReplaceArrayWithObject : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Array with Object";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have an array that contains various types of data." +
               $"{Environment.NewLine}" +
               $"string[] row = new string[2];\nrow[0] = \"Liverpool\";\nrow[1] = \"15\";";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Replace the array with an object that will have separate fields for each element." +
               $"{Environment.NewLine}" +
               $"Performance row = new Performance();\nrow.SetName(\"Liverpool\");\nrow.SetWins(\"15\");";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"Arrays are an excellent tool for storing data and collections of a single type. " +
            $"But if you use an array like post office boxes, storing the username in box 1 and the user’s address in box 14, " +
            $"you will someday be very unhappy that you did. This approach leads to catastrophic failures " +
            $"when somebody puts something in the wrong “box” and also requires your time for figuring out which data is stored where.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- In the resulting class, you can place all associated behaviors that had been previously stored " +
            $"in the main class or elsewhere." +
            $"{Environment.NewLine}" +
            $"- The fields of a class are much easier to document than the elements of an array.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Create the new class that will contain the data from the array. " +
            $"Place the array itself in the class as a public field." +
            $"{Environment.NewLine}" +
            $"2. Create a field for storing the object of this class in the original class. " +
            $"Don’t forget to also create the object itself in the place where you initiated the data array." +
            $"{Environment.NewLine}" +
            $"3. In the new class, create access methods one by one for each of the array elements. " +
            $"Give them self-explanatory names that indicate what they do. At the same time, " +
            $"replace each use of an array element in the main code with the corresponding access method." +
            $"{Environment.NewLine}" +
            $"4. When access methods have been created for all elements, make the array private." +
            $"{Environment.NewLine}" +
            $"5. For each element of the array, create a private field in the class and then change the access methods " +
            $"so that they use this field instead of the array." +
            $"{Environment.NewLine}" +
            $"6. When all data has been moved, delete the array.";
    }
}