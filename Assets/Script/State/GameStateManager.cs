using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public RoundState currentState;

    private void Start()
    {
        currentState = RoundState.PlayerTurn;
    }

    private void Update()
    {
        
    }

    public void TransitionToState(RoundState nextState)
    {
        currentState = nextState;
    }
}

public abstract class RoundStateBase
{
    protected GameStateManager gameStateManager;

    public RoundStateBase(GameStateManager gameStateManager)
    {
        this.gameStateManager = gameStateManager;
    }

    public abstract void UpdateState();
}
