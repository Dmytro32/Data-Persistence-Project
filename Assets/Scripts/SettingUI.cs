using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingUI : MonoBehaviour
{
    public TextMeshProUGUI  speedValue;
    public TextMeshProUGUI  MaxPowerValue;
    public Slider speedSlider;
    public Slider maxPowerSlider;
     Settings sets;

     private void Awake() {
        sets=GameObject.Find("SettingProcess").GetComponent<Settings>();
        Settings.ProcessData data= sets.LoadData();
        setSetting(data.speed,data.MaxPower);
    }
    void Update()
    {
      SetText(speedSlider.value,maxPowerSlider.value);
    }
    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonUpdate()
    {
        setSetting(speedSlider.value,maxPowerSlider.value);
        sets.SaveData(speedSlider.value,maxPowerSlider.value);
    }

    public void ButtonDefault()
    {
        setSetting(2f,2f);
        sets.SaveData(2f,2f);
    }
    void setSetting(float speed,float MaxPower)
    {
        speedSlider.value=speed;
        maxPowerSlider.value=MaxPower;
        SetText(speed,MaxPower);

    }
    void SetText(float speed,float MaxPower)
    {
        speedValue.text=speed.ToString();
        MaxPowerValue.text=MaxPower.ToString();
    }
}
