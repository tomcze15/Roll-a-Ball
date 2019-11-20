using UnityEngine;

public class Spin : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 5, 0) * Time.deltaTime * 5);
    }
}
