using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Olympvs
{
    public class CavernLevelTrigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Scene")
            {
                //Adicionar nome da Scene ou numero em que a posição do nivel esta no "Scenes In Build"
               SceneManager.LoadScene(4); 
            }
        }
    }
}


