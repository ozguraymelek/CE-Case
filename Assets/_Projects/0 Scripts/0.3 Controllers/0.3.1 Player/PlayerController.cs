using INV.Events;
using INV.Managers;
using UnityEngine;

namespace INV.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Struct References")] 
        [SerializeField] private BehavioralPlayerData iBehavioralPlayerData;
        [SerializeField] private ScreenMultiplierData screenMultiplierData;
        
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
            GameEvents.onUpdate -= MoveForward;
        }
        
        /// <summary>
        ///     Set Behavioral Player Data -
        /// </summary>
        private void InitializeInterfaces()
        {
            iBehavioralPlayerData = new BehavioralPlayerData(20, 150, 10, 
                0, 0,GetComponent<Collider>());
        }

        #endregion
        
        #region Subscribe Events

        private void OnStart()
        {
            GameEvents.onUpdate += MoveForward;
            InitializeInterfaces();
        }
        
        #endregion
        
        #region Update -> Player Move Axis-Z

        private void MoveForward()
        {
            print(iBehavioralPlayerData.GetPlayerForwardSpeed());
            transform.position += Vector3.forward * (iBehavioralPlayerData.GetPlayerForwardSpeed() * Time.deltaTime);
        }

        internal void MoveAxisX(Vector3 mouseMovementDirection)
        {
            print(screenMultiplierData.screenWidthMultiplier);
            
            var mouseToWorldDirection =
                new Vector3(mouseMovementDirection.x * screenMultiplierData.screenWidthMultiplier, 0f, 0f);
            
            print("GetPlayerSensitivityData: " + iBehavioralPlayerData.GetPlayerSensitivityData());
            
            var addVector = mouseToWorldDirection * (iBehavioralPlayerData.GetPlayerSensitivityData() * Time.deltaTime);
            
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

