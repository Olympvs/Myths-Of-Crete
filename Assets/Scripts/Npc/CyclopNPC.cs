using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class CyclopNPC : MonoBehaviour
    {
        Animator animator;

        private void Awake() 
        {
            animator = GetComponentInChildren<Animator>();
        }
    }
}
