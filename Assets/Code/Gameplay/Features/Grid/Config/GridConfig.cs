using System;
using UnityEngine;

namespace Code.Gameplay.Features.Grid.Config
{
    [Serializable]
    public class GridConfig
    {
        public Vector2Int Size = new Vector2Int(3, 3);
        public float CellSize = 0.3f;
        public float CellGap = 0.1f;
    }
}