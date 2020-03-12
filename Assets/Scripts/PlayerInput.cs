using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    [Inject]
    IGamingKeys InputForPlayer;
    [Inject(Id ="car")]
    IGamingKeys InputForCar;

    Engine engineObj;

    /* public void PlayerInputOne(IGamingKeys plr, IGamingKeysCar car)
     {
         InputForPlayer = plr;
         InputForCar = car;
         Debug.Log("Injection complete");
     }*/
    // Start is called before the first frame update
    [Inject]
    public void Construct(Engine obj)
    {
        engineObj = obj;
    }

    void Start()
    {
        engineObj.StartEngine();
        Debug.Log("  --> State = "+engineObj.state);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InputForCar.HandleA();
            InputForPlayer.HandleA();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            InputForPlayer.HandleD();
            InputForCar.HandleD();
        }
    }
}
