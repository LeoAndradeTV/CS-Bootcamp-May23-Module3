using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyState
{
    public override void OnStateEnter(EnemyStateManager manager)
    {
        Debug.Log("Enemy is following player");
    }

    public override void OnStateExit(EnemyStateManager manager)
    {
        Debug.Log("Exiting follow player");
    }

    public override void OnStateUpdate(EnemyStateManager manager)
    {
        if (manager.playerTransform != null)
        {
            // Exit condition to Idle State is distance is too large
            if (Vector3.Distance(manager.transform.position,manager.playerTransform.position) > 10)
            {
                manager.ChangeState(manager.idleState);
            }

            // Exit condition to Attack State is distance is too small
            if (Vector3.Distance(manager.transform.position, manager.playerTransform.position) < 2)
            {
                manager.ChangeState(manager.attackState);
            }

            // Follow Behavior
            manager.agent.destination = manager.playerTransform.position;
        } else
        {
            manager.ChangeState(manager.idleState);
        }
    }
}
