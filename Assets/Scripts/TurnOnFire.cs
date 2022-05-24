using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnFire : MonoBehaviour
{
    public GameObject light;
    private bool TriggerArea;

    private void Start()
    {
        TriggerArea = false;    //Player by default is not within the trigger zone
    }

    private void Update()
    {
        if (TriggerArea && Input.GetKeyDown(KeyCode.F))    //If in the zone and press F key
        {
            light.SetActive(!light.activeSelf); 
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")   //If the player in the zone 
        {                                       
            TriggerArea = true;                 //Can trigger the fire switch
        }
        
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")  //If the player exits the zone
        {
            TriggerArea = false;                //Can't trigger the fire switch
        }
    }
}
