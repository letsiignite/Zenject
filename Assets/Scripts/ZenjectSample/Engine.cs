using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Engine  : MonoBehaviour
{
    const int startState = 1;
    const int stopState = 0;
    public int state;

    public void StartEngine()
    {
        Debug.Log("  --> Before State = " + state);
        state = startState;

    }

    public void StopEngine()
    {
        state = stopState;
    }
    
}
