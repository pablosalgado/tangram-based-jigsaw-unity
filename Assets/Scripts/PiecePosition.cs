using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePosition : MonoBehaviour
{
    // The piece original position
    private Vector3 _rightPosition;

    public bool InRightPosition { get; set; }

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Save the original piece position and randomly move to a new position
        _rightPosition = transform.position;
        var left = Random.Range(0, 2) == 0;

        transform.position =
            left
                ? new Vector3(Random.Range(-10f, -5f), Random.Range(-4f, 4f), 0)
                : new Vector3(Random.Range(5f, 10f), Random.Range(-4f, 4f), 0);

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // When moving the piece snap it to its original position.
        if (Vector3.Distance(transform.position, _rightPosition) < 0.5f)
        {
            if (!InRightPosition)
            {
                _audioSource.Play();
            }
            
            transform.position = _rightPosition;
            InRightPosition = true;
            
        }
    }
}