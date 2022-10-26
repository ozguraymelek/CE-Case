using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace INV.Events
{
    public class GameEvents : MonoBehaviour
    {
        [Header("<-No Parameter-> Actions")]
        private Action onLevelStarted, onLevelFinished, onFailed, onSuccess, onInteractedWithObstacle;

        private void Awake()
        {
            ResetActions();
        }

        private void ResetActions()
        {
            onLevelStarted = null;
            onLevelFinished = null;
            onFailed = null;
            onSuccess = null;
            onInteractedWithObstacle = null;
        }

        #region Invokable Functions

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
        
    }
}

