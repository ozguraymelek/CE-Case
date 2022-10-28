using System;
using INV.Events;
using INV.Interfaces.UnityEventFunctions;
using UnityEngine;

namespace INV.Inputs
{
    public class InputHandler : MonoBehaviour
    { 
        [field: Header("Event Actions")]
        public static event Action<Vector3> onPointerPressed;
        public static event Action<Vector3> onPointerMoved;
        public static event Action<Vector3> onPointerRemoved;

        [Header("Interface References")]
        private IEventsUnityFunctions _iUnityEventFunctions;
        
        
        [Header("Settings")] private Vector3 lastMousePosition;

        #region All Functions
        
        #region Event Functions

        private void Start()
        {
            InitializeInterfaces();
            SubscribeOnStart();

            _iUnityEventFunctions?.Invoke(Actions.onStart);
        }

        private void FixedUpdate()
        {
            _iUnityEventFunctions?.Invoke(Actions.onFixedUpdate);
        }

        #endregion

        #region Initializes

        private void InitializeInterfaces()
        {
            _iUnityEventFunctions = new Actions();
        }
        

        #endregion
        
        #region Subscribes

        private void SubscribeOnStart()
        {
            Actions.onStart += OnStart;
        }

        private void OnStart()
        {
            Actions.onFixedUpdate += OnFixedUpdate;
            print(this.name + " started!");
        }

        #endregion

        #region Implementings

        private void OnFixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
                onPointerPressed?.Invoke(lastMousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                var currentMousePosition = Input.mousePosition;
                
                if (lastMousePosition != currentMousePosition)
                {
                    onPointerMoved?.Invoke(currentMousePosition - lastMousePosition);
                    lastMousePosition = currentMousePosition;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                onPointerRemoved?.Invoke(Input.mousePosition);
            }
        }

        #endregion

        #endregion
    }
    
    [Serializable]
    public class InputData
    {
        [Header("Bool Settings")] 
        [SerializeField] internal bool isPressing = false;
    }
}