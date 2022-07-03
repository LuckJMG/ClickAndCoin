using UnityEngine;

namespace ClickAndCoin
{
    public class CameraGridGenerator : MonoBehaviour, IGridGenerator
    {
        [SerializeField] private Camera currentCamera;
        [SerializeField] private GameObject tilePrefab;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            currentCamera = currentCamera != null ? currentCamera : Camera.main;
        }

        public void GenerateGrid()
        {
            NewGrid(_transform, tilePrefab, currentCamera);
        }

        private void NewGrid(Transform gridHolder, GameObject tilePrefab, Camera camera)
        {
            if (!tilePrefab.TryGetComponent<SpriteRenderer>(out var tileSpriteRenderer)) return;

            var tileSprite = tileSpriteRenderer.sprite;
            var tileTexture = tileSprite.texture;
            float tileWidth = tileTexture.width / tileSprite.pixelsPerUnit;
            float tileHeight = tileTexture.height / tileSprite.pixelsPerUnit;

            Vector2 cameraPosition = camera.transform.position;
            var xCameraOffset = cameraPosition.x;
            var yCameraOffset = cameraPosition.y;

            float cameraHeight = camera.orthographicSize * 2;
            float cameraWidth = camera.orthographicSize * 2 * camera.aspect;
            float xStartPosition = -cameraWidth / 2;
            float yStartPosition = -cameraHeight / 2;

            var tilesPerColumn = Mathf.CeilToInt(cameraWidth / tileWidth);
            var tilesPerRow = Mathf.CeilToInt(cameraHeight / tileHeight);

            for (int column = 0; column <= tilesPerColumn; column++)
            {
                var xTileOffset = tileWidth * column;
                var xPosition = xStartPosition + xTileOffset + xCameraOffset;

                for (int row = 0; row <= tilesPerRow; row++)
                {
                    var yTileOffset = tileHeight * row;
                    var yPosition = yStartPosition + yTileOffset + yCameraOffset;
                    var tilePosition = new Vector2(xPosition, yPosition);

                    var tileInstance = Instantiate(tilePrefab, gridHolder);
                    tileInstance.transform.localPosition = tilePosition;
                }
            }
        }
    }
}
