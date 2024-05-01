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
    //Canvas
    [SerializeField] public GameObject currentCanvas;
    [SerializeField] public GameObject winningCanvas;
    
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
    [SerializeField] public TMP_Text winText;
    
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
        gameStateManager.PlayerAction = 3;
        gameStateManager.shopCanvas.enabled = false;
        gameStateManager.drawButton.enabled = true;

        if (gameStateManager.CombatNumber == 2)
        {
            gameStateManager.opponentHands.SecondCombat();
        }

        if (gameStateManager.CombatNumber ==3)
        {
            gameStateManager.opponentHands.ThirdCombat();
        }

        if (gameStateManager.CombatNumber == 4)
        {
            gameStateManager.opponentHands.FourthCombat();
        }

       
    }

    public override void UpdateState()
    {
        gameStateManager.roundText.StartOfRoundAnim();
    }

    public override void OnDrawClick()
    {
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
    private Scene currentScene = SceneManager.GetActiveScene();
    private bool houseWin = false;
   
    float timer = 0f;
    float delay = 7f;
    public override void OnStateEnter()
    {
        timer = 0f;
        Cursor.visible = false;

        switch (gameStateManager.CombatNumber)
        {
            case 1:
                gameStateManager.opponentHands.FirstCombat();
                break;
            case 2:
                gameStateManager.opponentHands.AnimSecondCombat();
                break;
            case 3:
                gameStateManager.opponentHands.AnimThirdCombat();
                break;
            case 4:
                gameStateManager.opponentHands.AnimFourthCombat();
                break;
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
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "Player Win !";
                        gameStateManager.calculText.SetActive(false);
                    }
                    else if (gameStateManager.comboValue.comboValue < 2)
                    {
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "House Win !";
                        gameStateManager.calculText.SetActive(false);
                        houseWin = true;
                    }
                    break;
                case 2:
                    if (gameStateManager.comboValue.comboValue >= 3)
                    {
                        gameStateManager.calculText.SetActive(false);
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "Player Win !";
                    }
                    else if (gameStateManager.comboValue.comboValue < 3)
                    {
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "House Win !";
                        gameStateManager.calculText.SetActive(false);
                        houseWin = true;

                    }
                    break;
                case 3:
                    if (gameStateManager.comboValue.comboValue >= 4)
                    {
                        gameStateManager.calculText.SetActive(false);
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "Player Win !";
                    }
                    else if (gameStateManager.comboValue.comboValue < 4)
                    {
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "House Win !";
                        gameStateManager.calculText.SetActive(false);
                        houseWin = true;

                    }
                    break;
                case 4:
                    if (gameStateManager.comboValue.comboValue >= 4)
                    {
                        gameStateManager.calculText.SetActive(false);
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "Player Win !";
                        gameStateManager.currentCanvas.SetActive(false);
                        gameStateManager.winningCanvas.SetActive(true);
                        gameStateManager.gameObject.SetActive(false);
                    }
                    else if (gameStateManager.comboValue.comboValue < 4)
                    {
                        gameStateManager.winText.enabled = true;
                        gameStateManager.winText.text = "House Win !";
                        gameStateManager.calculText.SetActive(false);
                        houseWin = true;

                    }
                    break;
                  
            }
          
        }
        if (timer>=delay)
        {
            if (houseWin)
            {
                SceneManager.LoadScene(currentScene.name);
            }
            else
            {
                gameStateManager.TransitionToState(RoundState.EndOfRound);  
                gameStateManager.winText.enabled = false;
            }
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
            gameStateManager.playerGold += 20;
        }
        else
        {
            gameStateManager.playerGold += 10;
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


