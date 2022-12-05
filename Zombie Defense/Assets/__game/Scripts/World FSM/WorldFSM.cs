using Common.FSM;

public class WorldFSM :FSM
{
    public GameState currentGameState { get; private set; }

    private FSMState startBattleState;
    private StartBattleAct startBattle;
    
    private FSMState EnterGameState;
    private EnterGameAct EnterGame;
    
    private FSMState endBattleState;
    private EndBattleAct endBattle;
    
    private FSMState continueBattleState;
    private ContinueBattleAct continueBattle;

    private FSMState finishWorldState;
    private FinishWorldAct finishWorld;
    
    public WorldFSM(WorldController worldController) : base("World FSM")
    {
        startBattleState = this.AddState((byte) GameState.START_BATTLE);
        EnterGameState = this.AddState((byte)GameState.ENTER_GAME);
        endBattleState = this.AddState((byte) GameState.END_BATTLE);
        continueBattleState = this.AddState((byte) GameState.CONTINUE_BATTLE);
        finishWorldState = this.AddState((byte) GameState.FINISH_WORLD);
        
        startBattle = new StartBattleAct(worldController,startBattleState);
        EnterGame = new EnterGameAct(worldController, EnterGameState);
        endBattle = new EndBattleAct(worldController, endBattleState);
        continueBattle = new ContinueBattleAct(worldController, continueBattleState);
        finishWorld = new FinishWorldAct(worldController, finishWorldState);
        
        startBattleState.AddAction(startBattle);
        EnterGameState.AddAction(EnterGame);
        endBattleState.AddAction(endBattle);
        continueBattleState.AddAction(continueBattle);
        finishWorldState.AddAction(finishWorld);
        
    }

    public void ChangeState(GameState state)
    {
        //Crashlytics.Log($"Change from state {this.currentState} to {state}");
        switch (state)
        {
            case GameState.ENTER_GAME:
                ChangeToState(EnterGameState);
                currentGameState = GameState.ENTER_GAME;
                break;
            case GameState.END_BATTLE:
                ChangeToState(endBattleState);
                currentGameState = GameState.END_BATTLE;
                break;
            case GameState.START_BATTLE:
                ChangeToState(startBattleState);
                currentGameState = GameState.START_BATTLE;
                break;
            case GameState.CONTINUE_BATTLE:
                ChangeToState(continueBattleState);
                currentGameState = GameState.CONTINUE_BATTLE;
                break;
            case  GameState.FINISH_WORLD:
                ChangeToState(finishWorldState);
                currentGameState = GameState.FINISH_WORLD;
                break;
            default:
                break;
        }
    }

   
}
