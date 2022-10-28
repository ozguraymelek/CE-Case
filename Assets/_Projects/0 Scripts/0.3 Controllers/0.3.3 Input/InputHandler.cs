using System;
using INV.Events;
using INV.Interfaces.Inputs;
using INV.Interfaces.UnityEventFunctions;
using UnityEngine;

namespace INV.Inputs
{
    public class InputHandler : MonoBehaviour, IOnPointerPressed<Vector3>, IOnPointerRemoved<Vector3>
    {
        [Header("Interface References")]
        private IEventsUnityFunctions _iUnityEventFunctions;
        private IOnPointerPressedEvent<Vector3> _iInputsPressedEvent;
        private IOnPointerMovedEvent<Vector3> _iInputsMovedEvent;
        private IOnPointerRemovedEvent<Vector3> _iInputsRemovedEvent;
        private IInputIsPressingData _iIsPressingData;
        private IInputLastMousePosition _iInputLastPositionData;

        #region All Functions
        
        #region Event Functions

        private void Start()
        {
            SubscribePointerPressed();
            SubscribePointerRemoved();
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
            
            _iInputsPressedEvent = new InputsEvent<Vector3>();
            _iInputsMovedEvent = new InputsEvent<Vector3>();
            _iInputsRemovedEvent = new InputsEvent<Vector3>();
            
            _iIsPressingData = new InputData(false, Input.mousePosition);
            _iInputLastPositionData = new InputData(false, Input.mousePosition);
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

        private void SubscribePointerPressed()
        {
            InputsEvent<Vector3>.onPointerPressed += delegate { OnPointerPressed(Vector3.back); };
        }
        
        private void SubscribePointerRemoved()
        {
            InputsEvent<Vector3>.onPointerRemoved += delegate { OnPointerRemoved(Vector3.back); };
        }
        #endregion

        #region Interface Implementations
        
        public void OnPointerPressed(Vector3 anyComponent)
        {
            _iIsPressingData.SetIsPressingData(true);
        }

        public void OnPointerRemoved(Vector3 anyComponent)
        {
            _iIsPressingData.SetIsPressingData(false);
        }

        #endregion

        #region Functions that can be subscribed

        private void OnFixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _iInputsPressedEvent.Invoke(InputsEvent<Vector3>.onPointerPressed, _iInputLastPositionData.GetLastMousePosition());
                _iIsPressingData.GetIsPressingData();
            }

            if (Input.GetMouseButton(0))
            {
                var currentMousePosition = Input.mousePosition;
                
                if (_iInputLastPositionData.GetLastMousePosition() != currentMousePosition)
                {
                    _iInputsMovedEvent.Invoke(InputsEvent<Vector3>.onPointerMoved, currentMousePosition - _iInputLastPositionData.GetLastMousePosition());
                    _iInputLastPositionData.SetLastMousePosition(currentMousePosition);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                _iInputsRemovedEvent.Invoke(InputsEvent<Vector3>.onPointerRemoved, Input.mousePosition);
                _iIsPressingData.GetIsPressingData();
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
    
    public struct InputData : IInputIsPressingData , IInputLastMousePosition
    {
        [Header("Bool Settings")] 
        [SerializeField] internal bool isPressing;
        
        [Header("Vector Settings")] private Vector3 _lastMousePosition;
        
        public InputData(bool isPressing, Vector3 lastMousePosition)
        {
            this.isPressing = isPressing;
            this._lastMousePosition = lastMousePosition;
        }
        
        public bool GetIsPressingData()
        {
            return isPressing;
        }

        public void SetIsPressingData(bool state)
        {
            isPressing = state;
        }
        
        public Vector3 GetLastMousePosition()
        {
            return _lastMousePosition;
        }

        public void SetLastMousePosition(Vector3 currentPosition)
        {
            _lastMousePosition = currentPosition;
        }
    }
}