using UnityEngine;

namespace UnityGame.UI
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private RectTransform _visual;

        public void Show()
        {
            _visual.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _visual.gameObject.SetActive(false);
        }
    }
}
