using System;
using System.Collections;
using System.Collections.Generic;
using INV.Events;
using UnityEngine;

namespace INV.Inputs
{
    public class InputHandler : MonoBehaviour
    { 
        public static event Action<Vector3> onPointerPressed;
        public static event Action<Vector3> onPointerMoved;
        public static event Action<Vector3> onPointerRemoved;

        [Header("Script References")] [SerializeField]
        private GameEvents gameEvents;
        
        [Header("Settings")] private Vector3 lastMousePosition;

        #region All Functions

        #region Event Functions

        private void Start()
        {
            SubscribeOnStart();
        }

        #endregion

        #region Subscribes

        private void SubscribeOnStart()
        {
            GameEvents.onStart += OnStart;
        }

        private void OnStart()
        {
            GameEvents.onUpdate += OnUpdate;
        }

        #endregion

        #region Implementings

        private void OnUpdate()
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
}