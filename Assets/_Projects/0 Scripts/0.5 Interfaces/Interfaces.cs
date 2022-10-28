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
            void Invoke(Action action);
        }

        public interface IOnAwake
        {
            void Invoke(Action action);
        }

        public interface IOnStart
        {
            void Invoke(Action action);
        }

        public interface IOnUpdate
        {
            void Invoke(Action action);
        }
    
        public interface IOnFixedUpdate
        {
            void Invoke(Action action);
        }
    
        public interface IOnLateUpdate
        {
            void Invoke(Action action);
        }

        #endregion
    }

    namespace Inputs
    {
        #region Events
        
        public interface IInputsEvent<T> : IOnPointerPressedEvent<T>, IOnPointerMovedEvent<T>, IOnPointerRemovedEvent<T>
        {
            // If there is a script that you need to use "all" pointer event interfaces,
            // apply this interface (IEventsUnityFunctions) directly!
            
            new void Invoke(Action<T> action, T position);
        }

        public interface IOnPointerPressedEvent<T>
        {
            void Invoke(Action<T> action, T position);
        }
        
        public interface IOnPointerMovedEvent<T>
        {
            void Invoke(Action<T> action, T position);
        }
        
        public interface IOnPointerRemovedEvent<T>
        {
            void Invoke(Action<T> action, T position);
        }
        

        #endregion

        #region X

        public interface IInputs<T> : IOnPointerPressed<T>, IOnPointerMoved<T>, IOnPointerRemoved<T>
        {
            // If there is a script that you need to use "all" pointer interfaces,
            // apply this interface (IEventsUnityFunctions) directly!
            
            new void Invoke(Action<T> action, T position);
        }
        
        public interface IOnPointerPressed<in T>
        {
            void Invoke(T anyComponent);
        }
        
        public interface IOnPointerMoved<in T>
        {
            void Invoke(T anyComponent);
        }
        
        public interface IOnPointerRemoved<in T>
        {
            void Invoke(T anyComponent);
        }
        #endregion
        
    }
}
