using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{  
        public TMP_InputField userInput;
        public InputField field;
    // Start is called before the first frame update


 
    // Update is called once per frame
   
    public void BeginGame()
    {
        if (!String.IsNullOrEmpty(userInput.text))
        {
            Debug.Log("Input name:"+userInput.text);
            UpdateName();
        SceneManager.LoadScene(1);
            }
    }
    public void Exit()
    {
        if (Application.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();

        }
    }
    public void SettingsButton()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);

    }
    public void TableButton()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(3);
        
    }
    
 public void UpdateName()
 {
    InputField.Instance.pname=userInput.text;
 }

    
}
