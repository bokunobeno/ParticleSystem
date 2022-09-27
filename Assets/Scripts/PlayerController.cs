using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector2 moveInput;
    [SerializeField] private Transform camerPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBulletLocation;
    [SerializeField] private bool runIsPressed;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float runSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        _characterController.SimpleMove(move *moveSpeed);
    }

    private void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }

    void  OnFire(InputValue fire)
    {
        RaycastHit hit;
        if (Physics.Raycast(camerPosition.position, camerPosition.forward, out hit, Mathf.Infinity))
        {
            Instantiate(bullet, spawnBulletLocation.position, Quaternion.identity);
        }
    }

    void OnRun(InputValue run)
    {
        Debug.Log(run.isPressed);
        runIsPressed = run.isPressed;
    }
}
