using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravityEffect : Effect //INHERITANCE
{
    [SerializeField] private float takeOffForce;

    public override void GiveEffect(GameObject target) //POLYMORPHISM
    {
        base.GiveEffect(target);
        Rigidbody rb = target.GetComponent<Rigidbody>();
        if (rb == null)
            return;

        if(rb.useGravity == true)
        {
            rb.useGravity = false;
            rb.AddForce(Vector3.up * takeOffForce, ForceMode.Impulse);
        }
        else //re-gravity
        {
            rb.useGravity = true;
        }
        
    }

    public override void InitEffect() //POLYMORPHISM
    {
        effectType = EffectEnum.Antigravity;
    }
}
