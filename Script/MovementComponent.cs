using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    public event Action<float> OnForwardAxis = null;
    public event Action<float> OnRightAxis = null;
    public event Action<float> OnRotationAxis = null;
   
    
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotationSpeed = 50;

    [SerializeField] Player playerRef = null;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        
    }
    void Init()
    {
        playerRef = GetComponent<Player>();
    }
    void Move()
    {
        if (playerRef == null) return;
        Vector3 _moveDir=playerRef.Move.ReadValue<Vector3>();
        transform.position += transform.forward * Time.deltaTime * moveSpeed * _moveDir.z;
        transform.position += transform.right * Time.deltaTime * moveSpeed * _moveDir.x;
        OnForwardAxis?.Invoke(_moveDir.z);
        OnRightAxis?.Invoke(_moveDir.x);
    }
    void Rotate() 
    {
        if (playerRef == null) return;
        float _rotValue=playerRef.Rotate.ReadValue<float>();
        transform.eulerAngles += transform.up * Time.deltaTime * rotationSpeed * _rotValue;
        OnRotationAxis?.Invoke(_rotValue);
    }
   
}
