using UnityEngine;

namespace ClickAndCoin
{
    public class CoinManager : MonoBehaviour
    {
        [SerializeField] private Vector2 minMaxSpeed = new(.5f, 2f);
        private IMovementController _movementController;
        private float _speed;

        private void Awake()
        {
            _movementController = GetComponent<IMovementController>();
        }

        private void Start()
        {
            float minSpeed = minMaxSpeed.x;
            float maxSpeed = minMaxSpeed.y;
            _speed = Random.Range(minSpeed, maxSpeed);
        }

        private void Update()
        {
            _movementController.MoveTowardsDirection(Vector3.down, _speed);
        }
    }
}
