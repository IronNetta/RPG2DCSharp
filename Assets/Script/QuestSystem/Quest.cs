using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Quest
{
    public string title;
    public string desc;
    public int gold;
    public int xp;
    public bool isActive;
    public bool isCompleted = false;
    public string objType;
    public int reqAmount;
    public int count = 0;

    public void IncrementCount()
    {
        count++;
        if (count >= reqAmount)
        {
            isCompleted = true;
        }
    }
}
