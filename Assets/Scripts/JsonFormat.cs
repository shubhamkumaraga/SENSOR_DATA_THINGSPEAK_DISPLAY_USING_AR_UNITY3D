using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class JsonFormat
{
    public List<feedData> feeds;
}

[Serializable]
public class feedData
{
    public string created_at;
    public int entry_id;
    public string field1;
    public string field2;
}