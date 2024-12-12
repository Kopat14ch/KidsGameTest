using Code.Gameplay.Features.Grid.Behaviours;
using Code.Gameplay.Features.Grid.Config;
using Code.Infrastructure.AssetManagement;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Gameplay.Features.Grid.Factory
{
    public class GridFactory : IGridFactory
    {
        private readonly GridElementBehaviour _prefab;
        
        public GridFactory(IAssetProvider assetProvider)
        {
            _prefab = assetProvider.LoadAsset<GridElementBehaviour>("Grid/Cell");
        }

        public GridElementBehaviour Create(Transform container, Vector3 position, GridElementConfig config)
        {
            GridElementBehaviour created = Object.Instantiate(_prefab, position, quaternion.identity, container);
            created.Init(config);
            
            return created;
        }
    }
}