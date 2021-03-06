﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Allows a sprite to be animated using a SpriteAnimation
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimator : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// This field is used to check every frame if the current animation has changed.
    /// </summary>
    private SpriteAnimation _animation;

    /// <summary>
    /// Gets or sets the current animation. Setting a animation will reset the CurrentFrame value
    /// </summary>
    public SpriteAnimation Animation;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_animation == Animation)
        {
            return;
        }

        _animation = Animation;

        StopAllCoroutines();
        if (_animation == null || _animation.FrameCount == 0)
        {
            _spriteRenderer.sprite = null;
            return;
        }

        StartCoroutine("Animate", Animation);
    }

    private int _currentFrame;

    /// <summary>
    /// Gets or set the current frame of animation
    /// </summary>
    public int CurrentFrame
    {
        get
        {
            return _currentFrame;
        }
        set
        {
            _currentFrame = Mathf.Clamp(value, 0, _animation.FrameCount);
        }
    }

    private IEnumerator Animate()
    {
        if (_animation.FrameCount == 0)
        {
            yield break;
        }

        while (true)
        {
            CurrentFrame = (CurrentFrame + 1) % _animation.FrameCount;
            _spriteRenderer.sprite = _animation.Frames[CurrentFrame].Sprite;

            yield return new WaitForSeconds(_animation.FrameTime / _animation.FrameTimeDivider * _animation.Frames[CurrentFrame].FrameTimeMultiplier);
        }
    }

    
}
