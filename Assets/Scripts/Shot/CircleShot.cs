using UnityEngine;

namespace Shot
{
    public class CircleShot : MonoBehaviour {

        //발사될 총알 오브젝트
        public GameObject Bullet;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Shot();
        }

        private void Shot()
        {
            //360번 반복
            for (int i = 0; i < 360; i += 13)
            {
                //총알 생성
                GameObject temp = Instantiate(Bullet);

                //2초마다 삭제
                Destroy(temp, 2f);

                //총알 생성 위치를 (0,0) 좌표로 한다.
                temp.transform.position = Vector2.zero;

                //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
                temp.transform.rotation = Quaternion.Euler(0, 0, i);
            }
        }
    }
}
