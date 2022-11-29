using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesRecap : MonoBehaviour
{
    // Variables are containers that store data. Let's declare some

    int integerVariable; 
    // int stands for "integer". An integer variable can store integer numbers (e.g. -2, -1, 0, 1, 2, 420)

    float floatingPointVariable; 
    // float stands for "floating point". It's computer science gibberish to say "decimal number" (e.g. 1.2f, 0.1f, <-- yes use the f)

    double doubleVariable;
    // double has the same function as float, but it is a bigger container, thus it is used when more precision is required

    char characterVariable;
    // char stands for "character", such as 'a' or 'F', not like "Frodo" or "Obi-Wan"

    string stringVariable;
    // a string stores text. Yes, this time we can put "Obi-Wan" in it

    /* The words you see in blue are "keywords" and they do have a specific meaning to the compiler, 
        in this case the compiler understands that you want to create a variable of the specified type. 
        The full syntaxt to declare variables is:
    
            {Access modifier} [variable type] [name of the variable] [= variable initialization value];

        Let's see some examples
     */

    private float g = 9.81f; 

    private int nice = 69;

    public double pi = 3.14159265359f;

    char respect = 'F'; // <-- yes, for char initialization you use the single quotation marks

    public string helloWorld = "H"; // <-- for strings the double quotation mark 

    string notInitialized;

    /* You can either choose to initialize (i.e. giving a value during declaration) or to leave empty. 
        Whenever you don't specify the access modifier the compiler will go for "private". 
        In C# you use the "lowerCamelCase" convention, which means that when you name variables, you always start 
        with a lowercase letter and you stick words together by distinguishing them by uppercase letters.

        private string lazyVariableName;
        
    */

    void Start()
    {
        // Variable are containers of variable values (surprised?). Thus you will be able to change them whenever you want

        integerVariable = 69;
        floatingPointVariable = 69.420f;
        doubleVariable = 0.177013;
        characterVariable = 'E';
        stringVariable = "Hello there";

        Debug.Log(integerVariable);
        Debug.Log(floatingPointVariable);
        Debug.Log(doubleVariable);
        Debug.Log(characterVariable);
        Debug.Log(stringVariable);

        Debug.Log("The value of gravitation acceleration is " + g);
        Debug.Log(nice);
        Debug.Log(pi * 2);
        Debug.Log(respect);
        Debug.Log(helloWorld);
        Debug.Log(notInitialized);
    }
}
