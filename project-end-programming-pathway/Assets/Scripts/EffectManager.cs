using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private TMP_Text currentEffectText;
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


    private static EffectManager instance;
    public static bool HasInstance => instance != null;
    public static EffectManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        
        effects = new List<Effect>();
        foreach (GameObject go in effectPrefabs)
        {
            effects.Add(Instantiate(go).GetComponent<Effect>());
        }

        indexCurrentEffect = 0;
    }

    private void Update()
    {
        DisplayEffect();
        ManagePlayerRequestToChangeEffect();
    }

    private void ManagePlayerRequestToChangeEffect()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        if (scrollValue != 0.0f)
        {
            ChangeEffect(scrollValue > 0.0f ? 1 : -1);
        }
        
    }


    public void ChangeEffect(int n = 1)
    {
        indexCurrentEffect += n;
        indexCurrentEffect %= effects.Count;
        if (indexCurrentEffect < 0)
            indexCurrentEffect += effects.Count;

        DisplayEffect();
    }

    private void DisplayEffect()
    {
        Effect.EffectEnum eff = CurrentEffect.TypeName;
        if(eff == Effect.EffectEnum.Undefined)
        {
            Invoke("DisplayEffect()", 0.1f);
        }
        currentEffectText.text = eff.ToString();
    }
}
