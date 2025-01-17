using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public GameObject questPanel;
    public Text[] questInfos;
    public string questCompletedMessage;
    public int xp = 50;
    public int po = 500;
    public GameObject[] toHideAfterQuestCompleted;
    public GameObject[] toShowAfterQuestTaken;
    public GameObject ui;


    public void HideObjAfterQuest()
    {
        foreach (GameObject go in toHideAfterQuestCompleted)
        {
            go.SetActive(false);
        }
    }

    public void ShowObjAfterQuestTaken()
    {
        foreach (GameObject go in toShowAfterQuestTaken)
        {
            go.SetActive(true);
        }
    }
}
