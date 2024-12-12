using Code.Gameplay.Features.Grid.Behaviours;
using Code.Gameplay.Features.Grid.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Grid.Factory
{
    public interface IGridFactory
    {
        GridElementBehaviour Create(Transform container, Vector3 position, GridElementConfig config);
    }
}