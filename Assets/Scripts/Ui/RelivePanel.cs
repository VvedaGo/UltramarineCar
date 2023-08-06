using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
   public class RelivePanel : MonoBehaviour
   {
      [SerializeField] private Image _fillAmountTime;
      // [SerializeField] private TextMeshProUGUI _timeCount;
      [SerializeField] private TextMeshProUGUI _coinsCount;
      [SerializeField] private TextMeshProUGUI _timeLeftText;
      [SerializeField] private LosePanel _losePanel;
      [SerializeField] private GameHud _gameHud;
      private const int TimeToRelive = 10;
      private int _leftTime;
      private Coroutine _timer;
      private Tween _tween;

      public void Open()
      {
         _leftTime = TimeToRelive;
         _fillAmountTime.fillAmount = 1;
         gameObject.SetActive(true);
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
         _gameHud.Relive();
      }

      private IEnumerator Timer()
      {
         _tween = _fillAmountTime.DOFillAmount(0, 10f).SetEase(Ease.Linear);
         for (int i = 0; i < TimeToRelive; i++)
         {
            yield return new WaitForSeconds(1f);
            _leftTime--;
            _timeLeftText.text = $"{_leftTime}";
         }
         Close();
         _losePanel.Open();
      }
   }
}
