using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTool : Tool //INHERITANCE
{
    [SerializeField] private LineRenderer laser;
    public override void Use() //POLYMORPHISM
    {
        StartCoroutine(LaserAnimation());

        Ray ray = ComputeFireRay();
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.collider.gameObject.tag == "Target")
            {
                GetEffect().GiveEffect(hitInfo.collider.gameObject);
            }
        }
    }

    IEnumerator LaserAnimation()
    {
        laser.enabled = true;
        yield return new WaitForSeconds(0.1f);
        laser.enabled = false;
    }

    protected override void InitTool() //POLYMORPHISM
    {
        base.InitTool();
        laser.enabled = false;
    }

}
