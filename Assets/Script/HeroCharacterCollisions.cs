using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HeroCharacterCollisions : MonoBehaviour
{
    public GameObject dialWorldSpace;
    public TMP_Text dialTxt;
    Collider2D otherObj;
    public GameObject dialCanvas;
    public Text DialCanvasTxt;
    public QuestGiver[] quests;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "sign")
        {
            otherObj = other;
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
            sb.ui.SetActive(true);
        }
        if (other.gameObject.tag == "Flower")
        {
            otherObj = other;
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "exit")
        {
            string point = other.gameObject.GetComponent<ExitBehaviour>().teleportPoint;
            PlayerPrefs.SetString("Point", point);
            SceneManager.LoadScene(other.gameObject.name);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "garde")
        {
            ShowDialCanvasTxt(other.gameObject.GetComponent<PnjSimpleDial>().simpleDial);

        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "garde")
        {

            Invoke("HideDialCanvas", 1.5f);

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "sign")
        {
            SignBehaviour sb = other.gameObject.GetComponent<SignBehaviour>();
            sb.ui.SetActive(false);
            otherObj = null;
            Invoke("HideDialPanel", 0.5f);
        }
        if (other.gameObject.tag == "Flower")
        {
            otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            otherObj = null;
        }
    }
    public void HideDialPanel()
    {

        dialWorldSpace.SetActive(false);

    }
    public void HideDialCanvas()
    {

        dialCanvas.SetActive(false);

    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.E) && otherObj != null)
        {
            if (otherObj.gameObject.tag == "sign")
                showDial();
            if (otherObj.gameObject.tag == quests[0].quest.objType)
            {
                otherObj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                otherObj.gameObject.SetActive(false);
                otherObj = null;
                quests[0].quest.IncrementCount();
            }
        }
    }

    public void showDial()
    {
        SignBehaviour sb = otherObj.gameObject.GetComponent<SignBehaviour>();
        sb.ui.SetActive(false);
        dialWorldSpace.SetActive(true);
        dialTxt.SetText(sb.signText);
    }

    public void ShowDialCanvasTxt(string msg)
    {
        dialCanvas.SetActive(true);
        DialCanvasTxt.text = msg;
    }
}
