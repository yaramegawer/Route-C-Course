using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAssignment
{
    class Program
    {
        // Class-level field for scope demonstrations
        static int classField = 100;

        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           C# FUNDAMENTALS - ASSIGNMENT WITH ANSWERS                ║");
            Console.WriteLine("║                      20 Questions                                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");



            #region Question 1: Regions
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 2: REGIONS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is the purpose of #region and #endregion directives in C#? 
            //    How do they help in code organization?
            //The #region and #endregion directives in C# are used to define a collapsible section of code in editors like Visual Studio.
            //    Their main purpose is to help organize and manage large code files by allowing developers to group related code blocks together,
            //    which can then be expanded or collapsed for easier navigation.
            ////
            // ══════════════════════════════════════════════════════════════════════

            //Nested Region Example
            #region Nested Region Example
            Console.WriteLine("\n" + new string('-', 70) + "\n");
            #endregion
            #endregion

            #region Question 2: Variable Declaration - Explicit vs Implicit
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 3: VARIABLE DECLARATION - EXPLICIT VS IMPLICIT
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is the difference between explicit and implicit variable 
            //    declaration in C#? Provide examples of both.
            //  explicit declaration is when you specify the data type of a variable at the time of declaration,
            //  while implicit declaration uses the 'var' keyword, allowing the compiler to infer the type based on the assigned value.
            //
            // ══════════════════════════════════════════════════════════════════════



            // EXPLICIT DECLARATION 
            int explicitVar = 10;


            // IMPLICIT DECLARATION 
            var implicitVar = "Hello, World!";

            #endregion

            #region Question 3: Constants
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 4: CONSTANTS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Write the syntax for declaring a constant in C#. Why would you use 
            //    a constant instead of a regular variable?
            // A constant in C# is declared using the 'const' keyword followed by the data type, name, and value.
            // Constants are used instead of regular variables when you want to ensure that the value remains unchanged throughout the program,
            //
            // ══════════════════════════════════════════════════════════════════════



            // Constant examples
            const double Pi = 3.14159;

            #endregion

            #region Question 4: Class-level vs Method-level Scope
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 4: CLASS-LEVEL VS METHOD-LEVEL SCOPE
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Explain the difference between class-level scope and method-level 
            //    scope with examples.
            // A variable with class-level scope (also known as a field) is accessible from any method within the class,
            // while a variable with method-level scope (also known as a local variable) is only accessible within the method it is declared in.

            //
            // ══════════════════════════════════════════════════════════════════════


            #endregion

            #region Question 5: Block-level Scope
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 5: BLOCK-LEVEL SCOPE
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is block-level scope? Give an example showing a variable that 
            //    is only accessible within a specific block.
            // A variable with block-level scope is declared within a pair of curly braces {} and is only accessible within that block.
            //
            // ══════════════════════════════════════════════════════════════════════

            if (true)
            {
                // Block-level scope variable
                int blockVar = 50;
                Console.WriteLine($"Block-level variable inside block: {blockVar}");
            }
            #endregion

            #region Question 6: Variable Lifetime - Local vs Static
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 6: VARIABLE LIFETIME - LOCAL VS STATIC
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is variable lifetime? Explain the lifetime of local variables 
            //    vs static variables.
            // A variable's lifetime refers to the duration for which the variable exists in memory during program execution.
            // A local variable's lifetime is limited to the execution of the method in which it is declared,
            // while a static variable's lifetime spans the entire duration of the program, retaining its value between method calls.
            //
            // ══════════════════════════════════════════════════════════════════════


            #endregion

            #region Question 7: Garbage Collector
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 7: GARBAGE COLLECTOR
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is the Garbage Collector in C#? How does it affect the 
            //    lifetime of objects?
            // A: The Garbage Collector (GC) in C# is an automatic memory management feature that
            //    periodically frees up memory occupied by objects that are no longer in use or referenced by the application.
            //
            // ══════════════════════════════════════════════════════════════════════


            #endregion

            #region Question 8: Variable Shadowing
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 8: VARIABLE SHADOWING
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What is variable shadowing in C#? Does C# allow shadowing in 
            //    nested blocks within the same method?
            // A: Variable shadowing occurs when a variable declared in the inner scope
            //    has the same name as a variable in an outer scope, effectively "hiding" the outer variable within the inner scope.
            //  No it does not allow shadowing in nested blocks within the same method.
            //
            // ══════════════════════════════════════════════════════════════════════

            #endregion

            #region Question 9: C# Naming Rules
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 9: C# NAMING RULES
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: List five rules that must be followed when naming variables in C#.
            // A: 1. Variable names must start with a letter or an underscore (_).
            //    2. Variable names can only contain letters, digits, and underscores.
            //    3. Variable names cannot be the same as C# reserved keywords.
            //    4. Variable names are case-sensitive.
            //    5. Variable names should be descriptive and meaningful.
            //      
            //
            // ══════════════════════════════════════════════════════════════════════

            #endregion
            #region Question 10: Naming Conventions
            // ══════════════════════════════════════════════════════════════════════
            //QUESTION 10: NAMING CONVENTIONS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: What naming conventions are recommended for: (a) local variables, 
            //    (b) class names, (c) constants?
            // A: (a) Local variables: camelCase (e.g., myVariable)
            //    (b) Class names: PascalCase (e.g., MyClass)
            //    (c) Constants: PascalCase  (e.g., MyConstant )
            //
            // ══════════════════════════════════════════════════════════════════════
            #endregion

            #region Question 11: Error Types
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 11: ERROR TYPES
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Compare and contrast syntax errors, runtime errors, and logical 
            //    errors. Provide an example of each.


            //Definition: Errors caused by violating the rules of the programming language grammar. The code cannot be compiled or interpreted.

            // When detected: Usually detected at compile-time or before execution.

            // Example: Missing a comma or a keyword.

            //SELECT FirstName LastName FROM Researcher; --Missing comma between columns(Syntax error)

            //2.Runtime Errors

            //Definition: Errors that occur while the program is running, causing it to crash or behave unexpectedly.

            //When detected: During execution.

            //Example: Dividing by zero or accessing a null object.

            //SELECT 10 / 0 AS Result; --Runtime error: division by zero

            //3.Logical Errors

            //Definition: The code runs without crashing but produces incorrect or unintended results due to flawed logic.

            //When detected: Only when the program behaves incorrectly or results are wrong.

            //Example: Using WHERE Age > 30 when you meant Age >= 30.

            //SELECT * FROM Researcher WHERE Age > 30; --Might exclude researchers exactly 30 year
            // ══════════════════════════════════════════════════════════════════════

            #endregion

            #region Question 12: Exception Handling Importance
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 12: EXCEPTION HANDLING IMPORTANCE
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Why is exception handling important in C#? What would happen if 
            //    you don't handle exceptions?

            //Ans
            //Exception handling is important in C# because it allows programs to gracefully handle unexpected errors or conditions without crashing abruptly.
            //    By catching and managing exceptions, developers can provide meaningful error messages, perform necessary cleanup, and maintain application stability. 
            //    Without exception handling, unhandled errors cause the program to terminate unexpectedly, leading to poor user experience and potential data loss. 
            //    Therefore, proper exception handling improves reliability and robustness of applications.
            //
            // ══════════════════════════════════════════════════════════════════════


            #endregion

            #region Question 13: try-catch-finally
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 13: TRY-CATCH-FINALLY
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Write a code example demonstrating try-catch-finally. Explain when 
            //    the finally block executes.
            //
            // ══════════════════════════════════════════════════════════════════════

            try {                
                int result = 10 / 0; 
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Caught an exception: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("This block executes regardless of whether an exception was thrown or caught.");
            }

            #endregion

            #region Question 14: Common Built-in Exceptions
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 14: COMMON BUILT-IN EXCEPTIONS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: List and explain five common built-in exceptions in C# with 
            //    scenarios when each would occur.
            //1. NullReferenceException: Occurs when you try to access a member on a null object reference.
            //2. IndexOutOfRangeException: Occurs when you try to access an index that is outside the bounds of an array or collection.
            //3. DivideByZeroException: Occurs when you attempt to divide an integer by zero.
            //4. FormatException: Occurs when a string is not in the correct format for parsing.
            //5. InvalidOperationException: Occurs when a method call is invalid for the object's current state.
            //
            // ══════════════════════════════════════════════════════════════════════
            #endregion

            #region Question 15: Multiple catch Blocks
            // ══════════════════════════════════════════════════════════════════════
            // QUESTION 15: MULTIPLE CATCH BLOCKS
            // ══════════════════════════════════════════════════════════════════════
            //
            // Q: Why is the order of catch blocks important when handling multiple 
            //    exceptions? Write code showing correct ordering.
            // A: The order of catch blocks is important because C# evaluates them from top to bottom, and the first block that matches the exception type will be executed.
            //    If a more general exception type is placed before a more specific one, the specific catch block will never be reached, leading to incorrect exception handling.
            //    Correct ordering ensures that specific exceptions are caught before general ones, allowing for more precise error handling.
            // Example of correct ordering:
            try
            {
                             
                int result = 10 / 0; 
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Caught a DivideByZeroException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught a general exception: {ex.Message}");
                //
                // ══════════════════════════════════════════════════════════════════════

                #endregion

                #region Question 16: throw Keyword
                // ══════════════════════════════════════════════════════════════════════
                // QUESTION 16: THROW KEYWORD
                // ══════════════════════════════════════════════════════════════════════
                //
                // Q: What is the difference between 'throw' and 'throw ex' when 
                //    re-throwing an exception? Which one preserves the stack trace?
                // A: 'throw' re-throws the current exception while preserving the original stack trace,
                // allowing you to see where the exception was originally thrown.
                // 'throw ex' creates a new exception instance and resets the stack trace to the point of the re-throw, losing the original context of where the error occurred.
                // throw preserves the stack trace, while throw ex does not.
                //
                // ══════════════════════════════════════════════════════════════════════
                #endregion

                #region Question 17: Stack and Heap Memory
                // ══════════════════════════════════════════════════════════════════════
                // QUESTION 17: STACK AND HEAP MEMORY
                // ══════════════════════════════════════════════════════════════════════
                //
                // Q: Explain the differences between Stack and Heap memory in C#. 
                //    What types of data are stored in each?
                // A: Stack memory is a region of memory that stores value types and reference type references,
                // while heap memory is a region that stores reference type objects.
                // Value types (e.g., int, double, struct) are stored directly on the stack,
                // while reference types (e.g., class instances, arrays) are stored on the heap, with their references stored on the stack.
                //
                // ══════════════════════════════════════════════════════════════════════


                #endregion

                #region Question 18: Value Types vs Reference Types
                // ══════════════════════════════════════════════════════════════════════
                // QUESTION 18: VALUE TYPES VS REFERENCE TYPES
                // ══════════════════════════════════════════════════════════════════════
                //
                // Q: Write a code example showing how value types and reference types 
                //    behave differently when assigned to another variable.
                // A: When a value type is assigned to another variable, a copy of the value is created, and the two variables are independent of each other.
                // When a reference type is assigned to another variable, both variables reference the same object in memory, and changes to one variable will affect the other.

                int valueA = 10; // Value type
                int valueB = valueA; // Copy of valueA
                valueB = 20; // Changing valueB does not affect valueA
                console.WriteLine($"ValueA: {valueA}, ValueB: {valueB}"); // Output: ValueA: 10, ValueB: 20

                int [] arrayA = { 1, 2, 3 }; // Reference type
                int [] arrayB = arrayA; // Both arrayA and arrayB reference the same array
                arrayB[0] = 10; // Changing arrayB affects arrayA
                Console.WriteLine($"ArrayA[0]: {arrayA[0]}, ArrayB[0]: {arrayB[0]}"); // Output: ArrayA[0]: 10, ArrayB[0]: 10

                //
                // ══════════════════════════════════════════════════════════════════════

                #endregion

                #region Question 19: Object in C#
                // ══════════════════════════════════════════════════════════════════════
                // QUESTION 19: OBJECT IN C#
                // ══════════════════════════════════════════════════════════════════════
                //
                // Q: Why is 'object' considered the base type of all types in C#? 
                //    What methods does every type inherit from System.Object?
                // A: 'object' is considered the base type of all types in C# because every type, whether value or reference, ultimately derives from System.Object.
                // Every type in C# inherits methods from System.Object, including:
                // 1. ToString(): Returns a string representation of the object.
                // 2. Equals(object obj): Determines whether the specified object is equal to the current object.
                // 3. GetHashCode(): Serves as the default hash function.
                // 4. GetType(): Gets the Type of the current instance.
                //
                // ══════════════════════════════════════════════════════════════════════

                #endregion

            }


#endregion
        }


}