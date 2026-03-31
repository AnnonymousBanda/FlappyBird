using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GameObject startPanel;

    void Start()
    {
        startPanel.SetActive(true);
    }

    public void GameStart()
    {
        startPanel.SetActive(false); 
    }
}