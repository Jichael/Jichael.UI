using System;
using System.Collections.Generic;
using UnityEngine;

namespace Silicom.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        private readonly List<UIInstance> _UIInstances = new List<UIInstance>();

        public event Action<UIInstance> OnInstanceOpened;
        public event Action<UIInstance> OnInstanceClosed;

        public event Action OnFirstInstanceOpened;
        public event Action OnLastInstanceClosed;

        private void Awake()
        {
            Instance = this;
        }

        public void AddInstance(UIInstance instance)
        {
            _UIInstances.Add(instance);
            OnInstanceOpened?.Invoke(instance);
            if(_UIInstances.Count == 1) OnFirstInstanceOpened?.Invoke();
        }

        public void RemoveInstance(UIInstance instance)
        {
            _UIInstances.Remove(instance);
            OnInstanceClosed?.Invoke(instance);
            if(_UIInstances.Count == 0) OnLastInstanceClosed?.Invoke();
        }

        public void CloseAll()
        {
            for (int i = 0; i < _UIInstances.Count; i++)
            {
                _UIInstances[i].Close();
            }
        }
        
    }
}