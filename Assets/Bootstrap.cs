using RunnerGame.Infrastructure;
using UnityEngine;
using VContainer;
using static RunnerGame.Infrastructure.Game;

public class Bootstrap : MonoBehaviour
{
    private Game _game;
    [Inject] private void Construct(Game game) => _game = game;
    private void Start() => _game.SetState(GameStates.MainMenu);
}