using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour 
{

	// deklaracija varijable za brzinu i RigidBody komponentu
	public Text countText;
	public float speed;
	private int zbroj;
	private Rigidbody rb;
	void Start () 
	{
		// dohvaćanje komponente
		rb = GetComponent<Rigidbody>();
		zbroj = 0;
		SetCountText();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// dohvaćanje vrijednosti za osi
		float movementHorizontal = Input.GetAxis("Horizontal");
		float movementVertical = Input.GetAxis("Vertical");

		// postavljanje vektora
		Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

		// dodavanje sile na objekt
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter (Collider other)
	{
		// provjera tag-a drugog objekta
		if (other.gameObject.CompareTag("Pick Up"))
		{
			// objekt se deaktivira
			other.gameObject.SetActive(false);
			// nakon svakog skupljenog objekta rezultat se povećava za 1
			zbroj += 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Rezultat" + zbroj.ToString();
	}
}
