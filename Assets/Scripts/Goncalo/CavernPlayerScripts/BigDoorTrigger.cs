using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class BigDoorTrigger : MonoBehaviour
    {

        public AudioSource source;
        public AudioClip doorOpening;

         private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "DoorSceneTrigger")
            {
                Animator anim = other.GetComponentInChildren<Animator>();
                source.PlayOneShot(doorOpening);
                anim.Play("SceneTriggerDoor");
                //Exprimentar se da trigger a animação do cubo 
            }
        }
    }
}


