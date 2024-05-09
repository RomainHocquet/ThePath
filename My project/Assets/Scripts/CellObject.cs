using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
A CellObject can be anything that a cell own
*/
public class CellObject : MonoBehaviour
{

    //Called when the player interact with the object 
    public virtual void Interact()
    {
        Debug.Log("Subclass should implement Interact() function");

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
