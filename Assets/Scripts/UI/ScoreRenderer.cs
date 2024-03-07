using RunnerGame;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class ScoreRenderer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private IScoreManager _scoreManager;
        [Inject] private void Construct(IScoreManager scoreManager) => _scoreManager = scoreManager;
        private void Awake()
        {
            _scoreManager.OnChangeScore += OnChangeScoreHandler;
            OnChangeScoreHandler();
        }
        private void OnChangeScoreHandler(int newValue = 0) => _text.text = $"Score: {_scoreManager.Value}";
    }
}