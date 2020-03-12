using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text notificationText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void notify(string msg)
    {
        if (notificationText != null)
        {
            
        }
        else
        {
            //notificationText = GameObject.Find("msg").GetComponent<Text>();
            Debug.Log("------------------  Text Set  ------------------------------");
        }


        Debug.Log(" ---   Trying to notify  --> "+msg);
         
        notificationText.text = "\n"+msg;
    }
}
