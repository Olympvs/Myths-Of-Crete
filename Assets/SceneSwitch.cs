using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Olympvs
{
    public class SceneSwitch : MonoBehaviour
    {
        public int numberScene;

        private void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene(numberScene);
        }
    }
}
