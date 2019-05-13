using UnityEngine;
using System.Collections;

public class ScrollSpace : MonoBehaviour {

	public GameObject Cubes;
    public bool slide;
	private Vector3 screenPoint, offset, fPos, sPos;
	private float lockedYPos;
    
	void Update ()
    {
        if (Cubes.transform.position.x > transform.position.x + 1.87) Cubes.transform.position = Vector3.Lerp(Cubes.transform.position, new Vector3(transform.position.x + 1.87f, Cubes.transform.position.y, Cubes.transform.position.z), Time.deltaTime * 10f);
        else if (Cubes.transform.position.x < transform.position.x - 12.1f) Cubes.transform.position = Vector3.Lerp(Cubes.transform.position, new Vector3(transform.position.x - 12.1f, Cubes.transform.position.y, Cubes.transform.position.z), Time.deltaTime * 10f);
    }

    void OnMouseDown()
    {
        fPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        lockedYPos = screenPoint.x + 0.4f;
        offset = Cubes.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Cursor.visible = false;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = lockedYPos;
        Cubes.transform.position = curPosition;
    }

    void OnMouseUp()
    {
        sPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        if (fPos.x > sPos.x) Cubes.GetComponent<Rigidbody>().AddForce(Cubes.transform.right * Time.deltaTime * -(fPos.x - sPos.x) * 100f);
        else if (fPos.x < sPos.x) Cubes.GetComponent<Rigidbody>().AddForce(Cubes.transform.right * Time.deltaTime * (sPos.x - fPos.x) * 100f);
        Cursor.visible = true;
    }
}