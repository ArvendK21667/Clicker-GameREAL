using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CookieManager : MonoBehaviour
{

    [SerializeField] private float cookies = 0f;
    [SerializeField] private float cookiesPerClick = 1f;
    [SerializeField] private float cookiesPerSecond = 0f;
    [SerializeField] private TMP_Text cookieText;
    [SerializeField] private TMP_Text ClickerUpgradeText;
    [SerializeField] private TMP_Text BackerOneUpgradeText;
    [SerializeField] private TMP_Text BackerTwoUpgradeText;
    [SerializeField] private TMP_Text BackerThreeUpgradeText;
    [SerializeField] private Button clickerupgradeButton;
    [SerializeField] private Button upgradeButton1;
    [SerializeField] private Button upgradeButton2;
    [SerializeField] private Button upgradeButton3;
    [Range(1f, 4f)]
    private float upgradeMultiplayer = 1.6f; //Multiplyer for the Autoclicker
   
    private float costToUpgrade1 = 500f; //Cost for First Clicker upgrade
    private float costToUpgrade2 = 25f; //Cost for First AutoCookie Maker
    private float costToUpgrade3 = 200f; //Cost for Second AutoCookie Maker
    private float costToUpgrade4 = 1500f; //Cost for Third AutoCookie Maker
    private object imagecolor;
    
    private int clickerUpgradeMultiplayer = 3; //Multiplyer for the Clicker

    public void Start()
    {

        UpdateCookieText();
        UpdateClickerUpgradeText();
        UpdateBackerOneUpgradeText();
        UpdateBackerTwoUpgradeText();
        UpdateBackerThreeUpgradeText();

        // To Update to buttons on start to disabled them and make them red until number of cookies have been reached.
    }


    public void AddCookie()
    {
        cookiesPerClick = cookiesPerClick += cookiesPerSecond; //Tried to make total cookies equal cookies per click and cookies per second.
        cookies += cookiesPerClick;

        UpdateCookieText();
        UpdateClickerUpgradeText();
        //UpdateBackerOneUpgradeText();
        //UpdateBackerTwoUpgradeText();  //Not sure what to do here
        //UpdateBackerThreeUpgradeText();

    }

    public void UpgradeCookiesPerClick()
    {
        if (cookies >= costToUpgrade1)
        {
           
            cookies -= costToUpgrade1;
            cookiesPerClick += 1; //make it add an extra cookie per click after each upgrade e.g +2, +3, +4...
            UpdateCookieText();
            UpdateClickerUpgradeText();

        }

    }

    public void UpdateBackerOneUpgrade()
    {
        if (cookies >= costToUpgrade2)
        {

            cookies -= costToUpgrade2;
            cookiesPerSecond += 0.1f; //Tried to make it add 0.1 cookie per second (Not Sure)
            costToUpgrade2 = costToUpgrade2 * upgradeMultiplayer;
            upgradeMultiplayer -= 0.002f; //Cost of price multiplyer slowly decreases as time goes on
            UpdateCookieText();
            UpdateBackerOneUpgradeText();

        }
    }

    public void UpdateBackerTwoUpgrade()
    {
        if (cookies >= costToUpgrade3)
        {

            cookies -= costToUpgrade3;
            cookiesPerSecond += 1f; //Tried to make it add 0.1 cookie per second (Not Sure)
            costToUpgrade3 = costToUpgrade3 * upgradeMultiplayer;
            upgradeMultiplayer -= 0.002f; //Cost of price multiplyer slowly decreases as time goes on
            UpdateCookieText();
            UpdateBackerTwoUpgradeText();

        }
    }

    public void UpdateBackerThreeUpgrade()
    {
        if (cookies >= costToUpgrade4)
        {

            cookies -= costToUpgrade4; 
            cookiesPerSecond += 5f; //Tried to make it add 0.1 cookie per second (Not Sure)
            costToUpgrade4 = costToUpgrade4 * upgradeMultiplayer;
            upgradeMultiplayer -= 0.002f; //Cost of price multiplyer slowly decreases as time goes on
            UpdateCookieText();
            UpdateBackerThreeUpgradeText();

        }
    }

    private void UpdateClickerUpgradeText()
    {
        ClickerUpgradeText.text = " Clicker    Cost: " + (int)costToUpgrade1;

        if (cookies >= costToUpgrade1)
        {
            clickerupgradeButton.GetComponent<UnityEngine.UI.Image>().color = Color.white; // if has enough cookies button turns white
            clickerupgradeButton.interactable = true; // if has enough cookies you can click the button
        }
        else
        {
            clickerupgradeButton.GetComponent<UnityEngine.UI.Image>().color = Color.red; // if has not enough cookies button turns red
            clickerupgradeButton.interactable = false; // if has not enough cookies you can't click the button 
        }
    }

    public void UpdateBackerOneUpgradeText()
    {
        ClickerUpgradeText.text = " Slow Baker    Cost: " + (int)costToUpgrade2;

        if (cookies >= costToUpgrade2)
        {
            upgradeButton1.GetComponent<UnityEngine.UI.Image>().color = Color.white; // if has enough cookies button turns white
            upgradeButton1.interactable = true; // if has enough cookies you can click the button
        }
        else
        {
            upgradeButton1.GetComponent<UnityEngine.UI.Image>().color = Color.red; // if has not enough cookies button turns red
            upgradeButton1.interactable = false; // // if has not enough cookies you can't click the button 
        }
    }

    public void UpdateBackerTwoUpgradeText()
    {
        ClickerUpgradeText.text = " Medium Baker    Cost: " + (int)costToUpgrade3;

        if (cookies >= costToUpgrade3)
        {
            upgradeButton2.GetComponent<UnityEngine.UI.Image>().color = Color.white; // if has enough cookies button turns white
            upgradeButton2.interactable = true; // if has enough cookies you can click the button
        }
        else
        {
            upgradeButton2.GetComponent<UnityEngine.UI.Image>().color = Color.red; // if has not enough cookies button turns red
            upgradeButton2.interactable = false; // if has not enough cookies you can't click the button 
        }
    }

    public void UpdateBackerThreeUpgradeText()
    {
        ClickerUpgradeText.text = " Fast Baker    Cost: " + (int)costToUpgrade4;

        if (cookies >= costToUpgrade4)
        {
            upgradeButton3.GetComponent<UnityEngine.UI.Image>().color = Color.white; // if has enough cookies button turns white
            upgradeButton3.interactable = true; // if has enough cookies you can click the button
        }
        else
        {
            upgradeButton3.GetComponent<UnityEngine.UI.Image>().color = Color.red; // if has not enough cookies button turns red
            upgradeButton3.interactable = false; // if has not enough cookies you can't click the button 
        }
    }

    private void UpdateCookieText()
    {
        if (cookieText != null)

        {
            switch (cookies) //All the Texts for the main cookie text
            {

                case 0:
                    cookieText.text = " No Cookies ";
                    break;
                case 1:
                    cookieText.text = " One Cookies ";
                    break;
                default:
                    cookieText.text = cookies.ToString("f0") + " Cookies ";
                    break;
            }

        }
        else
        {
            Debug.LogWarning("Cookie Text not set");
        }


    }//Some random code I dont understand below!

    //IEnumerator AutomaticCookies()
    //{


    //    while (AutoClickisUnlocked == true)
    //    {
    //        Debug.Log("Test Tell me whats wrong");
    //        yield return new WaitForSeconds(10);
    //        cookies += cookiesPerSecond;

    //    }

    //}

    //void AutomaticCookiesText()
    //{


    //}

}