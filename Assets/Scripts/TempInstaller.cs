﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TempInstaller : MonoInstaller
{
    public GameObject cubePrefab;
   
    public override void InstallBindings()
    {
        // base.InstallBindings();

        BindInterfaces();
        BindMono();
        BindFactory();
        BindSignals();
    }

    void BindInterfaces()
    {
        Container.Bind<IGamingKeys>().To<PlayerMovement>().AsSingle();
        Container.Bind<IGamingKeys>().WithId("car").To<CarMovement>().AsSingle();
    }

    void BindMono()
    {
        Container.Bind<Engine>().FromInstance(new Engine());
        Container.Bind<SpinnerService>().FromInstance(new SpinnerService());
        Container.Bind<Notification>().FromInstance(GameObject.Find("GameObject").GetComponent<Notification>());
    }

    void BindFactory()
    {
        Container.BindFactory<CubePrefab, CubePrefab.Factory>().FromComponentInNewPrefab(cubePrefab);
    }

    void BindSignals()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<TestSignal>();
        Container.BindSignal<TestSignal>().ToMethod<SpinnerService>(x => x.UpdateRotationSpeed).FromResolve();
        //Container.BindSignal<TestSignal>().ToMethod(() => Debug.Log("  ----->>  Received TestSignal signal"));
    }

}
