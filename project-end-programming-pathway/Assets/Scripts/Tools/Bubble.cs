using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private ParticleSystem bubblePop;
    private Effect effect;
    private Rigidbody rb;

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
    }

    private void setEffect(Effect newEffect)
    {

        switch (newEffect.TypeName)
        {
            case Effect.EffectEnum.Antigravity:
                break;

            case Effect.EffectEnum.Explosion:
                break;

            case Effect.EffectEnum.Minimizer:
                break;

            default:
                Debug.Log("unknown effect");
                return;
        }

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
        //Instantiate(bubblePop);
        Destroy(gameObject);
    }
}
