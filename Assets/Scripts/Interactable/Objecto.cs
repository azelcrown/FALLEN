using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objecto : Interactable
{
    
    public override void Interact()
    {
        base.Interact(); // Sobreescribe la funci�n Interact() para este tipo de objetos

        Destroy(gameObject); // Destruir: el objeto desaparece
    }
}
