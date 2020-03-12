using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : IGamingKeys
{
    public void HandleA()
    {
        Debug.Log("Moving car Left");
    }

    public void HandleD()
    {
        Debug.Log("Moving car Right");
    }

    public void HandleS()
    {
        Debug.Log("Moving car Back");
    }

    public void HandleW()
    {
        Debug.Log("Moving car Forword");
    }

   
}
