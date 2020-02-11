using System;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Animations.ScrollRects
{
    /// <summary>
    /// This script can be added to a scrollrect. With it you can scroll to a specific item in the scrollrect.
    /// Provided all items are of equal size.  
    /// </summary>
    public class ScrollToItem: MonoBehaviour
    {
        private bool _lerpHorizontalEnabled;
        private float _timeLerped = 0.0f;
        private float _timeToLerp = 0.3f;
        private ScrollRect _scrollRect;
        private float _targetPercentageToScrollTo;
        private float _totalChildren;
        private void Start()
        {
            _scrollRect = GetComponent<ScrollRect>();
            _totalChildren = _scrollRect.content.childCount;
        }

        private void Update()
        {
            if (!_lerpHorizontalEnabled)
                return;
            
            _timeLerped += Time.deltaTime;
            _scrollRect.horizontalNormalizedPosition = Mathf.Lerp(_scrollRect.horizontalNormalizedPosition, _targetPercentageToScrollTo, _timeLerped / _timeToLerp);

            if (!Mathf.Approximately((float)Math.Round(_scrollRect.horizontalNormalizedPosition, 3),_targetPercentageToScrollTo))
                return;
            
            _lerpHorizontalEnabled = false;
            _timeLerped = 0.0f;
        }
        
        public void ScrollToIndex(int index)
        {
            if (_lerpHorizontalEnabled)
                return;
            
            _targetPercentageToScrollTo = index / (_totalChildren - 1);
            _lerpHorizontalEnabled = true;
        }
    }
}