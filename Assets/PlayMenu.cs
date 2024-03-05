using System;
using System.Collections;
using System.Collections.Generic;
using RunnerGame;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class PlayMenu : MonoBehaviour
{
    [Inject] private Game _game;
    [SerializeField] private Button buttonPlay;


    private void Awake()
    {
        buttonPlay.onClick.AddListener(OnClickHandler);
    }
    private void OnClickHandler()
    {
        _game.StateMachine.SetState(Game.GameStates.LoadLevel);
    }
}