using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerAnimator = null;
   
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateForwardAnimatorParam(float _value)
    {
        if (playerAnimator == null) return;
        Debug.Log(AnimationParameter.ForwardAxisParam);
        playerAnimator.SetFloat(AnimationParameter.ForwardAxisParam, _value,0.1f,Time.deltaTime);
    }
    
    public void UpdateRightAnimatorParam(float _value)
    {
        if (playerAnimator == null) return;
        playerAnimator.SetFloat(AnimationParameter.RightAxisParam, _value,0.1f,Time.deltaTime);
    }
   
    public void UpdateRotateAnimatorParam(float _value)
    {
        if (playerAnimator == null) return;
        playerAnimator.SetFloat(AnimationParameter.RotateAxisParam, _value);
    }
    public void UpdateIsAttackingAnimatorParam(bool _value)
    {
        if (playerAnimator == null) return;
        playerAnimator.SetBool(AnimationParameter.IsAttackingParam, _value);
    }
    public void UpdateSpeedAnimatorParam(float _value)
    {
        if (playerAnimator == null) return;
        playerAnimator.SetFloat(AnimationParameter.SpeedParam,Mathf.Abs (_value),.5f,Time.deltaTime);
    }

}
