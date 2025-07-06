using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public event EventHandler OnStateChanged;

    private enum State
    {
        WattingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

    [SerializeField] private Player player;

    private State state;

    private float wattingToStartTimer = 1;
    private float countDownToStartTimer = 3;
    private float gamePlayingTimer = 20;

    void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        TurnToWaittingToStart();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WattingToStart:
                wattingToStartTimer -= Time.deltaTime;
                if(wattingToStartTimer <= 0)
                {
                    TurnToCountDownToStart();
                }
                break;
            case State.CountDownToStart:
                countDownToStartTimer -= Time.deltaTime;
                if(countDownToStartTimer <= 0)
                {
                    TurnToGamePlaying();
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer <= 0)
                {
                    TurnToGameOver();
                }
                break;
            case State.GameOver:
                break;
            default:
                break;
        }

    }

    private void TurnToWaittingToStart()
    {
        state = State.WattingToStart;
        DisablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
    private void TurnToCountDownToStart()
    {
        state = State.CountDownToStart;
        DisablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
    private void TurnToGamePlaying()
    {
        state = State.GamePlaying;
        EnablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);

    }
    private void TurnToGameOver()
    {
        state = State.GameOver;
        DisablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }


    private void DisablePlayer()
    {
        player.enabled = false;
    }
    private void EnablePlayer()
    {
        player.enabled = true;
    }

    public bool IsCountDownState()
    {
        return state == State.CountDownToStart;
    }

    public bool IsGamePlayingState()
    {
        return state == State.GamePlaying;
    }
    public bool IsGameOverState()
    {
        return state == State.GameOver;
    }

    public float GetCountDownTimer()
    {
        return countDownToStartTimer;
    }
}
