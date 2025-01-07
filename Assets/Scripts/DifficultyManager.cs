using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public bool isHard = false;
    public float time, timeBonus, respawnTime, maxDistanceX, maxDistanceY;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeDifficulty()
    {
        if (isHard)
        {
            time = 20;
            timeBonus = 3;
            respawnTime = 7;
            maxDistanceX = 10;
            maxDistanceY = 3;
        }
        else
        {
            time = 15;
            timeBonus = 2;
            respawnTime = 5;
            maxDistanceX = 20;
            maxDistanceY = 6;
        }
        isHard = !isHard;
    }
}
