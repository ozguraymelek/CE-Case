using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace INV.Datas
{
    [CreateAssetMenu(menuName = "Scriptable/Menu/1 Data/Create a new Data",fileName = "New Data")]
    public class DataContainer : ScriptableObject
    {
        [Header("Structs")] 
        [SerializeField] internal GameData gameData;
        [SerializeField] internal PlayerData playerData;
        [SerializeField] internal LevelData levelData;
    }

    [Serializable]
    public struct GameData
    {
        
    }
    
    [Serializable]
    public struct PlayerData
    {
        
    }
    
    [Serializable]
    public struct LevelData
    {
        
    }
}

