using UnityEngine;

public class ScrollBGs : MonoBehaviour {
	
	public GameObject shopBGs;
	private Vector3 screenPoint, offset, fPos, sPos;
	private float lockedYPos;
    
    void Update()
    {
        if (shopBGs.transform.position.x > 200 + 0f)
        {
            shopBGs.transform.position = Vector3.Lerp(shopBGs.transform.position, new Vector3(200 + 0f, shopBGs.transform.position.y, shopBGs.transform.position.z), Time.deltaTime * 10f);
        }
        else if (shopBGs.transform.position.x < 200 - PlayerPrefs.GetInt("maxRangeBGs"))
        {
            shopBGs.transform.position = Vector3.Lerp(shopBGs.transform.position, new Vector3(200 - PlayerPrefs.GetInt("maxRangeBGs"), shopBGs.transform.position.y, shopBGs.transform.position.z), Time.deltaTime * 10f);
        }
    }
	void OnMouseDown()
    {
        fPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));//
        lockedYPos = screenPoint.x + 1f;
		offset = shopBGs.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
		Cursor.visible = false;
	}
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = lockedYPos;
        shopBGs.transform.position = curPosition;
    }
		void OnMouseUp()
    {
        sPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));//
        Cursor.visible = true;
        if (fPos.x > sPos.x)//
        {
            shopBGs.GetComponent<Rigidbody>().AddForce(shopBGs.transform.right * Time.deltaTime * -(fPos.x - sPos.x) * 100f);//
        }
        else if (fPos.x < sPos.x)//
        {
            shopBGs.GetComponent<Rigidbody>().AddForce(shopBGs.transform.right * Time.deltaTime * (sPos.x - fPos.x) * 100f);//
        }
    }
}