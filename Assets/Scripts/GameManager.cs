using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameState _state = 0;
    void Start()
    {
        _state = GameState.Initialize;
    }

    void Update()
    {
        switch (_state)
        {
            case GameState.Initialize:
                // �Q�[���J�n�O�ɂ��邱��
                _state = GameState.InGame;
                break;
            case GameState.InGame:
                // 
                break;
            case GameState.GameEnd:
                break;
        }
    }
    enum GameState
    {
        Initialize,
        InGame,
        GameEnd
    }
}
