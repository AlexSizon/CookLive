using AYellowpaper.SerializedCollections;
using InteractableObjects.Enums;
using UnityEngine;

namespace InteractableObjects.SO
{
    [CreateAssetMenu]
    public class IngredientPrefabStorage : ScriptableObject
    {
        public SerializedDictionary<IngredientType, GameObject> IngredientStorage;
    }
}
