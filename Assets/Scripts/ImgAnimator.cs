using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImgAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] _frameArray;
    [SerializeField] private Image _renderer;
    private int currentFrame;
    private float timer;

    public float framerate = 1f;

    private AudioSource audioSource;
    public AudioClip[] clips;
    public int frameToHit = 0;

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

            if (SceneManager.GetActiveScene().name == "Main")
            {
                frameToHit = 3;
            }
            else
            {
                frameToHit = 5;
            }

            if (currentFrame == frameToHit && clips.Length != 0)
            {
                audioSource.volume = 0.09f;
                audioSource.PlayOneShot(clips[Random.Range(0, 3)]);
            }
        }
    }
}
