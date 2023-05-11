using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCamera;

    [Range(0, 100)] public float health;
    [Range(0, 100)] public float stamina;
    [Range(0, 100)] public float cold;
    [Range(0, 100)] public float hunger;

    public Image HealthBar;
    public Image StaminaBar;
    public Image ColdBar;
    public Image HungerBar;

    private float coldChange = -1.0f;
    private float coldChangeModifier = 0.0f;

    public CameraShake cameraShake;
    private bool healthy = false;

    void Update()
    {
        HealthBar.fillAmount = health / 100;
        StaminaBar.fillAmount = stamina / 100;
        ColdBar.fillAmount = cold / 100;
        HungerBar.fillAmount = hunger / 100;

        if(hunger >= 0)                         //Utrata punkt�w g�odu
        {
            hunger -= 2.0f * Time.deltaTime;    //Pr�dko�� utraty g�odu
        }

        if (hunger <= 50)
        {
            GetComponent<CharController>().SetSpeedValue(hunger/10);
        }
        else if(hunger > 50)
        {
            GetComponent<CharController>().SetSpeedValue(5);
        }
        if (hunger <= 0)
        {
            health -= 1.5f * Time.deltaTime;
        }

        if (coldChange < 0)
        {
            if (cold >= 0)                          //Utrata punkt�w ciep�a
            {
                cold += coldChange * Time.deltaTime;      //Pr�dko�� utraty ciep�a
            }
        }
        else if (coldChange > 0)
            if (cold <= 100)                          //Utrata punkt�w ciep�a
            {
                cold += coldChange * Time.deltaTime;      //Pr�dko�� utraty ciep�a
            }


        if (cold >= 0 && cold <= 100)                          //Utrata punkt�w ciep�a
        {
            cold += coldChange * Time.deltaTime;      //Pr�dko�� utraty ciep�a
        }

        if (cold <= 50)
        {
            FrostEffect cameraObj = playerCamera.GetComponent<FrostEffect>();
            cameraObj.SetFrost(cold / 100);
        }
        if (cold <= 10)
        {
            health -= 1.0f  * Time.deltaTime;
        }

        /*
        if (health <= 50) cameraShake.ShakeMagnitudeValue(health);  //Efekty Utraty punkt�w zdrowia
        if (health <= 50 && !healthy)
        {
            cameraShake.Shake();
            healthy = true;
        }
        else if (health > 50 && healthy)
        {
            cameraShake.StopShake();
            healthy = false;
        }*/
        if (health <= 0)                //Przywo�anie ekranu ko�ca gry
        {
            Debug.Log("Umar� w butach");
        }

    }

    public void ChangeStamina(float changeValue)
    {
        stamina += changeValue * Time.deltaTime;
    }
    public float GetStamina()
    {
        return stamina;
    }

    public void ColdChange(float changeValue)
    {
        coldChange = coldChange + changeValue;
    }
}
