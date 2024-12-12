using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Level.Behaviours
{
    public class LevelViewBehaviour : MonoBehaviour
    {
        [SerializeField] private Text _levelText;

        public void StartFade(string findName)
        {
            _levelText.text = $"Find {findName}";
        }
    }
}