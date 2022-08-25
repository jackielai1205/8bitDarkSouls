using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float startingHealth;

   public float currentHealth { get; private set; }
   private Animator anim;

   private void Awake(){
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
   }

   public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0){
            anim.SetTrigger("Hurt");
        } else {
            anim.SetTrigger("Death");
        }
   }

   // hihihihihi

   public void Update(){
        if(Input.GetKeyDown("z")){
            TakeDamage(1);
        }
   }
}
