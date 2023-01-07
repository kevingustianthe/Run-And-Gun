using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth thePlayerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = thePlayerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = thePlayerHealth.currentHealth / 10;
    }
}
