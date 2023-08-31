using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace Game
{
    public class Coin:MonoBehaviour
    {
        private const float DurationPickUpAnimation = 0.7f;

        private void Start()
        {
            RotateCoin();
        }

        private void RotateCoin()
        {
            StartCoroutine(Rotating());
        }

        private IEnumerator Rotating()
        {
            while (gameObject.activeSelf)
            {
                transform.DORotate(transform.eulerAngles + new Vector3(0, 180, 0), 2.5f).SetEase(Ease.Linear);
                yield return new WaitForSeconds(2.5f);
            }
        }

        public void PickUp()
        {
            transform.DOMove(transform.position + new Vector3(0, 13, 0), DurationPickUpAnimation).SetEase(Ease.Linear).OnComplete(DestroyObject);
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}