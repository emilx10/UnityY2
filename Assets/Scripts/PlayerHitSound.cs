using UnityEngine;

public class PlayerHitSound : StateMachineBehaviour
{

    public AudioClip clip;
    private AudioSource audio;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(audio == null)
        {
            audio = animator.GetComponent<AudioSource>();
        }
        if(audio != null && clip != null) 
        {
            audio.PlayOneShot(clip);
        }
    }

   
}
