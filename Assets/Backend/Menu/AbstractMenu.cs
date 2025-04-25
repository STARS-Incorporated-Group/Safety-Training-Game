using UnityEngine;
using UnityEngine.InputSystem;

namespace Backend.Menu
{
    [RequireComponent(typeof(Canvas))]
    public abstract class AbstractMenu : MonoBehaviour
    {
        protected MenuManager manager { get; private set; }
        private bool _active;
        
        [Header("VR & Input Setup (common)")]
        [SerializeField] protected Transform            head;
        [SerializeField] protected float                spawnDistance = 2f;
        [SerializeField] protected GameObject           menu;
        [SerializeField] protected GameObject           parent;

        protected virtual void Initialize(MenuManager menuManager)
        {
            this.manager = manager;
        }
        
        /// <summary>
        /// Unity callback: called when the component is instantiated.
        /// </summary>
        protected virtual void Awake()
        {
            Initialize(MenuManager.GlobalManager);

            // 2) Hide on start
            _active = false;
            menu.SetActive(false);
            
            // 3) Give subclasses a chance to hook their buttons
            WireButtons();
        }

        /// <summary>
        /// Override to hook up your UI Buttons (e.g. onClick.AddListener(...)).
        /// </summary>
        protected virtual void WireButtons()
        {
        }

        /// <summary>
        /// Override to unhook your UI Buttons.
        /// </summary>
        protected virtual void UnwireButtons()
        {
        }


        protected virtual void OnEnable()  => Load();
        protected virtual void OnDisable() => Close();

        protected virtual void OnDestroy()
        {
            UnwireButtons();
        }

        public virtual void Load()
        {
            _active = true;
        }

        public virtual void Close()
        {
            _active = false;
        }

        public virtual void Back()
        {
            manager.Back();
        }

        private void Update()
        {
            UpdateVisibility();
        }

        protected virtual void UpdateVisibility()
        {
            // show/hide + position logic
            if (menu.activeSelf != _active)
            {
                menu.SetActive(_active);
            }

            if (_active)
            {
                var lookPos = new Vector3(head.position.x, menu.transform.position.y, head.position.z);
                menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
                menu.transform.LookAt(lookPos);
                menu.transform.forward *= -1;
            }
        }
    }
}