using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CookieManager : MonoBehaviour
{

    [SerializeField] private float cookies = 0f;
    [SerializeField] private float cookiesPerClick = 0.1f;
    [SerializeField] private float cookieOverTime = 0f;
    [SerializeField] private TMP_Text cookieText;
    [SerializeField] private TMP_Text upgradeText;
    [SerializeField] private Button upgradeButton;
    [Range(1f, 4f)]
    public float upgradeMultiplayer = 2.4f;

    private bool AutoClickisUnlocked = false;
    private float costToUpgrade = 5;
    private object imagecolor;

    public void Start()
    {

        UpdateCookieText();
        UpdateUpgradeText();
        AutomaticCookiesText();
        // AutomaticCookies();
        StartCoroutine(AutomaticCookies());
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
            cookiesPerClick += 0.2f;
            costToUpgrade = costToUpgrade * upgradeMultiplayer;
            upgradeMultiplayer -= 0.01f;
            UpdateCookieText();
            UpdateUpgradeText();

        }


    }

    private void UpdateUpgradeText()
    {
        upgradeText.text = " Upgrade " + (int)costToUpgrade;

        if (cookies >= costToUpgrade)
        {
            upgradeButton.GetComponent<UnityEngine.UI.Image>().color = Color.white; // if true turn white
            upgradeButton.interactable = true; // if true u can click the button
        }
        else
        {
            upgradeButton.GetComponent<UnityEngine.UI.Image>().color = Color.red; // if false turn red
            upgradeButton.interactable = false; // if false you cant click the button 
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
                    cookieText.text = cookies.ToString("f2") + " Cookies ";
                    break;
            }

        }
        else
        {
            Debug.LogWarning("Cookie Text not set");
        }


    }

    IEnumerator AutomaticCookies()
    {


        while (AutoClickisUnlocked == true)
        {
            Debug.Log("Test Tell me whats wrong");
            yield return new WaitForSeconds(10);
            cookies += cookieOverTime;

        }

    }

    void AutomaticCookiesText()
    {


    }

}