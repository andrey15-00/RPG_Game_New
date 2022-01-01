using UnityEngine;
using Zenject;

namespace UnityGame.UI
{
    public abstract class UIAbstractScreen : MonoBehaviour
    {
        [SerializeField] private RectTransform _visual;
        protected UISystem _uiSystem;

        protected abstract void InitInternal();

        public void Init(UISystem uiSystem)
        {
            
        }

        [Inject]
        private void Constructor(UISystem uiSystem)
        {
            if (_uiSystem != null)
                return;

            _uiSystem = uiSystem;

            InitInternal();
        }

        public virtual void Show()
        {
            _visual.gameObject.SetActive(true);
            _visual.transform.SetAsLastSibling();
        }

        public void Hide()
        {
            _visual.gameObject.SetActive(false);
        }
    }
}
