using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputField : MonoBehaviour
{
    public static InputField Instance;
    public string pname;
    MenuUI Field;
    void Awake()
    {
        Field=GameObject.Find("MenuUI").GetComponent<MenuUI>();
        if (Instance==null)
        {
            Instance=this;
            DontDestroyOnLoad(Instance);
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }



    }
    public void UpdateName(string name)
    {
        pname=name;
    }
 
    public string GetName()
    {
        return pname;
    }
}
