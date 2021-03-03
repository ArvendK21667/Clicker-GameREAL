using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookieManager : MonoBehaviour
{

    [SerializeField] private float cookies = 0f;
    [SerializeField] private float cookiesPerClick = 0.1f;
    [SerializeField] private TMP_Text cookieText;
    [SerializeField] private TMP_Text upgradeText;

    [SerializeField] private Button upgradeButton;
    


    private float costToUpgrade = 5;
    private object imagecolor;

    public void Start()
    {
        UpdateCookieText();
        UpdateUpgradeText();
    }


    public void AddCookie()
    {
        cookies += cookiesPerClick;

        UpdateCookieText();
        UpdateUpgradeText();
    }

    public void UpgradeCookiesPerClick()
    {
        if (cookies >= costToUpgrade)
        {

            cookies -= costToUpgrade;
            cookiesPerClick += 0.1f;
            costToUpgrade = costToUpgrade * 1.4f;
            UpdateCookieText();
            UpdateUpgradeText();

        }

        
    }

    private void UpdateUpgradeText()
    {
        upgradeText.text = " Upgrade " +  (int) costToUpgrade;

        if (cookies >= costToUpgrade)
        {
            upgradeButton.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            upgradeButton.interactable = false;
        }
    }

    private void UpdateCookieText()
    {
        if (cookieText != null)

        {
            switch (cookies)
            {

                case 0:
                    cookieText.text = " No Cookies ";
                    break;
                case 1:
                    cookieText.text = " One Cookies ";
                    break;
                default:
                    cookieText.text = (int) cookies + " Cookies ";
                    break;
            }

        }
        else
        {
            Debug.LogWarning("Cookie Text not set");
        }
        
       
    }

}