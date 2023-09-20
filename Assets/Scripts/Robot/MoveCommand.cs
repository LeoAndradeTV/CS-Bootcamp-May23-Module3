using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private NavMeshAgent agent;
    private Vector3 destination;

    public MoveCommand (NavMeshAgent agent, Vector3 destination)
    {
        this.agent = agent;
        this.destination = destination;
    }

    public override bool IsComplete => ReachedDestination();

    public override void Execute()
    {
        agent.SetDestination(destination);
    }

    private bool ReachedDestination()
    {
        if (agent.remainingDistance < 0.1f)
            return true;

        return false;
    }
}
