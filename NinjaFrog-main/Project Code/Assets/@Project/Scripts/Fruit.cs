using UnityEngine;

public class Fruit : MonoBehaviour
{
	GameController gc;
    private void Start()
    {
		gc = FindObjectOfType<GameController>();
    }
    public GameObject m_collectedPrefab;
	private void OnTriggerEnter2D( Collider2D other )
	{
		if ( other.name.Contains( "Player" ) )
		{
			var collected = Instantiate
			(
				m_collectedPrefab,
				transform.position,
				Quaternion.identity
			);
			var animator = collected.GetComponent<Animator>();
			var info = animator.GetCurrentAnimatorStateInfo( 0 );
			var time = info.length;
			gc.ScoreIncrement();
			Destroy( collected, time );
			Destroy( gameObject );
		}
	}
}