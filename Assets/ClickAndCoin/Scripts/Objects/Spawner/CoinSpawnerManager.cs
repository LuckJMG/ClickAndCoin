using UnityEngine;

namespace ClickAndCoin
{
    public class CoinSpawnerManager : MonoBehaviour
    {
        private IPrefabSpawner _prefabSpawner;

        private void Awake()
        {
            _prefabSpawner = GetComponent<IPrefabSpawner>();
        }

        private void Start()
        {
            _prefabSpawner.SpawnerInitialization();
        }
    }
}
