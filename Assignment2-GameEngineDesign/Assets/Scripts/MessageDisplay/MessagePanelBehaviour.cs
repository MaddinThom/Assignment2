using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MessagePanelBehaviour : MonoBehaviour {
    [SerializeField] private Text messageDisplay;
    [SerializeField] private float tweenTime;
    private Queue<string> messages = new Queue<string>();

    private void OnEnable()
    {
        //RocketEnginBehavior.fuelRunOut += RocketEnginBehavior_FuelRunOut;
        OpenDoor.keyCollected += CollectKey;
    }
    private void OnDisable()
    {
        //RocketEnginBehavior.fuelRunOut -= RocketEnginBehavior_FuelRunOut;
        OpenDoor.keyCollected -= CollectKey;
    }
    
    private void Awake()
    {
        messageDisplay.transform.localScale = new Vector3(0, 0, 0);
    }  
    
    private void CollectKey(string obj)
    {        
        messageDisplay.text = obj;
        messageDisplay.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        messageDisplay.transform.DOScale(0, tweenTime);
        messages.Enqueue(obj);
    }    
    
    private void Update()
    {
        CheckQueue();
    }  
    
    private void CheckQueue()
    {      
        if (!DOTween.IsTweening(messageDisplay.transform))
        {          
            if (messages.Count > 0)
            {
                DisplayMessageAnimate(messages.Dequeue());
            }       
        }    
    }    
    
    private void DisplayMessageAnimate(string obj)
    {        
        messageDisplay.text = obj;
        messageDisplay.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f); 
        messageDisplay.transform.DOScale(0, tweenTime);
    }
}