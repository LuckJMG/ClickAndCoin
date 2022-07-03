using System;
using UnityEngine;

namespace ClickAndCoin
{
    public class InputHandler : MonoBehaviour
    {
        public static Action OnDestroy;


        private void OnMouseDown()
        {
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }
    }
}
