using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.gameObject.CompareTag("Player"))
        {
            var currentScoreObject = GameObject.FindGameObjectWithTag("PlayerScore");

            var currentScore = currentScoreObject.GetComponent<Text>();

            var newScore = int.Parse(currentScore.text) + 1;

            currentScore.text = newScore.ToString();

            Destroy(gameObject);
        }

    }
}
