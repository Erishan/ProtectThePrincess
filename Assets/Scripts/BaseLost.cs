using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseLost : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    [SerializeField] TextMeshProUGUI healthText;
    LevelLoader level;
    LevelController levelControl;
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<LevelLoader>();
        levelControl = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        playerHealth--;
        Destroy(otherCollider.gameObject);
        healthText.text = playerHealth.ToString();
        if (playerHealth <= 0)
        {
            levelControl.PlayerLost();
        }
    }
}
