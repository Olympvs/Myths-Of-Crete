using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Olympvs
{
    public class SceneSwitch : MonoBehaviour
    {
        public int numberScene;
        public int spawnPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                GameManager.spawn = spawnPoint;
                SceneManager.LoadScene(numberScene);
            }
        }
    }
}
