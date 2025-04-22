using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public class RoomSelectionMenu: AbstractMenu
    {
        [Header("Configure Logic (assign in Inspector)")]
        [SerializeField] protected List<LevelSelectionMenu> roomMenus;
        
        [Header("UI Buttons (assign in Inspector)")]
        [SerializeField] protected List<Button> roomButtons;
        [SerializeField] protected Button backButton;
        
        private readonly List<UnityAction> _listeners = new List<UnityAction>();
        
        protected override void WireButtons()
        {
            for (var i = 0; i < roomMenus.Count; i++)
            {
                var index = i;
                UnityAction listener = () =>
                {
                    manager.Select(roomMenus[index]);
                };
                _listeners.Add(listener);
                roomButtons[i].onClick.AddListener(listener);
            }
            backButton.onClick.AddListener(Back);
        }

        protected override void UnwireButtons()
        {
            for (var i = 0; i < roomMenus.Count; i++)
            {
                roomButtons[i].onClick.RemoveListener(_listeners[i]);
            }
            _listeners.Clear();
            backButton.onClick.RemoveListener(Back);
        }
    }
}