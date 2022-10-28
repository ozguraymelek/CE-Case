using System;
using System.Collections;
using System.Collections.Generic;
using INV.Interfaces.UnityEventFunctions;
using INV.Managers;
using UnityEngine;

namespace INV.Events
{
    public class Actions : IEventsUnityFunctions
    {
        [Header("<- No Parameter -> Actions for Gameplay")]
        public static Action onLevelStarted, onLevelFinished, onFailed, onSuccess, onInteractedWithObstacle;

        [Header("<- No Parameter -> Actions for Event Functions")]
        public static Action onEnable, onAwake, onStart, onUpdate, onFixedUpdate, onLateUpdate;

        public void Invoke(Action action)
        {
            action?.Invoke();
        }
    }
    
    public class GameEvents : MonoBehaviour
    {

        private void InitializeActions()
        {
            var actions = new Actions();
        }

        #region All Functions

        #region Event Functions
        
        private void Awake()
        {
            ResetGameplayActions();
            ResetGameActions();
        }

        #endregion
        
        #region Initializes

        #region Resets
        
        private void ResetGameplayActions()
        {
            Actions.onLevelStarted = null;
            Actions.onLevelFinished = null;
            Actions.onFailed = null;
            Actions.onSuccess = null;
            Actions.onInteractedWithObstacle = null;
        }

        private void ResetGameActions()
        {
            Actions.onEnable = null;
            Actions.onAwake = null;
            Actions.onStart = null;
            Actions.onUpdate = null;
            Actions.onFixedUpdate = null;
            Actions.onLateUpdate = null;
        }
        
        #endregion
        
        #endregion

        #region Invokable Functions

        #region Gameplay Functions

        public void OnLevelStarted()
        {
            Actions.onLevelStarted?.Invoke();
        }
        
        public void OnLevelFinished()
        {
            Actions.onLevelFinished?.Invoke();
        }
        
        public void OnFailed()
        {
            Actions.onFailed?.Invoke();
        }
        
        public void OnSuccess()
        {
            Actions.onSuccess?.Invoke();
        }
        
        public void OnInteractedWithObstacle()
        {
            Actions.onInteractedWithObstacle?.Invoke();
        }

        #endregion
        
        #endregion

        #endregion
    }
}