using RunnerGame;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class ScoreRenderer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private ScoreManager _scoreManager;
        [Inject] private void Construct(ScoreManager scoreManager) => _scoreManager = scoreManager;
        private void Awake()
        {
            _scoreManager.OnChangeScore += OnChangeScoreHandler;
            OnChangeScoreHandler();
        }
        private void OnChangeScoreHandler(int newValue = 0) => _text.text = $"Score: {_scoreManager.Value}";
    }
}