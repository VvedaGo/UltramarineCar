using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelivePanel : MonoBehaviour
{
   [SerializeField] private Image _fillAmountTime;
   [SerializeField] private TextMeshProUGUI _timeCount;
   [SerializeField] private TextMeshProUGUI _coinsCount;

   private const int TimeToRelive = 10;
   private Coroutine _timer;
   public void Open()
   {
      
   }

   public void Close()
   {
      gameObject.SetActive(false);
   }

   public void StartTimer()
   {
      _timer = StartCoroutine(Timer());
   }

   private void EndTimer()
   {
      
   }

   public void WatchAdd()
   {
      
   }

   public void PayCoin()
   {
      
   }

   private IEnumerator Timer()
   {
      yield return null;
   }
}
