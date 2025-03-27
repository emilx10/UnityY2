using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PrefabListScriptableObjectScript prefabList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            Debug.Log(prefabList.GetPrefab().name); // Debug.log just to see if it works
        else if (Input.GetKeyDown(KeyCode.A))
            Debug.Log(prefabList.GetPrefab(PrefabsInList.Coin).name);
    }
}
