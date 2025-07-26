using System.Collections;
using UnityEngine;

public class CatAnimation : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private string animationStateName = "Cat"; 

    private void Start() {
        StartCoroutine(PlayCatAnimationLoop());
    }

    private IEnumerator PlayCatAnimationLoop() {
        while (true) {
            animator.Play(animationStateName, 0, 0f);

            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            float animLength = stateInfo.length;

            yield return new WaitForSeconds(animLength);  
            yield return new WaitForSeconds(5f);     
        }
    }
}
