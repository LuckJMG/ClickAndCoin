using UnityEngine;

namespace ClickAndCoin
{
    public class DespawnerManager : MonoBehaviour
    {
        private IObjectDespawner _objectDespawner;

        private void Awake()
        {
            _objectDespawner = GetComponent<IObjectDespawner>();
        }

        private void Start()
        {
            _objectDespawner.DespawnerInitialization();
            gameObject.AddComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}
