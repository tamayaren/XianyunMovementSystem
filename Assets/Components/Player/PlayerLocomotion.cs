using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;

    [Header("MovementStats")]
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 targetDirection;

    private void Start()
    {
       this.rigidbody = GetComponent<Rigidbody>();
       this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
        this.OnMovementHandle();
        this.OnRotationHandle();

        animator.SetFloat("Horizontal", Mathf.Abs(PlayerInputManager.Instance.normalizedInput.x));
        animator.SetFloat("Vertical", Mathf.Abs(PlayerInputManager.Instance.normalizedInput.y));
    }

    private void OnMovementHandle()
    {
        this.moveDirection = Camera.main.transform.forward * PlayerInputManager.Instance.normalizedInput.y;
        this.moveDirection = this.moveDirection + (Camera.main.transform.right * PlayerInputManager.Instance.normalizedInput.x);

        this.moveDirection.Normalize();

        if (PlayerInputManager.Instance.movementWeight > 0f)
        {
            float Speed = ((PlayerInputManager.Instance.movementWeight >= 3f) ? PlayerInputManager.Instance.runSpeed : PlayerInputManager.Instance.moveSpeed);

            this.moveDirection = this.moveDirection * ((PlayerInputManager.Instance.movementWeight >= 3f) ? PlayerInputManager.Instance.runSpeed : PlayerInputManager.Instance.moveSpeed);
        }

        Vector3 velocity = this.moveDirection;
        PlayerInputManager.Instance.rigidbody.velocity = velocity;
    }

    private void OnRotationHandle()
    {
        this.targetDirection = Camera.main.transform.forward * PlayerInputManager.Instance.normalizedInput.y;
        this.targetDirection = this.moveDirection + (Camera.main.transform.right * PlayerInputManager.Instance.normalizedInput.x);

        this.targetDirection.Normalize();

        if (this.targetDirection.magnitude == 0f) return;
        Quaternion targetRotation = Quaternion.LookRotation(this.targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerInputManager.Instance.rotSpeed * Time.deltaTime);

       transform.rotation = playerRotation;
    }
}
