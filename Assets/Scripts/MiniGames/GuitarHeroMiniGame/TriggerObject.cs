using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace MiniGames.GuitarHeroMiniGame
{
    public class TriggerObject : MonoBehaviour
    {
        private Action onDestroy;
        private Action onMissedObject;

        public void Initialize(Action onDestroy, Action onMissedObject)
        {
            this.onDestroy = onDestroy;
            this.onMissedObject = onMissedObject;
        }

        public void OnDestroy()
        {
            onDestroy.Invoke();
        }

        private float duration = 2;

        void Start()
        {
            StartCoroutine(CircleMovement());
        }

        private IEnumerator CircleMovement()
        {
            var rect = GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 0);
            rect.DOAnchorPos(new Vector3(-850, 0), duration);
            yield return new WaitForSeconds(duration);
            Destroy(gameObject);
            onMissedObject.Invoke();
        }
    }
}