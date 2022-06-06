using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class DoorController : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Door")
            {
                Animator anim = other.GetComponentInChildren<Animator>();
                if(Input.GetKeyDown(KeyCode.F))
                {
                    anim.SetTrigger("OpenClose");
                }
            }
        }
    }

}

