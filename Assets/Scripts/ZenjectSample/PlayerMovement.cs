using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : IGamingKeys
{
    public void HandleA()
    {
        Debug.Log("Moving player Left");
    }

    public void HandleD()
    {
        Debug.Log("Moving player Right");
    }

    public void HandleS()
    {
        Debug.Log("Moving player Back");
    }

    public void HandleW()
    {
        Debug.Log("Moving player Forword");
    }

    
}
