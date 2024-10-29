using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.EventSystems;
public class LeaderTable : MonoBehaviour
{
    private Dictionary<string,int> listJson;
    public TMP_Text tmpText;
    
    void Awake()
    {        SaveDatas jsonData=GameObject.Find("JsonData").GetComponent<SaveDatas>();
    listJson=jsonData.LoadData();

    tmpText.text="Name     Score\n";
}
    void Start()
    {
        if (listJson!=null)
        {
        var sortedDict = listJson.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        foreach (var line in sortedDict)
        {
            tmpText.text=tmpText.text+line.Key+" "+line.Value.ToString()+'\n';
        } 
        }
        
    }


}
