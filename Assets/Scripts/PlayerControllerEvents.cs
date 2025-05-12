using System;
using UnityEngine;

public class PlayerControllerEvents 
{

    public Action onStopMovement;
    public Action onStartMovement;


    public void StartMovement()
    {
        onStartMovement.Invoke();
    }

    public void StopMovement()
    {
        onStopMovement.Invoke();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
