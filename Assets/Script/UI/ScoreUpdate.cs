using Components;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        EntityManager e = World.DefaultGameObjectInjectionWorld.EntityManager;
        score.text= e.CreateEntityQuery(typeof(ScoreComponent)).GetSingleton<ScoreComponent>().score.ToString() ;
    }
}
