using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace INV.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Struct References")] 
        [SerializeField] private ScreenMultiplierData screenMultiplierData;
        
        #region Event Functions

        private void Start()
        {
            InitializeScreenMultiplier();
        }

        #endregion
        
        #region Initializes

        private void InitializeScreenMultiplier()
        {
            screenMultiplierData.screenWidthMultiplier = 1.0f / Screen.width;
            screenMultiplierData.screenHeightMultiplier = 1.0f / Screen.height;
        }
        
        #endregion
    }
    
    [Serializable]
    public struct ScreenMultiplierData
    {
        [Header("Float Settings")]
        [SerializeField] internal float screenWidthMultiplier;
        [SerializeField] internal float screenHeightMultiplier;
    }
}