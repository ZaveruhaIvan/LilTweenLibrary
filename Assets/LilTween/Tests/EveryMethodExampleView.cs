using System.Collections;
using LilTween.ChangeCanvasGroupAlpha;
using LilTween.ChangeColor;
using LilTween.ChangeGraphicAlpha;
using LilTween.Core;
using LilTween.MoveRect;
using LilTween.ScaleRect;
using LilTween.SimpleRotateRect;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public class EveryMethodExampleView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Graphic _graphic1;
        [SerializeField] private Graphic _graphic2;
        [SerializeField] private RectTransform _rectTransform1;
        [SerializeField] private RectTransform _rectTransform2;
        [SerializeField] private RectTransform _rectTransform3;
        [SerializeField] private float _duration = 0.75f;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);

            LilTweenSingleton.Instance.ChangeAlpha(_canvasGroup, 0.1f, _duration);
            LilTweenSingleton.Instance.ChangeAlpha(_graphic1, 0.1f, _duration);
            LilTweenSingleton.Instance.ChangeColor(_graphic2, Color.blue, _duration);
            LilTweenSingleton.Instance.MoveRect(_rectTransform1, new Vector2(800, 400), _duration);
            LilTweenSingleton.Instance.ScaleRect(_rectTransform2, new Vector2(3f, 3f), _duration);
            LilTweenSingleton.Instance.RotateRect(_rectTransform3, -180f, _duration);
        }
    }
}