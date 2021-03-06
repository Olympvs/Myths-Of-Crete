using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympvs
{
    public class PlayerManager : CharacterManager
    {
        public InputHandler inputHandler;
        Animator anim;
        CameraHandler cameraHandler;
        PlayerStats playerStats;
        PlayerLocomotion playerLocomotion;

        InteractableUI interactableUI;
        public GameObject interactableUIGameObject;
        public GameObject itemInteractableGameObject;

        public Quest quest;

        public bool isInteracting;

        [Header("Player Flags")]
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;
        public bool canDoCombo;
        public bool isUsingRightHand;
        public bool isUsingLeftHand;
        public bool isInvulnerable;
        public bool isDialog;
        public bool isSpeaking;

        private void Awake()
        {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }

        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
            playerStats = GetComponent<PlayerStats>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            interactableUI = FindObjectOfType<InteractableUI>();
            isDialog = false;
        }

        void Update()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            float delta = Time.deltaTime;
            
            isInteracting = anim.GetBool("isInteracting");
            canDoCombo = anim.GetBool("canDoCombo");
            isUsingRightHand = anim.GetBool("isUsingRightHand");
            isUsingLeftHand = anim.GetBool("isUsingLeftHand");
            isInvulnerable = anim.GetBool("isInvulnerable");
            anim.SetBool("isInAir", isInAir);

            inputHandler.TickInput(delta);
            playerLocomotion.HandleRollingAndSprinting(delta);
            playerLocomotion.HandleJumping();
            playerStats.RegenerateStamina();

            CheckForInteractableObject();
            CheckForDialog();
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            if (!isSpeaking)
            {
                playerLocomotion.HandleMovement(delta);
                playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
                

                if (cameraHandler != null)
                {
                    cameraHandler.FollowTarget(delta);
                    cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
                }
            }
            
        }

        private void LateUpdate() 
        {
            inputHandler.rollFlag = false;
            inputHandler.rb_Input = false;
            inputHandler.rt_Input = false;
            inputHandler.a_Input = false;
            inputHandler.jump_Input = false;

            if (isInAir)
            {
                playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
            }
        }

        public void CheckForInteractableObject()
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 0.4f, transform.forward, out hit, 1f, cameraHandler.ignoreLayers))
            {
                if (hit.collider.tag == "Interactable")
                {
                    Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                    if (interactableObject != null)
                    {
                        string interactableText = interactableObject.interactbleText;
                        interactableUI.interactableText.text = interactableText;
                        interactableUIGameObject.SetActive(true);

                        if (inputHandler.a_Input)
                        {
                            hit.collider.GetComponent<Interactable>().Interact(this);
                        }
                    }
                }
            }
            else
            {
                if (interactableUIGameObject != null)
                {
                    interactableUIGameObject.SetActive(false);
                }

                if (itemInteractableGameObject != null && inputHandler.a_Input)
                {
                    itemInteractableGameObject.SetActive(false);
                }
            }
        }

        public void CheckForDialog()
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 1f, transform.forward, out hit, 2f, cameraHandler.ignoreLayers))
            {
                if (hit.collider.tag == "Interactable" && isDialog)
                {
                    DialogueTrigger dialogueTrigger = hit.collider.GetComponent<DialogueTrigger>();
                    Debug.Log(isSpeaking);
                    if (dialogueTrigger != null && inputHandler.a_Input && isSpeaking == false)
                    {
                        if (hit.collider.GetComponent<DialogueTrigger>().condition == ScoreAndStates.missionScore)
                        {
                            hit.collider.GetComponent<DialogueTrigger>().TriggerDialogue();
                            isSpeaking = true;
                        }
                    }
                    if (dialogueTrigger != null && inputHandler.a_Input && isSpeaking == true)
                    {
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                        Debug.Log("heuyyy " + isInteracting);
                    } 
                }
            }
        }
    }
}
