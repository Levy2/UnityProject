//-----------------------------------------------------------------------
// <copyright file="PointsHandler.cs" company="DriVR Inc.">
//     Copyright (c) 2020 DriVR Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DriVR.Scenario {
    public class PointsHandler : MonoBehaviour
    {
        public int answersCorrect;
        public int answersWrong;

        private static PointsHandler instance;

        public static PointsHandler Instance { get { return instance; } private set { instance = value; } }

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
        }

        public void AddAnswerPoint(bool answerCorrect)
        {
            if (answerCorrect)
            {
                answersCorrect++;
            }
            else
            {
                answersWrong++;
            }

            StatsScreen.Instance.UpdateStatsText();
        }

        private void ResetPoints()
        {
            answersCorrect = 0;
            answersWrong = 0;
        }
    }
}