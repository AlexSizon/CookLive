using System;
using System.Collections;
using InteractableObjects.Enums;
using InteractableObjects.Interfaces;
using InteractableObjects.SO;
using UnityEngine;

namespace Equipment
{
    public class FoodStorage : MonoBehaviour, IInteractable
    {
        [SerializeField] private IngredientType ingredientType;
        [SerializeField] private ParticleSystem particleSystem;
        [SerializeField] private IngredientPrefabStorage ingredientPrefabStorage; //Temp Field
        [SerializeField] private Transform spawnPoint;

        public void Interact()
        {
            StartCoroutine(PlayParticles(1f));
            Instantiate(ingredientPrefabStorage.IngredientStorage[ingredientType], spawnPoint.position,
                Quaternion.identity);
        }

        private IEnumerator PlayParticles(float duration)
        {
            var currentParticles =
                Instantiate(particleSystem, spawnPoint.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            currentParticles.Play();
            yield return new WaitForSeconds(duration);
            currentParticles.Stop();
        }
    }
}