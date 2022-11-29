using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraysExplanation : MonoBehaviour
{
    // An array is a sigle variable that allows you store multiple values of the same type

    // You create an array by putting "[]" after the desired variable type

    char[] someChars;

    // Like normal variables you can initialize them 

    int[] numbersUpToTen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    string[] colorNames = { "Red", "Blue", "Yellow", "Cyan", "Amogus", "Lime", "Purple" };


    void Start()
    {
        foreach (int i in numbersUpToTen)
        {
            Debug.Log(i);
        }

        // In order to access the values inside of an array you need to refer to the index number

        Debug.Log(colorNames[3]);

        // The index of the first value is ALWAYS 0 and not 1

        Debug.Log(numbersUpToTen[0]); // will return "1"


        // Just like for variables, you can change the content of an array

        colorNames[4] = "Black";

        foreach (string colorName in colorNames)
        {
            Debug.Log(colorName);
        }


        colorNames[4] = colorNames[2];

        foreach (string colorName in colorNames)
        {
            Debug.Log(colorName);
        }

        // arrays also have some properties, like for example a given length

        Debug.Log(numbersUpToTen.Length);

        // they also have few methods, but we will see this later...

        //Debug.Log(numbersUpToTen[11]);
    }

}
