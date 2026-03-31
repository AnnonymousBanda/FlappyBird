using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorecardPanel : MonoBehaviour
{

    public GameObject scorecardPanel;
    void Start()
    {
        scorecardPanel.SetActive(false);
    }

    public void GameOver()
    {
        scorecardPanel.SetActive(true);
    }
}
