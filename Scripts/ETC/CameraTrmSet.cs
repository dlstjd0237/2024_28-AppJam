using Unity.Cinemachine;
using UnityEngine;

namespace BIS
{
    public class CameraTrmSet : MonoBehaviour
    {
        [SerializeField] private Transform _p1Trm, _p2Trm;
        [SerializeField] private CinemachineCamera _cam;
        private void LateUpdate()
        {
            // 중간 위치 계산
            Vector3 middlePosition = (_p1Trm.position + _p2Trm.position) / 2f;

            // 카메라 위치를 중간 위치로 설정
            transform.position = new Vector3(middlePosition.x, middlePosition.y, transform.position.z);

            // 카메라의 Orthographic Size를 두 플레이어의 거리로 설정
            float distance = Vector3.Distance(_p1Trm.position, _p2Trm.position);
            _cam.Lens.OrthographicSize = Mathf.Min((Mathf.Max(distance / 2f, 7.5f)), 13); // 적당한 크기 조정 (2로 나누어줌));
        }
    }
}
