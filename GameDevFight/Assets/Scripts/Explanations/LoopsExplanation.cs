using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopsExplanation : MonoBehaviour
{
    /* We programmers really like to write as few lines as possible 
      
       Sometimes we need the same operation to be applied a certain number of times. 

       Are we gonna write those certain number of lines? NOPE */


    // WELCOME TOOOO LOOOOOPPSS (loops)

    void Start()
    {
        // The FOR loop!
        
        for (int i = 0; i < 10; i = i + 2)
        {
            Debug.Log("Cookie " + i);
        }

        /*
            for (statement 1; statement 2; statement 3) 
            {
                // code block to be executed
            }

            Statement 1 is executed one time before the first execution of the code block.

            Statement 2 defines the condition for exiting the loop.

            Statement 3 is executed after each itreration of the code block.
        */




        for (int i = 3; i <= 12; i+=3)
        {
            Debug.Log("The number is " + i);
        }



        for (int i = 50; i > 1; i--)
        {
            Debug.Log("In Italy....");
        }


        // The WHILE loop!

        int countdown = 10;

        while (countdown > 0)
        {
            Debug.Log(countdown + "!");

            countdown--;
        }

        /*
            while (condition) 
            {
                // code block to be executed
            }

            As long as the condition is not met, the code block whill be executed
        */



        // The DO WHILE loop

        countdown = 0;

        do
        {
            Debug.Log(countdown + "!");

            countdown--;
        } while (countdown > 0);


        // The FOR EACH

        int[] numbers = { 0, 1, 2, 3, 4, 5 };

        foreach (int number in numbers)
        {
            Debug.Log(number);
        }

    }

}
