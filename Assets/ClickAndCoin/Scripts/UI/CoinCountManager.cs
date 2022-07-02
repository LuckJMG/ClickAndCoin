using TMPro;
using UnityEngine;

namespace ClickAndCoin
{
    public class CoinCountManager : MonoBehaviour
    {
        private const string message = "Coins:";

        [SerializeField] private TextMeshProUGUI coinTextMesh;
        private int _coinCount;

        private void Start()
        {
            DestroyOnClick.OnDestroy += OnUpdate;
        }

        private void OnUpdate()
        {
            _coinCount += 1;
            if (coinTextMesh != null) TextUpdater.Update(coinTextMesh, message, _coinCount);
        }
    }
}
