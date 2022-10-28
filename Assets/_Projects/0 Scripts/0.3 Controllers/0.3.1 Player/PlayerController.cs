using INV.Events;
using INV.Inputs;
using INV.Interfaces.Behavioral;
using INV.Interfaces.Inputs;
using INV.Interfaces.ScreenMultiplier;
using INV.Managers;
using UnityEngine;

namespace INV.Controllers
{
    public class PlayerController : MonoBehaviour, IOnPointerMoved<Vector3>
    {
        [Header("Interface References")] 
        [SerializeField] private IBehavioralPlayerData iBehavioralPlayerData;
        [SerializeField] private IScreenWidthMultiplier iScreenMultiplierData;
        
        
        #region Event Functions

        private void Start()
        {
            InitializeInterfaces();
            InitializeActionSubscribes();
            InitializeInputSubscribes();
        }

        #endregion
        
        #region Initializes

        private void InitializeActionSubscribes()
        {
            Actions.onStart += OnStart;
        }

        private void InitializeInputSubscribes()
        {
            InputsEvent<Vector3>.onPointerMoved += OnPointerMoved;
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
            
        }
        
        
        #endregion

        #region Interface Implementations
        
        public void OnPointerMoved(Vector3 mouseMovementDirection)
        {
            MoveAxisX(mouseMovementDirection);
        }

        #endregion
        
        #region Update -> Player Move Axis-Z
        
        internal void MoveAxisX(Vector3 mouseMovementDirection)
        {
            var mouseToWorldDirection =
                new Vector3((float)(mouseMovementDirection.x * iScreenMultiplierData?.GetScreenWidth()), 0f, 0f);
            
            var addVector = mouseToWorldDirection *
                            (iBehavioralPlayerData.GetPlayerSensitivityData() * Time.fixedDeltaTime);
            
            // iBehavioralPlayerData.GetPlayerRigidbody().AddForce(addVector);
            transform.position += addVector;
            
            if (transform.position.x < -iBehavioralPlayerData.GetPlayerBoundX())
                transform.position = new Vector3(-iBehavioralPlayerData.GetPlayerBoundX(), transform.position.y, transform.position.z);
            
            if (transform.position.x > iBehavioralPlayerData.GetPlayerBoundX())
                transform.position = new Vector3(iBehavioralPlayerData.GetPlayerBoundX(), transform.position.y, transform.position.z);
        }

        #endregion
    }
}

