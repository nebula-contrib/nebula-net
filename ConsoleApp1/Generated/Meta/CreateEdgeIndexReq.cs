/**
 * Autogenerated by Thrift Compiler (0.15.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace Nebula.Meta
{

  public partial class CreateEdgeIndexReq : TBase
  {
    private int _space_id;
    private byte[] _index_name;
    private byte[] _edge_name;
    private List<global::Nebula.Meta.IndexFieldDef> _fields;
    private bool _if_not_exists;
    private byte[] _comment;

    public int Space_id
    {
      get
      {
        return _space_id;
      }
      set
      {
        __isset.space_id = true;
        this._space_id = value;
      }
    }

    public byte[] Index_name
    {
      get
      {
        return _index_name;
      }
      set
      {
        __isset.index_name = true;
        this._index_name = value;
      }
    }

    public byte[] Edge_name
    {
      get
      {
        return _edge_name;
      }
      set
      {
        __isset.edge_name = true;
        this._edge_name = value;
      }
    }

    public List<global::Nebula.Meta.IndexFieldDef> Fields
    {
      get
      {
        return _fields;
      }
      set
      {
        __isset.fields = true;
        this._fields = value;
      }
    }

    public bool If_not_exists
    {
      get
      {
        return _if_not_exists;
      }
      set
      {
        __isset.if_not_exists = true;
        this._if_not_exists = value;
      }
    }

    public byte[] Comment
    {
      get
      {
        return _comment;
      }
      set
      {
        __isset.comment = true;
        this._comment = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool space_id;
      public bool index_name;
      public bool edge_name;
      public bool fields;
      public bool if_not_exists;
      public bool comment;
    }

    public CreateEdgeIndexReq()
    {
    }

    public CreateEdgeIndexReq DeepCopy()
    {
      var tmp506 = new CreateEdgeIndexReq();
      if(__isset.space_id)
      {
        tmp506.Space_id = this.Space_id;
      }
      tmp506.__isset.space_id = this.__isset.space_id;
      if((Index_name != null) && __isset.index_name)
      {
        tmp506.Index_name = this.Index_name.ToArray();
      }
      tmp506.__isset.index_name = this.__isset.index_name;
      if((Edge_name != null) && __isset.edge_name)
      {
        tmp506.Edge_name = this.Edge_name.ToArray();
      }
      tmp506.__isset.edge_name = this.__isset.edge_name;
      if((Fields != null) && __isset.fields)
      {
        tmp506.Fields = this.Fields.DeepCopy();
      }
      tmp506.__isset.fields = this.__isset.fields;
      if(__isset.if_not_exists)
      {
        tmp506.If_not_exists = this.If_not_exists;
      }
      tmp506.__isset.if_not_exists = this.__isset.if_not_exists;
      if((Comment != null) && __isset.comment)
      {
        tmp506.Comment = this.Comment.ToArray();
      }
      tmp506.__isset.comment = this.__isset.comment;
      return tmp506;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32)
              {
                Space_id = await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.String)
              {
                Index_name = await iprot.ReadBinaryAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.String)
              {
                Edge_name = await iprot.ReadBinaryAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.List)
              {
                {
                  TList _list507 = await iprot.ReadListBeginAsync(cancellationToken);
                  Fields = new List<global::Nebula.Meta.IndexFieldDef>(_list507.Count);
                  for(int _i508 = 0; _i508 < _list507.Count; ++_i508)
                  {
                    global::Nebula.Meta.IndexFieldDef _elem509;
                    _elem509 = new global::Nebula.Meta.IndexFieldDef();
                    await _elem509.ReadAsync(iprot, cancellationToken);
                    Fields.Add(_elem509);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.Bool)
              {
                If_not_exists = await iprot.ReadBoolAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.String)
              {
                Comment = await iprot.ReadBinaryAsync(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp510 = new TStruct("CreateEdgeIndexReq");
        await oprot.WriteStructBeginAsync(tmp510, cancellationToken);
        var tmp511 = new TField();
        if(__isset.space_id)
        {
          tmp511.Name = "space_id";
          tmp511.Type = TType.I32;
          tmp511.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp511, cancellationToken);
          await oprot.WriteI32Async(Space_id, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Index_name != null) && __isset.index_name)
        {
          tmp511.Name = "index_name";
          tmp511.Type = TType.String;
          tmp511.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp511, cancellationToken);
          await oprot.WriteBinaryAsync(Index_name, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Edge_name != null) && __isset.edge_name)
        {
          tmp511.Name = "edge_name";
          tmp511.Type = TType.String;
          tmp511.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp511, cancellationToken);
          await oprot.WriteBinaryAsync(Edge_name, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Fields != null) && __isset.fields)
        {
          tmp511.Name = "fields";
          tmp511.Type = TType.List;
          tmp511.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp511, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, Fields.Count), cancellationToken);
            foreach (global::Nebula.Meta.IndexFieldDef _iter512 in Fields)
            {
              await _iter512.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.if_not_exists)
        {
          tmp511.Name = "if_not_exists";
          tmp511.Type = TType.Bool;
          tmp511.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp511, cancellationToken);
          await oprot.WriteBoolAsync(If_not_exists, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Comment != null) && __isset.comment)
        {
          tmp511.Name = "comment";
          tmp511.Type = TType.String;
          tmp511.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp511, cancellationToken);
          await oprot.WriteBinaryAsync(Comment, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is CreateEdgeIndexReq other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.space_id == other.__isset.space_id) && ((!__isset.space_id) || (System.Object.Equals(Space_id, other.Space_id))))
        && ((__isset.index_name == other.__isset.index_name) && ((!__isset.index_name) || (TCollections.Equals(Index_name, other.Index_name))))
        && ((__isset.edge_name == other.__isset.edge_name) && ((!__isset.edge_name) || (TCollections.Equals(Edge_name, other.Edge_name))))
        && ((__isset.fields == other.__isset.fields) && ((!__isset.fields) || (TCollections.Equals(Fields, other.Fields))))
        && ((__isset.if_not_exists == other.__isset.if_not_exists) && ((!__isset.if_not_exists) || (System.Object.Equals(If_not_exists, other.If_not_exists))))
        && ((__isset.comment == other.__isset.comment) && ((!__isset.comment) || (TCollections.Equals(Comment, other.Comment))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.space_id)
        {
          hashcode = (hashcode * 397) + Space_id.GetHashCode();
        }
        if((Index_name != null) && __isset.index_name)
        {
          hashcode = (hashcode * 397) + Index_name.GetHashCode();
        }
        if((Edge_name != null) && __isset.edge_name)
        {
          hashcode = (hashcode * 397) + Edge_name.GetHashCode();
        }
        if((Fields != null) && __isset.fields)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Fields);
        }
        if(__isset.if_not_exists)
        {
          hashcode = (hashcode * 397) + If_not_exists.GetHashCode();
        }
        if((Comment != null) && __isset.comment)
        {
          hashcode = (hashcode * 397) + Comment.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp513 = new StringBuilder("CreateEdgeIndexReq(");
      int tmp514 = 0;
      if(__isset.space_id)
      {
        if(0 < tmp514++) { tmp513.Append(", "); }
        tmp513.Append("Space_id: ");
        Space_id.ToString(tmp513);
      }
      if((Index_name != null) && __isset.index_name)
      {
        if(0 < tmp514++) { tmp513.Append(", "); }
        tmp513.Append("Index_name: ");
        Index_name.ToString(tmp513);
      }
      if((Edge_name != null) && __isset.edge_name)
      {
        if(0 < tmp514++) { tmp513.Append(", "); }
        tmp513.Append("Edge_name: ");
        Edge_name.ToString(tmp513);
      }
      if((Fields != null) && __isset.fields)
      {
        if(0 < tmp514++) { tmp513.Append(", "); }
        tmp513.Append("Fields: ");
        Fields.ToString(tmp513);
      }
      if(__isset.if_not_exists)
      {
        if(0 < tmp514++) { tmp513.Append(", "); }
        tmp513.Append("If_not_exists: ");
        If_not_exists.ToString(tmp513);
      }
      if((Comment != null) && __isset.comment)
      {
        if(0 < tmp514++) { tmp513.Append(", "); }
        tmp513.Append("Comment: ");
        Comment.ToString(tmp513);
      }
      tmp513.Append(')');
      return tmp513.ToString();
    }
  }

}
