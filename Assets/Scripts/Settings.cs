using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Serializable]
    public class ProcessData
    {
        public float speed;
        public float MaxPower;
    }

 public ProcessData LoadData()
    {
        string path = Application.persistentDataPath + "/setting.json";
        if(File.Exists(path))
        {
            string js=File.ReadAllText(path);
            ProcessData data =JsonUtility.FromJson <ProcessData>(js);
            return data;
        }

        SaveData(2f,2f);
        ProcessData d=CreateObj(2f,2f);
        return d;
    }
    public void SaveData(float speed,float MaxPower)
    {
        ProcessData data = CreateObj(speed,MaxPower);
        string js=JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath+"/setting.json",js);
    }
    public ProcessData CreateObj(float speed,float MaxPower)
    {
        ProcessData d=new ProcessData();
        d.speed=speed;
        d.MaxPower=MaxPower;
        return d;
    }
    
}
