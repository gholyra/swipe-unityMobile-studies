using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{ 
    
    public Text ui_text;
    
    // VAR TOQUE
    Touch touch;
    
    // GUARDA AS INFOS DO TOQUE
    Vector2 touchStart;
    Vector2 touchEnd;

    void Update()
    {
        // VERIFICA SE HÁ TOQUE NA TELA
        if(Input.touchCount > 0)
        {
            // CAPTURA O COMPORTAMENTO DO TOQUE NA TELA NESTE MOMENTO
            touch = Input.GetTouch(0);

            // ANALISAR O COMPORTAMENTO
            if (touch.phase == TouchPhase.Began)
            {
                // OBTER A COORDENADA ONDE O TOQUE COMEÇOU RELATIVO AOS PIXELS DA TELA
                touchStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // ATUALIZA O SEGUNDO TOQUE ENQUANTO O DEDO ESTIVER DESLIZANDO PELA TELA
                touchEnd = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // ANALISA O MOVIMENTO QUANDO O TOQUE NA TELA É ENCERRADO
                
                // SUBTRAI O TOQUE FINAL PELO TOQUE INICIAL
                Vector2 dir = touchEnd - touchStart;
                
                // ANALISA E VERIFICA EM QUAL EIXO FOI O MAIOR MOVIMENTO (X OU Y)
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                {
                    // (X)
                    
                    // DETERMINAR A DIREÇÃO DO EIXO
                    if (dir.x > 0)
                    {
                        ui_text.text = "Right";
                    }
                    else
                    {
                        ui_text.text = "Left";
                    }
                }
                else
                {
                    // (Y)
                    if(dir.y > 0)
                    {
                        ui_text.text = "Up";
                    }
                    else
                    {
                        ui_text.text = "Down";
                    } 
                }
            }
        }
    }
}
