using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PrefabListScriptableObjectScript prefabList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Debug.Log(prefabList.GetRandomPrefab().name); // Debug.log just to see if it works
    }
}
