using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    [SerializeField] private List<GameObject> effectPrefabs;
    private List<Effect> effects; //instances
    private int indexCurrentEffect;

    public Effect CurrentEffect
    {
        get
        {
            if (effects == null)
            {
                Debug.Log("effects is null");
                return null;
            }
            if (indexCurrentEffect >= effects.Count)
            {
                Debug.Log("out of range");
                return null;
            }
            return effects[indexCurrentEffect];
        }
    }



    void Start()
    {
        InitTool();
        effects = new List<Effect>();
        foreach (GameObject go in effectPrefabs)
        {
            effects.Add(Instantiate(go).GetComponent<Effect>());
        }
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

    public void ChangeEffect()
    {
        indexCurrentEffect += 1;
        indexCurrentEffect %= effectPrefabs.Count;
    }
}
