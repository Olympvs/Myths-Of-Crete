using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Olympvs
{
    public class MenuManager : MonoBehaviour
    {
        [Header ("Scene Names")]
        public string startScene;
        public string leftIsland;
        public string rightIsland;
        public string cave;
        public string BossCave;
        public string mountain;
        public string controlScene;

        public void NewGame() 
        {
            GameManager.spawn = 0;
            SceneManager.LoadScene(startScene, LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ControlScene()
        {
            SceneManager.LoadScene(controlScene, LoadSceneMode.Single);
        }
    }
}
