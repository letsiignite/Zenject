using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZenjectSample;

public class TempInstaller : MonoInstaller
{
    public GameObject cubePrefab;

    public override void InstallBindings()
    {
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
        Container.BindInterfacesTo<SpinnerService>().AsSingle();
    }

    void BindMono()
    {
        Container.Bind<Engine>().FromInstance(new Engine());
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
        Container.DeclareSignal<CubeClickedSignal>();
        
    }

    
}
