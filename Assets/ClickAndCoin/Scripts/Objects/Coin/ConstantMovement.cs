using UnityEngine;

namespace ClickAndCoin
{
    public class ConstantMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 minMaxSpeed = new(.5f, 2f);
        private Transform _transform;
        private float _speed;

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            float minSpeed = minMaxSpeed.x;
            float maxSpeed = minMaxSpeed.y;
            _speed = Random.Range(minSpeed, maxSpeed);
        }

        private void Update()
        {
            MoveTowardsDirection(Vector3.down, _speed);
        }

        private void MoveTowardsDirection(Vector3 direction, float speed)
        {
            _transform.Translate(speed * Time.deltaTime * direction);
        }
    }
}
