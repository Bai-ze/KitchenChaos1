using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum State
    {
        WattingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

    private State state;

    private float wattingToStartTimer = 1;
    private float countDownToStartTimer = 3;
    private float gamePlayingTimer = 10;

    void Awake()
    {
        state = State.WattingToStart;
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

    private void TurnToCountDownToStart()
    {
        state = State.CountDownToStart;
    }
    private void TurnToGamePlaying()
    {
        state = State.GamePlaying;

    }
    private void TurnToGameOver()
    {
        state = State.GameOver;

    }
}
