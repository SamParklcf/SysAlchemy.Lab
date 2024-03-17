﻿namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: A class has a field that contains type code. The values of this type aren’t used in operator conditions and don’t affect the behavior of the program. <para/>
/// Solution: Create a new class and use its objects instead of the type code values. <para/>
/// See also <a href="https://refactoring.guru/replace-type-code-with-class">replace-type-code-with-class</a><para/>
/// What’s type code?
/// Type code occurs when,
/// instead of a separate data type, you have a set of numbers or strings that form a list of allowable values for some entity.
/// Often these specific numbers and strings are given understandable names via constants,
/// which is the reason for why such type code is encountered so much.
/// </summary>
public class ReplaceTypeCodeWithClass : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Type Code with Class";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return
            $"A class has a field that contains type code. The values of this type aren’t used in operator conditions " +
            $"and don’t affect the behavior of the program.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return $"Create a new class and use its objects instead of the type code values.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"One of the most common reasons for type code is working with databases, when a database has fields " +
            $"in which some complex concept is coded with a number or string." +
            $"{Environment.NewLine}" +
            $"For example, you have the class User with the field user_role, which contains information " +
            $"about the access privileges of each user, whether administrator, editor, or ordinary user. " +
            $"So in this case, this information is coded in the field as A, E, and U respectively." +
            $"{Environment.NewLine}" +
            $"What are the shortcomings of this approach? The field setters often don’t check which value is sent, " +
            $"which can cause big problems when someone sends unintended or wrong values to these fields." +
            $"{Environment.NewLine}" +
            $"In addition, type verification is impossible for these fields. It’s possible to send " +
            $"any number or string to them, which won’t be type checked by your IDE and even allow your program " +
            $"to run (and crash later).";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- We want to turn sets of primitive values—which is what coded types are—into full-fledged classes " +
            $"with all the benefits that object-oriented programming has to offer." +
            $"{Environment.NewLine}" +
            $"- By replacing type code with classes, we allow type hinting for values passed to methods and fields " +
            $"at the level of the programming language." +
            $"{Environment.NewLine}" +
            $"For example, while the compiler previously did’t see difference between your numeric constant " +
            $"and some arbitrary number when a value is passed to a method, now when data that does’t " +
            $"fit the indicated type class is passed, you’re warned of the error inside your IDE." +
            $"{Environment.NewLine}" +
            $"- Thus we make it possible to move code to the classes of the type. " +
            $"If you needed to perform complex manipulations with type values throughout the whole program, " +
            $"now this code can “live” inside one or multiple type classes.";
    }

    /// <inheritdoc/>
    public string WhenNotToUse()
    {
        return
            $"If the values of a coded type are used inside control flow structures (if, switch, etc.)" +
            $" and control a class behavior, you should use one of the two refactoring techniques for type code:" +
            $"{Environment.NewLine}" +
            $"- Replace Type Code with Subclasses" +
            $"{Environment.NewLine}" +
            $"- Replace Type Code with State/Strategy";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return
            $"1. Create a new class and give it a new name that corresponds to the purpose of the coded type. " +
            $"Here we’ll call it type class." +
            $"{Environment.NewLine}" +
            $"2. Copy the field containing type code to the type class and make it private. " +
            $"Then create a getter for the field. A value will be set for this field only from the constructor." +
            $"{Environment.NewLine}" +
            $"3. For each value of the coded type, create a static method in type class. " +
            $"It’ll be creating a new type class object corresponding to this value of the coded type." +
            $"{Environment.NewLine}" +
            $"4. In the original class, replace the type of the coded field with type class. " +
            $"Create a new object of this type in the constructor as well as in the field setter. " +
            $"Change the field getter so that it calls the type class getter." +
            $"{Environment.NewLine}" +
            $"5. Replace any mentions of values of the coded type with calls of the relevant type class static methods." +
            $"{Environment.NewLine}" +
            $"6. Remove the coded type constants from the original class.";
    }
}