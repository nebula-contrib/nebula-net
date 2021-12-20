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

  public partial class ListClusterInfoResp : TBase
  {
    private global::Nebula.Common.ErrorCode _code;
    private global::Nebula.Common.HostAddr _leader;
    private List<global::Nebula.Common.HostAddr> _meta_servers;
    private List<global::Nebula.Common.NodeInfo> _storage_servers;

    /// <summary>
    /// 
    /// <seealso cref="global::Nebula.Common.ErrorCode"/>
    /// </summary>
    public global::Nebula.Common.ErrorCode Code
    {
      get
      {
        return _code;
      }
      set
      {
        __isset.code = true;
        this._code = value;
      }
    }

    public global::Nebula.Common.HostAddr Leader
    {
      get
      {
        return _leader;
      }
      set
      {
        __isset.leader = true;
        this._leader = value;
      }
    }

    public List<global::Nebula.Common.HostAddr> Meta_servers
    {
      get
      {
        return _meta_servers;
      }
      set
      {
        __isset.meta_servers = true;
        this._meta_servers = value;
      }
    }

    public List<global::Nebula.Common.NodeInfo> Storage_servers
    {
      get
      {
        return _storage_servers;
      }
      set
      {
        __isset.storage_servers = true;
        this._storage_servers = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool code;
      public bool leader;
      public bool meta_servers;
      public bool storage_servers;
    }

    public ListClusterInfoResp()
    {
    }

    public ListClusterInfoResp DeepCopy()
    {
      var tmp1124 = new ListClusterInfoResp();
      if(__isset.code)
      {
        tmp1124.Code = this.Code;
      }
      tmp1124.__isset.code = this.__isset.code;
      if((Leader != null) && __isset.leader)
      {
        tmp1124.Leader = (global::Nebula.Common.HostAddr)this.Leader.DeepCopy();
      }
      tmp1124.__isset.leader = this.__isset.leader;
      if((Meta_servers != null) && __isset.meta_servers)
      {
        tmp1124.Meta_servers = this.Meta_servers.DeepCopy();
      }
      tmp1124.__isset.meta_servers = this.__isset.meta_servers;
      if((Storage_servers != null) && __isset.storage_servers)
      {
        tmp1124.Storage_servers = this.Storage_servers.DeepCopy();
      }
      tmp1124.__isset.storage_servers = this.__isset.storage_servers;
      return tmp1124;
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
                Code = (global::Nebula.Common.ErrorCode)await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                Leader = new global::Nebula.Common.HostAddr();
                await Leader.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.List)
              {
                {
                  TList _list1125 = await iprot.ReadListBeginAsync(cancellationToken);
                  Meta_servers = new List<global::Nebula.Common.HostAddr>(_list1125.Count);
                  for(int _i1126 = 0; _i1126 < _list1125.Count; ++_i1126)
                  {
                    global::Nebula.Common.HostAddr _elem1127;
                    _elem1127 = new global::Nebula.Common.HostAddr();
                    await _elem1127.ReadAsync(iprot, cancellationToken);
                    Meta_servers.Add(_elem1127);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
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
                  TList _list1128 = await iprot.ReadListBeginAsync(cancellationToken);
                  Storage_servers = new List<global::Nebula.Common.NodeInfo>(_list1128.Count);
                  for(int _i1129 = 0; _i1129 < _list1128.Count; ++_i1129)
                  {
                    global::Nebula.Common.NodeInfo _elem1130;
                    _elem1130 = new global::Nebula.Common.NodeInfo();
                    await _elem1130.ReadAsync(iprot, cancellationToken);
                    Storage_servers.Add(_elem1130);
                  }
                  await iprot.ReadListEndAsync(cancellationToken);
                }
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
        var tmp1131 = new TStruct("ListClusterInfoResp");
        await oprot.WriteStructBeginAsync(tmp1131, cancellationToken);
        var tmp1132 = new TField();
        if(__isset.code)
        {
          tmp1132.Name = "code";
          tmp1132.Type = TType.I32;
          tmp1132.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp1132, cancellationToken);
          await oprot.WriteI32Async((int)Code, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Leader != null) && __isset.leader)
        {
          tmp1132.Name = "leader";
          tmp1132.Type = TType.Struct;
          tmp1132.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp1132, cancellationToken);
          await Leader.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Meta_servers != null) && __isset.meta_servers)
        {
          tmp1132.Name = "meta_servers";
          tmp1132.Type = TType.List;
          tmp1132.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp1132, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, Meta_servers.Count), cancellationToken);
            foreach (global::Nebula.Common.HostAddr _iter1133 in Meta_servers)
            {
              await _iter1133.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Storage_servers != null) && __isset.storage_servers)
        {
          tmp1132.Name = "storage_servers";
          tmp1132.Type = TType.List;
          tmp1132.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp1132, cancellationToken);
          {
            await oprot.WriteListBeginAsync(new TList(TType.Struct, Storage_servers.Count), cancellationToken);
            foreach (global::Nebula.Common.NodeInfo _iter1134 in Storage_servers)
            {
              await _iter1134.WriteAsync(oprot, cancellationToken);
            }
            await oprot.WriteListEndAsync(cancellationToken);
          }
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
      if (!(that is ListClusterInfoResp other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.code == other.__isset.code) && ((!__isset.code) || (System.Object.Equals(Code, other.Code))))
        && ((__isset.leader == other.__isset.leader) && ((!__isset.leader) || (System.Object.Equals(Leader, other.Leader))))
        && ((__isset.meta_servers == other.__isset.meta_servers) && ((!__isset.meta_servers) || (TCollections.Equals(Meta_servers, other.Meta_servers))))
        && ((__isset.storage_servers == other.__isset.storage_servers) && ((!__isset.storage_servers) || (TCollections.Equals(Storage_servers, other.Storage_servers))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.code)
        {
          hashcode = (hashcode * 397) + Code.GetHashCode();
        }
        if((Leader != null) && __isset.leader)
        {
          hashcode = (hashcode * 397) + Leader.GetHashCode();
        }
        if((Meta_servers != null) && __isset.meta_servers)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Meta_servers);
        }
        if((Storage_servers != null) && __isset.storage_servers)
        {
          hashcode = (hashcode * 397) + TCollections.GetHashCode(Storage_servers);
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp1135 = new StringBuilder("ListClusterInfoResp(");
      int tmp1136 = 0;
      if(__isset.code)
      {
        if(0 < tmp1136++) { tmp1135.Append(", "); }
        tmp1135.Append("Code: ");
        Code.ToString(tmp1135);
      }
      if((Leader != null) && __isset.leader)
      {
        if(0 < tmp1136++) { tmp1135.Append(", "); }
        tmp1135.Append("Leader: ");
        Leader.ToString(tmp1135);
      }
      if((Meta_servers != null) && __isset.meta_servers)
      {
        if(0 < tmp1136++) { tmp1135.Append(", "); }
        tmp1135.Append("Meta_servers: ");
        Meta_servers.ToString(tmp1135);
      }
      if((Storage_servers != null) && __isset.storage_servers)
      {
        if(0 < tmp1136++) { tmp1135.Append(", "); }
        tmp1135.Append("Storage_servers: ");
        Storage_servers.ToString(tmp1135);
      }
      tmp1135.Append(')');
      return tmp1135.ToString();
    }
  }

}
