using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class GameState : MonoBehaviour 
{
    protected Context _context;

    public void SetContext(Context context)
    {
        this._context = context;
    }

    public abstract void Handle1();

    public abstract void Handle2();
}

class Context
{
    private GameState _gameState = null;

    public Context(GameState gameState)
    {
        this.TransitionTo(gameState);
    }

    public void TransitionTo(GameState gameState)
    {
        Debug.Log("changing");
        this._gameState = gameState;
        this._gameState.SetContext(this);
    }

    public void Request1()
    {
        this._gameState.Handle1();
    }

    public void Resquest2()
    {
        this._gameState.Handle2();
    }
}
