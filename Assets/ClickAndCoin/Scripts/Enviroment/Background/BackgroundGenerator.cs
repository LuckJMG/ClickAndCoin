using UnityEngine;

namespace ClickAndCoin
{
    public class BackgroundGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject currentCameraObject;
        [SerializeField] private Sprite tile;
        private IGridGenerator _gridGenerator;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            currentCameraObject =
            currentCameraObject != null ? currentCameraObject : Camera.main.gameObject;
            _gridGenerator = GetComponent<IGridGenerator>();
        }

        private void Start()
        {
            _gridGenerator.NewGrid(_transform, tile, currentCameraObject);
        }
    }
}
