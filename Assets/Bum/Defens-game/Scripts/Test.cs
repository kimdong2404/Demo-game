using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Test : MonoBehaviour
{
    float score;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    private void OnEnable()
    {
    }
    void Start()
    {
        score += 10;
        PlayerPrefs.SetFloat("score", score);
        float scorecopy = PlayerPrefs.GetFloat("score", 0);
        Debug.Log(scorecopy);
    }
   
       
    // Update is called once per frame
    void Update()
    {
    }
   
}

