using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHUD : MonoBehaviour
{
    // Update is called once per frame
    public void BulletTimer(float a)
    {
        GetComponent<Image>().fillAmount += a * Time.deltaTime;
    }

    public void BulletShoot()
    {
        GetComponent<Image>().fillAmount = 0;
    }
}
