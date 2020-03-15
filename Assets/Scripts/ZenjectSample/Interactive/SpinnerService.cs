using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
namespace ZenjectSample
{
    public class SpinnerService : IInitializable, IDisposable
    {
        #region private
        private const int minSpeed = 10;
        private const int maxSpeed = 200;

        private const int speedFactor = 50;

        private GameObject RotatingCube;
        private bool speeding = true;
        private int currentSpeed = 0;

        private SignalBus signalBus;
        #endregion


        public SpinnerService(SignalBus signal)
        {
            signalBus = signal;
        }

        public void Dispose()
        {
            signalBus.Unsubscribe<CubeClickedSignal>(UpdateRotationSpeed);
        }

        public void Initialize()
        {
            signalBus.Subscribe<CubeClickedSignal>(UpdateRotationSpeed);
        }

        public void UpdateRotationSpeed(CubeClickedSignal cubeClicked)
        {
            
            Debug.Log("  Current Speed = " + cubeClicked.currentSpeed);
            this.currentSpeed = cubeClicked.currentSpeed;
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

            currentSpeed = (speeding == true) ? (currentSpeed += speedFactor) : (currentSpeed -= speedFactor);
            signalBus.Fire(new SpeedSignal() { newSpeedValue = currentSpeed, targetId = cubeClicked.targetId });  
                                                                                                                  
        }
    }
}