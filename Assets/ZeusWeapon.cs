using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class ZeusWeapon : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) 
        {
            if (other.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
