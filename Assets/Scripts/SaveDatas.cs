using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
public class SaveDatas:MonoBehaviour
{


[Serializable]
 public class ProcessData
    {
        public Dictionary<string,int> data;

    
    public ProcessData(Dictionary<string,int> data)
    {
        this.data=data;
    }
    }

 public Dictionary<string,int> LoadData()
    {
        string path=Application.persistentDataPath + "/savefile.json";
        var json=File.ReadAllText(path);
        var data=JsonConvert.DeserializeObject<ProcessData>(json);

        return data.data;
    }
    public void SaveData(Dictionary<string,int>data)
    {
        string path=Application.persistentDataPath + "/savefile.json";
        ProcessData pdata=new ProcessData(data);
        string js=JsonConvert.SerializeObject(pdata);
        File.WriteAllText(path,js);
    }

    
}
