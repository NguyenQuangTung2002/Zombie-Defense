using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public static WorldController Instance;
    [SerializeField] private UiController UIController;
    [SerializeField] private WorldLevelSystem WorldLevelSystem;

    public List<Elevator> elevantors;
    
    public UiController UiController => UIController;

    public WorldLevelSystem worldLevelSystem
    {
        get
        {
            if (!WorldLevelSystem)
            {
                return null;
            }
            return WorldLevelSystem;
        }

        private set => WorldLevelSystem = value;
    }

    public WorldFSM stateCtrl { get; set; }
    private void Awake()
    {
        Instance = this;
        stateCtrl = new WorldFSM(this);
    }

    private void Start()
    {
        LoadWorldLevel();
    }

    private void Update()
    {
        stateCtrl.Update();
    }

    public void ChangeState(GameState state)
    {
        stateCtrl.ChangeState(state);
    }

    public void LoadWorldLevel()
    {
        if (worldLevelSystem.isEndLevel)
        {
            stateCtrl.ChangeState(GameState.FINISH_WORLD);
        }
        else
        {
            stateCtrl.ChangeState(GameState.ENTER_GAME);
        }
        
    }

    public void OnWorldLevelFinishedLoading(WorldLevelSystem worldLvSystem)
    {
        this.worldLevelSystem = worldLvSystem;
        //stateCtrl.ChangeState(GameState.ENTER_GAME);
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UiController.OpenUIInGame();
        }
    }

    public void Pause()
    {
        //Time.timeScale = 0;
        UltimateJoystick.DisableJoystick(Constants.MAIN_JOINSTICK);
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        if (stateCtrl.currentGameState != GameState.LOBBY
            && stateCtrl.currentGameState != GameState.END_BATTLE)
        {
            UltimateJoystick.EnableJoystick(Constants.MAIN_JOINSTICK);
        }
    }
}
 