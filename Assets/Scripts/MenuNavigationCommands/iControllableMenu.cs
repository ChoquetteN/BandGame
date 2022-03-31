using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iControllableMenu: iActivity
{
    void LabelMenuActions(int TopOfPage);
    int MenuIndex { get; }
}
