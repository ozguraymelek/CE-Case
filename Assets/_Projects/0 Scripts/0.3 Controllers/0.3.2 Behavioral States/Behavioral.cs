using System;
using System.Collections;
using System.Collections.Generic;
using INV.Events;
using INV.Inputs;
using INV.Managers;
using UnityEngine;

namespace INV.Controllers
{
    public class Behavioral : MonoBehaviour
    {
        [Header("Struct References")] 
        [SerializeField] private BehavioralPlayerData behavioralPlayerData;
        [SerializeField] private ScreenMultiplierData screenMultiplierData;
        
        [Header("Class References")] 
        [SerializeField] private InputData inputData;

        #region Event Functions

        private void Awake()
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
            GameEvents.onStart += OnStart;
            GameEvents.onInteractedWithObstacle += OnInteractedWithObstacle;

            InputHandler.onPointerMoved += OnPointerMoved;
            InputHandler.onPointerPressed += OnPointerPressed;
            InputHandler.onPointerRemoved += OnPointerRemoved;
        }

        private void UnSubscribe()
        {
            GameEvents.onUpdate -= MoveForward;
            GameEvents.onInteractedWithObstacle -= OnInteractedWithObstacle;
            
            InputHandler.onPointerMoved -= OnPointerMoved;
            InputHandler.onPointerPressed -= OnPointerPressed;
            InputHandler.onPointerRemoved -= OnPointerRemoved;
        }
        
        #endregion

        #region Subscribe Events

        private void OnPointerRemoved(Vector3 mouseMovementDirection)
        {
            inputData.isPressing = false;
        }

        private void OnPointerPressed(Vector3 mouseMovementDirection)
        {
            inputData.isPressing = true;
        }

        private void OnPointerMoved(Vector3 mouseMovementDirection)
        {
            MoveAxisX(mouseMovementDirection);
        }

        private void OnInteractedWithObstacle()
        {
            GameEvents.onInteractedWithObstacle += InteractedWithObstacle;
        }

        private void OnStart()
        {
            GameEvents.onUpdate += MoveForward;
        }

        #endregion

        #region Functions that can be subscribed

        #region Update -> Player Move Axis-Z

        private void MoveForward()
        {
            transform.position += Vector3.forward * behavioralPlayerData.playerForwardSpeed * Time.deltaTime;
        }

        private void MoveAxisX(Vector3 mouseMovementDirection)
        {
            var mouseToWorldDirection =
                new Vector3(mouseMovementDirection.x * screenMultiplierData.screenWidthMultiplier, 0f, 0f);

            var addVector = mouseToWorldDirection * behavioralPlayerData.playerSensitivity * Time.deltaTime;

            transform.position += addVector;

            var thisTr = transform;

            if (thisTr.position.x < -behavioralPlayerData.playerBoundX)
                thisTr.position = new Vector3(-behavioralPlayerData.playerBoundX, thisTr.position.y, thisTr.position.z);
            
            if (thisTr.position.x > behavioralPlayerData.playerBoundX)
                thisTr.position = new Vector3(behavioralPlayerData.playerBoundX, thisTr.position.y, thisTr.position.z);
        }

        #endregion

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
    }

    [Serializable]
    public struct BehavioralPlayerData
    {
        [Header("Float Settings")]
        [SerializeField] internal float playerForwardSpeed;
        [SerializeField] internal float playerSensitivity;
        [SerializeField] internal float playerBoundX;
        [SerializeField] internal float speedDecreaseFactor, speedIncreaseFactor;
        
        [Header("Components")] 
        [SerializeField] internal Collider playerCollider;
    }
}

