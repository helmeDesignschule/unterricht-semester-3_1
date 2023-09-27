using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // - Enemy Controller
    // - - Delay before attacks
    // - - Targeting
    // - - Health points

    // - Bullet
    // - - Trajectory
    // - - bullet size
    // - - Bullet Despawn after range
    // - - Damage Amount
    [SerializeField] private Pawn pawn;
    [SerializeField] private float distanceUntilStop = 3;
    [SerializeField] private float targetingDuration = 1;
    [SerializeField] private EnemyAnimator animator;
    [SerializeField] private Bullet bulletPrefab;
    
    private bool isTargetingPlayer = false;
    
    private void Update()
    {
        if (!isTargetingPlayer)
            UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (Vector2.Distance(pawn.GetPosition(), PlayerManager.playerPawn.GetPosition()) < distanceUntilStop)
        {
            pawn.CancelMovement();
            TargetPlayer();
        }
        else
        {
            pawn.MoveToPosition(PlayerManager.playerPawn.GetPosition());
        }
    }

    private void TargetPlayer()
    {
        isTargetingPlayer = true;
        StartCoroutine(TargetAndShootAtPlayerCoroutine());
    }

    private IEnumerator TargetAndShootAtPlayerCoroutine()
    {
        Debug.Log("Targeting Player");
        animator.ShowTargetingAnimation(targetingDuration);
        
        yield return new WaitForSeconds(targetingDuration);

        Vector2 bulletSpawnPosition = pawn.GetPosition();
        Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        
        newBullet.Launch(pawn, PlayerManager.playerPawn.GetPosition());
        
        isTargetingPlayer = false;
    }
}
