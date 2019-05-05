using UnityEngine;

public class ScrollMusics : MonoBehaviour {

	public GameObject shopMusics;
	private Vector3 screenPoint, offset, fPos, sPos;
	private float lockedYPos;

	void Update () {
		if (shopMusics.transform.position.x > 300 + 0f) {
			shopMusics.transform.position = Vector3.Lerp (shopMusics.transform.position, new Vector3 (300 + 0f, shopMusics.transform.position.y, shopMusics.transform.position.z), Time.deltaTime * 10f);
		} else if (shopMusics.transform.position.x < 300 - PlayerPrefs.GetInt("maxRangeMusic")) {
			shopMusics.transform.position = Vector3.Lerp (shopMusics.transform.position, new Vector3 (300 - PlayerPrefs.GetInt("maxRangeMusic"), shopMusics.transform.position.y, shopMusics.transform.position.z), Time.deltaTime * 10f);
		}
	}
	void OnMouseDown()
    {
        fPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));//
        lockedYPos = screenPoint.x + 1f;
		offset = shopMusics.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
		Cursor.visible = false;
	}
	void OnMouseDrag() {
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		curPosition.y = lockedYPos;
		shopMusics.transform.position = curPosition;
    }
    void OnMouseUp()
    {
        sPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));//
        Cursor.visible = true;
        if (fPos.x > sPos.x)//
        {
            shopMusics.GetComponent<Rigidbody>().AddForce(shopMusics.transform.right * Time.deltaTime * -(fPos.x - sPos.x) * 100f);//
        }
        else if (fPos.x < sPos.x)//
        {
            shopMusics.GetComponent<Rigidbody>().AddForce(shopMusics.transform.right * Time.deltaTime * (sPos.x - fPos.x) * 100f);//
        }
    }
}