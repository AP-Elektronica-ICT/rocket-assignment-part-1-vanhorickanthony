using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerNextLevel : MonoBehaviour
{
    public string mNextLevel = "";
    
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
            LoadLevel levelLoader = gameObject.GetComponent<LoadLevel>();
            
            levelLoader.SceneLoad(mNextLevel);
        }

    }
}
