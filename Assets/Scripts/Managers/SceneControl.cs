using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Olympvs
{
    public class SceneControl : MonoBehaviour
    {
        [Header ("Player Settings")]
        public GameObject player;

        [Header ("SpawnPoints")]
        public Transform[] spawns;

        void Start()
        {
            player.transform.position = spawns[GameManager.spawn].transform.position;
            player.transform.rotation = spawns[GameManager.spawn].transform.rotation;
        }
        
        void Update()
        {
            
        }
    }
}
