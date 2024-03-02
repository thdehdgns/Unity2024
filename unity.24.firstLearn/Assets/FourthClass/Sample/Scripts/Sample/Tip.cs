using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class Tip : MonoBehaviour
    {
        [SerializeField] private List<LoadingTip> tipList;
        [SerializeField] private Text toolTipText;

        private int currentIndex;

        public void ShowRandomToolTip()
        {
            int randomIndex = Random.Range(0, tipList.Count + 1);

            toolTipText.text = tipList[randomIndex].toolTipText;
        }

        private void Start()
        {
            ShowRandomToolTip();
        }
    }

    [System.Serializable]
    public class LoadingTip
    {
        public int toolTipIndex;
        public string toolTipText;
    } 
}
