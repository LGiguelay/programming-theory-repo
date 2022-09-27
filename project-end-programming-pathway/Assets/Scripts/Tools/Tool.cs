using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    [SerializeField] private List<GameObject> effectPrefabs;
    public List<Effect> effects; //instances
    public int indexCurrentEffect;

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
        effects = new List<Effect>();
        foreach (GameObject go in effectPrefabs)
        {
            effects.Add(Instantiate(go).GetComponent<Effect>());
        }
    }

    void Update()
    {
        
    }

    public abstract void Use();

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
