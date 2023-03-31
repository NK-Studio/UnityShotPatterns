using UnityEngine;

namespace Shot
{
    public class SpinShot : MonoBehaviour
    {
        //회전되는 스피드이다.
        public float TurnSpeed;

        //발사될 총알 오브젝트이다.
        public GameObject Bullet;

        public float SpawnInterval = 0.5f;
        private float _spawnTimer;

        private void Update()
        {
            //기본 회전
            transform.Rotate(Vector3.forward * (TurnSpeed * 100 * Time.deltaTime));

            //생성 간격 처리
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer < SpawnInterval) return;

            //초기화
            _spawnTimer = 0f;
            
            //총알 생성
            GameObject temp = Instantiate(Bullet);

            //2초후 자동 삭제
            Destroy(temp, 2f);

            //총알 생성 위치를 머즐 입구로 한다.
            temp.transform.position = transform.position;

            //총알의 방향을 오브젝트의 방향으로 한다.
            //->해당 오브젝트가 오브젝트가 360도 회전하고 있으므로, Rotation이 방향이 됨.
            temp.transform.rotation = transform.rotation;
        }
    }
}