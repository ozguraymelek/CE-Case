using INV.Events;
using INV.Interfaces.Behavioral;
using INV.Interfaces.ScreenMultiplier;
using INV.Managers;
using UnityEngine;

namespace INV.Controllers
{
    public class PlayerController : MonoBehaviour , IScreenWidthMultiplier
    {
        [Header("Interface References")] 
        [SerializeField] private IBehavioralPlayerData iBehavioralPlayerData;
        [SerializeField] private IScreenWidthMultiplier iScreenMultiplierData;
        
        
        #region Event Functions

        private void Start()
        {
            InitializeSubscribes();
        }

        #endregion
        
        #region Initializes

        private void InitializeSubscribes()
        {
            GameEvents.onStart += OnStart;
        }

        private void UnSubscribe()
        {
            
        }
        
        /// <summary>
        ///     Set Behavioral Player Data -
        /// </summary>
        private void InitializeInterfaces()
        {
            // ReSharper disable once HeapView.BoxingAllocation
            iBehavioralPlayerData = new BehavioralPlayerData(5f, 40f, 1.48f, 
                0, 0,GetComponent<Collider>(),GetComponent<Rigidbody>());

            // ReSharper disable once HeapView.BoxingAllocation
            iScreenMultiplierData = new ScreenMultiplierData(1.0f / Screen.width , 
                1.0f / Screen.height);
        }

        #endregion
        
        #region Subscribe Events

        private void OnStart()
        {
            InitializeInterfaces();
            print("tten");
        }
        
        #endregion

        #region Interface Implementations
        
        public float GetScreenWidth()
        {
            return iScreenMultiplierData.GetScreenWidth();
        }

        #endregion
        
        #region Update -> Player Move Axis-Z
        
        internal void MoveAxisX(Vector3 mouseMovementDirection)
        {
            print(GetScreenWidth());
            
            var mouseToWorldDirection =
                new Vector3(mouseMovementDirection.x * GetScreenWidth(), 0f, 0f);
            
            print("GetPlayerSensitivityData: " + iBehavioralPlayerData.GetPlayerSensitivityData());

            var addVector = mouseToWorldDirection *
                            (iBehavioralPlayerData.GetPlayerSensitivityData() * Time.fixedDeltaTime);
            
            // iBehavioralPlayerData.GetPlayerRigidbody().AddForce(addVector);
            transform.position += addVector;
            
            print("MoveAxisX");
            
            if (transform.position.x < -iBehavioralPlayerData.GetPlayerBoundX())
                transform.position = new Vector3(-iBehavioralPlayerData.GetPlayerBoundX(), transform.position.y, transform.position.z);
            
            if (transform.position.x > iBehavioralPlayerData.GetPlayerBoundX())
                transform.position = new Vector3(iBehavioralPlayerData.GetPlayerBoundX(), transform.position.y, transform.position.z);
        }

        #endregion
    }
}

