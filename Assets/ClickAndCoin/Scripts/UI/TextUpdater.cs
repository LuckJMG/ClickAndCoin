using TMPro;

namespace ClickAndCoin
{
    public static class TextUpdater
    {
        public static void Update(TextMeshProUGUI textMesh, string message, int number)
        {
            textMesh.text = message + ' ' + number.ToString();
        }
    }
}