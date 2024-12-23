using BIS.Managers;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

namespace BIS
{
    public class CameraManager
    {
        public CinemachineCamera MainCam => _mainCam;
        private CinemachineCamera _mainCam;
        private Vector3 _currentOffset = Vector3.zero;
        private float _currentAmplitude = 0f;
        private float _currentFrequency = 0f;

        public void ShakeCamera(Vector3 offSet, float amplitudeGain, float frequencyGain, float duration)
        {
            _mainCam = Manager.GameScene.MainCamera;
            _mainCam.StartCoroutine(ShakeCameraCoroutine(offSet, amplitudeGain, frequencyGain, duration));
        }

        private IEnumerator ShakeCameraCoroutine(Vector3 offSet, float amplitudeGain, float frequencyGain, float duration)
        {
            var cam = _mainCam.GetComponent<CinemachineBasicMultiChannelPerlin>();

            // 기존 값에 새로운 흔들림 효과를 추가
            _currentOffset += offSet;
            _currentAmplitude += amplitudeGain;
            _currentFrequency += frequencyGain;

            cam.PivotOffset = _currentOffset;
            cam.AmplitudeGain = _currentAmplitude;
            cam.FrequencyGain = _currentFrequency;

            yield return new WaitForSeconds(duration);

            // 효과가 끝나면 추가된 값만 제거
            _currentOffset -= offSet;
            _currentAmplitude -= amplitudeGain;
            _currentFrequency -= frequencyGain;

            cam.PivotOffset = _currentOffset;
            cam.AmplitudeGain = _currentAmplitude;
            cam.FrequencyGain = _currentFrequency;
        }
    }
}
