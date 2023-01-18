using System.Collections;
using UnityEngine;

namespace Slideshow
{
    public class Slide : MonoBehaviour
    {
        [SerializeField]
        public float disableDelay = 3;
        
        [SerializeField]
        private AnimatedImage[] images;

        private void OnValidate()
        {
            images = GetComponentsInChildren<AnimatedImage>();
        }

        public void Enter()
        {
            foreach (var currentImage in images)
            {
                currentImage.AnimatePosition(true);
                currentImage.AnimateColor(true);
            }
        }
        
        public void Exit()
        {
            foreach (var currentImage in images)
            {
                currentImage.AnimatePosition(false);
                currentImage.AnimateColor(false);
            }

            StartCoroutine(DelayedHide());
        }

        private IEnumerator DelayedHide()
        {
            yield return new WaitForSeconds(disableDelay);
            gameObject.SetActive(false);
        }
    }
}