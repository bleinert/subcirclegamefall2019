using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=32EIYs6Z18Q 
public class BGScroller : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRender;

    // Update is called once per frame
    void Update()
    {
        VerticalScroll();
    }

    void VerticalScroll()
    {
        bgRender.material.mainTextureOffset += new Vector2(0f, bgSpeed * Time.deltaTime);
    }
}
