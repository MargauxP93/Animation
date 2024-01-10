using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParameter
{
    public const string FORWARD_PARAM = "forward";
    public const string RIGHT_PARAM = "right";
    public const string ROTATE_PARAM = "rotate";
    public const string ISATTACKING_PARAM = "isAttacking";
    public const string SPEED_PARAM = "speed";

    public static readonly int ForwardAxisParam = Animator.StringToHash(FORWARD_PARAM);
    public static readonly int RightAxisParam = Animator.StringToHash(RIGHT_PARAM);
    public static readonly int RotateAxisParam = Animator.StringToHash(ROTATE_PARAM);
    public static readonly int IsAttackingParam = Animator.StringToHash(ISATTACKING_PARAM);
    public static readonly int SpeedParam = Animator.StringToHash(SPEED_PARAM);


    
}
