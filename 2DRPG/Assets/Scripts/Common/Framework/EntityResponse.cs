using System;
using System.Collections;

public class EntityResponse<T>
{
    public T Data { get; set; }

    public bool IsCallSuccessful { get; set; }

    public string BusinessEntityMessage { get; set; }
}


