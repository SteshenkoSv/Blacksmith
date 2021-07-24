using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] _frameArray;
    [SerializeField] private SpriteRenderer _renderer;
    private int currentFrame;
    private float timer;

    public float framerate = 1f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= framerate) 
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % _frameArray.Length;
            _renderer.sprite = _frameArray[currentFrame];
        }
    }
}
