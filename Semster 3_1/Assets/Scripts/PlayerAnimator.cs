using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Vector2 lookDirection = Vector2.down;
    private float speed = 0;

    private void Awake()
    {
        animator.SetFloat("LookDirectionX", lookDirection.x);
        animator.SetFloat("LookDirectionY", lookDirection.y);
        animator.SetFloat("Speed", speed);
    }

    public void SetLookDirection(Vector2 newDirection)
    {
        if (newDirection.magnitude <= 0)
            return;
        
        lookDirection = newDirection;
        animator.SetFloat("LookDirectionX", lookDirection.x);
        animator.SetFloat("LookDirectionY", lookDirection.y);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        animator.SetFloat("Speed", speed);
    }
}
