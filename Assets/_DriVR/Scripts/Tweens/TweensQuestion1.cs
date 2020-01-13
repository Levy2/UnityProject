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
        [SerializeField] private Transform arrowLeft;
        [SerializeField] private Transform arrowRight;

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
            //arrowLeft.GetComponent<SpriteRenderer>().DOColor(new Color32(30, 255, 0, 255), 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(4.5f);
            sequenceQuestionBegin.SetEase(Ease.InOutSine)
            .Append(playerCar.DOLocalMoveZ(-38.7f, 10))
            .Insert(0, greenCar.DOLocalMoveX(15.6f, 10))
            .Insert(0, blueCar.DOLocalMoveX(38.2f, 10));

            TweenHandler.Instance.SequenceUiQuestion();
        }
    }
}

