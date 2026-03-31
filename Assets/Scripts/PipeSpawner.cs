using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    float time = 0;

    public GameObject pipe;
    void Start()
    {
        
    }

    void Update()
    {
        if(time<GameController.spawnRate/GameController.scale)
        {
            time += Time.deltaTime;
        }
        else
        {
            float n = Random.Range(-0.5f, 2.5f);
            Vector2 pos = new Vector2(transform.position.x, n);
            //Debug.Log(n);
            Instantiate(pipe, pos,  Quaternion.identity);
            time = 0;
        }
    }
}
