using UnityEngine;

namespace ClickAndCoin
{
    internal static class GeneratePrefab
    {
        public static GameObject GeneratePrefabWithSprite(string name, Sprite sprite)
        {
            var spritePrefab = new GameObject(name);

            var spriteRenderer = spritePrefab.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;

            return spritePrefab;
        }
    }
}
