using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Slideshow
{
    #region Lerp Data

    [Serializable]
    public struct LerpData
    {
        public AnimationCurve curve;
        public float          duration;
    }

    [Serializable]
    public struct LerpPositionData
    {
        public Vector3  start;
        public Vector3  end;
        public LerpData lerpData;
    }

    [Serializable]
    public struct LerpColorData
    {
        public Color    start;
        public Color    end;
        public LerpData lerpData;
    }

    #endregion

    [RequireComponent(typeof(Image), typeof(LerpComponent))]
    public class AnimatedImage : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private LerpComponent lerpComponent;
        
        [SerializeField] private LerpPositionData inPositionAnimation;
        [SerializeField] private LerpColorData    inColorAnimation;
        [Space]
        [SerializeField] private LerpPositionData outPositionAnimation;
        [SerializeField] private LerpColorData    outColorAnimation;

        private void OnValidate()
        {
            if (image == null)
                image = GetComponent<Image>();

            if (lerpComponent == null)
                lerpComponent = GetComponent<LerpComponent>();
        }

        public void AnimatePosition(bool inOut)
        {
            lerpComponent.LerpPosition(transform,
                                       inOut ? inPositionAnimation : outPositionAnimation);
        }

        public void AnimateColor(bool inOut)
        {
            lerpComponent.LerpColor(image,
                                    inOut ? inColorAnimation : outColorAnimation);
        }
    }
}