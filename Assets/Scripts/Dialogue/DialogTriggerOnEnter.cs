using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class DialogTriggerOnEnter : MonoBehaviour
    {
        PlayerManager playerManager;
        public Dialogue dialogue;
        public int condition;

        private void OnTriggerEnter(Collider other) 
        {
            if (other.tag == "Player" && ScoreAndStates.missionScore == condition)
            {
                playerManager = other.GetComponent<PlayerManager>();

                TriggerDialogue();
                
                if (ScoreAndStates.missionScore == 2)
                {
                    StartCoroutine(WaitDialogue(2f));
                    StartCoroutine(WaitDialogue(4f));
                    StartCoroutine(WaitDialogue(8f));
                    StartCoroutine(WaitDialogue(13f));
                }
                else if (ScoreAndStates.missionScore == 3)
                {
                    StartCoroutine(WaitDialogue(5f));
                    StartCoroutine(WaitDialogue(8f));
                    StartCoroutine(WaitDialogue(10f));
                    StartCoroutine(WaitDialogue(15f));
                }
                else if (ScoreAndStates.missionScore == 4)
                {
                    StartCoroutine(WaitDialogue(3f));
                    StartCoroutine(WaitDialogue(6f));
                    StartCoroutine(WaitDialogue(9f));
                }
                
            }
            
        }

        

        IEnumerator WaitDialogue(float a)
        {
            yield return new WaitForSecondsRealtime(a);
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }

        private void OnTriggerExit(Collider other) 
        {
            playerManager.isDialog = false;
        }

        public void TriggerDialogue()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, playerManager);
        }
    }
}
