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
            // �߰� ��ġ ���
            Vector3 middlePosition = (_p1Trm.position + _p2Trm.position) / 2f;

            // ī�޶� ��ġ�� �߰� ��ġ�� ����
            transform.position = new Vector3(middlePosition.x, middlePosition.y, transform.position.z);

            // ī�޶��� Orthographic Size�� �� �÷��̾��� �Ÿ��� ����
            float distance = Vector3.Distance(_p1Trm.position, _p2Trm.position);
            _cam.Lens.OrthographicSize = Mathf.Min((Mathf.Max(distance / 2f, 7.5f)), 13); // ������ ũ�� ���� (2�� ��������));
        }
    }
}
