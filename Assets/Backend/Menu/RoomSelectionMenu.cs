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
            if (_listeners.Count == 0)
            {
                for (var i = 0; i < roomMenus.Count; i++)
                {
                    var index = i;
                    _listeners.Add(() => manager.Select(roomMenus[index]));
                }
            }

            for (var i = 0; i < roomButtons.Count; i++)
            {
                var index = i;
                roomButtons[i].onClick.AddListener(_listeners[index]);
            }
            backButton.onClick.AddListener(Back);
        }

        protected override void UnwireButtons()
        {
            for (var i = 0; i < roomMenus.Count; i++)
            {
                roomButtons[i].onClick.RemoveListener(_listeners[i]);
            }
            backButton.onClick.RemoveListener(Back);
        }
    }
}