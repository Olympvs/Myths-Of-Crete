using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Olympvs
{
    public class Mountain : MonoBehaviour
    {
        public int numberScene;
        public int spawnPoint;
        
        private void Update() 
        {
            if (ScoreAndStates.missionScore == 2)
            {
                GameManager.spawn = spawnPoint;
                SceneManager.LoadScene(numberScene);
            }
        }
    }
}
