
using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraUtils : MonoBehaviour
{
    [SerializeField]
    private float _zoomDefault = 60.0f;
    [SerializeField]
    private float _zoomOut = 72.0f;
    private float _zoomTarget;
    private CinemachineVirtualCamera _virtualCamera;

    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _virtualCamera.m_Lens.FieldOfView = _zoomDefault;
    }

    public void ZoomInOut(bool zoom)
    {
        // StopCoroutine(ZoomInOutCoroutine(zoom));
        if (zoom)
        {
            _zoomTarget = _zoomOut;

        }
        else
        {
            _zoomTarget = _zoomDefault;
        }

        StartCoroutine(ZoomInOutCoroutine(zoom));
    }

    private IEnumerator ZoomInOutCoroutine(bool zoom)
    {
        // var delta = zoom ? 1f : -1f;
        if (zoom)
        {
            for (float curr = _virtualCamera.m_Lens.FieldOfView; curr <= _zoomTarget; curr += 1.0f)
            {
                _virtualCamera.m_Lens.FieldOfView = curr;
                Debug.Log($"curr: {curr}");
                yield return new WaitForSeconds(.01f);
            }
        }
        else
        {
            for (float curr = _virtualCamera.m_Lens.FieldOfView; curr >= _zoomTarget; curr -= 1.0f)
            {
                _virtualCamera.m_Lens.FieldOfView = curr;
                Debug.Log($"curr: {curr}");
                yield return new WaitForSeconds(.01f);
            }
        }
    }
}
