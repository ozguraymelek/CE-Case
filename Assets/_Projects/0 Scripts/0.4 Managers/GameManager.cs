using System;
using System.Collections;
using System.Collections.Generic;
using INV.Events;
using UnityEngine;

namespace INV.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Struct References")] 
        [SerializeField] private ScreenMultiplierData screenMultiplierData;
        
        #region Event Functions

        private void Awake()
        {
            InitializeScreenMultiplier();
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
            screenMultiplierData.screenWidthMultiplier = 1.0f / Screen.width;
            screenMultiplierData.screenHeightMultiplier = 1.0f / Screen.height;
            
            print("width : " + screenMultiplierData.screenWidthMultiplier);
            print("height : " + screenMultiplierData.screenHeightMultiplier);
        }
        
        #endregion

        #region Interface Implementing
        
        
        
        #endregion

        
    }
    
    public struct ScreenMultiplierData
    {
        [Header("Float Settings")]
        internal float screenWidthMultiplier;
        internal float screenHeightMultiplier;
    }
}