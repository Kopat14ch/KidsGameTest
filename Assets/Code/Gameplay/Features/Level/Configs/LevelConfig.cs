using Code.Gameplay.Features.Grid.Config;
using UnityEngine;

namespace Code.Gameplay.Features.Level.Configs
{
    [CreateAssetMenu(menuName = "Configs/LevelConfig", fileName = "LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] public GridConfig GridConfig;

        public int Id;
    }
}