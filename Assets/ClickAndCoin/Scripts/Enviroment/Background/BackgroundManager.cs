using UnityEngine;

namespace ClickAndCoin
{
    public class BackgroundManager : MonoBehaviour
    {
        private IGridGenerator _gridGenerator;

        private void Awake()
        {
            _gridGenerator = GetComponent<IGridGenerator>();
        }

        private void Start()
        {
            _gridGenerator.GenerateGrid();
        }
    }
}
