using UnityEngine;


namespace Asteroids.Facade
{
    internal sealed class MapCreator
    {
        public Vector3 MapBorders { get; private set; }
        public MapCreator(float screenBorderX, float screenBorderY, Sprite backgroundImage)
        {
            var background = new GameObject("Background");
            background.AddComponent<SpriteRenderer>().sprite = backgroundImage;
            background.GetComponent<SpriteRenderer>().sortingOrder = -5;
            MapBorders = new Vector3(screenBorderX, screenBorderY);
        }
    }
}
