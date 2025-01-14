using UnityEngine;

[CreateAssetMenu(fileName = "New Prefab List", menuName = "Lior Hadashian/Prefab List")]
public class PrefabListScriptableObjectScript : ScriptableObject
{
    public GameObject[] prefabs = new GameObject[3];

    public GameObject GetRandomPrefab()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        return prefabs[randomIndex];
    }
}
