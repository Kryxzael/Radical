using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
     * Input 
     */
    private const string MOVE_AXIS_HORIZONTAL = "Horizontal";
    private const string MOVE_AXIS_VERTICAL = "Vertical";

    private Rigidbody _rigidbody;
    private SpriteAnimator _animator;
    private SpriteRenderer _renderer;

    [Header("Movement")]
    public float MoveSpeed;

    [Header("Animations")]
    public SpriteAnimation IdleAnimation;
    public SpriteAnimation WalkAnimation;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<SpriteAnimator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleMoveInput();
        UpdateAnimation();
    }

    /// <summary>
    /// Performs movement logic
    /// </summary>
    private void HandleMoveInput()
    {
        //Horizontal movement
        _rigidbody.velocity = new Vector3(
            x: Input.GetAxisRaw(MOVE_AXIS_HORIZONTAL) * MoveSpeed,
            y: _rigidbody.velocity.y,
            z: Input.GetAxisRaw(MOVE_AXIS_VERTICAL) * MoveSpeed
        );

        Debug.Log(_rigidbody.velocity);
    }

    /// <summary>
    /// Updates the player's current animation
    /// </summary>
    private void UpdateAnimation()
    {
        //Direction
        if (_rigidbody.velocity.x > 0)
            _renderer.flipX = false;

        else if (_rigidbody.velocity.x < 0)
            _renderer.flipX = true;

        //Animation
        if (Mathf.Abs(_rigidbody.velocity.x) > 0 || Mathf.Abs(_rigidbody.velocity.z) > 0)
            _animator.Animation = WalkAnimation;

        else
            _animator.Animation = IdleAnimation;
    }
}
