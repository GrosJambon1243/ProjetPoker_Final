using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum RoundState
{
    PlayerTurn,
    OpponentTurn,
    EndOfRound,
    ShoppingPhase,
    GameOver
}
public class GameStateManager : MonoBehaviour
{
    //Opponent Hand and Sprite
    [SerializeField] public OpponentScript opponentHands;
    
    //Button and Text
    [SerializeField] public Button drawButton;
    [SerializeField] private TMP_Text roundNumber;
    private int numberOfRound = 1;
    
    //Other
    public RoundStateBase currentState;
    public RoundStateBase[] allState = new RoundStateBase[5];
    private int combatNumber = 1;
    public int CombatNumber
    {
        get => combatNumber;
        set => combatNumber= value;
    }
   

    private void Start()
    {
        allState[0] = new PlayerTurnState(this);
        allState[1] = new OpponentTurnState(this);
        allState[2] = new EndOfRoundState(this);
        allState[3] = new ShoppingState(this);
        allState[4] = new GameOverState(this);

        currentState = allState[0];
        currentState.OnStateEnter();
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void OnDrawCLick()
    {
        currentState.OnDrawClick();
        if (currentState.PlayerAction == 0)
        {
            drawButton.enabled = false;
        }
       
    }

    public void OnEndTurnClick()
    {
        currentState.OnEndTurnClick();
        numberOfRound++;
        roundNumber.text = $"Turn : {numberOfRound}";
    }

    public void TransitionToState(RoundState nextState)
    {
        currentState = allState[(int)nextState];
        currentState.OnStateEnter();
    }
}

public abstract class RoundStateBase
{
    protected GameStateManager gameStateManager;
   
    private int playerAction;
    public int PlayerAction
    {
        get => playerAction;
        set => playerAction = value;
    }

    public RoundStateBase(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
    }
    public virtual void OnDrawClick()
    {
        Debug.Log("Cannot Draw");
    }

    public virtual void OnEndTurnClick()
    {
        
    }

    public abstract void OnStateEnter();
    
        
    
    public abstract void UpdateState();
}

public class PlayerTurnState : RoundStateBase
{
   
    public PlayerTurnState(GameStateManager gameStateManager) : base(gameStateManager)
    {
    }

    public override void OnStateEnter()
    {
        Cursor.visible = true;
        PlayerAction = 20;
    }

    public override void UpdateState()
    {
        
    }

    public override void OnDrawClick()
    {
       Debug.Log("Drawing");
       PlayerAction--;
       
    }

    public override void OnEndTurnClick()
    {
        gameStateManager.TransitionToState(RoundState.OpponentTurn);
    }
}
public class OpponentTurnState : RoundStateBase
{
    public OpponentTurnState(GameStateManager gameStateManager) : base(gameStateManager)  { }

    public override void OnStateEnter()
    {
        Cursor.visible = false;
        Debug.Log("Opponnent Turn");
        gameStateManager.opponentHands.FirstCombat();
        
    }

    public override void UpdateState()
    {
       
    }
}
public class EndOfRoundState : RoundStateBase
{
    public EndOfRoundState(GameStateManager gameStateManager) : base(gameStateManager)
    {
    }

    public override void OnStateEnter()
    {
        
    }

    public override void UpdateState()
    {
       
    }
}

public class GameOverState : RoundStateBase
{
    public GameOverState(GameStateManager gameStateManager) : base(gameStateManager) { }

    public override void OnStateEnter()
    {
        
    }

    public override void UpdateState()
    {
      
    }
}
public class ShoppingState : RoundStateBase
{
    public ShoppingState(GameStateManager gameStateManager) : base(gameStateManager)
    {
    }

    public override void OnStateEnter()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
