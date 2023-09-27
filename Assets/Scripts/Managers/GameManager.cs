using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private LevelManager[] levelManagers;

    private State currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex;

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
        if (levelManagers.Length > 0)
        {
            ChangeState(State.Briefing, levelManagers[currentLevelIndex]);
        }
    }

    public void ChangeState(State newState, LevelManager level)
    {
        currentState = newState;
        currentLevel = level;

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
        ChangeState(State.LevelEntrance, currentLevel);
    }

    private void InitiateLevel()
    {
        Debug.Log("Level Start");

        currentLevel.LevelStart();
        ChangeState(State.Level, currentLevel);
    }

    private void RunLevel()
    {
        Debug.Log("In level");
    }

    private void CompleteLevel()
    {
        Debug.Log("Level end");

        ChangeState(State.LevelEntrance, levelManagers[++currentLevelIndex]);
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
