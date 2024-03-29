﻿namespace SysAlchemy.Lab.Refactoring.Definitions.RefactoringTechniques.OrganizingData;

/// <summary>
/// Problem: You have a coded type that affects behavior but you can’t use subclasses to get rid of it. <para/>
/// Solution: Replace type code with a state object. If it’s necessary to replace a field value with type code, another state object is “plugged in”. <para/>
/// See also <a href="https://refactoring.guru/replace-type-code-with-state-strategy">replace-type-code-with-state-strategy</a><para/>
/// What’s type code?
/// Type code occurs when,
/// instead of a separate data type, you have a set of numbers or strings that form a list of allowable values for some entity.
/// Often these specific numbers and strings are given understandable names via constants,
/// which is the reason for why such type code is encountered so much.
/// </summary>
public class ReplaceTypeCodeWithStateOrStrategy : IRefactoringTechniquesInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Replace Type Code with State/Strategy";
    }

    /// <inheritdoc/>
    public string Problem()
    {
        return $"You have a coded type that affects behavior but you can’t use subclasses to get rid of it.";
    }

    /// <inheritdoc/>
    public string Solution()
    {
        return
            $"Replace type code with a state object. If it’s necessary to replace a field value with type code," +
            $" another state object is “plugged in”.";
    }

    /// <inheritdoc/>
    public string WhyRefactor()
    {
        return
            $"You have type code and it affects the behavior of a class, therefore we can’t use Replace Type Code with Class." +
            $"{Environment.NewLine}" +
            $"Type code affects the behavior of a class but we can’t create subclasses for the coded type " +
            $"due to the existing class hierarchy or other reasons. " +
            $"Thus means that we can’t apply Replace Type Code with Subclasses.";
    }

    /// <inheritdoc/>
    public string Benefits()
    {
        return
            $"- This refactoring technique is a way out of situations when a field with a coded type changes " +
            $"its value during the object’s lifetime. In this case, replacement of the value is made " +
            $"via replacement of the state object to which the original class refers." +
            $"{Environment.NewLine}" +
            $"- If you need to add a new value of a coded type, all you need to do is to add a new state subclass " +
            $"without altering the existing code (cf. the Open/Closed Principle).";
    }

    /// <inheritdoc/>
    public string Drawbacks()
    {
        return
            $"If you have a simple case of type code but you use this refactoring technique anyway, " +
            $"you will have many extra (and unneeded) classes.";
    }

    /// <inheritdoc/>
    public string GoodToKnow()
    {
        return
            $"Implementation of this refactoring technique can make use of one of two design patterns: State or Strategy. " +
            $"Implementation is the same no matter which pattern you choose. " +
            $"So which pattern should you pick in a particular situation?" +
            $"{Environment.NewLine}" +
            $"If you’re trying to split a conditional that controls the selection of algorithms, use Strategy." +
            $"{Environment.NewLine}" +
            $"But if each value of the coded type is responsible not only for selecting an algorithm " +
            $"but for the whole condition of the class, class state, field values, and many other actions, " +
            $"State is better for the job.";
    }

    /// <inheritdoc/>
    public string HowToRefactor()
    {
        return $"1. Use Self Encapsulate Field to create a getter for the field that contains type code." +
               $"{Environment.NewLine}" +
               $"2. Create a new class and give it an understandable name that fits the purpose of the type code. " +
               $"This class will be playing the role of state (or strategy). In it, create an abstract coded field getter." +
               $"{Environment.NewLine}" +
               $"3. Create subclasses of the state class for each value of the coded type. " +
               $"In each subclass, redefine the getter of the coded field so that it returns the corresponding value " +
               $"of the coded type." +
               $"{Environment.NewLine}" +
               $"4. In the abstract state class, create a static factory method that accepts the value " +
               $"of the coded type as a parameter. Depending on this parameter, " +
               $"the factory method will create objects of various states. For this, " +
               $"in its code create a large conditional; it’ll be the only one when refactoring is complete." +
               $"{Environment.NewLine}" +
               $"5. In the original class, change the type of the coded field to the state class. " +
               $"In the field’s setter, call the factory state method for getting new state objects." +
               $"{Environment.NewLine}" +
               $"6. Now you can start to move the fields and methods from the superclass to " +
               $"the corresponding state subclasses (using Push Down Field and Push Down Method)." +
               $"{Environment.NewLine}" +
               $"7. When everything movable has been moved, use 'Replace Conditional with Polymorphism' " +
               $"in order to get rid of conditionals that use type code once and for all.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}