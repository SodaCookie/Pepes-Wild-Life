using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextBehavior : MonoBehaviour {
    public float spread;
    public float force;
    public Transform emitter;
    public GameObject damageText;
    public Color suspicionColor;
    public Color approvalColor;
    public Color moneyColor;

    public void fire(float suspicion, float approvral, float money)
    {
        GameObject susp = Instantiate(damageText);
        susp.transform.position = emitter.position;
        susp.GetComponent<TextMesh>().color = suspicionColor;
        susp.GetComponent<TextMesh>().text = suspicion.ToString();
        susp.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-spread, spread), force);
        GameObject appr = Instantiate(damageText);
        appr.transform.position = emitter.position;
        appr.GetComponent<TextMesh>().color = approvalColor;
        appr.GetComponent<TextMesh>().text = approvral.ToString();
        appr.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-spread, spread), force);
        GameObject mon = Instantiate(damageText);
        mon.transform.position = emitter.position;
        mon.GetComponent<TextMesh>().color = moneyColor;
        mon.GetComponent<TextMesh>().text = money.ToString();
        mon.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-spread, spread), force);
    }
}
