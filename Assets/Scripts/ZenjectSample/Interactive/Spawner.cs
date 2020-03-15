using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace ZenjectSample
{
    public class Spawner : MonoBehaviour
    {
        [Inject]
        CubePrefab.Factory cubeFactory;
        public int delay = 1;
        CubePrefab cubePrefabObj;

      
        public void StartSpwner()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(delay);
            float x = 0;
            float y = 0;
            float z = -5;
            GameObject tempCube = cubeFactory.Create().gameObject;
            tempCube.transform.position = new Vector3(x, y, z);
            cubePrefabObj = tempCube.GetComponent<CubePrefab>();

        }

    }
}
