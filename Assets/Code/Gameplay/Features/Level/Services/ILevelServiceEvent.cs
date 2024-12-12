using System;

namespace Code.Gameplay.Features.Level.Services
{
    public interface ILevelServiceEvent
    {
        event Action LevelChanged;
        event Action Restarted;
    }
}