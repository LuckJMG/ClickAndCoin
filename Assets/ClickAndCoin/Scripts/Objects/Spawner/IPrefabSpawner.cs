using System.Collections;
using UnityEngine;

namespace ClickAndCoin
{
    public interface IPrefabSpawner
    {
        public void SpawnerInitialization();

        public void RandomSpawner(GameObject prefab, Vector3 startPoint, Vector3 endPoint);

        public IEnumerator RandomSpawnerCoroutine(GameObject prefab, Vector3 startPoint, Vector3 endPoint, float delayInSeconds);
    }
}
