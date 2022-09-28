using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Effect effect;

    private ParticleSystem bubblePop;
    private Rigidbody rb;
    private Renderer rdr;

    public Effect Effect
    {
        get
        {
            return effect;
        }
        set
        {
            setEffect(value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bubblePop = GetComponent<ParticleSystem>();
        rdr = GetComponent<Renderer>();
    }

    private void setEffect(Effect newEffect)
    {

        //switch (newEffect.TypeName)
        //{
        //    case Effect.EffectEnum.Antigravity:
        //        break;

        //    case Effect.EffectEnum.Explosion:
        //        break;

        //    case Effect.EffectEnum.Minimizer:
        //        break;

        //    case Effect.EffectEnum.Maximizer:
        //        break;

        //    default:
        //        Debug.Log("unknown effect");
        //        return;
        //}

        effect = newEffect;
    }

    internal void Launch(Vector3 direction, float speed)
    {
        rb.AddForce(direction * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            //Debug.Log("HITTING TARGET");
            effect.GiveEffect(collision.gameObject);
            DispawnBubble();
        }
    }

    private void DispawnBubble()
    {
        bubblePop.Play();
        rdr.enabled = false;
        Destroy(gameObject, 0.5f);
    }
}
