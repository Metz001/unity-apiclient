using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance = null;

    [SerializeField]
    private bool initUI = true;

    public GameObject PanelLogin;
    public GameObject LabelStatus;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        if (initUI)
        {
            Clear();
            Checking();
        }

    }

    void Clear()
    {
        LabelStatus.SetActive(false);
        PanelLogin.SetActive(false);

    }

    public void Checking()
    {
        Clear();
        ShowStaus("Comprobando . . .");
    }

    public void ShowStaus(string text)
    {
        Clear();
        LabelStatus.GetComponent<Text>().text = text;
        LabelStatus.SetActive(true);
    }
    public void ShowLogin()
    {
        Clear();
        PanelLogin.SetActive(true);
    }

}
