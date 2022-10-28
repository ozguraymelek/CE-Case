using System;
using System.Collections;
using System.Collections.Generic;
using INV.Events;
using INV.Interfaces.ScreenMultiplier;
using UnityEngine;

namespace INV.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Struct References")] 
        [SerializeField] private IScreenMultiplierData iScreenMultiplierData;
        
        #region Event Functions

        private void Awake()
        {
            InitializeInterfaces();
            // OnStart();
        }

        private void Update()
        {
            // OnUpdate();
        }

        #endregion
        
        #region Initializes

        private void InitializeScreenMultiplier()
        {
            
        }

        private void InitializeInterfaces()
        {
            iScreenMultiplierData =
                new ScreenMultiplierData(1.0f / Screen.width, 1.0f / Screen.height);
        }
        
        #endregion

        #region Interface Implementing
        
        
        
        #endregion

        
    }
    
    public struct ScreenMultiplierData : IScreenMultiplierData
    {
        [Header("Float Settings")]
        private float screenWidthMultiplier;
        private float screenHeightMultiplier;
        
        public ScreenMultiplierData(float screenWidthMultiplier, float screenHeightMultiplier)
        {
            this.screenWidthMultiplier = screenWidthMultiplier;
            this.screenHeightMultiplier = screenHeightMultiplier;
        }

        public float GetScreenHeight()
        {
            return screenHeightMultiplier;
        }

        public float GetScreenWidth()
        {
            return screenWidthMultiplier;
        }
    }
}