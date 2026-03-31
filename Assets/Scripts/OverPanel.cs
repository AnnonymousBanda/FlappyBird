using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverPanel : MonoBehaviour
{

    public GameObject overPanel;
    void Start()
    {
        overPanel.SetActive(false);
    }

    public void GameOver()
    {
        overPanel.SetActive(true);
    }
}
