using System.Collections;
using UnityEngine;

namespace ClickAndCoin
{
    public class CameraPrefabSpawner : MonoBehaviour, IPrefabSpawner
    {
        [SerializeField] private Camera currentCamera;
        [SerializeField] private GameObject prefab;
        [SerializeField] private float spawnDelayInSeconds;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            currentCamera = currentCamera != null ? currentCamera : Camera.main;
        }

        public void SpawnerInitialization()
        {
            var spawnerParameters = CameraSpawnerPositionCalculator(currentCamera);
            float xMin = spawnerParameters.x;
            float xMax = spawnerParameters.y;
            float y = spawnerParameters.z;

            var startPoint = new Vector2(xMin, y);
            var endPoint = new Vector2(xMax, y);

            StartCoroutine(RandomSpawnerCoroutine(prefab, startPoint, endPoint, spawnDelayInSeconds));
        }

        private IEnumerator RandomSpawnerCoroutine(GameObject prefab, Vector3 startPoint, Vector3 endPoint, float delayInSeconds)
        {
            while (true)
            {
                RandomSpawner(prefab, startPoint, endPoint);
                yield return new WaitForSeconds(delayInSeconds);
            }
        }

        private Vector3 CameraSpawnerPositionCalculator(Camera camera)
        {
            Vector3 position = camera.transform.position;
            float xPosition = position.x;
            float yPosition = position.y;

            float orthographicSize = camera.orthographicSize;
            float width = orthographicSize * 2 * camera.aspect;

            float y = yPosition + orthographicSize;
            float xMin = xPosition - width / 2;
            float xMax = xPosition + width / 2;

            var spawnerParameters = new Vector3(xMin, xMax, y);
            return spawnerParameters;
        }

        private void RandomSpawner(GameObject prefab, Vector3 startPosition, Vector3 endPosition)
        {
            if (prefab == null) return;

            var prefabSprite = prefab.GetComponent<SpriteRenderer>().sprite;
            var prefabPixelsPerUnit = prefabSprite.pixelsPerUnit;
            var prefabTexture = prefabSprite.texture;

            float prefabWidth = prefabTexture.width / prefabPixelsPerUnit;
            float prefabHeight = prefabTexture.height / prefabPixelsPerUnit;

            float cameraY = startPosition.y;
            float cameraMinX = startPosition.x + prefabWidth / 2;
            float cameraMaxX = endPosition.x - prefabWidth / 2;

            float yPrefabPosition = cameraY + prefabHeight / 2;
            float xPrefabPosition = Random.Range(cameraMinX, cameraMaxX);
            var prefabPosition = new Vector3(xPrefabPosition, yPrefabPosition, -1);

            var prefabInstance = Instantiate(prefab, _transform);
            prefabInstance.transform.position = prefabPosition;
        }

    }
}
