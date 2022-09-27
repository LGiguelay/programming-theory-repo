using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleTool : Tool
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private float bubbleSpeed;
    public override void Use()
    {
        Ray ray = ComputeFireRay();

        Bubble projectile = Instantiate(bubble, ray.origin, bubble.transform.rotation).GetComponent<Bubble>();
        projectile.Effect = CurrentEffect;
        projectile.Launch(ray.direction, bubbleSpeed);
    }

}
