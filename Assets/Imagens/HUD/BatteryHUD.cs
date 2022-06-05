using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryHUD : MonoBehaviour
{
    public void HPBattery(int v) //Int v = vida do personagem
    {
        switch (v)
        {
            case 0:
                GetComponent<Image>().fillAmount = 0f;
                break;
            case 1:
                GetComponent<Image>().fillAmount = 0.2f;
                break;
            case 2:
                GetComponent<Image>().fillAmount = 0.4f;
                break;
            case 3:
                GetComponent<Image>().fillAmount = 0.6f;
                break;
            case 4:
                GetComponent<Image>().fillAmount = 0.8f;
                break;
            case 5:
                GetComponent<Image>().fillAmount = 1f;
                break;
        }
    }
}
