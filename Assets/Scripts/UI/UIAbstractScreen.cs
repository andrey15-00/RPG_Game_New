using UnityEngine;

namespace UnityGame.UI
{
    public abstract class UIAbstractScreen : MonoBehaviour
    {
        [SerializeField] private RectTransform _visual;
        protected UISystem _uiSystem;

        protected abstract void InitInternal();

        public void Init(UISystem uiSystem)
        {
            if (_uiSystem != null)
                return;

            _uiSystem = uiSystem;

            InitInternal();
        }

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
