using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFixedUpdateExplanation : MonoBehaviour
{
    private void Awake()
    {
        /* Whenever a script is loaded, Awake is the first function to be called.
         * Awake is called even if the script component is not enabled.
         * 
         * It is usually used to set up references between scripts and for initialization.
         */

        Debug.Log("Awake");
    }

    void DoSomething()
    {
        Debug.Log("DoSometing");
    }

    private void Start()
    {
        /* Start is called after Awake and immidietly before the first Update, 
         * but only if the script component is enabled. 
         */
        DoSomething();
        Debug.Log("Start");
    }

    private void Update()
    {
        /* Update is called every frame.
         * It is usually used for regular updates such as:
         * - moving non-physics objetcs
         * - simple timers
         * - receiving input 
         * 
         * Unfortunatly, the intervals of time between the Update calls can vary according to the variable frame rate
         */

        Debug.Log("Update time: " + Time.deltaTime);

    }

    private void FixedUpdate()
    {
        /* FixedUpdate is similar to Update but instead of being called every frame, it is called every physiscs step.
         * Thus the intervals of time are consistent.
         * 
         * FixedUpdate is usually used for adjusting physics (Rigidbody) objects
         */

        Debug.Log("FixedUpdate time: " + Time.deltaTime);
    }
}
