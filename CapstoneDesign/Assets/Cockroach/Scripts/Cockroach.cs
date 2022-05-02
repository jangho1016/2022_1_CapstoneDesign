using UnityEngine;
using System.Collections;

public class Cockroach : MonoBehaviour {
    Animator cockroach;
    public IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        cockroach = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            cockroach.SetBool("idle", true);
            cockroach.SetBool("walk", false);
        }
        if (Input.GetKey("down"))
        {
            cockroach.SetBool("walk", true);
            cockroach.SetBool("idle", false);
            cockroach.SetBool("run", false);
        }
        if (Input.GetKey("up"))
        {
            cockroach.SetBool("run", true);
            cockroach.SetBool("walk", false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            cockroach.SetBool("hit", true);
            cockroach.SetBool("walk", false);
            cockroach.SetBool("run", false);
            cockroach.SetBool("idle", false);
            StartCoroutine("idle2");
            idle2();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            cockroach.SetBool("attack", true);
            cockroach.SetBool("idle", false);
            cockroach.SetBool("walk", false);
            cockroach.SetBool("run", false);
            StartCoroutine("walk2");
            walk2();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            cockroach.SetBool("death", true);
            cockroach.SetBool("walk", false);
            cockroach.SetBool("run", false);
        }
        if (Input.GetKey("right"))
        {
            cockroach.SetBool("turn_right", true);
            cockroach.SetBool("walk", false);
            cockroach.SetBool("run", false);
            StartCoroutine("walk");
            walk();
        }
        if (Input.GetKey("left"))
        {
            cockroach.SetBool("turn_left", true);
            cockroach.SetBool("walk", false);
            cockroach.SetBool("run", false);
            StartCoroutine("walk");
            walk();
        }
    }
    IEnumerator walk()
    {
        yield return new WaitForSeconds(1.0f);
        cockroach.SetBool("walk", true);
        cockroach.SetBool("turn_right", false);
        cockroach.SetBool("turn_left", false);
        cockroach.SetBool("attack", false);
    }

    IEnumerator idle()
    {
        yield return new WaitForSeconds(2.0f);
        cockroach.SetBool("idle", true);
        cockroach.SetBool("walk", false);
        cockroach.SetBool("hit", false);
        cockroach.SetBool("hit", false);
    }

    IEnumerator idle2()
    {
        yield return new WaitForSeconds(0.2f);
        cockroach.SetBool("idle", true);
        cockroach.SetBool("walk", false);
        cockroach.SetBool("hit", false);
        cockroach.SetBool("hit", false);
    }

    IEnumerator walk2()
    {
        yield return new WaitForSeconds(0.5f);
        cockroach.SetBool("walk", true);
        cockroach.SetBool("turn_right", false);
        cockroach.SetBool("turn_left", false);
        cockroach.SetBool("attack", false);
    }
}
