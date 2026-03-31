using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject restart;
    void Start()
    {
        restart.SetActive(false);
    }

    public void GameOver()
    {
        restart.SetActive(true);
    }
}
