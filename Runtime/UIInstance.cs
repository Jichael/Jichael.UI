using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Silicom.UI
{
    public class UIInstance : MonoBehaviour
    {
        [SerializeField] private UIAnimationController animationController;

        [SerializeField] private bool openedOnAwake;

        [SerializeField] private bool animateIn;
        [SerializeField, ShowIf(nameof(animateIn))] private UIAnimationEffect animationIn;
        [SerializeField] private bool animateOut;
        [SerializeField, ShowIf(nameof(animateOut))] private UIAnimationEffect animationOut;

        [SerializeField] private bool ignoreManager;

        public bool Opened { get; private set; }
        public bool Disabled { get; set; }

        public event Action OnOpen;
        public event Action OnClose;

        protected virtual void Awake()
        {
            if (openedOnAwake)
            {
                Opened = false;
                Open();
            }
            else
            {
                Opened = true;
                Close();
            }
        }

        protected virtual void OnDestroy()
        {
            Opened = false;
            if(!ignoreManager) UIManager.Instance.RemoveInstance(this);
        }

        public virtual void Open()
        {
            if (Opened || Disabled) return;
            if (Mathf.Approximately(Time.timeScale, 0)) return;
            
            Opened = true;
            if(!ignoreManager) UIManager.Instance.AddInstance(this);
            OnOpen?.Invoke();
            if(animateIn) UIAnimationManager.Instance.PlayAnimation(animationController, animationIn);
        }

        public virtual void Close()
        {
            if (!Opened || Disabled) return;
            if (Mathf.Approximately(Time.timeScale, 0)) return;
            
            Opened = false;
            OnClose?.Invoke();
            if(!ignoreManager) UIManager.Instance.RemoveInstance(this);
            if(animateOut) UIAnimationManager.Instance.PlayAnimation(animationController, animationOut);
        }

        public virtual void Toggle()
        {
            if (Opened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }
}