using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // Singleton Class

    public Text score_txt;
    public int score = 0;

    void Awake()
    {
        // Make sure there is only on instance of this class
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
