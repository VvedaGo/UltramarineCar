using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelivePanel : MonoBehaviour
{
   [SerializeField] private Image _fillAmountTime;
   [SerializeField] private TextMeshProUGUI _timeCount;
   [SerializeField] private TextMeshProUGUI _coinsCount;
   [SerializeField] private TextMeshProUGUI _timeLeftText;

   private const int TimeToRelive = 10;
   private int _leftTime;
   private Coroutine _timer;
   private Tween _tween;

   public void Open()
   {
      _leftTime = TimeToRelive;
      _fillAmountTime.fillAmount = 1;
   }

   public void Close()
   {
      EndTimer();
      gameObject.SetActive(false);
   }

   public void StartTimer()
   {
      _timer = StartCoroutine(Timer());
   }

   private void EndTimer()
   {
      if(_tween!=null)
         _tween.Kill();

      if (_timer != null)
      {
         StopCoroutine(_timer);
      }
   }

   public void WatchAdd()
   {
      
   }

   public void PayCoin()
   {
      
   }

   private IEnumerator Timer()
   {
      _tween = _fillAmountTime.DOFillAmount(0, 10f);
      for (int i = 0; i < TimeToRelive; i++)
      {
         yield return new WaitForSeconds(1f);
         _leftTime--;
         _timeLeftText.text = $"{_leftTime}";
      }
      Close();
   }
}
