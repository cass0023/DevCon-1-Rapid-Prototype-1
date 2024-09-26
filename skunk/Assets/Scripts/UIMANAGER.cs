using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIMANAGER : MonoBehaviour
{
    public static UIMANAGER instance;
    [SerializeField]
    TextMeshProUGUI SprayCounter;
    [HideInInspector]
    public int SprayCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void updateSprayCounterUI()
    {
        SprayCounter.text = SprayCount.ToString();
    }
}
