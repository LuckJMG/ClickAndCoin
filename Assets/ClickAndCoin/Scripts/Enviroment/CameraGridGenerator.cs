using UnityEngine;

namespace ClickAndCoin
{
    public class CameraGridGenerator : MonoBehaviour, IGridGenerator
    {
        public void NewGrid(Transform gridHolder, GameObject tilePrefab, GameObject cameraObject = null)
        {
            if (!tilePrefab.TryGetComponent<SpriteRenderer>(out var tileSpriteRenderer)) return;
            Camera camera = cameraObject != null ? cameraObject.GetComponent<Camera>() : Camera.main;

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

        public void NewGrid(Transform gridHolder, Sprite tile, GameObject cameraObject = null)
        {
            Camera camera = cameraObject != null ? cameraObject.GetComponent<Camera>() : Camera.main;
            var tilePrefab = GeneratePrefab.GeneratePrefabWithSprite("tilePrefab", tile);
            var tileSpriteRenderer = tilePrefab.GetComponent<SpriteRenderer>();

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

        public void ReloadGrid(Transform gridHolder, GameObject camera = null)
        {
            var tilePrefab = gridHolder.GetChild(0).gameObject;

            while (gridHolder.childCount != 0)
            {
                var tileChild = gridHolder.GetChild(0).gameObject;
                Destroy(tileChild);
            }

            NewGrid(gridHolder, tilePrefab, camera);
        }
    }
}
