using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public override void OnStateEnter(EnemyStateManager manager)
    {
        Debug.Log("Attacking Player");
    }

    public override void OnStateExit(EnemyStateManager manager)
    {
        Debug.Log("Exiting attack state");
    }

    public override void OnStateUpdate(EnemyStateManager manager)
    {
        // Exit condition to go back to follow
        if (Vector3.Distance(manager.transform.position, manager.playerTransform.position) > 2f)
        {
            manager.ChangeState(manager.followState);
        }
    }
}
