using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Text notificationText;
   

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
