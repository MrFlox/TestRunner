﻿namespace RunnerGame.Infrastructure
{
    public interface IGame
    {
        void SetState(GameStates.GameStates newState);
    }
}