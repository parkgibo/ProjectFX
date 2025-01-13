using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    
    public Vector2 inputVec;
    public float speed;

    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer; //���󺯰�
    public landtiles targetTile; //landtiles ��ü ������ ���� public ������ ���� ���濹��

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer ������Ʈ ��������
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    public void OnFire()
    {
        changeColor();
        Debug.Log("���콺 Ŭ��!");
        if (targetTile != null)
        {
            targetTile.AdvanceStage(); // landtiles�� AdvanceStage �޼��� ȣ��
            Debug.Log("Ÿ���� ������ ����Ǿ����ϴ�.");
        }
        else
        {
            Debug.LogWarning("targetTile�� �������� �ʾҽ��ϴ�.");
        }
    }
    private void changeColor()
    {
        // ������ ������ �����Ͽ� ����
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        spriteRenderer.color = randomColor;
    }
}
