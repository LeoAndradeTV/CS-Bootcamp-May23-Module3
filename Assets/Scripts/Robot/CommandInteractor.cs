using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandInteractor : Interactor
{
    Queue<Command> commands = new Queue<Command>();

    [SerializeField] private NavMeshAgent agent;

    private Command currentCommand;

    public override void Interact()
    {
        if (PlayerInput.Instance.HasCommanded() && isHitting)
        {
            if (hit.collider.CompareTag("Ground"))
            {
                // Visual help -- Doesn't add to behavior
                GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.transform.position = hit.point;

                // Add a move command to the queue
                commands.Enqueue(new MoveCommand(agent, hit.point));
            }

            if (hit.collider.CompareTag("Builder"))
            {
                commands.Enqueue(new BuildCommand(agent, hit.transform.GetComponent<Builder>()));
            }
        }

        ProcessCommands();
    }

    private void ProcessCommands()
    {
        if (currentCommand != null && !currentCommand.IsComplete)
            return;

        if (commands.Count == 0)
            return;

        currentCommand = commands.Dequeue();

        currentCommand.Execute();
    }
}
