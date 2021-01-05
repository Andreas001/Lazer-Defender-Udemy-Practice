using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI healthText;
    Player player;

    void Start() {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    void Update() {
        healthText.SetText(player.GetHealth().ToString());
    }
}
