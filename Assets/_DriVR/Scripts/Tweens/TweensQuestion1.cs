//-----------------------------------------------------------------------
// <copyright file="TweensQuestion1.cs" company="DriVR Inc.">
//     Copyright (c) 2020 DriVR Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DriVR.Scenario
{
    public class TweensQuestion1 : MonoBehaviour
    {
        #region Fields

        private Sequence sequenceQuestionBegin;
        private Sequence sequenceCorrect;
        private Sequence sequenceIncorrect;

        [SerializeField] private Transform playerCar;
        [SerializeField] private Transform greenCar;
        [SerializeField] private Transform blueCar;

        #endregion

        private void Start()
        {
            sequenceQuestionBegin = DOTween.Sequence();
            sequenceCorrect = DOTween.Sequence();
            sequenceIncorrect = DOTween.Sequence();
            StartSequenceQuestionBegin();
        }

        private void StartSequenceQuestionBegin()
        {
            sequenceQuestionBegin.SetEase(Ease.InOutSine);
            sequenceQuestionBegin.AppendInterval(1f);
            sequenceQuestionBegin.Append(playerCar.DOLocalMoveZ(-166.5f, 10));
            sequenceQuestionBegin.Insert(0, greenCar.DOLocalMoveX(15.6f, 10));
            sequenceQuestionBegin.Insert(0, blueCar.DOLocalMoveX(38.2f, 10));
        }
    }
}

