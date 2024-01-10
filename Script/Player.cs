using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event Action<bool> OnAttack = null;

    [SerializeField] MovementComponent movement = null;
    [SerializeField] PlayerAnimation playerAnimation = null;
    [SerializeField] MyInputs controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    [SerializeField] InputAction attack = null;
    [SerializeField] InputAction sprint = null;
    [SerializeField] InputAction attackOneClick = null;

    [SerializeField] bool isAttacking = false;
    [SerializeField] bool isSprinting = false;

    public InputAction Move => move;
    public InputAction Rotate => rotate;
    public InputAction Attack => attack;    
    public InputAction Sprint => sprint;    
    public InputAction AttackOneClick => attackOneClick;    


    private void Awake()
    {
        controls= new MyInputs();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        AttackFunc();
        playerAnimation.UpdateSpeedAnimatorParam(isSprinting ? 3 : 1);
    }
    void Init()
    {
        movement= GetComponent<MovementComponent>();
        playerAnimation=GetComponent<PlayerAnimation>();
        movement.OnForwardAxis += playerAnimation.UpdateForwardAnimatorParam;
        movement.OnRightAxis+= playerAnimation.UpdateRightAnimatorParam;
        movement.OnRotationAxis+= playerAnimation.UpdateRotateAnimatorParam;
        OnAttack += playerAnimation.UpdateIsAttackingAnimatorParam;
    }
    void AttackFunc() 
    {
        if (!isAttacking) return;
        Debug.Log("attack");
    }
    void SetIsAttacking(InputAction .CallbackContext _context)
    {
        isAttacking = _context.ReadValueAsButton();
        OnAttack?.Invoke(isAttacking);
    }
    void OneAttack(InputAction .CallbackContext _context)
    {
        OnAttack?.Invoke(true);
    }
    private void OnEnable()
    {
        move = controls.Player.Movement;
        move.Enable();
        rotate = controls.Player.Rotate;
        rotate.Enable();
        attack = controls.Player.AttackContinue;
        attack.Enable();
        attack.performed += SetIsAttacking;
        attackOneClick= controls.Player.AttackOneClick;
        attackOneClick.Enable();
        sprint = controls.Player.Sprint;
        sprint.Enable();
        sprint.performed += SetSprintActivation;
    }
    void SetSprintActivation(InputAction .CallbackContext _context)
    {
        isSprinting = !isSprinting;
        if (playerAnimation == null) return;
       // playerAnimation.UpdateSpeedAnimatorParam(isSprinting ? 3 : 1);
    }
    private void OnDisable()
    {
        
    }
}
