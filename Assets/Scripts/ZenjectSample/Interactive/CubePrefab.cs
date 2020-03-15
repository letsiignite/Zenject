using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace ZenjectSample
{
    public class CubePrefab : MonoBehaviour
    {

        #region Private
        private Notification notificationObj;
        private int rotationSpeed = 10;
        private string id;
        private Vector3 rotation;
        private SignalBus signalBus;
        #endregion

        [Inject]
        public void Construct(Notification obj, SignalBus signal)
        {
            notificationObj = obj;
            signalBus = signal;
        }



        private void OnDisable()
        {
            Debug.Log("   OnDisable------>  OnDisable, IDisposable");
            signalBus.Unsubscribe<SpeedSignal>(SetSpeed);
        }

       
        void Start()
        {
           
            notificationObj.notify("Cube created at -  " + Time.time);
            id = DateTime.Now.ToString();
            rotation = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
            Debug.Log("   START------>  MonoBehaviour, IInitializable");
            signalBus.Subscribe<SpeedSignal>(SetSpeed);
        }

        
        void Update()
        {

            transform.Rotate(rotation);
        }

        private void OnMouseDown()
        {
            signalBus.Fire(new CubeClickedSignal() { currentSpeed = rotationSpeed, targetId = id });
           
        }

        public void SetSpeed(SpeedSignal speedSignal) // update rotation speed accordingly
        {
            if (speedSignal.targetId != id)
            {
                return;
            }
            rotationSpeed = speedSignal.newSpeedValue;
            if (rotationSpeed < 10)
            {
                rotationSpeed = 10;
            }
            rotation.y = rotationSpeed * Time.deltaTime;

            Debug.Log("   Updated speed = " + rotationSpeed);
        }
        public class Factory : PlaceholderFactory<CubePrefab>
        {
        }
    }

}


