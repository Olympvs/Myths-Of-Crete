using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Olympvs
{
    public class QuestGiver : MonoBehaviour
    {
        public Quest quest;

        public PlayerManager playerManager;

        public GameObject questWindow;
        public Text titleText;
        public Text descriptionText;

        public void OpenQuestWindow()
        {
            //questWindow.SetActive(true);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
        }

        public void AcceptQuest()
        {
            //questWindow.SetActive(false);
            quest.isActive = true;
            playerManager.quest = quest;
        }
    }
}
