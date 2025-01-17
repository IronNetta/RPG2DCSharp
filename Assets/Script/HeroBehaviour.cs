using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    
    void Awake()
    {
        string point = PlayerPrefs.GetString("Point", "Point_1");
        Vector3 teleportPosition = GameObject.Find(point).transform.position;
        transform.position = teleportPosition;
    }
}
