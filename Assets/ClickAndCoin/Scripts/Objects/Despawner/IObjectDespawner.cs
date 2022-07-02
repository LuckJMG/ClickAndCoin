using UnityEngine;

namespace ClickAndCoin
{
    public interface IObjectDespawner
    {
        public void DespawnerTransformCalculator(Vector3 startPoint, Vector3 endPoint);
    }
}
