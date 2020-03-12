using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class SpinnerService 
{
    const int minSpeed = 10;
    const int maxSpeed = 200;
    
    const int speedFactor = 50;

    GameObject RotatingCube;
    bool speeding = true;
    int currentSpeed = 0;

    public void UpdateRotationSpeed(TestSignal test)
    {
        //Debug.Log(" ####  UpdateRotationSpeed  ####   "+test.CubeToRotate.name);
        Debug.Log("  Current Speed = "+currentSpeed);

        if (currentSpeed >= maxSpeed)
        {
            speeding = false;
            Debug.Log("     speeding = false;");
        }
        if (currentSpeed <= minSpeed)
        {
            speeding = true;
            Debug.Log("     speeding = true;");
        }

        currentSpeed = (speeding == true)?(currentSpeed += speedFactor) : (currentSpeed -= speedFactor);
        
        test.CubeToRotate.GetComponent<CubePrefab>().SetSpeed(currentSpeed);
    }
}
