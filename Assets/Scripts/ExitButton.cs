using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject exit;
    void Start()
    {
        exit.SetActive(false);
    }

    public void GameOver()
    {
        exit.SetActive(true);
    }
}
