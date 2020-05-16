using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int _current, int _max)
    {
        float _value = (float)_current / _max;

    }
}
