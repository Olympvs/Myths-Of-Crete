using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class Pearl : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) 
        {
            if (other.tag == "Player" && ScoreAndStates.missionScore == 4)
            {
                ScoreAndStates.missionScore++;
                Destroy(gameObject);
            }
        }
    }
}
