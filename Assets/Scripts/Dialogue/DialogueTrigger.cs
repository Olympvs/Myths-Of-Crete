using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Olympvs
{
   public class DialogueTrigger : MonoBehaviour
    {
        InputHandler inputHandler;
        PlayerManager playerManager;
        public Dialogue dialogue;
        public GameObject popUp;
        public Text popUpText;
        public QuestGiver questGiver;

        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            questGiver = FindObjectOfType<QuestGiver>();
        }

        void Update() 
        {
        }

        private void LateUpdate() 
        {
            //inputHandler.a_Input = false;
        }

        private void OnTriggerEnter(Collider other) 
        {
            if (other.tag == "Player")
            {
                playerManager = other.GetComponent<PlayerManager>();
                popUpText.text = "Press F to Talk";
                popUp.SetActive(true);
                playerManager.isDialog = true;
            }
        }
        
        private void OnTriggerStay(Collider other) 
        {
            
        }

        private void OnTriggerExit(Collider other) 
        {
            popUp.SetActive(false);
            playerManager.isDialog = false;
        }

        public void TriggerDialogue()
        {
            popUp.SetActive(false);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, playerManager);
            questGiver.OpenQuestWindow();
            questGiver.AcceptQuest();
        }
    } 
}
