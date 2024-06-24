using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee.List;
using static AchevementDatabase;

[CreateAssetMenu()]
public class AchevementDatabase : ScriptableObject
{
    [Reorderable(sortable =false, paginate =false)]
    public AchevementsArray achevements;

    [System.Serializable]
    public class AchevementsArray : ReorderableArray<Achevement> {
        
    }
}