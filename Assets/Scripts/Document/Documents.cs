﻿using System.Collections.Generic;

public class Documents : XSingleton<Documents>
{

    private Dictionary<uint, XDocument> documents;


    /// <summary>
    /// regist all doc here
    /// </summary>
    public void Initial()
    {
        RegistDocument<XEquipDocument>();
        RegistDocument<XMailDocument>();

        //... 
    }


    public void Unintial()
    {
        if (documents != null)
        {
            var e = documents.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current.Value.OnUninitial();
            }
            documents.Clear();
            e.Dispose();
        }
    }


    public T RegistDocument<T>() where T : XDocument, new()
    {
        if (documents == null) documents = new Dictionary<uint, XDocument>();
        uint uid = XCommon.singleton.XHash(typeof(T).Name);
        if (documents.ContainsKey(uid))
        {
             XDebug.Log("has registed document " , typeof(T).Name);
            return documents[uid] as T;
        }
        else
        {
            T doc = new T();
            doc.OnInitial();
            documents.Add(uid, doc);
            return doc;
        }
    }


    public bool DetachDocument<T>() where T : XDocument, new()
    {
        return DetachDocument(typeof(T).Name);
    }

    //lua interface
    public bool DetachDocument(string name)
    {
        uint id = XCommon.singleton.XHash(name);
        if (documents != null)
            return documents.ContainsKey(id);
        else
        {
             XDebug.LogError("not initial for documents with " , name);
            return false;
        }
    }
    

    public T GetDocument<T>() where T : XDocument, new()
    {
        uint id = XCommon.singleton.XHash(typeof(T).Name);
        if (documents != null && documents.ContainsKey(id))
        {
            return documents[id] as T;
        }
        else
            return null;
    }

    //lua interface
    public object GetDocument(string name)
    {
        uint id = XCommon.singleton.XHash(name);
        if (documents != null && documents.ContainsKey(id))
        {
            return documents[id];
        }
        else
            return null;
    }

    public void OnEnterScene()
    {
        if (documents != null)
        {
            var e = documents.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current.Value.OnEnterScene();
            }
            e.Dispose();
        }
    }

    public void OnEnterSceneFinally()
    {
        if (documents != null)
        {
            var e = documents.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current.Value.OnEnterSceneFinally();
            }
            e.Dispose();
        }
    }


    public void OnLeaveScene()
    {
        if (documents != null)
        {
            var e = documents.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current.Value.OnLeaveScene();
            }
            e.Dispose();
        }
    }

    public void AttachHost()
    {
        if(documents!=null)
        {
            var e = documents.GetEnumerator();
            while(e.MoveNext())
            {
                e.Current.Value.OnAttachToHost();
            }
            e.Dispose();
        }
    }

    public void DeatchHost()
    {
        if (documents != null)
        {
            var e = documents.GetEnumerator();
            while (e.MoveNext())
            {
                e.Current.Value.OnDeatchToHost();
            }
            e.Dispose();
        }
    }
    
    public void Reconnect()
    {
        if(documents!=null)
        {
            var e = documents.GetEnumerator();
            while(e.MoveNext())
            {
                e.Current.Value.OnReconnected();
            }
            e.Dispose();
        }
    }

    public void Update()
    {
        if(documents!=null)
        {
            var e = documents.GetEnumerator();
            while(e.MoveNext())
            {
                e.Current.Value.OnUpdate();
            }
        }
    }

}
