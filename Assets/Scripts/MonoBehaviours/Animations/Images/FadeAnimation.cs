using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Animations.Images
{
    public class FadeAnimation: MonoBehaviour
    {
        private Image _imageComponent;
        private bool _isAnimating;

        public IEnumerator numerator;
        private void Awake()
        {
            _imageComponent = gameObject.GetComponent<Image>();
        }

        public Coroutine FadeIn()
        {
            if (numerator != null) StopCoroutine(numerator);
            numerator = FadeInCoroutine();
            
            return StartCoroutine(numerator);
        }
        
        public Coroutine FadeOut()
        {
            if (numerator != null) StopCoroutine(numerator);
            numerator = FadeOutCoroutine();
            
            return StartCoroutine(numerator);
        }
        
        IEnumerator FadeOutCoroutine()
        {
            Color newColor = _imageComponent.color;      
            for (float f = 1f; f >= -0.02; f -= 0.02f)
            {  
                newColor.a = f;
                _imageComponent.color = newColor;
                yield return new WaitForSeconds(.02f);
            }
        }
        IEnumerator FadeInCoroutine()
        {
            Color newColor = _imageComponent.color;
            for (float f = 0f; f <= 1.02; f += 0.02f)
            {  
                newColor.a = f;
                _imageComponent.color = newColor;
                yield return new WaitForSeconds(.02f);
            }
        }
    }
}