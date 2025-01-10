using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public Text textHealth;
    public int health = 100;

    private void Start()
    {
        textHealth.text = health.ToString();
    }

    public void TakeDmg()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
