using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DoorSceneTrigger")
        {
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.Play("SceneDoorTrigger");
            //Exprimentar se da trigger a animação do cubo 
        }
    }
}
