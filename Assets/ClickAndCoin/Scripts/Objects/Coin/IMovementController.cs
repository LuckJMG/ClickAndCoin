using UnityEngine;

namespace ClickAndCoin
{
    public interface IMovementController
    {
        public void MoveTowardsDirection(Vector3 direction, float speed);
    }
}
