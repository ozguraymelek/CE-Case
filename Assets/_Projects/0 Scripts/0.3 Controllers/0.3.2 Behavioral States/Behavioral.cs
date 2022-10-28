using System;
using System.Collections;
using INV.Events;
using INV.Inputs;
using INV.Interfaces.Behavioral;
using INV.Interfaces.Inputs;
using INV.Managers;
using UnityEngine;

namespace INV.Controllers
{
    public class Behavioral : MonoBehaviour
    {
        [Header("Monobehaviour Scrip References")] [SerializeField]
        private PlayerController playerController;

        [Header("Struct References")] [SerializeField]
        private BehavioralPlayerData behavioralPlayerData;

        // [Header("Class References")] [SerializeField]

        #region Event Functions

        private void Start()
        {
            GetComponents();
            InitializeSubscribes();
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }

        #endregion

        #region Initializes

        private void GetComponents()
        {
            behavioralPlayerData.playerCollider = GetComponentInChildren<Collider>();
        }

        private void InitializeSubscribes()
        {
            Actions.onInteractedWithObstacle += OnInteractedWithObstacle;
            
            // InputsEvent<Vector3>.onPointerPressed += OnPointerPressed;
        }

        private void UnSubscribe()
        {
            Actions.onInteractedWithObstacle -= OnInteractedWithObstacle;
        }

        #endregion

        #region Subscribe Events
        
        private void OnInteractedWithObstacle()
        {
            Actions.onInteractedWithObstacle += InteractedWithObstacle;
        }

        #endregion

        #region Functions that can be subscribed

        #region Interacted With Obstacle

        private void InteractedWithObstacle()
        {
            var initSpeed = behavioralPlayerData.playerForwardSpeed;

            StartCoroutine(DecreaseRunnerSpeed(initSpeed));
        }

        private IEnumerator DecreaseRunnerSpeed(float initSpeed)
        {
            bool decreasing = true;

            while (decreasing == true)
            {
                behavioralPlayerData.playerForwardSpeed -= behavioralPlayerData.speedDecreaseFactor * Time.deltaTime;

                if (behavioralPlayerData.playerForwardSpeed <= -initSpeed)
                {
                    StartCoroutine(IncreaseRunnerSpeed(initSpeed));

                    decreasing = false;
                }

                yield return null;
            }
        }

        private IEnumerator IncreaseRunnerSpeed(float initSpeed)
        {
            bool increasing = true;

            while (increasing == true)
            {
                behavioralPlayerData.playerForwardSpeed += behavioralPlayerData.speedIncreaseFactor * Time.deltaTime;

                if (behavioralPlayerData.playerForwardSpeed >= initSpeed)
                {
                    behavioralPlayerData.playerForwardSpeed = initSpeed;

                    increasing = false;
                }

                yield return null;
            }
        }

        #endregion

        #endregion

        #region Interface Implementations
        
        

        #endregion
    }

    public struct BehavioralPlayerData : IBehavioralPlayerData
    {
        [Header("Float Settings")] 
        [SerializeField] internal float playerForwardSpeed;

        [SerializeField] internal float playerSensitivity;
        [SerializeField] internal float playerBoundX;
        [SerializeField] internal float speedDecreaseFactor, speedIncreaseFactor;

        [Header("Components")]
        [SerializeField] internal Collider playerCollider;
        [SerializeField] internal Rigidbody playerRigidbody;

        public BehavioralPlayerData(float playerForwardSpeed, float playerSensitivity, float playerBoundX, float speedDecreaseFactor,
            float speedIncreaseFactor, Collider playerCollider, Rigidbody playerRigidbody)
        {
            this.playerForwardSpeed = playerForwardSpeed;
            this.playerSensitivity = playerSensitivity;
            this.playerBoundX = playerBoundX;
            this.speedDecreaseFactor = speedDecreaseFactor;
            this.speedIncreaseFactor = speedIncreaseFactor;
            this.playerCollider = playerCollider;
            this.playerRigidbody = playerRigidbody;
        }
        
        public float GetPlayerForwardSpeed()
        {
            return playerForwardSpeed;
        }

        public float GetPlayerSensitivityData()
        {
            return playerSensitivity;
        }

        public float GetPlayerBoundX()
        {
            return playerBoundX;
        }

        public Collider GetPlayerCollider()
        {
            return playerCollider;
        }

        public Rigidbody GetPlayerRigidbody()
        {
            return playerRigidbody;
        }
    }
}