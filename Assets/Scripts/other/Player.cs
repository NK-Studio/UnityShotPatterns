using UnityEngine;

namespace other
{
    public class Player : MonoBehaviour
    {
        //캐릭터 이동 시스템
        public float Speed = 5f;

        private void Update()
        {
            //좌우 이동
            transform.Translate(Vector2.right * (Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime), Space.Self);
            //상하 이동
            transform.Translate(Vector2.up * (Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime), Space.Self);
        }
    }
}
