using Backend.Menu;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class LevelSelectionMenu : AbstractMenu
    {
        [Header("Configure Events (assign in Inspector)")]
        [SerializeField] protected List<UnityEvent> startEvents;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected List<Button> startButtons;
        [SerializeField] protected Button backButton;

        private readonly List<UnityAction> _listeners = new List<UnityAction>();

        protected override void Awake()
        {
            base.Awake();
            if (startButtons.Count != startEvents.Count)
            {
                throw new ArgumentException("mismatch between StartButtons count and StartEvents count.");
            }
        }

        protected override void WireButtons()
        {
            for (var i = 0; i < startButtons.Count; i++)
            {
                var index = i;
                UnityAction listener = () =>
                {
                    manager.Close();
                    startEvents[index].Invoke();
                };
                
                this._listeners.Add(listener);
                startButtons[index].onClick.AddListener(listener);
            }
            backButton.onClick.AddListener(Back);
        }
        
        protected override void UnwireButtons()
        {
            for (var i = 0; i < startButtons.Count; i++)
            {
                startButtons[i].onClick.RemoveListener(_listeners[i]);
            }
            _listeners.Clear();
            backButton.onClick.RemoveListener(Back);
        }

        public void SelectLevel(int index)
        {
            if (index < startButtons.Count)
            {
                manager.Close();
                startEvents[index].Invoke();
            }
            else
            {
                throw new IndexOutOfRangeException("index is out of range.");
            }
        }
    }
}