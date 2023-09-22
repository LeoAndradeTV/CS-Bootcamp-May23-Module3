using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private State currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.Briefing);
    }

    public void ChangeState(State newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case State.Briefing:
                StartBriefing();
                break;
            case State.LevelEntrance:
                InitiateLevel();
                break;
            case State.Level:
                RunLevel();
                break;
            case State.LevelExit:
                CompleteLevel();
                break;
            case State.GameOver:
                GameOver();
                break;
            case State.GameEnd:
                GameEnd();
                break;
        }
    }

    private void StartBriefing()
    {
        Debug.Log("Started Briefing");
    }

    private void InitiateLevel()
    {
        Debug.Log("Level Start");
    }

    private void RunLevel()
    {
        Debug.Log("In level");
    }

    private void CompleteLevel()
    {
        Debug.Log("Level end");
    }

    private void GameOver()
    {
        Debug.Log("You lose, game over");
    }

    private void GameEnd()
    {
        Debug.Log("Congrats! You win!");
    }

    public enum State
    {
        Briefing,
        LevelEntrance,
        Level,
        LevelExit,
        GameOver,
        GameEnd
    }
}
