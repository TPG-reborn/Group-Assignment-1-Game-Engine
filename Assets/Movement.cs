using UnityEngine;
public class Movement : MonoBehaviour
{
    //Setting the speed value for the cube
    public float speed = 7.5f;

   void Start()
   {

   }
   void Update()
   {
      //Move forward upon pressing W
      if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

      //Move left upon pressing A
      if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       
      //Move back upon pressing S
      if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

      //Move right upon pressing D
      if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }


}