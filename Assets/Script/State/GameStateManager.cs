using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum RoundState
{
    PlayerTurn,
    OpponentTurn,
    EndOfRound,
    GameOver
}
public class GameStateManager : MonoBehaviour
{
    //Opponent Hand and Sprite
    [SerializeField] public OpponentScript opponentHands;
    [SerializeField] public CarteManager carteManager;
    
    //Button and Text
    [SerializeField] public Button drawButton;
    [SerializeField] public Button nextBattle;
    [SerializeField] public TMP_Text roundNumber;
    [SerializeField] public TMP_Text goldAmount;
    [SerializeField] public TextScript roundText;
    [SerializeField] public HandsCombo comboValue;
    private int numberOfRound = 1;
    [SerializeField] public Canvas shopCanvas;
    [SerializeField] public GameObject calculText;
    
    //Other
    public RoundStateBase currentState;
    public RoundStateBase[] allState = new RoundStateBase[5];
    private int combatNumber = 1;
    public int playerGold = 0;
    public bool doubleGold;
    [SerializeField] private AudioSource clicking;
    private int playerAction;
    public int PlayerAction
    {
        get => playerAction;
        set => playerAction = value;
    }
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
        allState[3] = new GameOverState(this);

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
        clicking.Play();
        if (PlayerAction == 0)
        {
            drawButton.enabled = false;
        }
       
    }
    
    public void OnEndTurnClick()
    {
        currentState.OnEndTurnClick();
        clicking.Play();
        numberOfRound++;
        roundNumber.text = $"Let's Gamble!\nPlayer Turn";
    }

    public void OnNextBattleClick()
    {
        currentState.OnNextBattleClick();
        numberOfRound = 1;
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

    public virtual void OnNextBattleClick()
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

    // ReSharper disable Unity.PerformanceAnalysis
    public override void OnStateEnter()
    {
        
      
        gameStateManager.roundNumber.text = $"Let's Gamble!\nPlayer Turn";
        gameStateManager.roundText.ResetAnim();
        gameStateManager.carteManager.CreateDeck();
        gameStateManager.carteManager.Piger();
        Cursor.visible = true;
        gameStateManager.PlayerAction = 2;
        gameStateManager.shopCanvas.enabled = false;
        gameStateManager.drawButton.enabled = true;

        if (gameStateManager.CombatNumber == 2)
        {
            gameStateManager.opponentHands.SecondCombat();
        }
    }

    public override void UpdateState()
    {
        gameStateManager.roundText.StartOfRoundAnim();
    }

    public override void OnDrawClick()
    {
       Debug.Log("Drawing");
       gameStateManager.PlayerAction--;
       
    }

    public override void OnEndTurnClick()
    {
        gameStateManager.TransitionToState(RoundState.OpponentTurn);
    }
}
public class OpponentTurnState : RoundStateBase
{
    public OpponentTurnState(GameStateManager gameStateManager) : base(gameStateManager)  { }
    private Scene scene = SceneManager.GetActiveScene();
    float timer = 0f;
    float delay = 8f;
    public override void OnStateEnter()
    {
        timer = 0f;
        Cursor.visible = false;
       
        if (gameStateManager.CombatNumber == 1)
        {
            gameStateManager.opponentHands.FirstCombat();
        }
        else if (gameStateManager.CombatNumber == 2)
        {
            gameStateManager.opponentHands.AnimSecondCombat();
        }
        gameStateManager.calculText.SetActive(true);
        gameStateManager.calculText.GetComponent<CalculatingScript>().Coroutine();
        
        

    }

    public override void UpdateState()
    {
        timer += Time.deltaTime;
        gameStateManager.roundNumber.text = $"Let's Gamble!\nHouse Turn";
        if (timer>= 4)
        {
            switch (gameStateManager.CombatNumber)
            {
                case 1:
                    if (gameStateManager.comboValue.comboValue >= 2)
                    {
                        Debug.Log("Player1");
                    }
                    else if (gameStateManager.comboValue.comboValue < 2)
                    {
                        Debug.Log("House1");
                    }
                    break;
                case 2:
                    if (gameStateManager.comboValue.comboValue >= 3)
                    {
                        Debug.Log("Player2");
                    }
                    else if (gameStateManager.comboValue.comboValue < 3)
                    {
                        Debug.Log("House2");
                    }
                    break;
                  
            }
          
        }
        if (timer>=delay)
        {
            gameStateManager.calculText.SetActive(false);
            gameStateManager.TransitionToState(RoundState.EndOfRound);  
           
        }
       
    }

}
public class EndOfRoundState : RoundStateBase
{
    public EndOfRoundState(GameStateManager gameStateManager) : base(gameStateManager)
    {
    }

    public override void OnStateEnter()
    {
        
        if (gameStateManager.doubleGold)
        {
            gameStateManager.playerGold += 10;
        }
        else
        {
            gameStateManager.playerGold += 5;
        }
        gameStateManager.shopCanvas.enabled = true;
        Cursor.visible = true;
    }

    public override void UpdateState()
    {
        gameStateManager.goldAmount.text = gameStateManager.playerGold.ToString();
    }

    public override void OnNextBattleClick()
    {
        gameStateManager.CombatNumber += 1;
        gameStateManager.shopCanvas.enabled = false;
        gameStateManager.TransitionToState(RoundState.PlayerTurn);
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


