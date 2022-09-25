using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    private Ray ray;
    private void Start()
    {
        
    }

    private void Update()
    {
        ray = ComputeFireRay();
       
    }

    public abstract void Use();

    protected Ray ComputeFireRay()
    {
        GameObject canonEnd = GameObject.Find("CanonEnd");
        if(canonEnd == null)
        {
            Debug.Log("Couldn't find CanonEnd");
            return new Ray(Vector3.zero, Vector3.forward);
        }
        Vector3 origin;
        Vector3 direction;
        origin = canonEnd.transform.position;
        direction = Camera.main.transform.forward;
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        return new Ray(origin, direction);
    }
}
