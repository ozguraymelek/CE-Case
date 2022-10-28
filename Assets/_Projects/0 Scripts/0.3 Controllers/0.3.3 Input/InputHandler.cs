using System;
using INV.Events;
using INV.Interfaces.Inputs;
using INV.Interfaces.UnityEventFunctions;
using UnityEngine;

namespace INV.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        [Header("Interface References")]
        private IEventsUnityFunctions _iUnityEventFunctions;
        private IInputsEvent<Vector3> _iInputsEvent;
        
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
            _iInputsEvent = new InputsEvent<Vector3>();
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
            
        }

        #endregion

        #region Implementings

        private void OnFixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
                _iInputsEvent.Invoke(InputsEvent<Vector3>.onPointerPressed, lastMousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                var currentMousePosition = Input.mousePosition;
                
                if (lastMousePosition != currentMousePosition)
                {
                    _iInputsEvent.Invoke(InputsEvent<Vector3>.onPointerMoved, currentMousePosition - lastMousePosition);
                    lastMousePosition = currentMousePosition;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _iInputsEvent.Invoke(InputsEvent<Vector3>.onPointerRemoved, Input.mousePosition);
            }
        }

        #endregion

        #endregion
    }
    
    public class InputsEvent<T> : IInputsEvent<T>
    {
        [field: Header("Event Actions")]
        public static Action<T> onPointerPressed;
        public static Action<T> onPointerMoved;
        public static Action<T> onPointerRemoved;
        
        public void Invoke(Action<T> action, T position)
        {
            action?.Invoke(position);
        }
    }
    
    [Serializable]
    public class InputData
    {
        [Header("Bool Settings")] 
        [SerializeField] internal bool isPressing = false;
    }
}