using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleManager : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public List<Toggle> toggles = new List<Toggle>();

    public DataManger dataMangerInstance;
    void Start()
    {
        // 添加所有Toggles到列表中
        foreach (Transform child in toggleGroup.transform)
        {
            Toggle toggle = child.GetComponent<Toggle>();
            if (toggle != null)
            {
                toggles.Add(toggle);
                toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle); });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnToggleValueChanged(Toggle changedToggle)
    {
        // 处理Toggle状态变化
        if (changedToggle.isOn)
        {
            Debug.Log(changedToggle.name + " is ON");
        }
        else
        {
            Debug.Log(changedToggle.name + " is OFF");
        }

        switch(changedToggle.name)
        {
            case "Toggle0":
                PlayerPrefs.SetInt("PlayerID", 0);
                dataMangerInstance.playerID = 0;
                break;
            
            case "Toggle1":
                PlayerPrefs.SetInt("PlayerID", 1);
                dataMangerInstance.playerID = 1;
                break;

            case "Toggle2":
                PlayerPrefs.SetInt("PlayerID", 2);
                dataMangerInstance.playerID = 2;
                break;
        }
        PlayerPrefs.Save();

        Debug.Log(dataMangerInstance.playerID.ToString());
        // // 打印所有开启的Toggles
        // foreach (Toggle toggle in toggles)
        // {
        //     if (toggle.isOn)
        //     {
        //         Debug.Log(toggle.name + " is selected.");
        //     }
        // }
    }
}
