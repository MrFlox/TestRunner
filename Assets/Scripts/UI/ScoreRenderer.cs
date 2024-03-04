using RunnerGame;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class ScoreRenderer : MonoBehaviour
    {
        private TMP_Text _text;
        [SerializeField] private ScoreManager scoreManager;
        [Inject] private GameLifetimeScope.HelloWorldService _helloWorldService;
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            scoreManager.OnChangeScore += OnChangeScoreHandler;
            _helloWorldService.Hello();
        }
        private void OnChangeScoreHandler(int newValue) => _text.text = $"Score: {newValue}";
    }
}