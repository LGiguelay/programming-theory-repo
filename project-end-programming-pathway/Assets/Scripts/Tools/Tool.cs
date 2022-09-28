using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public Effect GetEffect()
    {
        if(!EffectManager.HasInstance)
        {
            return null;
        }

        return EffectManager.Instance.CurrentEffect;
    }



    void Start()
    {
        InitTool();
    }

    public abstract void Use();

    protected virtual void InitTool()
    {

    }

    protected Ray ComputeFireRay()
    {
        GameObject canonEnd = GameObject.Find("CanonEnd");
        if (canonEnd == null)
        {
            Debug.Log("Couldn't find CanonEnd");
            return new Ray(Vector3.zero, Vector3.forward);
        }
        Vector3 origin;
        Vector3 direction;
        origin = canonEnd.transform.position;
        direction = Camera.main.transform.forward;

        Debug.DrawRay(origin, direction, Color.red);
        return new Ray(origin, direction);
    }
}
