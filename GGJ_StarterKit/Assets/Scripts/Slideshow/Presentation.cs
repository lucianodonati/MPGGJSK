using System.Collections;
using UnityEngine;

namespace Slideshow
{
    public class Presentation : MonoBehaviour
    {
        [SerializeField]
        private float startDelay = 3;

        [SerializeField]
        private Slide[] slides;

        private int currentIndex;

        private Slide CurrentSlide
        {
            get
            {
                if (currentIndex >= 0 && currentIndex < slides.Length) 
                    return slides[currentIndex];
                return null;
            }
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(startDelay);
            CurrentSlide.Enter();
        }

        private void MoveSlides(bool forward)
        {
            currentIndex += forward ? 1 : -1;
            CurrentSlide.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CurrentSlide.Exit();
                MoveSlides(false);
                CurrentSlide.Enter();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CurrentSlide.Exit();
                MoveSlides(true);
                CurrentSlide.Enter();
            }
        }
    }
}