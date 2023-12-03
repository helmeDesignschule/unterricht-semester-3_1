using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private GameObject targetingVisuals;
    [SerializeField] private Animator animator;

    private Vector3 lastPosition;
    
    private void Awake()
    {
        targetingVisuals.SetActive(false);
        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 movement = transform.position - lastPosition;
        if (movement.magnitude > 0)
        {
            movement.Normalize();
            animator.SetFloat("MoveDirectionX", movement.x);
            animator.SetFloat("MoveDirectionY", movement.y);
        }
        lastPosition = transform.position;
    }


    public void ShowTargetingAnimation(float duration)
    {
        StartCoroutine(ShowTargetingAnimationCoroutine(duration));
    }

    private IEnumerator ShowTargetingAnimationCoroutine(float duration)
    {
        targetingVisuals.SetActive(true);

        Transform targetingVisualsTransform = targetingVisuals.transform;
        targetingVisualsTransform.localScale = Vector3.zero;

        float passedTime = 0;
        while (passedTime < duration)
        {
            passedTime += Time.deltaTime;
            yield return null;
            float scale = passedTime / duration;
            scale = Mathf.Clamp01(scale);
            targetingVisualsTransform.localScale = new Vector3(scale, scale, scale);
        }
        
        targetingVisuals.SetActive(false);
    }
}
