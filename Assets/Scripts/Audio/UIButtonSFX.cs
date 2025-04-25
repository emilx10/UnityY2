using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSFX : MonoBehaviour
{
    public AudioSource clickSound;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
    }

    private void PlaySound()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
}