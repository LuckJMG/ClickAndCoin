using UnityEngine;

namespace ClickAndCoin
{
    public class ConstantMovement : MonoBehaviour, IMovementController
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void MoveTowardsDirection(Vector3 direction, float speed)
        {
            _transform.Translate(speed * Time.deltaTime * direction);
        }
    }
}
