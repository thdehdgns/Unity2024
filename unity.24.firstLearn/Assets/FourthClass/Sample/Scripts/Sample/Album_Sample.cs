using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class Album_Sample : MonoBehaviour
    {
        [SerializeField] private Image imageShow;

        public void ShowRandomAlbum()
        {
            int albumIndex = Random.RandomRange(1, 3);
            string albumName = "Album_" + albumIndex.ToString("D2");

            string spritePath = "Album/" + albumName;

            Sprite albumSprite = Resources.Load<Sprite>(spritePath);

            imageShow.sprite = albumSprite;
        }
    } 
}
