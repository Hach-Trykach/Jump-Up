using UnityEngine;

public class SpawnBlocks : MonoBehaviour {

	public GameObject cube, block, firstBlock, allCubes, diamond;
	private GameObject blockInst, firstBlockInst;
	private Vector3 blockPos, firstBlockPos;
	private float speed = 3f;
	public bool onPlace, onFirstBlock, spawn;

	void Start () {
		spawnBlock ();
		spawnFirstBlock ();
	}

	void Update () {
		if (blockInst.transform.position != blockPos && !onPlace) {
			blockInst.transform.position = Vector3.Lerp (blockInst.transform.position, blockPos, Time.deltaTime * speed);
		} else if (blockInst.transform.position == blockPos) {
			onPlace = true;
		}
		if (firstBlockInst.transform.position != firstBlockPos && !onFirstBlock) {
			firstBlockInst.transform.position = Vector3.Lerp (firstBlockInst.transform.position, firstBlockPos, Time.deltaTime * speed * 2);
		} else if (firstBlockInst.transform.position == firstBlockPos) {
			onFirstBlock = true;
		}

		if (CubeJump.jump && CubeJump.nextBlock) {
			spawnBlock ();
			onPlace = false;
		}
	}

	void spawnBlock() {
		//blockPos = new Vector3 (Random.Range (1f, 1.7f), Random.Range (-2.5f, -0.7f), 0f);
		blockPos = new Vector3 (Random.Range (1f, 2f), Random.Range (-2.5f, -0.4f), 0f);
		blockInst = Instantiate (block, new Vector3(5f, 2.5f, 0f), Quaternion.identity) as GameObject;
		blockInst.transform.localScale = new Vector3(RandomScale(), blockInst.transform.localScale.y, 2);
		blockInst.transform.parent = allCubes.transform;
		if (CubeJump.count_blocks % 5 == 0 && CubeJump.count_blocks != 0) {
			GameObject diamondInst = Instantiate (diamond, new Vector3 (blockInst.transform.position.x, blockInst.transform.position.y + 0.5f, blockInst.transform.position.z), Quaternion.Euler (Camera.main.transform.eulerAngles)) as GameObject;
			diamondInst.transform.parent = blockInst.transform;
		}
	}

	void spawnFirstBlock() {
		firstBlockPos = new Vector3 (-1.8f, -3.5f, 0f);
		firstBlockInst = Instantiate (firstBlock, new Vector3(5f, 2.5f, 0f) , Quaternion.identity) as GameObject;
		firstBlockInst.transform.localScale = new Vector3(1.7f, 0.6f, 2f);
		firstBlockInst.transform.parent = allCubes.transform;
	}

	float RandomScale () {
		float random;
		if(Random.Range (0f, 100) > 80)
			random = Random.Range(1.1f, 2f);
		else
			random = Random.RandomRange(1.3f, 1.5f);
		return random;
	}
}