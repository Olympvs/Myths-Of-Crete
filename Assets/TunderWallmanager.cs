using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class TunderWallmanager : MonoBehaviour
    {
        public GameObject enemie1;
        public GameObject enemie2;
        public GameObject enemie3;
        public GameObject enemie4;
        public GameObject enemie5;

        private void Update() 
        {
            if (enemie1 == null && enemie2 == null && enemie3 == null && enemie4 == null && enemie5 == null)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
