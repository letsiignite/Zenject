using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class SpinnerService : IInitializable    // what is the need of using it. We should use it when we want something to happen on start().
{
    const int minSpeed = 10;
    const int maxSpeed = 200;
    
    const int speedFactor = 50;

    GameObject RotatingCube;
    bool speeding = true;
    int currentSpeed = 0;

    SignalBus signalBus;

    public SpinnerService(SignalBus signal)
    {
        signalBus = signal;
    }

    public void Initialize()
    {
       //                                                               I have nothing to initialize here, so left it empty
    }

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
        signalBus.Fire(new SpeedSignal() { newSpeedValue = currentSpeed});  // fire as signal to update the rotation speed.
        //test.CubeToRotate.GetComponent<CubePrefab>().SetSpeed(currentSpeed);
    }
}
