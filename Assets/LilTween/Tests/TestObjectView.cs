using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tests
{
    public class TestObjectView : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public Image Image { get; private set; }

        [SerializeField] private TextMeshProUGUI _text;

        public void Set(bool isLilTween)
        {
            if (isLilTween)
            {
                SetLilTween();
            }
            else
            {
                SetDoTween();
            }
        }

        public void SetDoTween()
        {
            _text.text = "D";
            Image.color = Color.green;
        }

        public void SetLilTween()
        {
            _text.text = "L";
            Image.color = Color.blue;
        }
    }
}