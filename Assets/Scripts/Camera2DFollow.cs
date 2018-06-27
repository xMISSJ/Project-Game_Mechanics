using System;
using UnityEngine;

namespace UnityStandardAssets._2D
    {
        public class Camera2DFollow : MonoBehaviour
        {
            public Transform target;
            public float damping;                                   // Makes it so the amplitude is reduced.
            public float lookAheadFactor;
            public float lookAheadReturnSpeed;
            public float lookAheadMoveThreshold;

            private float OffsetZ;
            private Vector3 LastTargetPosition;
            private Vector3 CurrentVelocity;
            private Vector3 LookAheadPos;

        // Use this for initialization
        private void Start()
            {
                LastTargetPosition = target.position;                   // Sets as last target position, the current target position.
                OffsetZ = (transform.position - target.position).z;     // Makes it so the camera is not moving its OffsetZ. Otherwise the camera will zoom in.
                transform.parent = null;                                
            }


            // Update is called once per frame
            private void Update()
            {
                // Only updates LookAheadPos if accelerating or the direction is changed.
                float xMoveDelta = (target.position - LastTargetPosition).x;

                bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

                if (updateLookAheadTarget)
                {
                    LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
                }
                else
                {
                    LookAheadPos = Vector3.MoveTowards(LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                }

                Vector3 aheadTargetPos = target.position + LookAheadPos + Vector3.forward * OffsetZ;
                Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref CurrentVelocity, damping);

                transform.position = newPos;

                LastTargetPosition = target.position;
            }
        }
    }