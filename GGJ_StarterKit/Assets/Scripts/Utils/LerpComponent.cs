using System.Collections;
using Slideshow;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    /// <summary>
    /// Class intended to illustrate the use of Lerp for academic purpose and not for professional use.
    /// Use this to learn and create a proper implementation.
    /// </summary>
    public class LerpComponent : MonoBehaviour
    {
        // Don't care about any of this? ---> Call Mathf.Lerp() | Vector3.Lerp() | Color.Lerp() | etc..
        // You still need to feed it the correct things though!
        private static float Lerp(float start, float end, float t)
        {
            return start + (end - start) * Mathf.Clamp01(t);
        }

        #region Color

        private IEnumerator LerpColorRoutine(
            Graphic        target,
            Color          startColor,
            Color          endColor,
            AnimationCurve curve,
            float          duration)
        {
            float timeElapsed = 0;

            target.color = startColor;

            do
            {
                // Same as Lerp for single values,but 3 times over!
                target.color =  Color.Lerp(startColor, endColor, curve.Evaluate(timeElapsed / duration));
                timeElapsed  += Time.deltaTime;

                yield return null;
            } while (timeElapsed < duration);

            target.color = endColor;
        }

        public void LerpColor(
            Graphic       target,
            LerpColorData data)
        {
            if (data.lerpData.duration > 0)
                StartCoroutine(LerpColorRoutine(target, data.start, data.end, data.lerpData.curve,
                                                data.lerpData.duration));
        }

        #endregion

        #region Position (Vector3)

        private IEnumerator LerpPositionRoutine(
            Transform      target,
            Vector3        startPosition,
            Vector3        endPosition,
            AnimationCurve curve,
            float          duration)
        {
            float timeElapsed = 0;

            target.position = startPosition;

            do
            {
                // Same as Lerp for single values,but 3 times over!
                target.position =
                    Vector3.Lerp(startPosition, endPosition, curve.Evaluate(timeElapsed / duration));
                timeElapsed += Time.deltaTime;

                yield return null;
            } while (timeElapsed < duration);

            target.position = endPosition;
        }

        public void LerpPosition(
            Transform        target,
            LerpPositionData data)
        {
            if (data.lerpData.duration > 0)
                StartCoroutine(LerpPositionRoutine(target, data.start, data.end, data.lerpData.curve,
                                                   data.lerpData.duration));
        }

        #endregion
    }
}