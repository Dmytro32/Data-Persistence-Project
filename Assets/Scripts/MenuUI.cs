using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuUI : MonoBehaviour
{  
       public TMP_InputField userInput;
         static  string InputName;
    // Start is called before the first frame update
    void Awake()
    {
     if (InputName!=null)
     {
        Destroy(gameObject);
     }
     DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
    InputName =userInput.text;
    }
    public void BeginGame()
    {
        if (InputName!=null)
        {
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
    public string GetName()
    {return InputName;
    }
}
