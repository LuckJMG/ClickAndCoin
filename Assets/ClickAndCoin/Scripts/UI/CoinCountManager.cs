using TMPro;
using UnityEngine;

namespace ClickAndCoin
{
    public class CoinCountManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinTextMesh;
        private int _coinCount;

        private void Start()
        {
            InputHandler.OnDestroy += OnCountUpdate;
        }

        private void OnDestroy()
        {
            InputHandler.OnDestroy -= OnCountUpdate;
        }

        private void OnCountUpdate()
        {
            _coinCount += 1;
            if (coinTextMesh != null) coinTextMesh.text = "Coins: " + _coinCount.ToString();
        }
    }
}
