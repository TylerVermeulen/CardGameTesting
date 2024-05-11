using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OpponentHp : MonoBehaviour
{
    public static float maxHp;
    public static float staticHp;
    public float hp;
    [SerializeField] private Image Health;
    [SerializeField] private TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 30;
        staticHp = 30;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthInfo();
        CheckIfOver();
        hpText.text = hp + " HP";
    }
    private void SetHealthInfo()
    {
        hp = staticHp;
        Health.fillAmount = hp / maxHp;
    }
    private void CheckIfOver()
    {
        if (hp >= maxHp)
        {
            hp = maxHp;
        }
    }
}
