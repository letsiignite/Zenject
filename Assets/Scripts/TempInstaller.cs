using System;
using System.Collections;
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
        Container.BindInterfacesTo<SceneManagerScript>().AsSingle();
    }

    void BindMono()
    {
        Container.Bind<Engine>().FromInstance(new Engine());
        //Container.Bind<SpinnerService>().FromInstance(new SpinnerService());
        Container.Bind<SpinnerService>().AsSingle();
        Container.Bind<Spawner>().FromInstance(GameObject.Find("GameObject").GetComponent<Spawner>());
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
        Container.DeclareSignal<SpeedSignal>();
        Container.BindSignal<TestSignal>().ToMethod<SpinnerService>(x => x.UpdateRotationSpeed).FromResolve();
        //Container.BindSignal<SpeedSignal>().ToMethod<Spawner>(x=>x.UpdateTheSpeed).FromResolve();
        //Container.BindSignal<SpeedSignal>().ToMethod<CubePrefab>(x => x.SetSpeed).FromResolve();

        //Container.BindSignal<SpeedSignal>().ToMethod<CubePrefab>((Factory, x) => Factory.SetSpeed(x)).FromResolve();
        //                                                                      Trying to find a way to bind  CubePrefab from the spawned instance of prefab.

        //Container.BindSignal<TestSignal>().ToMethod(() => Debug.Log("  ----->>  Received TestSignal signal"));
    }

    
}
