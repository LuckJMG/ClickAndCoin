using UnityEngine;

namespace ClickAndCoin
{
    public interface IGridGenerator
    {
        public void NewGrid(Transform gridHolder, GameObject tilePrefab, GameObject center = null);

        public void NewGrid(Transform gridHolder, Sprite tile, GameObject center = null);

        public void ReloadGrid(Transform gridHolder, GameObject center = null);
    }
}
