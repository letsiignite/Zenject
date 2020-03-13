using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CubePrefab : MonoBehaviour
{
    Notification notificationObj;
    int rotationSpeed = 10;
    Vector3 rotation;
    SignalBus signalBus;
    [Inject]
    public void Construct(Notification obj, SignalBus signal)
    {
        notificationObj = obj;
        signalBus = signal;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject .name+" -  Created -  "+Time.time);
        notificationObj.notify("Cube created at -  "+Time.time);
        rotation = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(rotation);
    }

    private void OnMouseDown()
    {
        //Debug.Log("  CLICKED");
        signalBus.Fire(new TestSignal() { CubeToRotate = this.gameObject });
        //Debug.Log("Fired signal");
    }

    public void SetSpeed(int newSpeed)
    {
       
        if (newSpeed < 10)
        {
            newSpeed = 10;
        }
        rotation.y = newSpeed * Time.deltaTime;
        
        Debug.Log("   Updated speed = " + newSpeed);
    }
    public class Factory : PlaceholderFactory<CubePrefab>
    {
    }
}



/*
 * cube floats and rotates. 
 * service(Iinitializable)
 * cube shoud send a signal onclick.
 * Signal checks speed, if more than 100 -reduce or less than 10 to speed up
 * Service sends signal to rotate speed.
 * 
 * */
