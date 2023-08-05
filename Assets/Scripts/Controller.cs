using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.Items;

namespace RM
{
    [RequireComponent(typeof(CharacterController))]
    public class Controller : MonoBehaviour
    {
        CharacterController characterController;

        public bool isLocal = true;
        public float speed = .5f;
        public float rotationSpeed = .5f;

        [HideInInspector] public float horizontal;
        [HideInInspector] public float vertical;
        [HideInInspector] public float mouseX;
        [HideInInspector] public float mouseY;

        public bool isShooting = false;
        public bool isReloading = false;
        
        [HideInInspector] public float lookAngle;
        [HideInInspector] public float tiltAngle;

        public Transform pivotTransform;
        public Transform cameraTransform;

        public RuntimeItem currentWeapon;

        private void Start()
        {
            Init("TestWeapon");
        }

        public void Init(string weaponId)
        {
            characterController = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (isLocal )
            {
                Crosshair.singleton.Init(this);
            }

            currentWeapon = ItemManager.singleton.CreateItemInstance(weaponId);
            currentWeapon.Reload();
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            
            HandleMovement(delta);
            HandleRotation(delta);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                    Cursor.lockState = CursorLockMode.None;
                else
                    Cursor.lockState = CursorLockMode.Locked;
                
                Cursor.visible = !Cursor.visible;
            }

            if (!isLocal)
                return;
            
            HandleInput();
            HandleShooting();
        }

        void HandleInput()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            isShooting = Input.GetMouseButton(0);
            isReloading = Input.GetKeyDown(KeyCode.R);
        }

        void HandleMovement(float delta)
        {
            Vector3 direction = transform.forward * vertical;
            direction += transform.right * horizontal;
            direction.Normalize();

            RaycastHit hit;
            Physics.SphereCast(transform.position, characterController.radius, Vector3.down, out hit,
                characterController.height / 2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);

            Vector3 desiredMove = Vector3.ProjectOnPlane(direction, hit.normal).normalized;

            if (!characterController.isGrounded)
            {
                desiredMove += Physics.gravity;
            }

            characterController.Move(desiredMove * (delta/speed));
        }

        void HandleRotation(float delta)
        {
            lookAngle += mouseX * (delta*rotationSpeed);
            Vector3 camEulers = Vector3.zero;
            camEulers.y = lookAngle;
            transform.eulerAngles = camEulers;

            tiltAngle -= mouseY * (delta*rotationSpeed);
            tiltAngle = Mathf.Clamp(tiltAngle, -45, 45);

            Vector3 tiltEuler = Vector3.zero;
            tiltEuler.x = tiltAngle;
            pivotTransform.localEulerAngles = tiltEuler;
        }

        void HandleShooting()
        {
            if (isShooting)
            {
                if (currentWeapon.canFire())
                {
                    currentWeapon.Shoot();
                    Ballistics.RaycastBullet(cameraTransform.position, cameraTransform.forward, this);
                }
            }
            else
            {
                if (isReloading)
                {
                    currentWeapon.Reload();
                }
            }
        }
    }
}
