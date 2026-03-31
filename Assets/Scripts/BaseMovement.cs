using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    public Renderer meshRender;


    void Update()
    {
        Vector2 offset = meshRender.material.mainTextureOffset;
        offset = offset + new Vector2(GameController.baseVelocity * Time.deltaTime * GameController.scale, 0f);
        meshRender.material.mainTextureOffset=offset;
    }
}
