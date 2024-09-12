using System;
using System.Collections;
using System.Collections.Generic;
using MiniGames.GuitarHeroMiniGame;
using MiniGames.Interfaces;
using UnityEngine;
using Random = System.Random;

namespace MiniGames
{
    public class GuitarHero : MiniGame
    {
        [SerializeField] private GameObject triggerObject;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private RectTransform triggeredObject;
        private List<RectTransform> triggerObjects;
        private Action onComplete;
        private int missedObjects = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && triggerObjects.Count > 0)
            {
                foreach (var item in triggerObjects)
                {
                    Debug.Log(item.name);
                    if (item.anchoredPosition.x > triggeredObject.anchoredPosition.x - 25 &&
                        item.anchoredPosition.x < triggeredObject.anchoredPosition.x + 25)
                    {
                        Destroy(item.gameObject);
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if (missedObjects > 2) MiniGameFailed();
        }

        public override void StartGame()
        {
            triggerObjects = new List<RectTransform>();
            StartCoroutine(CirclesSpawner(10));
        }

        public override void GetMiniGameResult()
        {
        }

        public override void ResetGame()
        {
            foreach (var item in triggerObjects)
            {
                Destroy(item.gameObject);
            }

            missedObjects = 0;
            triggerObjects.Clear();
        }

        private IEnumerator CirclesSpawner(int circlesCount)
        {
            for (int i = 0; i < circlesCount; i++)
            {
                var currentTriggerObject = Instantiate(triggerObject, spawnPoint).GetComponent<RectTransform>();
                triggerObjects.Add(currentTriggerObject);
                currentTriggerObject.GetComponent<TriggerObject>()
                    .Initialize(() => triggerObjects.Remove(currentTriggerObject), () => missedObjects++);
                Random r = new Random();
                var seconds = (float)r.Next(1, 10) / 10;
                yield return new WaitForSeconds(seconds);
            }
        }
    }
}