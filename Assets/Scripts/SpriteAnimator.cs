using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] _frameArray;
    [SerializeField] private SpriteRenderer _renderer;
    private int currentFrame;
    private float timer;

    public float framerate = 1f;

    private AudioSource audioSource;
    public AudioClip[] clips;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= framerate) 
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % _frameArray.Length;
            _renderer.sprite = _frameArray[currentFrame];
            if (currentFrame == 3)
            {
                audioSource.volume = 0.15f;
                audioSource.PlayOneShot(clips[Random.Range(0, 3)]);
            }
        }
    }
}
