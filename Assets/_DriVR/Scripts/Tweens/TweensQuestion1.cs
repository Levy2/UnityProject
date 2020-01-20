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

        private static TweensQuestion1 instance;

        private Sequence sequenceQuestionBegin;
        private Sequence sequenceCorrect;
        private Sequence sequenceIncorrect;

        private Vector3 playerCarStartPos;
        private Vector3 greenCarStartPos;
        private Vector3 blackCarStartPos;

        [SerializeField] private Transform playerCar;
        [SerializeField] private Transform greenCar;
        [SerializeField] private Transform blackCar;
        [SerializeField] private Transform arrowLeft;
        [SerializeField] private Transform arrowRight;

        #endregion

        #region Properties and Indexers

        public static TweensQuestion1 Instance { get { return instance; } private set { instance = value; } }

        #endregion

        private void Awake()
        {
            if (Instance == null) { Instance = this; }
        }

        private void Start()
        {
            sequenceQuestionBegin   = DOTween.Sequence();
            sequenceCorrect         = DOTween.Sequence();
            sequenceIncorrect       = DOTween.Sequence();

            playerCarStartPos = new Vector3(playerCar.transform.localPosition.x, playerCar.transform.localPosition.y, playerCar.transform.localPosition.z);
            greenCarStartPos = new Vector3(greenCar.transform.localPosition.x, greenCar.transform.localPosition.y, greenCar.transform.localPosition.z);
            blackCarStartPos = new Vector3(blackCar.transform.localPosition.x, blackCar.transform.localPosition.y, blackCar.transform.localPosition.z);

            StartSequenceQuestionBegin();
        }

        private void StartSequenceQuestionBegin()
        {
            arrowLeft.GetComponent<SpriteRenderer>().DOColor(new Color32(30, 255, 0, 255), 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(4.5f);
            sequenceQuestionBegin.SetEase(Ease.InOutSine)
            .Append(playerCar.DOLocalMoveZ(-38.7f, 10))
            .Insert(0, greenCar.DOLocalMoveX(15.6f, 10))
            .Insert(0, blackCar.DOLocalMoveX(38.2f, 10));

            TweenHandler.Instance.SequenceUiQuestion();
        }

        public void StartSequenceQuestionIncorrect()
        {
            playerCar.localPosition = playerCarStartPos;
            greenCar.localPosition = greenCarStartPos;
            blackCar.localPosition = blackCarStartPos;

            arrowLeft.GetComponent<SpriteRenderer>().DOColor(new Color32(30, 255, 0, 255), 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(4.5f);

            sequenceIncorrect
            .Append(playerCar.DOLocalMoveZ(-21.28f, 9))
            .Insert(0, greenCar.DOLocalMoveX(15.6f, 10))
            .Insert(0, blackCar.DOLocalMoveX(30.7f, 10));
        }
    }
}

