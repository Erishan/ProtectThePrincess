using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 100;
    bool doesTimePassed = false;
    LevelController levelControl;
    bool playerContinues;

    private void Start()
    {
        levelControl = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerContinues = FindObjectOfType<LevelController>().PlayerContinues();
        if (playerContinues)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

            bool doesTimePassed = (Time.timeSinceLevelLoad >= levelTime);

            if (doesTimePassed)
            {
                FindObjectOfType<AttackerSpawn>().StopSpawning();
            }
        }
    }

    public bool GetDoesTimePassed()
    {
        bool doesTimePassed = (Time.timeSinceLevelLoad >= levelTime);
        return doesTimePassed;
    }
}
