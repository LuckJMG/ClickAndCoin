using UnityEngine;

namespace ClickAndCoin
{
    public class CameraObjectDespawner : MonoBehaviour, IObjectDespawner
    {
        [SerializeField] private Camera currentCamera;
        [SerializeField] private float yOffset;
        private Transform _transform;

        private void Awake()
        {
            currentCamera = currentCamera != null ? currentCamera : Camera.main;
            _transform = transform;
        }

        public void DespawnerInitialization()
        {
            Vector3 despawnerParameters = CameraTransformCalculator(currentCamera, yOffset);
            float xMin = despawnerParameters.x;
            float xMax = despawnerParameters.y;
            float y = despawnerParameters.z;

            var startPoint = new Vector2(xMin, y);
            var endPoint = new Vector2(xMax, y);

            DespawnerTransformCalculator(startPoint, endPoint);
        }

        private Vector3 CameraTransformCalculator(Camera camera, float yOffset)
        {
            Vector3 position = camera.transform.position;
            float xPosition = position.x;
            float yPosition = position.y;

            float orthographicSize = camera.orthographicSize;
            float width = orthographicSize * 2 * camera.aspect;

            float y = yPosition - orthographicSize - yOffset;
            float xMin = xPosition - width / 2;
            float xMax = xPosition + width / 2;

            var spawnerParameters = new Vector3(xMin, xMax, y);
            return spawnerParameters;
        }

        private void DespawnerTransformCalculator(Vector3 startPoint, Vector3 endPoint)
        {
            float yPosition = startPoint.y;

            float xMinPoint = startPoint.x;
            float xMaxPoint = endPoint.x;

            float xScale = Mathf.Abs(xMaxPoint - xMinPoint);
            float xPosition = xMinPoint + xScale / 2;

            _transform.position = new Vector2(xPosition, yPosition);
            _transform.localScale = new Vector2(xScale, .0025f);
        }

    }
}
