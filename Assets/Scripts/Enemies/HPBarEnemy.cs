using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPBarEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _heartIcon;
    [SerializeField] private TextMeshPro _hpText;

    public void SetHP(int hp) {
        _hpText.text = hp.ToString();
    }
}
