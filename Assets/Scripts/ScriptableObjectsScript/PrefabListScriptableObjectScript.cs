using UnityEngine;

public enum PrefabsInList
{
    Coin,
    Laser,
    Barrel
}

[CreateAssetMenu(fileName = "New Prefab List", menuName = "Lior Hadashian/Prefab List")]
public class PrefabListScriptableObjectScript : ScriptableObject
{
    public GameObject[] prefabs = new GameObject[3];

    //Returns a random prefab
    public GameObject GetPrefab()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        return prefabs[randomIndex];
    }

    public GameObject GetPrefab(PrefabsInList prefab)
    {
        switch (prefab)
        {
            case PrefabsInList.Coin:
                return prefabs[0];
            case PrefabsInList.Laser:
                return prefabs[1];
            case PrefabsInList.Barrel:
                return prefabs[2];
            default:
                return null;
        }
    }
}
