using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Olympvs 
{
    public class DialogueManager : MonoBehaviour
    {
        public Text nameText;
        public Text dialogueText;

        public Animator animator;

        PlayerManager playerManager;

        private Queue<string> sentences;

        void Start()
        {
            sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue, PlayerManager playerManagerX) 
        {
            playerManager = playerManagerX;
            animator.SetBool("IsOpen", true);
            Debug.Log("Starting conversation with " + dialogue.name);

            nameText.text = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences) 
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialog();
                return;
            }

            string sentence = sentences.Dequeue();
            Debug.Log(sentence);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }

        void EndDialog()
        {
            if (ScoreAndStates.missionScore == 1)
            {
                playerManager.isSpeaking = false;
                Debug.Log(playerManager.isInteracting);
                Debug.Log("End of conversation.");
                animator.SetBool("IsOpen", false);
                ScoreAndStates.missionScore++;
            }
            else if (ScoreAndStates.missionScore == 2)
            {
                playerManager.isSpeaking = false;
                Debug.Log(playerManager.isInteracting);
                Debug.Log("End of conversation.");
                animator.SetBool("IsOpen", false);
                ScoreAndStates.missionScore++;
            }
            else if (ScoreAndStates.missionScore == 3)
            {
                playerManager.isSpeaking = false;
                Debug.Log(playerManager.isInteracting);
                Debug.Log("End of conversation.");
                animator.SetBool("IsOpen", false);
                ScoreAndStates.missionScore++;
            }
            else
            {
                playerManager.isSpeaking = false;
                Debug.Log(playerManager.isInteracting);
                Debug.Log("End of conversation.");
                animator.SetBool("IsOpen", false);
                //ScoreAndStates.missionScore++;
            }
            
        }
    }
}
