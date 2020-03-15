using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace ZenjectSample
{
    public class SceneManagerScript : IInitializable
    {
        Spawner spawnerObj;

        public SceneManagerScript(Spawner spawner)
        {
            Debug.Log(" SceneManager  IInitializable");
            spawnerObj = spawner;
        }
        public void Initialize()
        {
            Debug.Log("IInitializable");
            spawnerObj.StartSpwner();
        }
    }
}
