using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;
    
    public Text ScoreText;
    public Text ScoreText1;

    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;
    private InputField staticData;
    private SaveDatas jsonData;
    private Dictionary<string,int> listJson;
    private string player;
    void Awake()
    {
        jsonData=GameObject.Find("JsonData").GetComponent<SaveDatas>();
        listJson=jsonData.LoadData();
       
        UpdateScore();
        if (listJson==null)
        {
            listJson=new Dictionary<string, int>();
        }
          
        Debug.Log(listJson);
    }
    // Start is called before the first frame update
    void Start()
    {
        staticData=GameObject.Find("StaticData").GetComponent<InputField>();
        player=staticData.GetName();
        Debug.Log("Player is "+player);
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        UpdateScore1();
    }
    
    
 private void UpdateScore()
 {
    if ( listJson!= null) 
    {
    var sortedDict = listJson.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    
    ScoreText1.text = $"Best Score {sortedDict.Values.First()} Name : {sortedDict.Keys.First()}";
    }
    else
    {
        ScoreText1.text = $"Best Score - Name : -";
    }
 }
    private void UpdateScore1()
    {
       if ((listJson==null)||(!listJson.ContainsKey(player)))
       {
            listJson.Add(player,m_Points);
            

       }
        else if (listJson[player]<m_Points)
        {
            listJson[player]=m_Points;
   
        }
        jsonData.SaveData(listJson);
    }
    }



