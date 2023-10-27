using UnityEngine;

namespace Ursaanimation.CubicFarmAnimals
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;
        public string walkForwardAnimation = "walk_forward";
        public string walkBackwardAnimation = "walk_backwards";
        public string runForwardAnimation = "run_forward";
        public string turn90LAnimation = "turn_90_L";
        public string turn90RAnimation = "turn_90_R";
        public string trotAnimation = "trot_forward";
        public string sittostandAnimation = "sit_to_stand";
        public string standtositAnimation = "stand_to_sit";
        public string idle = "idle";

        private float fallingTreshold = 1.0f;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            if(rigidbody.velocity.y < -fallingTreshold)
            {
                //falling
                animator.Play(walkBackwardAnimation);
            }
            else if (rigidbody.velocity.y > fallingTreshold)
            {
                //rising
                animator.Play(walkForwardAnimation);
            }
            else
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    animator.Play(walkForwardAnimation);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    animator.Play(walkBackwardAnimation);
                }
                else
                {
                    animator.Play(idle);
                }
            }
            
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    animator.Play(walkForwardAnimation);
            //}
            //else if (Input.GetKeyDown(KeyCode.S))
            //{
            //    animator.Play(walkBackwardAnimation);
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    animator.Play(runForwardAnimation);
            //}
            //else if (Input.GetKeyDown(KeyCode.A))
            //{
            //    animator.Play(turn90LAnimation);
            //}
            //else if (Input.GetKeyDown(KeyCode.D))
            //{
            //    animator.Play(turn90RAnimation);
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
            //    animator.Play(trotAnimation);
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha4))
            //{
            //    animator.Play(sittostandAnimation);
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha3))
            //{
            //    animator.Play(standtositAnimation);
            //}
            //else if (Input.GetKeyUp(KeyCode.W))
            //{
            //    animator.Play(idle);
            //}




        }
    }
}
