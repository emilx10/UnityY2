using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class PlatformScripts : MonoBehaviour
{
    public GameObject platform;
    public NavMeshSurface navMeshSurface;
    private NavMeshModifier navMeshModifier;
    public float delayInSeconds = 3f;

    void Start()
    {
        navMeshModifier = platform.GetComponent<NavMeshModifier>();

        SetPlatformVisibility(false);

        StartCoroutine(LoopPlatformVisibility());
    }

    private IEnumerator LoopPlatformVisibility()
    {
        while (true)
        {
            TogglePlatform(true);

            yield return new WaitForSeconds(delayInSeconds);

            TogglePlatform(false);

            yield return new WaitForSeconds(delayInSeconds);
        }
    }

    public void TogglePlatform(bool show)
    {
        SetPlatformVisibility(show);
        if (show)
        {
            navMeshSurface.BuildNavMesh();
        }
        else
        {
            navMeshModifier.enabled = false;
        }
    }

    private void SetPlatformVisibility(bool visible)
    {
        platform.SetActive(visible);
        navMeshModifier.enabled = visible;
    }
}