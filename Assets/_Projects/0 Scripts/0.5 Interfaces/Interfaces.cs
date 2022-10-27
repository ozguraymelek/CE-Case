using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace INV.Interfaces
{
    namespace BehavioralInterfaces
    {
        #region Behavioral.cs

        public interface IBehavioralPlayerData : IBehavioralPlayerForwardSpeedData, IBehavioralPlayerSensitivityData,
            IBehavioralPlayerBoundX, IBehavioralPlayerCollider
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

        #endregion
    }
}
