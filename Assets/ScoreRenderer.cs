using System;
using System.Collections;
using System.Collections.Generic;
using RunnerGame;
using TMPro;
using UnityEngine;

public class ScoreRenderer : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField] private ScoreManager scoreManager;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        scoreManager.OnChangeScore += OnChangeScoreHandler;
    }
    private void OnChangeScoreHandler(int newValue) => _text.text = $"Score: {newValue}";
}