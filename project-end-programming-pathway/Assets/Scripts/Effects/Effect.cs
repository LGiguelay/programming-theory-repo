using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public enum EffectEnum
    {
        Undefined,
        Antigravity,
        Explosion,
        Minimizer
    }
    [SerializeField] protected EffectEnum effectType = EffectEnum.Undefined;
    public EffectEnum TypeName
    {
        get
        {
            return effectType;
        }
        protected set
        {
            effectType = value;
        }
    }
    public virtual void GiveEffect(GameObject target)
    {
        if (target.tag != "Target")
            return;
    }

    private void Start()
    {
        InitEffect();
    }

    public abstract void InitEffect();

}
