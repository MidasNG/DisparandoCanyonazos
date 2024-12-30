using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMusic : MonoBehaviour
{
    public AudioClip victory, defeat;
    private void Start()
    {
        if (GameObject.Find("VictoryText") != null) GetComponent<AudioSource>().PlayOneShot(victory);
        else GetComponent<AudioSource>().PlayOneShot(defeat);
    }
}
