using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [Inject]
    CubePrefab.Factory cubeFactory;
    public int delay = 1;
    CubePrefab cubePrefabObj;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delay);
        float x = 0;
        float y = 0;
        float z = -5;
        GameObject tempCube = cubeFactory.Create().gameObject;
        tempCube.transform.position = new Vector3(x,y,z);
        cubePrefabObj = tempCube.GetComponent<CubePrefab>();
        //StartCoroutine(Spawn());
    }

    public void UpdateTheSpeed(SpeedSignal signal)
    {
        Debug.Log("  +++  UpdateTheSpeed  +++");
        //cubePrefabObj.SetSpeed(signal.newSpeedValue);
    }
}
