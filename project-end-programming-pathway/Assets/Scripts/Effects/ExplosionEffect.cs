using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : Effect //INHERITANCE
{
    private ParticleSystem explosionParticles;
    public override void GiveEffect(GameObject target) //POLYMORPHISM
    {
        base.GiveEffect(target);

        explosionParticles.transform.position = target.transform.position;
        explosionParticles.Play();
        //target.GetComponent<Renderer>().enabled = false;
        Destroy(target);
    }
    public override void InitEffect() //POLYMORPHISM
    {
        explosionParticles = GetComponent<ParticleSystem>();
        effectType = EffectEnum.Explosion;
    }
}
