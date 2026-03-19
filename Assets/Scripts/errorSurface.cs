using System.Collections;
using UnityEngine;

public class ErrorSurface : MonoBehaviour
{
    [SerializeField] private GameObject errorMessagePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.TryGetComponent(out DynamicObject dynamicObject))
        {
            var container = dynamicObject.Container;

            if (container != null)
            {
                StartCoroutine(SpawnErrorMessageRoutine(container.gameObject));
            }
        }
    }

    private IEnumerator SpawnErrorMessageRoutine(GameObject container)
    {
        yield return new WaitForSeconds(1f);
        GameObject errorMessage = Instantiate(errorMessagePrefab, container.transform.position + Vector3.up * 0.5f, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(errorMessage);
    }
}