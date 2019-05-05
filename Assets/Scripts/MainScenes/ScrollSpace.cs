using UnityEngine;

public class ScrollSpace : MonoBehaviour {

	public GameObject shopCubes;
	private Vector3 screenPoint, offset, fPos, sPos;
	private float lockedYPos;
    
	void Update () {
        if (shopCubes.transform.position.x > 100 + 1.87)
        {
            shopCubes.transform.position = Vector3.Lerp(shopCubes.transform.position, new Vector3(100 + 1.87f, shopCubes.transform.position.y, shopCubes.transform.position.z), Time.deltaTime * 10f);
        }
        else if (shopCubes.transform.position.x < 100 - 12.1f)
        {
            shopCubes.transform.position = Vector3.Lerp(shopCubes.transform.position, new Vector3(100 - 12.1f, shopCubes.transform.position.y, shopCubes.transform.position.z), Time.deltaTime * 10f);
        }
	}

    void OnMouseDown()
    {
        fPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));//
        lockedYPos = screenPoint.x + 0.4f;
        offset = shopCubes.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Cursor.visible = false;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = lockedYPos;
        shopCubes.transform.position = curPosition;
    }

    void OnMouseUp()
    {
        sPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));//
        Cursor.visible = true;
        if (fPos.x > sPos.x)//
        {
            shopCubes.GetComponent<Rigidbody>().AddForce(shopCubes.transform.right * Time.deltaTime * -(fPos.x - sPos.x) * 100f);//
        }
        else if (fPos.x < sPos.x)//
        {
            shopCubes.GetComponent<Rigidbody>().AddForce(shopCubes.transform.right * Time.deltaTime * (sPos.x - fPos.x) * 100f);//
        }
    }
}