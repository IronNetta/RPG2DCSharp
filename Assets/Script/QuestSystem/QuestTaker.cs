using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTaker : MonoBehaviour
{
    QuestGiver qg;
    Collider2D otherObj;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "quest_giver")
        { 
        otherObj = other;
        qg = other.gameObject.GetComponent<QuestGiver>();
        qg.ui.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "quest_giver")
        {
            qg = other.gameObject.GetComponent<QuestGiver>();
            qg.ui.SetActive(false);
            qg.questPanel.SetActive(false);
            qg = null;
            GetComponent<HeroCharacterCollisions>().HideDialCanvas();
        }

    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.E) && otherObj != null )
        {
            if (otherObj.gameObject.tag == "quest_giver")
                {
                    if (qg == null)
                       {
                          qg = otherObj.gameObject.GetComponent<QuestGiver>();
                if (!qg.quest.isActive)
                {
                    qg.questPanel.SetActive(true);
                    qg.questInfos[0].text = qg.quest.title;
                    qg.questInfos[1].text = qg.quest.desc;
                    qg.questInfos[2].text = "XP:" + qg.quest.xp + " | Gold:" + qg.quest.gold;
                    qg.ShowObjAfterQuestTaken();
                }
                else //quete active
                {
                    if (qg.quest.isCompleted && qg.po > 0)
                    {
                        QuestCompleted();
                    }
                }
            }
                }
        }
    }

    public void TakeQuest()
    {
        qg.quest.isActive = true;
        qg.questPanel.SetActive(false);
    }

    public void QuestCompleted()
    {
        qg.HideObjAfterQuest();
        GetComponent<HeroCharacterCollisions>().ShowDialCanvasTxt(qg.questCompletedMessage);
        print("XP:" + qg.quest.xp + " | Gold:" + qg.quest.gold);
        GetComponent<HeroStats>().xp += qg.xp;
        GetComponent<HeroStats>().po += qg.po;
        qg.po = 0;
        qg.xp = 0;
    }  

}