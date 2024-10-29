using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed ;
    public float MaxMovement ;
    Settings sets;
    
    // Start is called before the first frame update
    void Awake()
    {
        sets=GameObject.Find("Settings").GetComponent<Settings>();
        Settings.ProcessData data=sets.LoadData();
        Speed=data.speed;
        MaxMovement=data.MaxPower; 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}
