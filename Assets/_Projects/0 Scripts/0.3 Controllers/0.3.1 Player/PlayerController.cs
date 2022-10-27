using INV.Events;
using INV.Interfaces.Behavioral;
using INV.Interfaces.ScreenMultiplier;
using INV.Managers;
using UnityEngine;

namespace INV.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Interface References")] 
        [SerializeField] private IBehavioralPlayerData iBehavioralPlayerData;
        
        [Header("Struct References")]
        [SerializeField] private IScreenMultiplierData iScreenMultiplierData;
        
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
            iBehavioralPlayerData = new BehavioralPlayerData(5f, 40f, 1.48f, 
                0, 0,GetComponent<Collider>(),GetComponent<Rigidbody>());

            iScreenMultiplierData = new ScreenMultiplierData(1.0f / Screen.width , 
                1.0f / Screen.height);
        }

        #endregion
        
        #region Subscribe Events

        private void OnStart()
        {
            GameEvents.onUpdate += MoveForward;
            InitializeInterfaces();
            print("tten");
        }
        
        #endregion
        
        #region Update -> Player Move Axis-Z

        private void MoveForward()
        {
            print(iBehavioralPlayerData.GetPlayerForwardSpeed());
            // iBehavioralPlayerData.GetPlayerRigidbody().velocity = Vector3.forward * iBehavioralPlayerData.GetPlayerForwardSpeed();
            transform.position += Vector3.forward * (iBehavioralPlayerData.GetPlayerForwardSpeed() * Time.fixedDeltaTime);
        }

        internal void MoveAxisX(Vector3 mouseMovementDirection)
        {
            print(iScreenMultiplierData.GetIScreenMultiplierData().GetScreenWidth());
            
            var mouseToWorldDirection =
                new Vector3(mouseMovementDirection.x * iScreenMultiplierData.GetIScreenMultiplierData().GetScreenWidth(), 0f, 0f);
            
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

