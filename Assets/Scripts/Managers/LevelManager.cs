using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public UnityEvent OnLevelStart;
    public UnityEvent OnLevelEnd;

    [SerializeField] private bool isFinalLevel;

    public void LevelStart()
    {
        OnLevelStart?.Invoke();
    }

    public void LevelEnd()
    {
        OnLevelEnd?.Invoke();

        // If this is the final level
        // Go to State.GameEnd
        if (isFinalLevel)
        {
            GameManager.Instance.ChangeState(GameManager.State.GameEnd, this);
        }
        // If it's not
        // Go to next Level
        else
        {
            GameManager.Instance.ChangeState(GameManager.State.LevelExit, this);
        }

        
    }
}
