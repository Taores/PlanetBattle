using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger Instance { get; private set; }

    public int playerID;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保持对象在场景切换时不被销毁
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
