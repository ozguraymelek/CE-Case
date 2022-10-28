using System;
using System.Collections;
using System.Collections.Generic;
using INV.Managers;
using UnityEngine;

namespace INV.Interfaces
{
    namespace Behavioral
    {
        #region Behavioral.cs

        public interface IBehavioralPlayerData : IBehavioralPlayerForwardSpeedData, IBehavioralPlayerSensitivityData,
            IBehavioralPlayerBoundX, IBehavioralPlayerCollider, IBehavioralPlayerRigidbody
        {
            // If there is a script that you need to use all behavioral interfaces,
            // apply this interface (IBehavioralPlayerData) directly!
        }

        public interface IBehavioralPlayerForwardSpeedData
        {
            float GetPlayerForwardSpeed();
        }

        public interface IBehavioralPlayerSensitivityData
        {
            float GetPlayerSensitivityData();
        }

        public interface IBehavioralPlayerBoundX
        {
            float GetPlayerBoundX();
        }
    
        public interface IBehavioralSpeedDecreaseFactor
        {
            float GetSpeedDecreaseFactor();
        }
    
        public interface IBehavioralSpeedIncreaseFactor
        {
            float GetSpeedIncreaseFactor();
        }
    
        public interface IBehavioralPlayerCollider
        {
            Collider GetPlayerCollider();
        }

        public interface IBehavioralPlayerRigidbody
        {
            Rigidbody GetPlayerRigidbody();
        }

        #endregion
    }

    namespace ScreenMultiplier
    {
        public interface IScreenMultiplierData : IScreenHeightMultiplier, IScreenWidthMultiplier
        {
            // If there is a script that you need to use "all" screen data interfaces,
            // apply this interface (IScreenMultiplierData) directly!
        }
        
        public interface IScreenWidthMultiplier
        {
            float GetScreenWidth();
        }
        
        public interface IScreenHeightMultiplier
        {
            float GetScreenHeight();
        }
    }
    
    namespace UnityEventFunctions
    {
        #region Unity Events

        public interface IEventsUnityFunctions : IOnStart, IOnFixedUpdate
        {
            // If there is a script that you need to use "all" unity event interfaces,
            // apply this interface (IEventsUnityFunctions) directly!
            new void Invoke(Action onStart);
        }

        public interface IOnEnable
        {
            void OnEnableA();
        }

        public interface IOnAwake
        {
            void OnAwake();
        }

        public interface IOnStart
        {
            void Invoke(Action action);
        }

        public interface IOnUpdate
        {
            void OnUpdate();
        }
    
        public interface IOnFixedUpdate
        {
            void Invoke(Action action);
        }
    
        public interface IOnLateUpdate
        {
            void OnLateUpdate();
        }

        #endregion
    }
}
