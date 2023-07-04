using CortexDeveloper.ECSMessages.Service;
using Samples.UserInterfaceExample;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update

    Button button;
    public GameObject text;
    
    // get panel
    public GameObject panel;

    void Awake()
    {
        button = GetComponent<Button>();
       
        button.onClick.AddListener(StartGame);
    }

    
    private void OnDestroy()
    {
        button.onClick.RemoveListener(StartGame);
    }

    void StartGame()
    {
        var ecb = World.DefaultGameObjectInjectionWorld.EntityManager;

        MessageBroadcaster
            .PrepareMessage()
            .AliveForUnlimitedTime()
            .PostImmediate(ecb, new StartGameCommand
            {
                start = true
            });

        
        this.gameObject.SetActive(false);
        panel.SetActive(false);
        text.SetActive(false);

    }
    
}
