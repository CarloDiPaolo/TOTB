using System;
using TMPro;
using UnityEngine;

namespace FleischWolf
{
    public class ScoreManager : MonoBehaviour
    {
        public TMP_Text scoreText;
        private int pointAmount;

        void Start()
        {
            pointAmount = 0;
            scoreText.text = pointAmount.ToString();
        }


        public void AddScore()
        {
            pointAmount +=1;
            scoreText.text = pointAmount.ToString();
        }


        

    }  
}