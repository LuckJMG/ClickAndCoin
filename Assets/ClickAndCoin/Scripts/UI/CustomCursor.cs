using UnityEngine;

namespace ClickAndCoin
{
    public class CustomCursor : MonoBehaviour
    {
        [SerializeField] private Texture2D customCursorTexture;

        private void Start()
        {
            Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }
}
