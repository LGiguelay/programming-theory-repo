using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizerEffect : Effect //INHERITANCE
{
    [SerializeField] private float sizeFactor = 0.99f;
    public override void GiveEffect(GameObject target) //POLYMORPHISM
    {
        base.GiveEffect(target);
        StartCoroutine(ChangeSize(target.transform));
    }

    public override void InitEffect() //POLYMORPHISM
    {
        if(sizeFactor < 1.0)
        {
            effectType = Effect.EffectEnum.Minimizer;
        }
        else
        {
            effectType = Effect.EffectEnum.Maximizer;
        }
    }

    private IEnumerator ChangeSize(Transform t) //ABSTRACTION
    {
        for(int i = 0; i < 10; i++)
        {
            t.localScale = t.localScale * sizeFactor;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
