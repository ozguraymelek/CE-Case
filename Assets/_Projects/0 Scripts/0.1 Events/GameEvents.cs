using System;
using System.Collections;
using System.Collections.Generic;
using INV.Managers;
using UnityEngine;

namespace INV.Events
{
    public class GameEvents : MonoBehaviour
    {
        [Header("<- No Parameter -> Actions for Gameplay")]
        public static Action onLevelStarted, onLevelFinished, onFailed, onSuccess, onInteractedWithObstacle;

        [Header("<- No Parameter -> Actions for Event Functions")]
        public static Action onEnable, onAwake, onStart, onUpdate, onFixedUpdate, onLateUpdate;

        #region All Functions

        #region Event Functions
        
        private void Awake()
        {
            ResetGameplayActions();
            ResetGameActions();
        }

        private void Start()
        {
            OnStart();
        }

        private void Update()
        {
            OnUpdate();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
        }

        #endregion
        
        #region Initializes

        #region Resets
        
        private void ResetGameplayActions()
        {
            onLevelStarted = null;
            onLevelFinished = null;
            onFailed = null;
            onSuccess = null;
            onInteractedWithObstacle = null;
        }

        private void ResetGameActions()
        {
            onEnable = null;
            onAwake = null;
            onStart = null;
            onUpdate = null;
            onFixedUpdate = null;
            onLateUpdate = null;
        }
        
        #endregion
        
        #endregion

        #region Invokable Functions

        #region Gameplay Functions

        public void OnLevelStarted()
        {
            onLevelStarted?.Invoke();
        }
        
        public void OnLevelFinished()
        {
            onLevelFinished?.Invoke();
        }
        
        public void OnFailed()
        {
            onFailed?.Invoke();
        }
        
        public void OnSuccess()
        {
            onSuccess?.Invoke();
        }
        
        public void OnInteractedWithObstacle()
        {
            onInteractedWithObstacle?.Invoke();
        }

        #endregion

        #region Event Functions

        public void OnEnableA() //not event function.
        {
            onEnable?.Invoke();
        }

        public void OnAwake()
        {
            onAwake?.Invoke();
        }

        public void OnStart()
        {
            onStart?.Invoke();
        }
        
        public void OnUpdate()
        {
            onUpdate?.Invoke();
        }
        
        public void OnFixedUpdate()
        {
            onFixedUpdate?.Invoke();
        }
        
        public void OnLateUpdate()
        {
            onLateUpdate?.Invoke();
        }
        #endregion

        #endregion

        #endregion
    }
}