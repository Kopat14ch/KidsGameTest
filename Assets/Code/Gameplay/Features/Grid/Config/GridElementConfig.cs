using UnityEngine;

namespace Code.Gameplay.Features.Grid.Config
{
    [CreateAssetMenu(menuName = "Configs/GridElementConfig", fileName = "GridElementConfig", order = 0)]
    public class GridElementConfig : ScriptableObject
    {
        public Color BackgroundColor = new Color(1, 1, 1, 1);
        public Sprite Sprite;
        public string Name;
        public int RotateValue;
        public Vector3 Scale = new Vector3(0.4f,0.4f,0.4f);
        public Vector3 ScaleIcon = new Vector3(1f,1f,1f);
    }
}